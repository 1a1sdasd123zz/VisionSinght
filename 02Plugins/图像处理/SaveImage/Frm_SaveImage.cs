using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VisionCore.ToolBase;
using VisionCore.UserControls;

namespace SaveImage
{
    public partial class Frm_SaveImage : Frm_ToolBase
    {
        private readonly SaveImage _tool;
        private readonly string _originalSettings;

        public Frm_SaveImage(SaveImage tool)
        {
            _tool = tool;
            InitializeComponent();
            InitLinkUI();

            if (_tool is IPersistableTool p)
                _originalSettings = p.ExportSettings();

            // 初始化 UI
            chk_LocalPath.Checked = !_tool.UseLinkedDirectory;
            chk_LinkPath.Checked = _tool.UseLinkedDirectory;
            btn_Select.Text = _tool.LocalSaveDirectory ?? string.Empty;
            cmb_ImageFormat.Properties.Items.Clear();
            cmb_ImageFormat.Properties.Items.AddRange(new object[] { "png", "jpg", "bmp", "tiff" });
            if (!string.IsNullOrWhiteSpace(_tool.ImageFormat)) cmb_ImageFormat.EditValue = _tool.ImageFormat; else cmb_ImageFormat.SelectedIndex = 0;

            TogglePathMode();

            // 事件
            chk_LocalPath.CheckedChanged += (s, e) => { if (chk_LocalPath.Checked) { chk_LinkPath.Checked = false; TogglePathMode(); } };
            chk_LinkPath.CheckedChanged += (s, e) => { if (chk_LinkPath.Checked) { chk_LocalPath.Checked = false; TogglePathMode(); } };
            BtnRun.Click += (s, e) => DoRun();
            BtnConfirm.Click += (s, e) => { OnConfirm(); };
            BtnCancel.Click += (s, e) => { OnCancel(); };
            FormClosing += Frm_SaveImage_FormClosing;
        }

        private void TogglePathMode()
        {
            var useLinked = chk_LinkPath.Checked && !chk_LocalPath.Checked;
            _tool.UseLinkedDirectory = useLinked;
            uLink2.Visible = useLinked;
            btn_Select.Visible = !useLinked;
        }

        private void Frm_SaveImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK && _tool is IPersistableTool p && _originalSettings != null)
            {
                p.ImportSettings(_originalSettings);
            }
        }

        private void InitLinkUI()
        {
            // 图像输入链接
            uLink1.Setup(_tool, nameof(SaveImage.InputImage), typeof(System.Drawing.Image));
            // 目录链接（string）
            uLink2.Setup(_tool, nameof(SaveImage.InputDirectory), typeof(string));
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

        private void ApplyUIToTool()
        {
            _tool.UseLinkedDirectory = chk_LinkPath.Checked && !chk_LocalPath.Checked;
            if (!_tool.UseLinkedDirectory)
            {
                _tool.LocalSaveDirectory = btn_Select.Text?.Trim();
            }
            _tool.ImageFormat = (cmb_ImageFormat.EditValue as string) ?? "png";
        }

        private void DoRun()
        {
            ApplyUIToTool();
            var sw = System.Diagnostics.Stopwatch.StartNew();
            _tool.Run(out bool ok, out string msg);
            sw.Stop();
            LblState.Text = ok ? "OK" : msg;
            LblState.ForeColor = ok ? Color.LimeGreen : Color.Red;
            LblTime.Text = sw.ElapsedMilliseconds + " ms";
            // 可选: 显示最后保存文件
            if (ok && !string.IsNullOrWhiteSpace(_tool.LastSavedFile))
                this.Text = "图像保存 - " + _tool.LastSavedFile;
        }

        private void btn_SelectFolder_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            using (var dlg = new FolderBrowserDialog())
            {
                if (dlg.ShowDialog(this) != DialogResult.OK) return;
                btn_Select.Text = dlg.SelectedPath;
            }
        }
    }
}