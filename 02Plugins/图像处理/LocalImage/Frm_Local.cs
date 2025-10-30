using System;
using System.Linq;
using System.Windows.Forms;
using VisionCore.ToolBase;
using System.Drawing; 

namespace LocalImage
{
    public sealed partial class Frm_Local : Frm_ToolBase
    {
        private readonly LocalImage _tool;
        private BindingSource _bs; 
        private readonly string _originalSettings; 

        public Frm_Local(LocalImage localImage)
        {
            InitializeComponent();
            _tool = localImage;
            Text = localImage.Name + " 参数";

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = true;
            gridView1.OptionsView.ColumnAutoWidth = false;

            if (_tool is IPersistableTool p)
                _originalSettings = p.ExportSettings();

            chk_File.Checked = _tool.RunMode == RunMode.File;
            chk_Folder.Checked = _tool.RunMode == RunMode.Folder;
            panel_FileMode.Visible = chk_File.Checked;
            pannel_FolderMode.Visible = chk_Folder.Checked;
            chk_FolderMode.Checked = _tool.FolderMode == FolderMode.Loop;
            btn_SelectFile.Text = _tool.SingleFilePath ?? string.Empty;
            RefreshFileGrid();

            BtnRun.Click += (_, _) => DoRun();
            BtnConfirm.Click += (_, _) => { OnConfirm(); };
            BtnCancel.Click += (_, _) => { OnCancel(); };
            FormClosing += Frm_Local_FormClosing; 

            // 打开时显示图像，图像过大会导致打开速度变慢，取消该功能
            //RefreshPreview();
        }

        private void Frm_Local_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK && _tool is IPersistableTool p && _originalSettings != null)
            {
                p.ImportSettings(_originalSettings);
            }
        }

        private void OnConfirm()
        {
            ApplyUIToTool();
            _tool.MarkConfirmed();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnCancel()
        {
            _tool.ClearConfirmationFlag();
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void RefreshFileGrid()
        {
            _bs = new BindingSource { DataSource = _tool.FolderFiles.Select(f => new { 文件 = f }).ToList() };
            gridControl1.DataSource = _bs;
            gridView1.PopulateColumns();
            gridView1.BestFitColumns();
        }

        private void ApplyUIToTool()
        {
            _tool.RunMode = chk_File.Checked ? RunMode.File : RunMode.Folder;
            _tool.FolderMode = chk_FolderMode.Checked ? FolderMode.Loop : FolderMode.Sigle;
            if (_tool.RunMode == RunMode.File)
                _tool.SetSingleFile(btn_SelectFile.Text);
        }

        private void DoRun()
        {
            ApplyUIToTool();
            var swRun = System.Diagnostics.Stopwatch.StartNew();
            _tool.Run(out bool ok, out string msg);
            swRun.Stop();
            var runMs = swRun.ElapsedMilliseconds;
            if (ok)
            {
                RefreshPreview();
            }
            LblState.Text = ok ? "OK" : msg;
            LblTime.Text = $"{runMs} ms";
            LblState.ForeColor = ok ? Color.LimeGreen : Color.Red;
        }

        private void RefreshPreview()
        {
            try
            {
                if (showDisplay1 != null && _tool.OutputImage != null)
                {
                    // 只保留快速显示，不做Clone
                    showDisplay1.ShowImage((Bitmap)_tool.OutputImage, copy: false);
                }
            }
            catch { }
        }

        private void chk_File_CheckedChanged(object sender, EventArgs e)
        {
            if (!chk_File.Checked) return;
            panel_FileMode.Visible = true;
            pannel_FolderMode.Visible = false;
            chk_Folder.Checked = false;
        }

        private void chk_Folder_CheckedChanged(object sender, EventArgs e)
        {
            if (!chk_Folder.Checked) return;
            panel_FileMode.Visible = true;
            pannel_FolderMode.Visible = true;
            chk_File.Checked = false;
        }

        private void btn_SelectFolder_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using var dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog(this) != DialogResult.OK) return;
            _tool.SetFolder(dlg.SelectedPath);
            RefreshFileGrid();
            // 不自动 Run；等待用户点击 Run
        }

        private void btn_SelectFile_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using var dlg = new OpenFileDialog();
            dlg.Filter = "图像文件|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff|所有文件|*.*";
            dlg.Multiselect = false;
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                btn_SelectFile.Text = dlg.FileName;
                _tool.SetSingleFile(dlg.FileName);
                // 不自动 Run；等待用户点击 Run
            }
        }
    }
}
