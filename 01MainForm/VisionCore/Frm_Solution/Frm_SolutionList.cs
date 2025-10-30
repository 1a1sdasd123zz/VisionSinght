using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using VisionCore.Solution;
using System.IO;

namespace VisionCore.Frm_Solution
{
    public partial class Frm_SolutionList : XtraForm
    {
        public event Action<Solution.Solution> OpenSolutionRequested;

        private BindingList<SolutionInfo> _binding;
        private readonly Regex _nameValid = new Regex("^[A-Za-z0-9_\u4e00-\u9fa5]+$", RegexOptions.Compiled);
        private string _originalNameEditing; // 进入编辑时的原名称

        public Frm_SolutionList()
        {
            InitializeComponent();
            InitGrid();
        }

        private void Frm_SolutionList_Load(object sender, EventArgs e) => BindData();

        private void BindData()
        {
            SolutionManager.Instance.EnsureLoaded();
            _binding = new BindingList<SolutionInfo>(SolutionManager.Instance.Solutions);
            gridControl1.DataSource = _binding;
            gridView1.PopulateColumns();
            if (gridView1.Columns[nameof(SolutionInfo.Name)] != null)
                gridView1.Columns[nameof(SolutionInfo.Name)].OptionsColumn.AllowEdit = true;
            if (gridView1.Columns[nameof(SolutionInfo.Enable)] != null)
                gridView1.Columns[nameof(SolutionInfo.Enable)].OptionsColumn.AllowEdit = false;
            gridView1.BestFitColumns();
            // 动态编辑颜色事件
            gridView1.ShownEditor += GridView1_ShownEditor;
            gridView1.HiddenEditor += GridView1_HiddenEditor;
            gridView1.ValidatingEditor += GridView1_ValidatingEditor;
        }

        private void InitGrid()
        {
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsBehavior.ReadOnly = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = true;
            gridView1.OptionsView.ColumnAutoWidth = false;
        }

        #region 按钮
        private void btn_Open_Click(object sender, EventArgs e) => OpenSelected();

        private void btn_AddNew_Click(object sender, EventArgs e)
        {
            try
            {
                var name = MakeUniqueBase("新方案");
                SolutionManager.Instance.NewSolution(name, string.Empty, false);
                RefreshBinding();
                FocusRowByName(name);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("添加空白方案失败: " + ex.Message);
            }
        }

        private void btn_AddCur_Click(object sender, EventArgs e)
        {
            try
            {
                var srcInfo = GetFocusedInfo();
                if (srcInfo == null)
                {
                    XtraMessageBox.Show("请先选中要复制的方案");
                    return;
                }
                var srcPath = srcInfo.Path;
                var newName = MakeUniqueBase(srcInfo.Name + "_Copy");
                var newFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Solutions", newName + ".uv");
                File.Copy(srcPath, newFile, true);
                var info = new SolutionInfo
                {
                    Name = newName,
                    Description = srcInfo.Description,
                    Enable = false,
                    CreateTime = DateTime.Now,
                    LastModifyTime = DateTime.Now,
                    Path = newFile
                };
                SolutionManager.Instance.Solutions.Add(info);
                SolutionManager.Instance.SaveList();
                RefreshBinding();
                FocusRowByName(newName);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("复制选中方案失败: " + ex.Message);
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            var info = GetFocusedInfo();
            if (info == null) return;
            var activeName = SolutionManager.Instance.CurrentSolution?.Data?.Name;
            if (!string.IsNullOrEmpty(activeName) && info.Name.Equals(activeName, StringComparison.OrdinalIgnoreCase))
            {
                XtraMessageBox.Show("当前激活方案不能删除，请先切换到其它方案。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (SolutionManager.Instance.Solutions.Count <= 1)
            {
                XtraMessageBox.Show("至少需要保留一个方案，无法删除。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (XtraMessageBox.Show($"确定删除方案：{info.Name}?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;
            try
            {
                try { if (File.Exists(info.Path)) File.Delete(info.Path); } catch { }
                SolutionManager.Instance.Solutions.Remove(info);
                SolutionManager.Instance.SaveList();
                RefreshBinding();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("删除方案失败: " + ex.Message);
            }
        }

        private void btn_SetStart_Click(object sender, EventArgs e)
        {
            var info = GetFocusedInfo();
            if (info == null)
            {
                XtraMessageBox.Show("请先选中要设为默认启动的方案。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (info.Enable)
            {
                XtraMessageBox.Show("该方案已经是默认启动。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (XtraMessageBox.Show($"设定 {info.Name} 为默认启动方案?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            foreach (var s in SolutionManager.Instance.Solutions) s.Enable = ReferenceEquals(s, info);
            SolutionManager.Instance.SaveList();
            RefreshBinding();
            FocusRowByName(info.Name);
        }
        #endregion

        #region 名称实时验证
        private void GridView1_ShownEditor(object sender, EventArgs e)
        {
            if (gridView1.FocusedColumn == null || gridView1.FocusedColumn.FieldName != nameof(SolutionInfo.Name)) return;
            _originalNameEditing = (gridView1.GetFocusedRow() as SolutionInfo)?.Name;
            if (gridView1.ActiveEditor != null)
            {
                gridView1.ActiveEditor.EditValueChanged += ActiveEditor_EditValueChanged;
                // 初次设置颜色
                UpdateNameEditorColor();
            }
        }

        private void GridView1_HiddenEditor(object sender, EventArgs e)
        {
            if (gridView1.ActiveEditor != null)
            {
                gridView1.ActiveEditor.EditValueChanged -= ActiveEditor_EditValueChanged;
            }
            _originalNameEditing = null; // 清空
        }

        private void ActiveEditor_EditValueChanged(object sender, EventArgs e) => UpdateNameEditorColor();

        private void UpdateNameEditorColor()
        {
            if (gridView1.ActiveEditor == null || gridView1.FocusedColumn?.FieldName != nameof(SolutionInfo.Name)) return;
            var txt = gridView1.ActiveEditor.EditValue?.ToString().Trim() ?? string.Empty;
            var valid = IsNameValid(txt, out _);
            gridView1.ActiveEditor.BackColor = valid ? Color.FromArgb(40, 120, 40) : Color.FromArgb(160, 40, 40);
            gridView1.ActiveEditor.ForeColor = Color.White;
        }

        private bool IsNameValid(string name, out string reason)
        {
            if (string.IsNullOrWhiteSpace(name)) { reason = "名称不能为空"; return false; }
            if (!_nameValid.IsMatch(name)) { reason = "只能包含中文、字母、数字、下划线"; return false; }
            var dup = SolutionManager.Instance.Solutions.Any(s => !s.Name.Equals(_originalNameEditing, StringComparison.OrdinalIgnoreCase) && s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (dup) { reason = "名称已存在"; return false; }
            reason = null; return true;
        }
        #endregion

        #region 编辑提交验证
        private void GridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (gridView1.FocusedColumn == null || gridView1.FocusedColumn.FieldName != nameof(SolutionInfo.Name)) return;
            var newName = (e.Value ?? string.Empty).ToString().Trim();
            var rowInfo = gridView1.GetFocusedRow() as SolutionInfo;
            if (rowInfo == null) return;

            // 验证
            if (!IsNameValid(newName, out var reason))
            {
                XtraMessageBox.Show(reason, "名称无效", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // 恢复原值并允许退出编辑
                e.Value = _originalNameEditing;
                rowInfo.Name = _originalNameEditing;
                return; // 不设置 e.Valid=false，允许关闭编辑器
            }

            // 未修改直接返回
            if (string.Equals(newName, _originalNameEditing, StringComparison.OrdinalIgnoreCase)) return;

            // 确认修改
            if (XtraMessageBox.Show($"确认将方案名修改为：{newName}?", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
            {
                // 恢复原值
                e.Value = _originalNameEditing;
                rowInfo.Name = _originalNameEditing;
                return;
            }

            // 重命名文件及更新路径
            try
            {
                var oldPath = rowInfo.Path;
                var dir = Path.GetDirectoryName(oldPath);
                var safeNewFileName = SanitizeFileName(newName) + ".uv";
                var newPath = Path.Combine(dir ?? string.Empty, safeNewFileName);

                // 若路径不同且文件存在则提示
                if (!string.Equals(oldPath, newPath, StringComparison.OrdinalIgnoreCase))
                {
                    if (File.Exists(newPath))
                    {
                        if (XtraMessageBox.Show($"文件 {safeNewFileName} 已存在，是否覆盖?", "覆盖确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        {
                            // 取消覆盖 -> 回退
                            e.Value = _originalNameEditing;
                            rowInfo.Name = _originalNameEditing;
                            return;
                        }
                        try { File.Delete(newPath); } catch { }
                    }
                    File.Move(oldPath, newPath);
                    rowInfo.Path = newPath;
                }

                // 更新 .uv 内部名称
                try
                {
                    var sol = VisionCore.Solution.Solution.Load(rowInfo.Path);
                    sol.Data.Name = newName;
                    sol.Save(rowInfo.Path);
                }
                catch { }

                rowInfo.Name = newName;
                rowInfo.LastModifyTime = DateTime.Now;
                SolutionManager.Instance.SaveList();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("重命名文件失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Value = _originalNameEditing;
                rowInfo.Name = _originalNameEditing;
            }
        }
        #endregion

        #region Helper
        private SolutionInfo GetFocusedInfo() => gridView1.FocusedRowHandle >= 0 ? gridView1.GetRow(gridView1.FocusedRowHandle) as SolutionInfo : null;
        private string MakeUniqueBase(string baseName)
        {
            int i = 0; string name;
            do { name = i == 0 ? baseName : baseName + i; i++; }
            while (SolutionManager.Instance.Solutions.Any(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
            return name;
        }
        private string SanitizeFileName(string name)
        {
            var invalid = Path.GetInvalidFileNameChars();
            foreach (var c in invalid) name = name.Replace(c, '_');
            return name;
        }
        private void FocusRowByName(string name)
        {
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                if (gridView1.GetRow(i) is SolutionInfo info && info.Name == name)
                {
                    gridView1.FocusedRowHandle = i; break;
                }
            }
        }
        private void OpenSelected()
        {
            var info = GetFocusedInfo();
            if (info == null) return;
            try
            {
                var sol = SolutionManager.Instance.OpenSolution(info);
                OpenSolutionRequested?.Invoke(sol);
                XtraMessageBox.Show($"打开方案成功：{info.Name}");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("打开方案失败: " + ex.Message);
            }
        }
        private void RefreshBinding()
        {
            gridControl1.DataSource = null;
            _binding = new BindingList<SolutionInfo>(SolutionManager.Instance.Solutions);
            gridControl1.DataSource = _binding;
            gridView1.PopulateColumns();
            if (gridView1.Columns[nameof(SolutionInfo.Name)] != null)
                gridView1.Columns[nameof(SolutionInfo.Name)].OptionsColumn.AllowEdit = true;
            if (gridView1.Columns[nameof(SolutionInfo.Enable)] != null)
                gridView1.Columns[nameof(SolutionInfo.Enable)].OptionsColumn.AllowEdit = false;
        }
        #endregion
    }
}