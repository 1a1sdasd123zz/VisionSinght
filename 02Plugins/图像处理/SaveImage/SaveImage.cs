using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using VisionCore.PluginBase;
using VisionCore.ToolBase;
using VisionCore.Linking;

namespace SaveImage
{
    [Category("图像处理")]
    [DisplayName("图像保存")]
    [Tool("图像保存","图像处理", Description="保存输入图像到磁盘", IconResource="SaveImage.Resources.Icon.svg")]
    public class SaveImage : ToolBase, IPersistableTool
    {
        // Name / Enable inherited

        // 输入链接上下文
        public ToolLinkContext LinkContext { get; set; } = new ToolLinkContext();

        #region 输入
        // 输入图像（可链接）
        public Image InputImage { get; set; }
        // 输入目录（当使用“链接路径”模式时可通过变量链接提供保存目录）
        public string InputDirectory { get; set; }
        #endregion

        #region 配置(内部状态)
        // 是否使用链接目录；否则使用本地选定目录
        public bool UseLinkedDirectory { get; set; }
        // 本地保存目录
        public string LocalSaveDirectory { get; set; }
        // 图像格式(扩展名, 不含点)，默认 png
        public string ImageFormat { get; set; } = "png";
        #endregion

        #region 输出变量
        [LinkableVar("图像", Description = "输出图像", IsPrimary = true, AsTypes = new[] { typeof(Image) })]
        public Image OutputImage { get; private set; }

        [LinkableVar("宽度", Description = "图像宽度", AsTypes = new[] { typeof(int) })]
        public int Width { get { return OutputImage != null ? OutputImage.Width : 0; } }

        [LinkableVar("高度", Description = "图像高度", AsTypes = new[] { typeof(int) })]
        public int Height { get { return OutputImage != null ? OutputImage.Height : 0; } }

        [LinkableVar("结果", Description = "运行结果", AsTypes = new[] { typeof(bool) })]
        public bool LastResult { get; private set; }

        [LinkableVar("保存文件", Description = "最后保存的文件路径", AsTypes = new[] { typeof(string) })]
        public string LastSavedFile { get; private set; }
        #endregion

        #region 运行
        protected override bool OnRun(out string message)
        {
            // 应用输入变量
            LinkManager.Instance.ApplyBindings(this, LinkContext);
            LastSavedFile = null;
            if (InputImage == null) { message = "无输入图像"; LastResult = false; return false; }

            // 复制到输出(保持独立)
            if (OutputImage != null)
            {
                try { var old = OutputImage; OutputImage = null; old.Dispose(); } catch { }
            }
            OutputImage = (Image)InputImage.Clone();

            // 决定保存目录
            string dir = UseLinkedDirectory ? InputDirectory : LocalSaveDirectory;
            if (string.IsNullOrWhiteSpace(dir)) { message = "未指定保存目录"; LastResult = false; return false; }
            try { if (!Directory.Exists(dir)) Directory.CreateDirectory(dir); }
            catch (Exception ex) { message = "创建目录失败: " + ex.Message; LastResult = false; return false; }

            var fmt = string.IsNullOrWhiteSpace(ImageFormat) ? "png" : ImageFormat.Trim().ToLowerInvariant();
            if (fmt.StartsWith(".")) fmt = fmt.Substring(1);
            var fileName = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff") + "." + fmt;
            var fullPath = Path.Combine(dir, fileName);
            try
            {
                SaveBitmap(OutputImage, fullPath, fmt);
                LastSavedFile = fullPath;
                LastResult = true;
                message = "OK";
                return true;
            }
            catch (Exception ex)
            {
                LastResult = false; message = ex.Message; return false;
            }
        }

        private void SaveBitmap(Image img, string path, string fmt)
        {
            if (img == null) return;
            fmt = fmt.ToLowerInvariant();
            switch (fmt)
            {
                case "jpg":
                case "jpeg":
                    img.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg); break;
                case "bmp": img.Save(path, System.Drawing.Imaging.ImageFormat.Bmp); break;
                case "tif":
                case "tiff": img.Save(path, System.Drawing.Imaging.ImageFormat.Tiff); break;
                case "png": img.Save(path, System.Drawing.Imaging.ImageFormat.Png); break;
                default: img.Save(path, System.Drawing.Imaging.ImageFormat.Png); break;
            }
        }
        #endregion

        #region 设置持久化
        // 打开窗口后确认前的快照
        public string LastConfirmedSettings { get; private set; }

        [Serializable]
        private class SaveImageSettings
        {
            public ToolLinkContext LinkContext;
            public bool UseLinkedDirectory;
            public string LocalSaveDirectory;
            public string ImageFormat;
        }

        public string ExportSettings()
        {
            try
            {
                var cfg = new SaveImageSettings
                {
                    LinkContext = LinkContext,
                    UseLinkedDirectory = UseLinkedDirectory,
                    LocalSaveDirectory = LocalSaveDirectory,
                    ImageFormat = ImageFormat
                };
                using (var ms = new MemoryStream())
                {
#pragma warning disable SYSLIB0011
                    new BinaryFormatter().Serialize(ms, cfg);
#pragma warning restore SYSLIB0011
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
            catch { return string.Empty; }
        }

        public void ImportSettings(string data)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(data)) return;
                var bytes = Convert.FromBase64String(data);
                using (var ms = new MemoryStream(bytes))
                {
#pragma warning disable SYSLIB0011
                    var cfg = new BinaryFormatter().Deserialize(ms) as SaveImageSettings;
#pragma warning restore SYSLIB0011
                    if (cfg != null)
                    {
                        if (cfg.LinkContext != null) LinkContext = cfg.LinkContext;
                        UseLinkedDirectory = cfg.UseLinkedDirectory;
                        LocalSaveDirectory = cfg.LocalSaveDirectory;
                        ImageFormat = cfg.ImageFormat ?? "png";
                    }
                }
            }
            catch { }
        }

        public void MarkConfirmed() { LastConfirmedSettings = ExportSettings(); }
        public void ClearConfirmationFlag() { LastConfirmedSettings = null; }
        #endregion

        public override void OpenForm() { new Frm_SaveImage(this).ShowDialog(); }
    }
}
