using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.Utils.Svg;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VisionCore.Solution;
using System.Collections.Generic; // added
using System.Xml.Serialization;

namespace VisionCore.Frm_Solution
{
    public partial class Frm_ProcessConfig : XtraUserControl
    {
        //添加节点（传递路径）
        public event Action<string> AddNodeEvent;
        //删除节点（传递路径）
        public event Action<string> RemoveNodeEvent;
        //节点重命名（传递旧路径、新名称）
        public event Action<string, string> ReNodeNameEvent;
        //节点启用切换
        public event Action<string, string> EnableEvent;
        // 选中流程变化（传递流程路径）
        public event Action<string> SelectedProcessChanged;

        private ImageList _treeImages;
        private static readonly Size NodeIconSize = new Size(32, 32);

        private enum NodeKind
        {
            Process,
            Folder
        }

        public Solution.Solution SolutionMgr { get; set; } = new Solution.Solution("默认方案");

        private readonly Color _selFocusBack = Color.DodgerBlue; // 高亮(获得焦点)
        private readonly Color _selUnfocusBack = Color.FromArgb(55, 55, 55); // 高亮(失焦)
        private readonly Color _selFocusBorder = Color.FromArgb(100, 180, 230);
        private readonly Color _selUnfocusBorder = Color.FromArgb(90, 90, 90);

        private ProcessItem _clipboardProcess; // 内部剪贴板(深拷贝)

        public Frm_ProcessConfig()
        {
            InitializeComponent();
            bar_Main.AllowCustomization = false;
            bar_Main.AllowQuickCustomization = false;
            InitTreeIcons();
            this.Load += Frm_PressConfig_Load;

            tree_PressTree.NodeMouseClick += (s, e) => { if (e.Button == MouseButtons.Right) tree_PressTree.SelectedNode = e.Node; };
            tree_PressTree.MouseDown += (s, e) => { if (e.Button == MouseButtons.Right && tree_PressTree.GetNodeAt(e.Location) == null) tree_PressTree.SelectedNode = null; };

            tree_PressTree.LabelEdit = true;
            tree_PressTree.AfterLabelEdit += Tree_PressTree_AfterLabelEdit;
            tree_PressTree.AfterSelect += Tree_PressTree_AfterSelect;

            // 始终显示选中高亮
            tree_PressTree.HideSelection = false;
            tree_PressTree.FullRowSelect = true;
            tree_PressTree.DrawMode = TreeViewDrawMode.OwnerDrawText;
            tree_PressTree.DrawNode += Tree_PressTree_DrawNode;
            tree_PressTree.GotFocus += (s, e) => tree_PressTree.Invalidate();
            tree_PressTree.LostFocus += (s, e) => tree_PressTree.Invalidate();

            popupMenu1.BeforePopup += popupMenu1_BeforePopup;

            mbtn_Copy.ItemClick += (s, e) => CopySelectedProcess();
            mbtn_Paste.ItemClick += (s, e) => PasteProcessToTarget();
            mbtn_Remove.ItemClick += btn_Remove_ItemClick;
            mbtn_ReName.ItemClick += (s, e) => BeginRenameSelected();
            mbtn_Enable.ItemClick += (s, e) => ToggleEnableSelectedProcess();
        }

        private void Tree_PressTree_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            // 自定义绘制：选中节点始终高亮
            var tree = sender as TreeView;
            if (tree == null)
            {
                e.DrawDefault = true; return;
            }

            bool selected = (e.Node == tree.SelectedNode);
            var bounds = e.Bounds;
            bounds.Width = tree.Width - bounds.X - 4; // 拉满一行

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            if (selected)
            {
                var back = tree.Focused ? _selFocusBack : _selUnfocusBack;
                var border = tree.Focused ? _selFocusBorder : _selUnfocusBorder;
                using (var br = new SolidBrush(back)) g.FillRectangle(br, bounds);
                using (var pen = new Pen(border)) g.DrawRectangle(pen, bounds.X, bounds.Y, bounds.Width - 1, bounds.Height - 1);
            }

            // 文本颜色：未选中 -> 使用节点自身 ForeColor（用于显示禁用流程灰色）；选中 -> 白色 或 浅灰(若禁用)
            Color nodeFore = e.Node.ForeColor.IsEmpty ? tree.ForeColor : e.Node.ForeColor;
            if (!selected)
            {
                // nothing extra
            }
            else
            {
                bool disabled = (e.Node.Tag is NodeKind nk && nk == NodeKind.Process && nodeFore == Color.DimGray);
                nodeFore = disabled ? Color.LightGray : Color.White;
            }
            TextRenderer.DrawText(g, e.Node.Text, tree.Font, new Rectangle(bounds.X + 4, bounds.Y, bounds.Width - 8, bounds.Height), nodeFore, TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
        }

        private void Tree_PressTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is NodeKind kind && kind == NodeKind.Process)
            {
                var path = GetNodePath(e.Node);
                SelectedProcessChanged?.Invoke(path);
            }
            // 选中变化时刷新以便显示高亮
            tree_PressTree.Invalidate();
        }

        // 从反序列化后的 Solution 渲染树
        public void FromSolution(Solution.Solution manager)
        {
            if (manager == null || manager.Data == null) return;
            SolutionMgr = manager;
            tree_PressTree.BeginUpdate();
            try
            {
                tree_PressTree.Nodes.Clear();
                foreach (var node in SolutionMgr.Data.Root)
                {
                    var ui = CreateTreeNode(node);
                    if (ui != null)
                        tree_PressTree.Nodes.Add(ui);
                }
                tree_PressTree.ExpandAll();
            }
            finally
            {
                tree_PressTree.EndUpdate();
            }
            // 默认选择第一个流程（若存在），否则通知无选中
            RefreshSelectionAfterStructureChange(force: true);
        }

        private TreeNode CreateTreeNode(ProcessNode node)
        {
            if (node is ProcessFolder folder)
            {
                var tn = new TreeNode(folder.Name)
                {
                    ImageKey = "Folder",
                    SelectedImageKey = "Folder",
                    Tag = NodeKind.Folder
                };
                foreach (var child in folder.Children)
                {
                    var ui = CreateTreeNode(child);
                    if (ui != null) tn.Nodes.Add(ui);
                }
                return tn;
            }
            if (node is ProcessItem item)
            {
                var tn = new TreeNode(item.Name)
                {
                    ImageKey = "Process",
                    SelectedImageKey = "Process",
                    Tag = NodeKind.Process
                };
                if (!item.Enabled) tn.ForeColor = Color.DimGray; // 灰色显示禁用流程
                return tn;
            }
            return null;
        }

        private void popupMenu1_BeforePopup(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var node = tree_PressTree.SelectedNode;
            bool isFolder = node?.Tag is NodeKind.Folder;
            bool isProcess = node?.Tag is NodeKind.Process;
            btn_Remove.Enabled = isProcess;
            btn_RemoveFile.Enabled = isFolder;
            mbtn_Copy.Enabled = isProcess;
            mbtn_ReName.Enabled = isProcess;
            mbtn_Enable.Enabled = isProcess;
            mbtn_Paste.Enabled = _clipboardProcess != null && (isFolder || isProcess || node == null);
            if (isProcess)
            {
                var proc = SolutionMgr.GetProcess(GetNodePath(node));
                mbtn_Enable.Caption = (proc?.Enabled ?? true) ? "禁用" : "启用";
            }
            else mbtn_Enable.Caption = "禁用";
        }

        private void CopySelectedProcess()
        {
            var node = tree_PressTree.SelectedNode;
            if (node == null || node.Tag is not NodeKind kind || kind != NodeKind.Process) return;
            var path = GetNodePath(node);
            var proc = SolutionMgr.GetProcess(path);
            if (proc == null) return;
            // 深拷贝 (序列化)
            _clipboardProcess = DeepClone(proc);
        }

        private void PasteProcessToTarget()
        {
            if (_clipboardProcess == null) return;
            // 目标：若当前选中文件夹 -> 其下；若选中流程 -> 同级；若无选中 -> 根
            TreeNode target = tree_PressTree.SelectedNode;
            TreeNode parentFolderNode = null;
            if (target != null)
            {
                if (target.Tag is NodeKind.Folder) parentFolderNode = target;
                else if (target.Tag is NodeKind.Process) parentFolderNode = target.Parent; // 同级
            }
            var collection = parentFolderNode?.Nodes ?? tree_PressTree.Nodes;
            // 生成唯一名称(复制时始终以 "流程" 为基名)
            string baseName = "流程"; // 原 clipboard 名不再沿用
            string newName = GetNextUniqueText(collection, baseName);

            // 克隆新的 ProcessItem (保持工具/ID 复制，但新的流程 Id 防止冲突)
            var cloned = DeepClone(_clipboardProcess);
            cloned.Id = Guid.NewGuid().ToString("N");
            cloned.Name = newName;

            var fullPath = parentFolderNode == null ? newName : GetNodePath(parentFolderNode) + "/" + newName;
            SolutionMgr.AddProcessItem(fullPath, cloned);

            // 变量注册：为克隆流程里的所有工具重新注册变量
            try
            {
                foreach (var tr in cloned.Tools)
                {
                    var type = Type.GetType(tr.AssemblyQualifiedType ?? string.Empty, false);
                    if (type == null) continue;
                    var inst = Activator.CreateInstance(type) as VisionCore.ToolBase.ITool;
                    if (inst == null) continue;
                    inst.Name = tr.Name; inst.Enable = tr.Enabled;
                    if (inst is VisionCore.ToolBase.IPersistableTool p && !string.IsNullOrWhiteSpace(tr.SettingsJson) && tr.SettingsJson != "{}")
                        try { p.ImportSettings(tr.SettingsJson); } catch { }
                    VisionCore.Linking.LinkRegistry.Instance.RegisterTool(newName, inst.Name, inst);
                }
            }
            catch { }

            var newNode = new TreeNode(newName)
            {
                ImageKey = "Process",
                SelectedImageKey = "Process",
                Tag = NodeKind.Process
            };
            if (!cloned.Enabled) newNode.ForeColor = Color.DimGray;
            collection.Add(newNode);
            if (parentFolderNode != null) parentFolderNode.Expand(); else tree_PressTree.ExpandAll();
            tree_PressTree.SelectedNode = newNode;
            SelectedProcessChanged?.Invoke(fullPath);
        }

        private static T DeepClone<T>(T obj)
        {
            if (obj == null) return default;
            try
            {
                var ser = new XmlSerializer(typeof(T));
                using var ms = new MemoryStream();
                ser.Serialize(ms, obj);
                ms.Position = 0;
                return (T)ser.Deserialize(ms);
            }
            catch { return default; }
        }

        private void BeginRenameSelected()
        {
            var node = tree_PressTree.SelectedNode;
            if (node == null || node.Tag is not NodeKind kind || kind != NodeKind.Process) return;
            try { node.BeginEdit(); } catch { }
        }

        private void ToggleEnableSelectedProcess()
        {
            var node = tree_PressTree.SelectedNode;
            if (node == null || node.Tag is not NodeKind kind || kind != NodeKind.Process) return;
            var path = GetNodePath(node);
            var proc = SolutionMgr.GetProcess(path);
            if (proc == null) return;
            proc.Enabled = !proc.Enabled;
            node.ForeColor = proc.Enabled ? SystemColors.WindowText : Color.DimGray;
            mbtn_Enable.Caption = proc.Enabled ? "禁用" : "启用";
            tree_PressTree.Invalidate(node.Bounds); // 立即刷新颜色
        }

        private void Tree_PressTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null) return; // 取消
            var node = e.Node;
            var oldPath = GetNodePath(node);
            var newName = e.Label.Trim();
            if (newName.Length == 0)
            {
                e.CancelEdit = true;
                return;
            }

            // 重名校验（同级）
            TreeNodeCollection siblings = node.Parent?.Nodes ?? tree_PressTree.Nodes;
            bool exists = siblings.Cast<TreeNode>()
                .Any(n => !ReferenceEquals(n, node) && string.Equals(n.Text, newName, StringComparison.OrdinalIgnoreCase));
            if (exists)
            {
                XtraMessageBox.Show($"名称 \"{newName}\" 已存在。", "重名", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.CancelEdit = true;
                return;
            }

            // 确认对话框
            if (XtraMessageBox.Show($"确定将 \"{node.Text}\" 重命名为 \"{newName}\"？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                e.CancelEdit = true;
                return;
            }

            // 更新 UI 名称（AfterLabelEdit 不取消时会自动更新，这里显式赋值以确保一致）
            node.Text = newName;

            if (node.Tag is NodeKind kind)
            {
                if (kind == NodeKind.Process)
                {
                    ReNodeNameEvent?.Invoke(oldPath, newName);
                    SolutionMgr.RenameProcess(oldPath, newName);
                    // 更新变量注册表中的流程名（旧名->新名，只针对最末级名称）
                    try
                    {
                        var oldProcName = oldPath.Split('/').Last();
                        VisionCore.Linking.LinkRegistry.Instance.RenameProcess(oldProcName, newName);
                    }
                    catch { }
                    SelectedProcessChanged?.Invoke(GetNodePath(node));
                }
                else if (kind == NodeKind.Folder)
                {
                    // 文件夹重命名：更新其下所有子流程路径（对业务层可先删除再重新 Add，或提供 RenameFolder）
                    RenameFolderInSolution(oldPath, newName, node);
                    RefreshSelectionAfterStructureChange();
                }
            }
        }

        private void RenameFolderInSolution(string oldFolderPath, string newFolderName, TreeNode folderNode)
        {
            // 获取该文件夹下所有流程路径（递归）
            var procNodes = folderNode.Nodes.Cast<TreeNode>().SelectMany(EnumerateProcessNodesRecursive).ToList();
            foreach (var procNode in procNodes)
            {
                var oldProcPath = GetNodePath(procNode); // oldFolder/子/.../流程X
                var segments = GetNodeSegments(procNode);
                // 第一段是根文件夹名
                if (segments.Count > 0)
                    segments[0] = newFolderName;
                var newProcPath = string.Join("/", segments);

                // 业务层：删除旧流程再新增
                SolutionMgr.RemoveProcess(oldProcPath);
                SolutionMgr.AddProcess(newProcPath);
                ReNodeNameEvent?.Invoke(oldProcPath, segments.Last());
            }
        }

        private static IEnumerable<TreeNode> EnumerateProcessNodesRecursive(TreeNode node)
        {
            foreach (TreeNode child in node.Nodes)
            {
                if (child.Tag is NodeKind kind && kind == NodeKind.Process)
                    yield return child;
                else if (child.Tag is NodeKind kind2 && kind2 == NodeKind.Folder)
                {
                    foreach (var d in EnumerateProcessNodesRecursive(child))
                        yield return d;
                }
            }
        }

        private void AddProcessNode()
        {
            TreeNode parent = null;
            // 仅允许添加到“文件夹”下；若当前选中的是文件夹则作为其子节点，否则添加到根
            if (tree_PressTree.SelectedNode?.Tag is NodeKind kind && kind == NodeKind.Folder)
                parent = tree_PressTree.SelectedNode;

            var collection = parent?.Nodes ?? tree_PressTree.Nodes;
            string text = GetNextUniqueText(collection, "流程");

            var node = new TreeNode(text)
            {
                ImageKey = "Process",
                SelectedImageKey = "Process",
                Tag = NodeKind.Process
            };
            collection.Add(node);

            if (parent != null)
                parent.Expand();
            else
                tree_PressTree.ExpandAll();

            tree_PressTree.SelectedNode = node;

            var path = GetNodePath(node);
            AddNodeEvent?.Invoke(path);
            SolutionMgr.AddProcess(path);
            SelectedProcessChanged?.Invoke(path);
        }

        private void AddFolderNode()
        {
            // 文件夹只作为一级节点：始终添加到根节点
            var collection = tree_PressTree.Nodes;

            string text = GetNextUniqueText(collection, "文件夹");

            var node = new TreeNode(text)
            {
                ImageKey = "Folder",
                SelectedImageKey = "Folder",
                Tag = NodeKind.Folder
            };
            collection.Add(node);

            tree_PressTree.ExpandAll();
            tree_PressTree.SelectedNode = node;
            RefreshSelectionAfterStructureChange();
        }

        private static string GetNextUniqueText(TreeNodeCollection nodes, string baseName)
        {
            // 生成：baseName0, baseName1, baseName2 ...
            int i = 0;
            string name;
            bool Exists(string n) => nodes.Cast<TreeNode>()
                .Any(t => string.Equals(t.Text, n, StringComparison.OrdinalIgnoreCase));

            do
            {
                name = $"{baseName}{i++}";
            } while (Exists(name));

            return name;
        }

        private static string GetNodePath(TreeNode node) => string.Join("/", GetNodeSegments(node));

        private static List<string> GetNodeSegments(TreeNode node)
        {
            var stack = new Stack<string>(); var cur = node;
            while (cur != null) { stack.Push(cur.Text); cur = cur.Parent; }
            return stack.ToList();
        }

        // 查找树中第一个流程节点（深度优先）
        private TreeNode FindFirstProcessNode()
        {
            foreach (TreeNode root in tree_PressTree.Nodes)
            {
                var found = FindFirstProcessNodeRecursive(root);
                if (found != null) return found;
            }
            return null;
        }

        private TreeNode FindFirstProcessNodeRecursive(TreeNode node)
        {
            if (node.Tag is NodeKind kind && kind == NodeKind.Process) return node;
            foreach (TreeNode child in node.Nodes)
            {
                var r = FindFirstProcessNodeRecursive(child);
                if (r != null) return r;
            }
            return null;
        }

        // 当结构变化后刷新默认选中逻辑
        private void RefreshSelectionAfterStructureChange(bool force = false)
        {
            var firstProc = FindFirstProcessNode();
            if (firstProc == null)
            {
                // 无流程 -> 通知清空
                SelectedProcessChanged?.Invoke(null);
                return;
            }
            if (force || tree_PressTree.SelectedNode == null || !(tree_PressTree.SelectedNode.Tag is NodeKind k && k == NodeKind.Process))
            {
                tree_PressTree.SelectedNode = firstProc;
                SelectedProcessChanged?.Invoke(GetNodePath(firstProc));
            }
        }

        private static Bitmap LoadSvgAsBitmapFromResources(string name, Size size)
        {
            try
            {
                var obj = Properties.Resources.ResourceManager.GetObject(name);
                if (obj is SvgImage svg1)
                {
                    Image img = SvgBitmap.Create(svg1).Render(null);
                    var bmp = new Bitmap(size.Width, size.Height);
                    using (var g = Graphics.FromImage(bmp))
                    {
                        g.Clear(Color.Transparent);
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                        g.DrawImage(img, new Rectangle(Point.Empty, size));
                    }
                    img.Dispose();
                    return bmp;
                }
            }
            catch { }
            return null;
        }

        private static Bitmap CreatePlaceholderBitmap(Color color, Size size)
        {
            var bmp = new Bitmap(size.Width, size.Height);
            using var g = Graphics.FromImage(bmp);
            g.Clear(Color.Transparent);
            using var b = new SolidBrush(color);
            g.FillRectangle(b, 2, 2, Math.Max(2, size.Width - 4), Math.Max(2, size.Height - 4));
            return bmp;
        }

        private void InitTreeIcons()
        {
            _treeImages = new ImageList
            {
                ColorDepth = ColorDepth.Depth32Bit,
                ImageSize = NodeIconSize
            };
            var processBmp = LoadSvgAsBitmapFromResources("子流程", NodeIconSize) ?? CreatePlaceholderBitmap(Color.DeepSkyBlue, NodeIconSize);
            var folderBmp = LoadSvgAsBitmapFromResources("File", NodeIconSize) ?? CreatePlaceholderBitmap(Color.Goldenrod, NodeIconSize);
            _treeImages.Images.Add("Process", processBmp);
            _treeImages.Images.Add("Folder", folderBmp);
            tree_PressTree.ImageList = _treeImages;
            var fontHeight = (int)Math.Ceiling(tree_PressTree.Font.GetHeight());
            tree_PressTree.ItemHeight = Math.Max(NodeIconSize.Height + 6, fontHeight + 6);
            tree_PressTree.Font = new Font(tree_PressTree.Font.FontFamily, tree_PressTree.Font.Size + 1.5f);
            tree_PressTree.ItemHeight = Math.Max(NodeIconSize.Height + 6, (int)Math.Ceiling(tree_PressTree.Font.GetHeight()) + 6);
        }

        private void Frm_PressConfig_Load(object sender, EventArgs e)
        {
            bar_Main.SetPopupContextMenu(tree_PressTree, popupMenu1);
        }

        private void btn_Remove_ItemClick(object sender, ItemClickEventArgs e)
        {
            var node = tree_PressTree.SelectedNode;
            if (node == null) return;
            if (node.Tag is NodeKind kind && kind == NodeKind.Process)
            {
                if (XtraMessageBox.Show($"确定删除流程: {node.Text}？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;
                var path = GetNodePath(node);
                node.Remove();
                RemoveNodeEvent?.Invoke(path);
                SolutionMgr.RemoveProcess(path);
                try { var procName = path.Split('/').Last(); VisionCore.Linking.LinkRegistry.Instance.RemoveProcess(procName); } catch { }
                RefreshSelectionAfterStructureChange(force: true);
            }
        }

        // 新增: 恢复工具栏事件处理程序
        private void btn_Add_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddProcessNode();
        }
        private void btn_AddFile_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddFolderNode();
        }
        private void btn_RemoveFile_ItemClick(object sender, ItemClickEventArgs e)
        {
            var node = tree_PressTree.SelectedNode;
            if (node == null) return;
            if (node.Tag is NodeKind kind && kind == NodeKind.Folder)
            {
                int count = EnumerateProcessNodesRecursive(node).Count();
                if (XtraMessageBox.Show($"确定删除文件夹: {node.Text} 及其包含的 {count} 个流程？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;
                RemoveFolderRecursively(node);
                node.Remove();
                RefreshSelectionAfterStructureChange(force: true);
            }
        }

        private void RemoveFolderRecursively(TreeNode folderNode)
        {
            foreach (TreeNode child in folderNode.Nodes)
            {
                if (child.Tag is NodeKind cKind && cKind == NodeKind.Process)
                {
                    var path = GetNodePath(child);
                    RemoveNodeEvent?.Invoke(path);
                    SolutionMgr.RemoveProcess(path);
                    try { var procName = path.Split('/').Last(); VisionCore.Linking.LinkRegistry.Instance.RemoveProcess(procName); } catch { }
                }
            }
            foreach (TreeNode child in folderNode.Nodes)
            {
                if (child.Tag is NodeKind cKind && cKind == NodeKind.Folder)
                    RemoveFolderRecursively(child);
            }
        }
    }
}
