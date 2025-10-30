using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VisionCore.Linking;

namespace VisionCore.Frm_Solution
{
    public partial class Frm_LinkValue : XtraForm
    {
        private readonly Type _targetType;
        private readonly string _excludeToolName; // 新增: 排除自身工具
        public string SelectedVariablePath { get; private set; }

        private class GridRow
        {
            public string 类型 { get; set; }
            public string 名称 { get; set; }
            public string 值 { get; set; }
            public string 路径 { get; set; }
        }

        /// <param name="targetType">目标属性类型</param>
        /// <param name="excludeToolName">需要排除的工具名称（自身）</param>
        public Frm_LinkValue(Type targetType = null, string excludeToolName = null)
        {
            _targetType = targetType ?? typeof(object);
            _excludeToolName = excludeToolName;
            InitializeComponent();
            InitGrid();
            LoadTree();
            treeView1.AfterSelect += TreeView1_AfterSelect;
            btn_Confirm.Click += Btn_Confirm_Click;
            btn_Cancel.Click += (_, _) => { DialogResult = DialogResult.Cancel; Close(); };
            gridView1.DoubleClick += (_, _) => { if (gridView1.GetFocusedRow() is GridRow r) { SelectedVariablePath = r.路径; DialogResult = DialogResult.OK; Close(); } };
            gridView1.Click += (_, _) => UpdateSelectedPathFromGrid();
            gridView1.FocusedRowChanged += (_, __) => UpdateSelectedPathFromGrid();
        }

        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            UpdateSelectedPathFromGrid();
            if (string.IsNullOrWhiteSpace(SelectedVariablePath))
            {
                XtraMessageBox.Show("请先选择一个变量", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void UpdateSelectedPathFromGrid()
        {
            var row = gridView1.GetFocusedRow() as GridRow;
            if (row != null)
                SelectedVariablePath = row.路径;
        }

        private void InitGrid()
        {
            gridControl1.DataSource = new List<GridRow>();
            gridView1.Columns.Clear();
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.OptionsSelection.MultiSelect = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = true;
            gridView1.Appearance.FocusedRow.BackColor = Color.FromArgb(60, 120, 200);
            gridView1.Appearance.FocusedRow.ForeColor = Color.White;
            gridView1.Appearance.SelectedRow.BackColor = Color.FromArgb(60, 120, 200);
            gridView1.Appearance.SelectedRow.ForeColor = Color.White;
            gridView1.Appearance.HideSelectionRow.BackColor = Color.FromArgb(60, 80, 120);
            gridView1.Appearance.HideSelectionRow.ForeColor = Color.White;
            gridView1.OptionsSelection.InvertSelection = false;
            gridView1.OptionsView.EnableAppearanceEvenRow = false;
            gridView1.OptionsView.EnableAppearanceOddRow = false;
            AddCol("类型", 100);
            AddCol("名称", 150);
            AddCol("值", 250);
        }

        private void AddCol(string field, int width)
        {
            var col = new GridColumn { FieldName = field, Caption = field, Visible = true, Width = width };
            col.AppearanceHeader.BackColor = Color.Black;
            gridView1.Columns.Add(col);
        }

        private void LoadTree()
        {
            treeView1.Nodes.Clear();
            var groups = LinkRegistry.Instance.All
                .Where(v => string.IsNullOrEmpty(_excludeToolName) || !v.ToolId.Equals(_excludeToolName, StringComparison.OrdinalIgnoreCase))
                .GroupBy(v => v.ProcessId)
                .OrderBy(g => g.Key);
            foreach (var proc in groups)
            {
                var nProc = new TreeNode(proc.Key) { Tag = proc.Key };
                foreach (var tool in proc.GroupBy(v => v.ToolId)
                                          .Where(g => string.IsNullOrEmpty(_excludeToolName) || !g.Key.Equals(_excludeToolName, StringComparison.OrdinalIgnoreCase))
                                          .OrderBy(g => g.Key))
                {
                    var nTool = new TreeNode(tool.Key) { Tag = tool.First().ToolId };
                    nProc.Nodes.Add(nTool);
                }
                treeView1.Nodes.Add(nProc);
            }
            treeView1.ExpandAll();
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            string procName = null;
            string toolName = null;
            if (e.Node.Parent == null)
                procName = e.Node.Text;
            else
            {
                procName = e.Node.Parent.Text;
                toolName = e.Node.Text;
            }

            var vars = LinkRegistry.Instance.All.Where(v => v.ProcessId == procName);
            if (!string.IsNullOrEmpty(toolName)) vars = vars.Where(v => v.ToolId == toolName);
            // 排除自身工具
            if (!string.IsNullOrEmpty(_excludeToolName)) vars = vars.Where(v => !v.ToolId.Equals(_excludeToolName, StringComparison.OrdinalIgnoreCase));
            vars = vars.Where(v => IsAssignableToTarget(v, _targetType));

            var list = vars.Select(v => new GridRow
            {
                类型 = v.DataType.Name,
                名称 = string.IsNullOrWhiteSpace(v.Description) ? v.DisplayName : v.Description,
                值 = SafePreview(v),
                路径 = v.FullPath
            }).ToList();
            gridControl1.DataSource = list;
            gridView1.BestFitColumns();
            if (list.Count > 0)
            {
                gridView1.FocusedRowHandle = 0;
                UpdateSelectedPathFromGrid();
            }
        }

        private bool IsAssignableToTarget(VariableDescriptor v, Type target)
        {
            if (target == null || target == typeof(object)) return true;
            if (target.IsAssignableFrom(v.DataType)) return true;
            if (v.ExtraTypes.Any(t => target.IsAssignableFrom(t))) return true;
            return false;
        }

        private string SafePreview(VariableDescriptor v)
        {
            try
            {
                var val = v.Getter?.Invoke();
                if (val == null) return "<null>";
                if (val is System.Drawing.Image img) return string.Format("Image({0}x{1})", img.Width, img.Height);
                return val.ToString();
            }
            catch { return "<err>"; }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (treeView1.Nodes.Count > 0)
            {
                // 自动选择第一个包含工具的流程的第一个工具
                var firstProc = treeView1.Nodes.Cast<TreeNode>().FirstOrDefault(p => p.Nodes.Count > 0);
                if (firstProc != null)
                {
                    treeView1.SelectedNode = firstProc.Nodes[0];
                }
            }
        }
    }
}