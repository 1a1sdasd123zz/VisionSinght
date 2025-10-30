using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using VisionCore.ToolBase; // added
using VisionCore.PluginBase; // potential future use
using VisionCore.Linking;

namespace VisionCore.Solution
{
    /// <summary>
    /// 解决方案管理 单例 负责：
    /// 1. 维护 Solutions.xml（方案列表及默认方案标记）
    /// 2. 创建 / 保存 / 加载 单个 .uv 方案文件（Solution）
    /// 3. 保证任意时刻只有一个默认方案
    /// 4. 维护当前激活方案（CurrentSolution）并发布变更事件
    /// 5. 运行期缓存工具实例，避免保存时丢失状态
    /// </summary>
    public sealed class SolutionManager
    {
        private static readonly Lazy<SolutionManager> _lazy = new Lazy<SolutionManager>(() => new SolutionManager());
        public static SolutionManager Instance => _lazy.Value;

        private readonly string _configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Configs", "Solutions.xml");
        private readonly string _solutionsRootDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Solutions");

        private bool _loaded;

        public List<SolutionInfo> Solutions { get; private set; } = new List<SolutionInfo>();

        /// <summary>当前激活方案</summary>
        public Solution CurrentSolution { get; private set; }

        /// <summary>当前方案变更事件（加载、创建或切换时触发）</summary>
        public event Action<Solution> CurrentSolutionChanged;

        /// <summary>运行期缓存: toolRef.Id -> 实例 (新增: 为避免保存时重新 new 导致状态丢失)</summary>
        private readonly Dictionary<string, ITool> _toolInstances = new Dictionary<string, ITool>();
        /// <summary>运行期缓存: toolRef.Id -> 所属流程名称（新增: 便于增量注册变量）</summary>
        private readonly Dictionary<string, string> _toolProcessMap = new Dictionary<string, string>();
        private readonly Dictionary<string, GlobalVariableTool> _globalVarTools = new Dictionary<string, GlobalVariableTool>();

        private SolutionManager()
        {
            Directory.CreateDirectory(Path.GetDirectoryName(_configFilePath) ?? ".");
            Directory.CreateDirectory(_solutionsRootDir);
        }

        private void OnCurrentSolutionChanged() => CurrentSolutionChanged?.Invoke(CurrentSolution);

        #region 方案列表加载/保存
        private void LoadList()
        {
            Solutions.Clear();
            if (!File.Exists(_configFilePath))
            {
                EnsureAtLeastOneDefault();
                SaveList();
                _loaded = true;
                return;
            }
            try
            {
                var ser = new XmlSerializer(typeof(List<SolutionInfo>));
                using var fs = File.OpenRead(_configFilePath);
                if (ser.Deserialize(fs) is List<SolutionInfo> list) Solutions = list;
            }
            catch { Solutions = new List<SolutionInfo>(); }
            EnsureAtLeastOneDefault();
            _loaded = true;
        }

        public void Reload() => LoadList();
        public void EnsureLoaded() { if (!_loaded) LoadList(); }

        public void SaveList()
        {
            EnsureAtLeastOneDefault();
            try
            {
                var ser = new XmlSerializer(typeof(List<SolutionInfo>));
                using var fs = File.Create(_configFilePath);
                ser.Serialize(fs, Solutions);
            }
            catch { }
        }

        private void EnsureAtLeastOneDefault()
        {
            if (Solutions.Count == 0)
            {
                var def = CreateSolutionInfo("默认方案", "自动生成默认方案", CreateEmptySolutionFile("默认方案"));
                def.Enable = true;
                Solutions.Add(def);
                return;
            }
            var enabled = Solutions.Where(s => s.Enable).ToList();
            if (enabled.Count == 0) Solutions[0].Enable = true;
            else if (enabled.Count > 1) foreach (var s in enabled.Skip(1)) s.Enable = false;
        }

        private SolutionInfo CreateSolutionInfo(string name, string desc, string fullPath)
        {
            var now = DateTime.Now;
            return new SolutionInfo
            {
                Name = name,
                Description = desc,
                Enable = false,
                CreateTime = now,
                LastModifyTime = now,
                Path = fullPath
            };
        }

        private string CreateEmptySolutionFile(string name)
        {
            var safeName = SanitizeFileName(name);
            var filePath = Path.Combine(_solutionsRootDir, safeName + ".uv");
            try { new Solution(name).Save(filePath); } catch { }
            return filePath;
        }

        private string SanitizeFileName(string name)
        {
            var invalid = Path.GetInvalidFileNameChars();
            foreach (var c in invalid) name = name.Replace(c, '_');
            return name;
        }
        #endregion

        #region 外部操作入口
        public Solution LoadDefaultSolution()
        {
            EnsureLoaded();
            var current = Solutions.FirstOrDefault(s => s.Enable) ?? Solutions.First();
            Solution sol;
            try
            {
                if (!File.Exists(current.Path))
                {
                    current.Path = CreateEmptySolutionFile(current.Name);
                    SaveList();
                }
                sol = Solution.Load(current.Path);
            }
            catch { sol = new Solution(current.Name); }
            SetCurrentSolution(sol);
            return sol;
        }

        public Solution OpenSolution(SolutionInfo info, bool setAsDefault = false)
        {
            if (info == null) return null;
            EnsureLoaded();
            if (setAsDefault)
            {
                foreach (var s in Solutions) s.Enable = ReferenceEquals(s, info);
                SaveList();
            }
            Solution sol;
            try { sol = Solution.Load(info.Path); }
            catch { sol = new Solution(info.Name); }
            SetCurrentSolution(sol);
            return sol;
        }

        public Solution NewSolution(string name, string description, bool setDefault = true)
        {
            EnsureLoaded();
            if (string.IsNullOrWhiteSpace(name)) name = "新方案";
            string baseName = name; int suffix = 0;
            while (Solutions.Any(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase))) name = baseName + (++suffix).ToString();

            var file = CreateEmptySolutionFile(name);
            var info = CreateSolutionInfo(name, description, file);
            if (setDefault)
            {
                foreach (var s in Solutions) s.Enable = false;
                info.Enable = true;
            }
            Solutions.Add(info); SaveList();
            var sol = Solution.Load(file);
            SetCurrentSolution(sol);
            return sol;
        }

        public void SaveSolution(Solution solution)
        {
            if (solution == null || solution.Data == null) return;
            EnsureLoaded();
            var info = Solutions.FirstOrDefault(s => s.Name.Equals(solution.Data.Name, StringComparison.OrdinalIgnoreCase));
            if (info == null)
            {
                info = CreateSolutionInfo(solution.Data.Name, string.Empty, CreateEmptySolutionFile(solution.Data.Name));
                Solutions.Add(info);
            }
            info.LastModifyTime = DateTime.Now;
            try
            {
                PersistAllToolSettings(solution);
                solution.Save(info.Path);
            }
            catch { }
            if (Solutions.Count == 1) info.Enable = true;
            SaveList();
            if (ReferenceEquals(solution, CurrentSolution)) OnCurrentSolutionChanged();
        }
        #endregion

        #region 当前方案切换/实例构建
        private void SetCurrentSolution(Solution sol)
        {
            if (sol == null) return;
            if (!ReferenceEquals(CurrentSolution, sol))
            {
                CurrentSolution = sol;
                // 新增: 清空运行期实例缓存，准备重新按 Solution 数据构建实例
                _toolInstances.Clear();
                _toolProcessMap.Clear();
                // 订阅工具事件用于变量索引增量维护
                sol.ToolAdded += OnToolAdded;
                sol.ToolRemoved += OnToolRemoved;
                sol.ToolRenamed += OnToolRenamed;
                RestoreToolSettings(sol); // 内部会注册变量
                OnCurrentSolutionChanged();
            }
        }

        private void RestoreToolSettings(Solution sol)
        {
            LinkRegistry.Instance.Clear(); // 新增: 重新构建变量索引
            if (sol?.Data?.Root == null) return;
            foreach (var proc in sol.Data.Root.OfType<ProcessItem>())
                RestoreToolsInProcess(proc, proc.Name);
            foreach (var folder in sol.Data.Root.OfType<ProcessFolder>())
                RestoreFolder(folder);
        }

        private void RestoreFolder(ProcessFolder folder)
        {
            foreach (var childProc in folder.Children.OfType<ProcessItem>())
                RestoreToolsInProcess(childProc, childProc.Name);
            foreach (var subFolder in folder.Children.OfType<ProcessFolder>())
                RestoreFolder(subFolder);
        }

        private void RestoreToolsInProcess(ProcessItem proc, string processName)
        {
            foreach (var tref in proc.Tools.Where(tref => !string.IsNullOrWhiteSpace(tref.AssemblyQualifiedType) || !string.IsNullOrWhiteSpace(tref.TypeKey)))
            {
                try
                {
                    ITool tool = null;
                    // 优先通过 ToolFactory (支持基于 ToolAttribute 的解析)
                    var like = new VisionCore.ToolBase.ToolRefLike
                    {
                        Id = tref.Id,
                        Name = tref.Name,
                        TypeKey = tref.TypeKey,
                        AssemblyQualifiedType = tref.AssemblyQualifiedType
                    };
                    if (!VisionCore.ToolBase.ToolFactory.TryCreate(like, out tool))
                    {
                        // 退回旧反射逻辑
                        var type = Type.GetType(tref.AssemblyQualifiedType ?? string.Empty, false);
                        if (type != null) tool = Activator.CreateInstance(type) as ITool;
                    }
                    if (tool == null) continue;

                    tool.Name = tref.Name;
                    tool.Enable = tref.Enabled;
                    if (tool is IPersistableTool p && !string.IsNullOrWhiteSpace(tref.SettingsJson))
                        try { p.ImportSettings(tref.SettingsJson); } catch { }

                    _toolInstances[tref.Id] = tool;
                    _toolProcessMap[tref.Id] = processName;
                    LinkRegistry.Instance.RegisterTool(processName, tool.Name, tool);
                }
                catch { }
            }
        }
        #endregion

        #region 保存工具配置（修改: 使用缓存实例而非重新 new）
        private void PersistAllToolSettings(Solution sol)
        {
            if (sol?.Data?.Root == null) return;
            foreach (var proc in sol.Data.Root.OfType<ProcessItem>()) PersistProcess(proc);
            foreach (var folder in sol.Data.Root.OfType<ProcessFolder>()) PersistFolder(folder);
        }
        private void PersistFolder(ProcessFolder folder) { foreach (var childProc in folder.Children.OfType<ProcessItem>()) PersistProcess(childProc); foreach (var subFolder in folder.Children.OfType<ProcessFolder>()) PersistFolder(subFolder); }
        private void PersistProcess(ProcessItem proc)
        {
            foreach (var tref in proc.Tools.Where(t => !string.IsNullOrWhiteSpace(t.AssemblyQualifiedType)))
            {
                try
                {
                    if (_toolInstances.TryGetValue(tref.Id, out var tool))
                    {
                        tref.Enabled = tool.Enable; // 同步启用状态
                        if (tool is IPersistableTool p) tref.SettingsJson = p.ExportSettings();
                    }
                    // 若未找到实例保持原有 SettingsJson（可能是未实际创建的工具）
                }
                catch { }
            }
        }
        #endregion

        #region 外部工具实例访问辅助（原有小扩展）
        public ITool GetToolInstance(string toolRefId) { _toolInstances.TryGetValue(toolRefId, out var inst); return inst; }
        #endregion

        #region 公开运行期注册新工具实例（新增功能）
        /// <summary>
        /// 新增: 拖拽/动态添加工具后立即缓存并注册变量, 使其输出即时出现在“变量链接”窗口中。
        /// </summary>
        public void RegisterRuntimeTool(ToolRef tref, string processName, ITool instance = null)
        {
            if (tref == null || CurrentSolution == null || string.IsNullOrWhiteSpace(processName)) return;
            try
            {
                if (instance == null)
                {
                    var like = new VisionCore.ToolBase.ToolRefLike
                    {
                        Id = tref.Id,
                        Name = tref.Name,
                        TypeKey = tref.TypeKey,
                        AssemblyQualifiedType = tref.AssemblyQualifiedType
                    };
                    if (!VisionCore.ToolBase.ToolFactory.TryCreate(like, out instance))
                    {
                        if (!string.IsNullOrWhiteSpace(tref.AssemblyQualifiedType))
                        {
                            var type = Type.GetType(tref.AssemblyQualifiedType, false);
                            if (type != null) instance = Activator.CreateInstance(type) as ITool;
                        }
                    }
                }
                if (instance == null) return;
                instance.Name = tref.Name; instance.Enable = tref.Enabled;
                if (instance is IPersistableTool p && !string.IsNullOrWhiteSpace(tref.SettingsJson) && tref.SettingsJson != "{}")
                    try { p.ImportSettings(tref.SettingsJson); } catch { }
                _toolInstances[tref.Id] = instance;
                _toolProcessMap[tref.Id] = processName;
                LinkRegistry.Instance.RegisterTool(processName, instance.Name, instance);
            }
            catch { }
        }

        public void RegisterRuntimeToolForGlobals()
        {
            // Re-register all global variables (clear only global section by rebuilding LinkRegistry for globals)
            foreach (var kv in _globalVarTools) { /* keep existing tool objects */ }
            RebuildGlobalVariableRegistry();
        }
        #endregion

        #region 全局变量新增/查询
        public GlobalVariable AddGlobalVariable(Type type)
        {
            if (CurrentSolution?.Data == null || type == null) return null;
            string baseName = "Value";
            int idx = 0; string name;
            var gvList = CurrentSolution.Data.GlobalVariables;
            bool Exists(string n) => gvList.Any(v => v.Name.Equals(n, StringComparison.OrdinalIgnoreCase));
            do { name = baseName + idx++; } while (Exists(name));
            var gv = new GlobalVariable { Name = name, Type = type.AssemblyQualifiedName, Value = null };
            gvList.Add(gv);
            RegisterGlobalVariable(gv);
            return gv;
        }
        public IEnumerable<GlobalVariable> GetGlobalVariables() => CurrentSolution?.Data?.GlobalVariables ?? Enumerable.Empty<GlobalVariable>();

        private void RegisterGlobalVariable(GlobalVariable gv)
        {
            try
            {
                if (gv == null) return;
                if (_globalVarTools.TryGetValue(gv.Name, out var tool))
                {
                    tool.Target = gv; // update reference
                }
                else
                {
                    tool = new GlobalVariableTool(gv);
                    _globalVarTools[gv.Name] = tool;
                }
                LinkRegistry.Instance.RegisterTool("_Global", gv.Name, tool, string.IsNullOrWhiteSpace(gv.Annotation)? null : gv.Annotation); // processId: _Global   toolId: 变量名
            }
            catch { }
        }
        public void RebuildGlobalVariableRegistry()
        {
            foreach (var gv in GetGlobalVariables()) RegisterGlobalVariable(gv);
        }

        public void UpdateGlobalVariableValue(string name, object value)
        {
            var gv = GetGlobalVariables().FirstOrDefault(v => v.Name == name);
            if (gv == null) return;
            // 序列化为字符串
            if (value == null) gv.Value = null;
            else gv.Value = Convert.ToString(value);
            // 重新注册（覆盖 Getter）
            RegisterGlobalVariable(gv);
        }
        #endregion

        private class GlobalVariableTool : ITool
        {
            public GlobalVariable Target { get; set; }
            public GlobalVariableTool(GlobalVariable gv) { Target = gv; }
            public string Name { get => Target?.Name; set { if (Target != null) Target.Name = value; } }
            public bool Enable { get; set; } = true; // 全局变量始终可用
            public void Run(out bool success, out string message) { success = true; message = null; } // 无运行逻辑
            [LinkableVar("值", Description = "全局变量值")] public object Value
            {
                get
                {
                    try
                    {
                        if (Target == null) return null;
                        if (Target.Value == null) return null;
                        var type = Type.GetType(Target.Type, false);
                        if (type == null) return Target.Value;
                        if (type == typeof(string)) return Target.Value;
                        return Convert.ChangeType(Target.Value, type);
                    }
                    catch { return null; }
                }
            }
            public void OpenForm() { /* 全局变量无配置界面 */ }
        }
        private void OnToolAdded(string processPath, ToolRef tr)
        {
            try
            {
                if (tr == null) return;
                // 尝试即时构建实例 (延迟到运行时也可，由运行器创建)；若不成功仍可稍后创建
                if (!_toolInstances.ContainsKey(tr.Id))
                {
                    ITool inst;
                    var like = new VisionCore.ToolBase.ToolRefLike { Id = tr.Id, Name = tr.Name, TypeKey = tr.TypeKey, AssemblyQualifiedType = tr.AssemblyQualifiedType };
                    if (VisionCore.ToolBase.ToolFactory.TryCreate(like, out inst))
                    {
                        inst.Name = tr.Name; inst.Enable = tr.Enabled;
                        if (inst is IPersistableTool p && !string.IsNullOrWhiteSpace(tr.SettingsJson))
                            try { p.ImportSettings(tr.SettingsJson); } catch { }
                        _toolInstances[tr.Id] = inst;
                        _toolProcessMap[tr.Id] = processPath.Split('/').Last();
                        LinkRegistry.Instance.RegisterTool(processPath.Split('/').Last(), inst.Name, inst);
                    }
                }
            }
            catch { }
        }
        private void OnToolRemoved(string processPath, ToolRef tr)
        {
            try
            {
                if (tr == null) return;
                var procName = processPath.Split('/').Last();
                // 移除变量
                LinkRegistry.Instance.RemoveTool(procName, tr.Name);
                // 保留实例缓存可选: 这里选择删除
                _toolInstances.Remove(tr.Id);
                _toolProcessMap.Remove(tr.Id);
            }
            catch { }
        }
        private void OnToolRenamed(string processPath, ToolRef tr, string oldName)
        {
            try
            {
                if (tr == null) return;
                var procName = processPath.Split('/').Last();
                LinkRegistry.Instance.RemoveTool(procName, oldName);
                if (_toolInstances.TryGetValue(tr.Id, out var inst))
                {
                    inst.Name = tr.Name;
                    LinkRegistry.Instance.RegisterTool(procName, inst.Name, inst);
                }
            }
            catch { }
        }
    }
}
