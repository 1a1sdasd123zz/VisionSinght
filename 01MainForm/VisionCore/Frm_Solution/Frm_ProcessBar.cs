using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VisionCore.PluginBase;
using VisionCore.Solution;
using DevExpress.Utils.Svg;
using VisionCore.Manager.PluginServer;
using VisionCore.ToolBase;
using System.Reflection;
using System.Runtime.InteropServices;
using VisionCore.Frm_Solution.Rendering; // 导入渲染器命名空间
using VisionCore.Runtime;

namespace VisionCore.Frm_Solution
{
    /// <summary>
    /// 流程工具栏视图：
    /// 展示当前选中流程内的工具列表，负责：
    /// 1) 工具拖拽添加 (来自外部插件面板)
    /// 2) 工具运行状态展示 (耗时 / 成功失败 / 旋转动画)
    /// 3) 工具重命名 / 删除 / 启用禁用
    /// 4) 双击打开工具配置窗口
    /// 与业务执行解耦：运行逻辑由 <see cref="ProcessExecutionService"/> 提供，界面只订阅事件并刷新。
    /// </summary>
    public partial class Frm_ProcessBar : XtraUserControl
    {
        #region 样式常量
        // 图标区域相关尺寸与间距，绘制时保持一致
        private const int IconSize = 28;          // 图标实际储存大小
        private const int IconDrawSize = 26;      // 绘制时的缩放尺寸（留出边缘空隙）
        private const int LeftPadding = 4;        // 行左侧内边距
        private const int BetweenIndexAndName = 6;// 图标/索引与名称之间的间隔
        private const int RightPadding = 6;       // 行右侧内边距
        #endregion

        // 当前绑定的 Solution（可能被主窗体替换）
        private Solution.Solution _solution = new Solution.Solution("默认方案");
        // 供 TreeView 显示工具图标使用的 ImageList
        private readonly ImageList _toolImages = new ImageList { ColorDepth = ColorDepth.Depth32Bit, ImageSize = new Size(IconSize, IconSize) };
        // 当前显示的流程路径（如 "流程1" 或 "文件夹A/流程B"）
        private string _currentProcessPath;
        // 双击打开配置窗体时阻止紧接着的编辑事件
        private bool _blockLabelEditByDoubleClick;

        #region 字体与画刷缓存
        // 避免频繁创建 GDI 对象
        private readonly Font _indexFont = new Font("Segoe UI", 10f, FontStyle.Regular);
        private readonly Font _resultFont = new Font("Segoe UI", 9f, FontStyle.Regular);
        private readonly Brush _elapsedBrush = new SolidBrush(Color.Gray);
        private readonly Brush _successBrush = new SolidBrush(Color.LimeGreen);
        private readonly Brush _failBrush = new SolidBrush(Color.IndianRed);
        private readonly Brush _nameBrush = new SolidBrush(Color.White);
        private readonly Brush _rowBackBrush = new SolidBrush(Color.FromArgb(60, 60, 60));
        private readonly Brush _rowBackSelectedBrush = new SolidBrush(Color.FromArgb(90, 90, 90));
        #endregion

        // 动画计时器：驱动运行中工具的旋转帧刷新
        private readonly System.Windows.Forms.Timer _animTimer = new System.Windows.Forms.Timer { Interval = 120 };

        // 渲染器与上下文：将视觉细节与节点逻辑分离
        private IToolItemRenderer _renderer;
        private ToolItemRenderContext _renderContext;

        #region 运行状态缓存
        /// <summary>界面侧保存的工具运行状态（即使当前流程未显示，完成后切换仍可显示上次结果）。</summary>
        private class ToolState { public long Elapsed; public bool? Success; public bool IsRunning; public int SpinnerFrame; }
        private readonly Dictionary<string, ToolState> _toolStateCache = new Dictionary<string, ToolState>();
        #endregion

        // 执行业务服务
        private ProcessExecutionService _execService;

        /// <summary>是否有流程处于运行中（一次或循环）。</summary>
        public bool IsRunning => _execService?.IsRunning ?? false;
        /// <summary>是否处于循环运行模式。</summary>
        public bool IsLoop => _execService?.IsLoop ?? false;
        /// <summary>运行状态变化事件 (isRunning,isLoop) -> 主界面按钮刷新。</summary>
        public event Action<bool, bool> RunStateChanged; // (isRunning,isLoop) 转发服务事件

        #region Win32 双缓冲
        // TreeView 开启原生双缓冲，减少滚动与绘制闪烁
        private const int TV_FIRST = 0x1100;
        private const int TVM_SETEXTENDEDSTYLE = TV_FIRST + 44;
        private const int TVM_GETEXTENDEDSTYLE = TV_FIRST + 45;
        private const int TVS_EX_DOUBLEBUFFER = 0x0004;
        [DllImport("user32.dll", CharSet = CharSet.Auto)] private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
        private void EnableNativeDoubleBuffer(TreeView tv)
        {
            if (tv == null || !tv.IsHandleCreated) return;
            try
            {
                var styles = SendMessage(tv.Handle, TVM_GETEXTENDEDSTYLE, IntPtr.Zero, IntPtr.Zero).ToInt32();
                styles |= TVS_EX_DOUBLEBUFFER;
                SendMessage(tv.Handle, TVM_SETEXTENDEDSTYLE, IntPtr.Zero, (IntPtr)styles);
            }
            catch { }
        }
        private void EnableTreeDoubleBuffer()
        {
            try
            {
                // 反射写入受保护的 DoubleBuffered 属性
                typeof(Control).InvokeMember("DoubleBuffered", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty, null, tree_PressTree, new object[] { true });
            }
            catch { }
        }
        #endregion

        public Frm_ProcessBar()
        {
            InitializeComponent();
            bar_Main.AllowCustomization = false;
            bar_Main.AllowQuickCustomization = false;

            // TreeView 基本外观与交互配置
            tree_PressTree.AllowDrop = true;          // 支持外部拖入工具
            tree_PressTree.ShowRootLines = true;      // 显示根连接线（美观）
            tree_PressTree.ShowPlusMinus = false;     // 仅平铺工具，不显示折叠
            tree_PressTree.ImageList = _toolImages;   // 图标来源
            tree_PressTree.LabelEdit = true;          // 允许重命名
            tree_PressTree.DrawMode = TreeViewDrawMode.OwnerDrawAll; // 自定义绘制
            tree_PressTree.ItemHeight = IconSize + 6; // 行高
            tree_PressTree.Font = new Font("Segoe UI", 9f, FontStyle.Regular);

            // 事件绑定
            tree_PressTree.DrawNode += Tree_PressTree_DrawNode;
            tree_PressTree.BeforeLabelEdit += Tree_PressTree_BeforeLabelEdit;
            tree_PressTree.AfterLabelEdit += Tree_PressTree_AfterLabelEdit;
            tree_PressTree.NodeMouseDoubleClick += Tree_PressTree_NodeMouseDoubleClick;
            tree_PressTree.DragEnter += Tree_PressTree_DragEnter;
            tree_PressTree.DragOver += Tree_PressTree_DragOver;
            tree_PressTree.DragDrop += Tree_PressTree_DragDrop;

            // 双缓冲提升绘制体验
            EnableTreeDoubleBuffer();
            if (tree_PressTree.IsHandleCreated) EnableNativeDoubleBuffer(tree_PressTree);
            else tree_PressTree.HandleCreated += (s, e) => EnableNativeDoubleBuffer(tree_PressTree);

            // 动画计时器：刷新运行中工具的转圈帧
            _animTimer.Tick += (s, e) =>
            {
                bool any = false;
                foreach (var ti in tree_PressTree.Nodes.OfType<ToolItem>())
                {
                    if (ti.IsRunning)
                    {
                        ti.SpinnerFrame = (ti.SpinnerFrame + 1) % 12; // 简易 0-11 循环
                        any = true;
                        InvalidateNodeFullRow(ti);
                        var key = ti.Ref?.Id?.ToString();
                        if (!string.IsNullOrEmpty(key) && _toolStateCache.TryGetValue(key, out var st)) st.SpinnerFrame = ti.SpinnerFrame;
                    }
                }
                if (!any) _animTimer.Stop(); // 无运行节点则暂停计时器
            };

            // 初始化默认渲染实现
            _renderer = new DefaultToolItemRenderer();
            _renderContext = new ToolItemRenderContext
            {
                IconDrawSize = IconDrawSize,
                IconSize = IconSize,
                LeftPadding = LeftPadding,
                BetweenIndexAndName = BetweenIndexAndName,
                RightPadding = RightPadding,
                IndexFont = _indexFont,
                ResultFont = _resultFont,
                NameFont = tree_PressTree.Font,
                ElapsedBrush = _elapsedBrush,
                SuccessBrush = _successBrush,
                FailBrush = _failBrush,
                NameBrush = _nameBrush,
                RowBackBrush = _rowBackBrush,
                RowBackSelectedBrush = _rowBackSelectedBrush
            };

            // 创建执行服务并挂接事件
            _execService = new ProcessExecutionService(_solution);
            HookServiceEvents();

            UpdateProcessNameCaption();

            // 右键菜单绑定
            tree_PressTree.NodeMouseClick += (s,e)=>{ if(e.Button==MouseButtons.Right){ tree_PressTree.SelectedNode = e.Node; ShowToolPopup(e.Location); } };
            btn_SetEnable.ItemClick += (s,e)=>ToggleSelectedToolEnable();
            btn_RemoveTool.ItemClick += (s,e)=>RemoveSelectedTool();
        }

        /// <summary>
        /// 连接业务执行服务事件到界面刷新逻辑。
        /// </summary>
        private void HookServiceEvents()
        {
            if (_execService == null) return;
            _execService.RunStateChanged += (r, l) =>
            {
                RunStateChanged?.Invoke(r, l);
                if (!r) // 停止后恢复原始标题
                    RestoreCaptionAfterRun();
            };
            _execService.ToolStarted += OnToolStarted;
            _execService.ToolFinished += OnToolFinished;
            _execService.ProcessStarted += OnProcessStarted;
            _execService.ProcessFinished += (name, elapsed) => BeginInvoke(new Action(() => txt_Time.Caption = elapsed + "ms"));
        }

        private void RestoreCaptionAfterRun()
        {
            if (InvokeRequired) { try { BeginInvoke(new Action(RestoreCaptionAfterRun)); } catch { } return; }
            UpdateProcessNameCaption();
        }

        private void OnProcessStarted(string path)
        {
            if (InvokeRequired) { try { BeginInvoke(new Action<string>(OnProcessStarted), path); } catch { } return; }
            // 主界面触发“运行全部”时实时提示当前流程名（不改变选中节点）
            if (txt_ProName != null && !string.IsNullOrWhiteSpace(path))
            {
                var p = _solution?.GetProcess(path);
                txt_ProName.Caption = (p?.Name ?? path.Split('/').Last()) + " (运行中)";
            }
        }

        #region 公开给主界面的业务入口 (转调服务)
        /// <summary>运行全部流程（一次）。</summary>
        public void RunAllOnce() => _execService?.RunAllOnce();
        /// <summary>循环运行全部流程。</summary>
        public void StartLoopAll() => _execService?.StartLoopAll();
        /// <summary>停止全部运行/循环。</summary>
        public void StopRun() => _execService?.StopAll();
        /// <summary>运行当前选中流程一次。</summary>
        public void RunSelectedOnce()
        {
            if (!string.IsNullOrWhiteSpace(_currentProcessPath))
                _execService?.RunProcessOnce(_currentProcessPath);
        }
        /// <summary>循环运行选中流程。</summary>
        public void StartLoopSelected()
        {
            if (!string.IsNullOrWhiteSpace(_currentProcessPath))
                _execService?.StartLoopProcess(_currentProcessPath);
        }
        /// <summary>停止当前选中流程的循环。</summary>
        public void StopSelectedProcess()
        {
            if (!string.IsNullOrWhiteSpace(_currentProcessPath))
                _execService?.StopLoopProcess(_currentProcessPath);
        }
        /// <summary>
        /// 计算主界面运行控制按钮的可用性。
        /// </summary>
        public (bool canStartOnce, bool canLoop, bool canStop) GetButtonAvailability()
        {
            bool hasSel = !string.IsNullOrWhiteSpace(_currentProcessPath);
            if (!IsRunning) return (hasSel, hasSel, false);
            if (IsLoop) return (false, false, true);
            return (false, false, true);
        }
        #endregion

        #region 处理服务事件 -> 刷新界面
        private void OnToolStarted(ToolRef tr)
        {
            if (InvokeRequired) { try { BeginInvoke(new Action<ToolRef>(OnToolStarted), tr); } catch { } return; }
            var key = tr.Id?.ToString();
            var node = tree_PressTree.Nodes.Cast<TreeNode>().OfType<ToolItem>().FirstOrDefault(n => n.Ref == tr);
            if (node != null)
            {
                node.IsRunning = true;
                int startFrame = 0;
                if (!string.IsNullOrEmpty(key) && _toolStateCache.TryGetValue(key, out var stCache) && stCache.IsRunning)
                    startFrame = stCache.SpinnerFrame % 12;
                node.SpinnerFrame = startFrame;
                if (!_animTimer.Enabled) _animTimer.Start();
                InvalidateNodeFullRow(node);
            }
            // 缓存运行状态（即使当前流程未显示）
            CacheUpdate(key, s => { s.IsRunning = true; s.Success = null; if (node != null) s.SpinnerFrame = node.SpinnerFrame; });
        }
        private void OnToolFinished(ToolRef tr, long elapsed, bool ok)
        {
            if (InvokeRequired) { try { BeginInvoke(new Action<ToolRef, long, bool>(OnToolFinished), tr, elapsed, ok); } catch { } return; }
            var key = tr.Id?.ToString();
            var node = tree_PressTree.Nodes.Cast<TreeNode>().OfType<ToolItem>().FirstOrDefault(n => n.Ref == tr);
            if (node != null)
            {
                node.LastElapsedMs = elapsed;
                node.LastSuccess = ok;
                node.IsRunning = false;
                InvalidateNodeFullRow(node);
            }
            CacheUpdate(key, s => { s.Elapsed = elapsed; s.Success = ok; s.IsRunning = false; });
        }
        private void CacheUpdate(string key, Action<ToolState> update)
        {
            if (string.IsNullOrEmpty(key)) return;
            if (!_toolStateCache.TryGetValue(key, out var st))
            {
                st = new ToolState();
                _toolStateCache[key] = st;
            }
            update?.Invoke(st);
        }
        #endregion

        #region 数据/工具辅助(界面层仅用来绘制)
        /// <summary>
        /// 解析工具引用的图标：优先使用插件描述中的 SVG；失败返回占位图。
        /// </summary>
        private Bitmap ResolveToolBitmap(ToolRef t)
        {
            try
            {
                var desc = PluginToolService.GetAll().FirstOrDefault(d => d.ToolType.AssemblyQualifiedName == t.AssemblyQualifiedType || d.Name == t.TypeKey);
                if (desc?.Icon != null)
                {
                    var image = SvgBitmap.Create(desc.Icon).Render(new Size(IconSize, IconSize), null);
                    return new Bitmap(image);
                }
            }
            catch { }
            return null;
        }
        private static Bitmap CreatePlaceholder()
        {
            var b = new Bitmap(IconSize, IconSize);
            using var g = Graphics.FromImage(b); g.Clear(Color.Transparent);
            using var br = new SolidBrush(Color.SteelBlue); g.FillEllipse(br, 3, 3, IconSize - 6, IconSize - 6);
            return b;
        }
        #endregion

        #region 绑定/刷新
        /// <summary>绑定新的 Solution（刷新视图）。</summary>
        public void BindSolution(Solution.Solution solution)
        {
            _solution = solution ?? _solution;
            if (_execService != null) _execService.Solution = _solution;
            UpdateProcessNameCaption();
            RefreshToolsOnly();
        }
        /// <summary>显示指定流程路径的工具列表。</summary>
        public void ShowProcess(string processPath)
        {
            _currentProcessPath = processPath;
            UpdateProcessNameCaption();
            RefreshToolsOnly();
        }
        private void UpdateProcessNameCaption()
        {
            if (txt_ProName == null) return;
            if (string.IsNullOrWhiteSpace(_currentProcessPath)) { txt_ProName.Caption = "未选择流程"; return; }
            var proc = _solution?.GetProcess(_currentProcessPath);
            txt_ProName.Caption = proc?.Name ?? _currentProcessPath.Split('/').Last();
        }
        private ProcessItem GetCurrentProcess()
        {
            if (string.IsNullOrWhiteSpace(_currentProcessPath)) return null;
            return _solution.GetProcess(_currentProcessPath);
        }
        /// <summary>
        /// 重新构建当前流程的工具节点（不改变流程选择）。
        /// </summary>
        private void RefreshToolsOnly()
        {
            tree_PressTree.BeginUpdate();
            try
            {
                tree_PressTree.Nodes.Clear(); _toolImages.Images.Clear();
                var proc = GetCurrentProcess(); if (proc == null) return;
                int idx = 0;
                foreach (var t in proc.Tools)
                {
                    var bmp = ResolveToolBitmap(t) ?? CreatePlaceholder();
                    var keyImg = (t.TypeKey ?? "tool") + (idx++);
                    _toolImages.Images.Add(keyImg, bmp);

                    // 回填运行状态（如果缓存中已存在）
                    long elapsed = 0; bool? success = null; bool isRun = false; int frame = 0;
                    var stateKey = t.Id?.ToString();
                    if (!string.IsNullOrEmpty(stateKey) && _toolStateCache.TryGetValue(stateKey, out var st))
                    {
                        elapsed = st.Elapsed; success = st.Success; isRun = st.IsRunning; frame = st.SpinnerFrame % 12;
                    }

                    var node = new ToolItem(t, bmp)
                    {
                        ImageKey = keyImg,
                        SelectedImageKey = keyImg,
                        LastElapsedMs = elapsed,
                        LastSuccess = success,
                        IsRunning = isRun,
                        SpinnerFrame = frame
                    };
                    tree_PressTree.Nodes.Add(node);
                }
                if (tree_PressTree.Nodes.OfType<ToolItem>().Any(n => n.IsRunning) && !_animTimer.Enabled) _animTimer.Start();
            }
            finally { tree_PressTree.EndUpdate(); }
        }
        #endregion

        #region 绘制
        private void Tree_PressTree_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            var node = e.Node as ToolItem;
            var fullRow = new Rectangle(0, e.Bounds.Top, tree_PressTree.ClientSize.Width, e.Bounds.Height);
            _renderer.Render(e.Graphics, fullRow, e, node, _renderContext);
        }
        #endregion

        #region 拖拽/编辑
        private void Tree_PressTree_DragEnter(object sender, DragEventArgs e) => e.Effect = (!string.IsNullOrWhiteSpace(_currentProcessPath) && e.Data.GetDataPresent(typeof(ToolDragData).FullName)) ? DragDropEffects.Copy : DragDropEffects.None;
        private void Tree_PressTree_DragOver(object sender, DragEventArgs e) => Tree_PressTree_DragEnter(sender, e);
        private void Tree_PressTree_DragDrop(object sender, DragEventArgs e)
        {
            var proc = GetCurrentProcess(); if (proc == null) return; if (!e.Data.GetDataPresent(typeof(ToolDragData).FullName)) return;
            var data = (ToolDragData)e.Data.GetData(typeof(ToolDragData).FullName);
            var uniqueName = MakeUniqueName(proc, data.DisplayName);
            var toolRef = new ToolRef { Name = uniqueName, TypeKey = data.DisplayName, AssemblyQualifiedType = data.AssemblyQualifiedType, Enabled = true, SettingsJson = "{}" };
            if (_solution.AddTool(_currentProcessPath, toolRef))
            {
                var bmp = ResolveToolBitmap(toolRef) ?? CreatePlaceholder();
                var key = toolRef.TypeKey + toolRef.Id; _toolImages.Images.Add(key, bmp);
                var toolNode = new ToolItem(toolRef, bmp) { ImageKey = key, SelectedImageKey = key };
                tree_PressTree.Nodes.Add(toolNode);
                try
                {
                    var procName = _currentProcessPath.Split('/').Last();
                    SolutionManager.Instance.RegisterRuntimeTool(toolRef, procName, toolNode.Instance as ITool);
                    var cached = SolutionManager.Instance.GetToolInstance(toolRef.Id);
                    if (cached != null) toolNode.Instance = cached;
                }
                catch { }
            }
        }
        private static string MakeUniqueName(ProcessItem proc, string baseName)
        {
            if (proc == null) return baseName;
            if (!proc.Tools.Any(t => t.Name.Equals(baseName, StringComparison.OrdinalIgnoreCase))) return baseName;
            var used = new HashSet<int>();
            foreach (var t in proc.Tools)
            {
                var n = ExtractSuffixIndex(baseName, t.Name); if (n >= 0) used.Add(n);
            }
            int i = 0; while (used.Contains(i)) i++; return baseName + i;
        }
        private static int ExtractSuffixIndex(string baseName, string name)
        {
            if (string.IsNullOrEmpty(name) || !name.StartsWith(baseName, StringComparison.Ordinal)) return -1;
            var tail = name.Substring(baseName.Length); if (tail.Length == 0) return -1; return int.TryParse(tail, out var v) && v >= 0 ? v : -1;
        }
        private void Tree_PressTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            _blockLabelEditByDoubleClick = true;
            if (e.Node is ToolItem ti && ti.Ref != null)
            {
                // 惰性实例化：首次双击才创建工具实例（或使用缓存）
                if (ti.Instance == null)
                {
                    try
                    {
                        var cached = SolutionManager.Instance.GetToolInstance(ti.Ref.Id);
                        if (cached != null) ti.Instance = cached;
                        else
                        {
                            var type = Type.GetType(ti.Ref.AssemblyQualifiedType, false);
                            if (type != null)
                            {
                                ti.Instance = Activator.CreateInstance(type) as ITool;
                                if (ti.Instance != null)
                                {
                                    ti.Instance.Name = ti.Ref.Name; ti.Instance.Enable = ti.Ref.Enabled;
                                    if (ti.Instance is IPersistableTool p && !string.IsNullOrWhiteSpace(ti.Ref.SettingsJson) && ti.Ref.SettingsJson != "{}")
                                        try { p.ImportSettings(ti.Ref.SettingsJson); } catch { }
                                    var procName = _currentProcessPath?.Split('/').Last();
                                    if (!string.IsNullOrEmpty(procName)) SolutionManager.Instance.RegisterRuntimeTool(ti.Ref, procName, ti.Instance);
                                }
                            }
                        }
                    }
                    catch { }
                }
                // 打开配置窗口
                try { ti.Instance?.OpenForm(); } catch { }
                // “确定”后写回配置快照（工具实现中由 MarkConfirmed 负责生成）
                if (ti.Instance != null)
                {
                    var prop = ti.Instance.GetType().GetProperty("LastConfirmedSettings");
                    if (prop != null)
                    {
                        var val = prop.GetValue(ti.Instance) as string;
                        if (!string.IsNullOrEmpty(val))
                        {
                            try
                            {
                                ti.Ref.SettingsJson = val; ti.Ref.Enabled = ti.Instance.Enable;
                                ti.Instance.GetType().GetMethod("ClearConfirmationFlag")?.Invoke(ti.Instance, null);
                            }
                            catch { }
                        }
                    }
                }
            }
        }
        private void Tree_PressTree_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            // 双击打开配置时会先触发 LabelEdit，这里阻止第一次编辑
            if (_blockLabelEditByDoubleClick) { e.CancelEdit = true; _blockLabelEditByDoubleClick = false; }
        }
        private void Tree_PressTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null) return;
            var newName = e.Label.Trim(); if (newName.Length == 0) { e.CancelEdit = true; return; }
            var proc = GetCurrentProcess(); if (proc == null) { e.CancelEdit = true; return; }
            var node = e.Node as ToolItem; if (node?.Ref == null) { e.CancelEdit = true; return; }
            // 通过 Solution.RenameTool 统一校验与触发事件（变量重建 + UI 刷新）
            if (!_solution.RenameTool(_currentProcessPath, node.Ref.Id, newName)) { e.CancelEdit = true; return; }
            node.Text = newName; // UI立即同步
            if (node.Instance != null) node.Instance.Name = newName;
        }
        #endregion

        #region 局部刷新
        /// <summary>按整行区域重绘指定节点，避免出现截断或背景块。</summary>
        private void InvalidateNodeFullRow(ToolItem node)
        {
            if (node == null) return; var r = node.Bounds; if (r == Rectangle.Empty) return;
            var full = new Rectangle(0, r.Top, tree_PressTree.ClientSize.Width, r.Height);
            tree_PressTree.Invalidate(full, false);
        }
        #endregion

        /// <summary>
        /// 显示右键工具菜单，动态更新启用/禁用按钮文字。
        /// </summary>
        private void ShowToolPopup(Point location)
        {
            if (tree_PressTree.SelectedNode is ToolItem ti)
            {
                var instEnabled = ti.Ref.Enabled;
                btn_SetEnable.Caption = instEnabled ? "禁用" : "启用";
                popupMenuTool.ShowPopup(tree_PressTree.PointToScreen(location));
            }
        }
        private void ToggleSelectedToolEnable()
        {
            if (tree_PressTree.SelectedNode is not ToolItem ti) return;
            ti.Ref.Enabled = !ti.Ref.Enabled;
            if (ti.Instance != null) ti.Instance.Enable = ti.Ref.Enabled;
            btn_SetEnable.Caption = ti.Ref.Enabled ? "禁用" : "启用";
            InvalidateNodeFullRow(ti);
        }
        private void RemoveSelectedTool()
        {
            if (tree_PressTree.SelectedNode is not ToolItem ti) return;
            var proc = GetCurrentProcess(); if (proc == null) return;
            if (MessageBox.Show($"确定删除工具: {ti.Ref.Name}?","确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            if (_solution.RemoveTool(_currentProcessPath, ti.Ref.Id))
            {
                // 事件会触发刷新; 这里直接移除节点以提升响应
                tree_PressTree.Nodes.Remove(ti);
            }
        }
    }
}
