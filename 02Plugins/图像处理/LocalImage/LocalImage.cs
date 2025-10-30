using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using VisionCore.ToolBase;
using VisionCore.PluginBase;
using VisionCore.Linking; // 变量链接属性

namespace LocalImage;

[Category("图像处理")]
[DisplayName("本地图像")]
[Tool("本地图像","图像处理", Description="从本地加载图像(单张/文件夹循环)",IconResource = "LocalImage.Resources.Icon.svg")]
[Serializable]
public class LocalImage : ToolBase, IPersistableTool
{
    /// <summary>
    /// 最近一次在配置窗口点击“确定”时导出的配置快照（用于写回 ToolRef.SettingsJson）。
    /// </summary>
    public string LastConfirmedSettings { get; private set; }

    #region 内部配置字段
    private RunMode _runMode = RunMode.File;            // 当前运行模式：单文件 or 文件夹
    private FolderMode _folderMode = FolderMode.Loop;   // 文件夹模式下的取图方式
    private readonly List<string> Files = new List<string>(); // 文件夹模式：符合扩展名的全部文件路径
    private int _folderIndex;                           // 循环模式当前索引
    private string _singleFilePath;                     // 单文件模式路径
    #endregion

    #region 输出缓存字段
    private Image outputImage;                          // 当前输出图像对象
    private int Width;                                  // 缓存宽度，避免多次访问 Image.Width
    private int Height;                                 // 缓存高度
    private bool _lastResult;                           // 上一次运行结果
    #endregion

    #region 输出 (变量链接可用)
    /// <summary>当前输出图像。</summary>
    [LinkableVar("图像", Description = "输出图像", IsPrimary = true, AsTypes = new[] { typeof(Image) })]
    public Image OutputImage => outputImage;

    /// <summary>输出宽度。</summary>
    [LinkableVar("宽度", Description = "图像宽度", AsTypes = new[] { typeof(int) })]
    public int ImageWidth => Width;

    /// <summary>输出高度。</summary>
    [LinkableVar("高度", Description = "图像高度", AsTypes = new[] { typeof(int) })]
    public int ImageHeight => Height;

    /// <summary>加载是否成功。</summary>
    [LinkableVar("结果", Description = "加载结果", AsTypes = new[] { typeof(bool) })]
    public bool LastResult => _lastResult;
    #endregion

    #region 配置访问（供界面/序列化）
    /// <summary>运行模式：单文件 / 文件夹。</summary>
    public RunMode RunMode { get => _runMode; set => _runMode = value; }
    /// <summary>文件夹模式：循环 / 只取首张。</summary>
    public FolderMode FolderMode { get => _folderMode; set => _folderMode = value; }
    /// <summary>单文件路径。</summary>
    public string SingleFilePath { get => _singleFilePath; set => _singleFilePath = value; }
    /// <summary>当前文件夹文件集合只读视图。</summary>
    public IReadOnlyList<string> FolderFiles => Files;
    /// <summary>最近一次运行耗时(ms)。</summary>
    public double ElapsedMs => LastElapsedMs;
    #endregion

    #region 文件收集
    private static readonly string[] ImageExts = { ".bmp", ".jpg", ".jpeg", ".png", ".tif", ".tiff" };

    /// <summary>
    /// 指定文件夹并扫描符合扩展名的图像文件。
    /// </summary>
    public void SetFolder(string folder, bool includeSub = false)
    {
        Files.Clear();
        _folderIndex = 0;
        if (string.IsNullOrWhiteSpace(folder) || !Directory.Exists(folder)) return;
        var opt = includeSub ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
        Files.AddRange(Directory.EnumerateFiles(folder, "*.*", opt)
            .Where(f => ImageExts.Contains(Path.GetExtension(f).ToLowerInvariant())));
    }

    /// <summary>设置单文件路径。</summary>
    public void SetSingleFile(string file) => _singleFilePath = string.IsNullOrWhiteSpace(file) ? null : file;

    /// <summary>直接提供一组文件加入列表。</summary>
    public void SetFolderFileList(IEnumerable<string> files)
    {
        Files.Clear();
        if (files != null)
            Files.AddRange(files.Where(f => File.Exists(f) && ImageExts.Contains(Path.GetExtension(f).ToLowerInvariant())));
        _folderIndex = 0;
    }
    #endregion

    #region Run
    /// <summary>
    /// 核心运行逻辑：按模式取得图像并加载为输出。
    /// </summary>
    protected override bool OnRun(out string message)
    {
        message = string.Empty; Width = Height = 0; _lastResult = false;
        try
        {
            string targetPath;
            if (_runMode == RunMode.File)
            {
                if (string.IsNullOrWhiteSpace(_singleFilePath) || !File.Exists(_singleFilePath))
                {
                    message = "未选择有效图像文件";
                    return false;
                }
                targetPath = _singleFilePath;
            }
            else
            {
                if (Files.Count == 0) { message = "文件夹中无有效图像"; return false; }
                if (_folderMode == FolderMode.Sigle)
                    targetPath = Files[0];
                else
                {
                    if (_folderIndex >= Files.Count) _folderIndex = 0;
                    targetPath = Files[_folderIndex];
                    _folderIndex = (_folderIndex + 1) % Files.Count;
                }
            }
            // 释放上一张
            if (outputImage != null)
            {
                try { var old = outputImage; outputImage = null; old.Dispose(); } catch { }
            }
            outputImage = Image.FromFile(targetPath);
            Width = outputImage.Width; Height = outputImage.Height;
            message = "OK"; _lastResult = true;
            return true;
        }
        catch (Exception ex)
        {
            message = ex.Message; _lastResult = false; return false;
        }
    }
    #endregion

    #region 设置持久化 (XmlSerializer)
    /// <summary>
    /// 可序列化配置 DTO。
    /// </summary>
    public class LocalImageSettings
    {
        public bool Enable { get; set; }
        public RunMode RunMode { get; set; }
        public FolderMode FolderMode { get; set; }
        public string SingleFilePath { get; set; }
        public List<string> Files { get; set; }
    }

    private static readonly XmlSerializer _settingsSerializer = new XmlSerializer(typeof(LocalImageSettings));

    /// <summary>导出配置（XML 字符串）。</summary>
    public string ExportSettings()
    {
        var cfg = new LocalImageSettings
        {
            Enable = Enable,
            RunMode = _runMode,
            FolderMode = _folderMode,
            SingleFilePath = _singleFilePath,
            Files = new List<string>(Files),
        };
        using (var ms = new MemoryStream())
        {
            _settingsSerializer.Serialize(ms, cfg);
            return Encoding.UTF8.GetString(ms.ToArray());
        }
    }

    /// <summary>导入配置。</summary>
    public void ImportSettings(string xml)
    {
        if (string.IsNullOrWhiteSpace(xml)) return;
        try
        {
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                var obj = _settingsSerializer.Deserialize(ms);
                var cfg = obj as LocalImageSettings;
                if (cfg != null)
                {
                    Enable = cfg.Enable;
                    _runMode = cfg.RunMode;
                    _folderMode = cfg.FolderMode;
                    _singleFilePath = cfg.SingleFilePath;
                    Files.Clear(); if (cfg.Files != null) Files.AddRange(cfg.Files.Where(File.Exists));
                    _folderIndex = 0;
                }
            }
        }
        catch { }
    }

    /// <summary>标记“已确认”以写回最新配置。</summary>
    public void MarkConfirmed() => LastConfirmedSettings = ExportSettings();
    /// <summary>清除确认标记。</summary>
    public void ClearConfirmationFlag() => LastConfirmedSettings = null;
    #endregion

    /// <summary>
    /// 打开配置窗口。
    /// </summary>
    public override void OpenForm() { new Frm_Local(this).ShowDialog(); }
}

/// <summary>运行模式。</summary>
public enum RunMode { File, Folder }
/// <summary>文件夹取图模式。</summary>
public enum FolderMode { Loop, Sigle }

