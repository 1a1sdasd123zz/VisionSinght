using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VisionCore.Manager.PluginServer;
using VisionCore.PluginBase;
using VisionCore.Solution;
using VisionCore.ToolBase;

namespace VisionCore.Runtime
{
    /// <summary>
    /// 流程执行服务：调度 Solution 中的流程与工具执行。<br/>
    /// 特点：
    /// <list type="bullet">
    /// <item>支持整套流程一次性执行或循环执行</item>
    /// <item>流程内部顺序或并行（预留）执行工具</item>
    /// <item>运行事件回调（流程/工具开始结束、整体运行状态）</item>
    /// <item>可配置失败策略（继续 / 停止当前流程 / 停止全部）</item>
    /// </list>
    /// </summary>
    public class ProcessExecutionService
    {
        #region 配置枚举
        /// <summary>工具失败后的处理策略。</summary>
        public ToolFailureStrategy FailureStrategy { get; set; } = ToolFailureStrategy.ContinueProcess;
        /// <summary>流程中工具的执行模式。</summary>
        public ProcessExecutionMode ExecutionMode { get; set; } = ProcessExecutionMode.SequentialTools;
        #endregion

        private readonly Dictionary<string, CancellationTokenSource> _loopTokens = new Dictionary<string, CancellationTokenSource>();
        private readonly object _sync = new object();

        /// <summary>当前使用的 Solution（可在运行前替换）。</summary>
        public Solution.Solution Solution { get; set; }

        /// <summary>是否存在正在执行（单次或循环）的任务。</summary>
        public bool IsRunning { get; private set; }
        /// <summary>是否处于循环模式（任意流程循环中即为 true）。</summary>
        public bool IsLoop { get; private set; }

        #region 事件
        public event Action<bool, bool> RunStateChanged; // (isRunning,isLoop)
        public event Action<string> ProcessStarted; // processPath
        public event Action<ToolRef> ToolStarted;
        public event Action<ToolRef, long, bool> ToolFinished; // tool, elapsedMs, success
        public event Action<string, long> ProcessFinished; // processName, elapsedMs
        #endregion

        public ProcessExecutionService(Solution.Solution solution) => Solution = solution;

        #region Public API (单次)
        /// <summary>执行全部已启用流程一次。</summary>
        public void RunAllOnce() => _ = RunProcessesOnceInternal(GetAllProcessPaths());
        /// <summary>执行指定流程一次。</summary>
        public void RunProcessOnce(string processPath)
        {
            if (string.IsNullOrWhiteSpace(processPath)) return;
            _ = RunProcessesOnceInternal(new List<string> { processPath });
        }
        #endregion

        #region Public API (循环)
        /// <summary>开启所有启用流程的循环执行。</summary>
        public void StartLoopAll()
        {
            lock (_sync)
            {
                if (IsLoop) return;
                EnsureRunningFlags(loop: true);
                foreach (var path in GetAllProcessPaths()) StartLoopInternal(path);
            }
        }
        /// <summary>开启单个流程循环。</summary>
        public void StartLoopProcess(string processPath)
        {
            if (string.IsNullOrWhiteSpace(processPath)) return;
            lock (_sync)
            {
                EnsureRunningFlags(loop: true);
                StartLoopInternal(processPath);
            }
        }
        /// <summary>停止单个流程循环。</summary>
        public void StopLoopProcess(string processPath)
        {
            if (string.IsNullOrWhiteSpace(processPath)) return;
            lock (_sync)
            {
                if (_loopTokens.TryGetValue(processPath, out var cts))
                {
                    try { cts.Cancel(); } catch { }
                    _loopTokens.Remove(processPath);
                }
                if (_loopTokens.Count == 0)
                {
                    IsLoop = false;
                    IsRunning = false;
                    RaiseRunStateChanged();
                }
            }
        }
        /// <summary>停止所有正在运行（包括循环）的流程。</summary>
        public void StopAll()
        {
            lock (_sync)
            {
                foreach (var kv in _loopTokens.ToList())
                {
                    try { kv.Value.Cancel(); } catch { }
                }
                _loopTokens.Clear();
                IsLoop = false;
                IsRunning = false;
                RaiseRunStateChanged();
            }
        }
        #endregion

        #region Core Logic
        private async Task RunProcessesOnceInternal(List<string> processPaths)
        {
            if (processPaths == null || processPaths.Count == 0) return;
            lock (_sync)
            {
                if (IsRunning && !IsLoop) return; // 已有一次性批次在执行
                if (!IsLoop) EnsureRunningFlags(loop: false);
            }
            try
            {
                var tasks = new List<Task>();
                foreach (var path in processPaths)
                {
                    var captured = path;
                    tasks.Add(Task.Run(() =>
                    {
                        var proc = Solution?.GetProcess(captured);
                        if (proc == null || !proc.Enabled) return; // 跳过禁用的流程
                        RaiseProcessStarted(captured);
                        RunProcess(proc, captured, CancellationToken.None);
                    }));
                }
                await Task.WhenAll(tasks);
            }
            finally
            {
                lock (_sync)
                {
                    if (!IsLoop)
                    {
                        IsRunning = false;
                        RaiseRunStateChanged();
                    }
                }
            }
        }

        private void StartLoopInternal(string processPath)
        {
            if (_loopTokens.ContainsKey(processPath)) return;
            var proc = Solution?.GetProcess(processPath);
            if (proc != null && !proc.Enabled) return; // 不启动禁用流程
            var cts = new CancellationTokenSource();
            _loopTokens[processPath] = cts;
            Task.Run(() => LoopWorker(processPath, cts.Token), cts.Token);
        }

        private void LoopWorker(string processPath, CancellationToken token)
        {
            while (!token.IsCancellationRequested && IsLoop)
            {
                var proc = Solution?.GetProcess(processPath);
                if (proc == null) break;
                if (!proc.Enabled) { Thread.Sleep(50); continue; }
                RaiseProcessStarted(processPath);
                RunProcess(proc, processPath, token);
            }
        }

        private List<string> GetAllProcessPaths()
        {
            var list = new List<string>();
            var root = Solution?.Data?.Root; if (root == null) return list;
            foreach (var node in root)
            {
                if (node is ProcessItem pi)
                {
                    if (pi.Enabled) list.Add(pi.Name);
                }
                else if (node is ProcessFolder pf) CollectFolderProcessesRecursive(pf, prefix: pf.Name, list, onlyEnabled: true);
            }
            return list;
        }
        private void CollectFolderProcessesRecursive(ProcessFolder folder, string prefix, List<string> list, bool onlyEnabled)
        {
            foreach (var c in folder.Children)
            {
                if (c is ProcessItem pi)
                {
                    if (!onlyEnabled || pi.Enabled)
                        list.Add(prefix + "/" + pi.Name);
                }
                else if (c is ProcessFolder pf) CollectFolderProcessesRecursive(pf, prefix + "/" + pf.Name, list, onlyEnabled);
            }
        }

        private void RunProcess(ProcessItem proc, string processPath, CancellationToken token)
        {
            if (proc == null || !proc.Enabled) return; // 双保险
            var swProcess = Stopwatch.StartNew();
            if (ExecutionMode == ProcessExecutionMode.SequentialTools)
            {
                foreach (var toolRef in proc.Tools)
                {
                    if (token.IsCancellationRequested) break;
                    var tool = GetOrCreateToolInstance(toolRef, proc.Name);
                    if (tool == null || !tool.Enable) continue;
                    RaiseToolStarted(toolRef);
                    var swTool = Stopwatch.StartNew();
                    bool ok; string msg;
                    try { tool.Run(out ok, out msg); }
                    catch { ok = false; msg = null; }
                    swTool.Stop();
                    RaiseToolFinished(toolRef, swTool.ElapsedMilliseconds, ok);
                    if (!ok)
                    {
                        if (FailureStrategy == ToolFailureStrategy.StopProcess) break;
                        if (FailureStrategy == ToolFailureStrategy.StopAll)
                        {
                            StopAll();
                            break;
                        }
                    }
                }
            }
            else
            {
                var enabledTools = proc.Tools.Where(t => t.Enabled).ToList();
                Parallel.ForEach(enabledTools, (toolRef, state) =>
                {
                    if (token.IsCancellationRequested) { state.Stop(); return; }
                    var tool = GetOrCreateToolInstance(toolRef, proc.Name);
                    if (tool == null || !tool.Enable) return;
                    RaiseToolStarted(toolRef);
                    var swTool = Stopwatch.StartNew();
                    bool ok; string msg;
                    try { tool.Run(out ok, out msg); }
                    catch { ok = false; msg = null; }
                    swTool.Stop();
                    RaiseToolFinished(toolRef, swTool.ElapsedMilliseconds, ok);
                    if (!ok && FailureStrategy != ToolFailureStrategy.ContinueProcess)
                    {
                        if (FailureStrategy == ToolFailureStrategy.StopProcess) state.Stop();
                        else if (FailureStrategy == ToolFailureStrategy.StopAll)
                        {
                            StopAll(); state.Stop();
                        }
                    }
                });
            }
            swProcess.Stop();
            RaiseProcessFinished(proc.Name, swProcess.ElapsedMilliseconds);
        }
        #endregion

        #region Helpers
        private void EnsureRunningFlags(bool loop)
        {
            IsLoop = loop;
            IsRunning = true;
            RaiseRunStateChanged();
        }
        private void RaiseRunStateChanged() { try { RunStateChanged?.Invoke(IsRunning, IsLoop); } catch { } }
        private void RaiseProcessStarted(string path) { try { ProcessStarted?.Invoke(path); } catch { } }
        private void RaiseToolStarted(ToolRef tr) { try { ToolStarted?.Invoke(tr); } catch { } }
        private void RaiseToolFinished(ToolRef tr, long elapsedMs, bool ok) { try { ToolFinished?.Invoke(tr, elapsedMs, ok); } catch { } }
        private void RaiseProcessFinished(string name, long elapsedMs) { try { ProcessFinished?.Invoke(name, elapsedMs); } catch { } }

        private ITool GetOrCreateToolInstance(ToolRef tref, string processName)
        {
            var inst = SolutionManager.Instance.GetToolInstance(tref.Id);
            if (inst != null) return inst;
            try
            {
                var typeName = tref.AssemblyQualifiedType;
                if (!string.IsNullOrWhiteSpace(typeName))
                {
                    var type = Type.GetType(typeName, false);
                    if (type != null)
                    {
                        inst = Activator.CreateInstance(type) as ITool;
                        if (inst != null)
                        {
                            inst.Name = tref.Name; inst.Enable = tref.Enabled;
                            SolutionManager.Instance.RegisterRuntimeTool(tref, processName, inst);
                        }
                    }
                }
            }
            catch { }
            return inst;
        }
        #endregion
    }

    /// <summary>工具失败策略。</summary>
    public enum ToolFailureStrategy { ContinueProcess, StopProcess, StopAll }
    /// <summary>流程中工具执行模式。</summary>
    public enum ProcessExecutionMode { SequentialTools, ParallelTools }
}
