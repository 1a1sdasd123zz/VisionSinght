using DevExpress.XtraEditors;
using DevExpress.XtraBars; // status bar items
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Collections.Generic; // 新增

namespace VisionCore.UserControls;

public partial class ShowDisplay : XtraUserControl
{
    private Bitmap _currentImage;              // 当前图像
    private float _zoom = 1f;                  // 缩放比例
    private PointF _pan = new PointF(0, 0);    // 平移偏移
    private bool _panning;                     // 是否正在拖动
    private Point _lastMouse;                  // 上次鼠标位置
    private bool _showFixedCenterCrosshair = false; // 固定在图像中心的十字线
    private Point _cursorPoint;                // 鼠标坐标(控件)

    private const float ZoomStep = 1.25f;
    private const float MinZoom = 0.05f;
    private const float MaxZoom = 20f;

    // 状态栏项
    private BarStaticItem _coordItem;
    private BarStaticItem _zoomItem;

    // 右键菜单
    private ContextMenuStrip _ctx;
    private ToolStripMenuItem _fullscreenMenuItem;   // 全屏菜单项

    private byte[] _pixelBuf; // 像素缓存
    private int _stride;
    private PixelFormat _fmt;

    private Point? _lastRgbCoord = null;
    private Color _lastRgbColor = Color.Empty;

    // 全屏相关
    private bool _isFullscreen = false;
    private Form _fullscreenForm;
    private Control _originalParent;
    private DockStyle _prevDock;
    private Size _prevSize;
    private Point _prevLocation;

    // 多级缩略图（图像金字塔，用于缩小时提升流畅度）
    // 级别 0 为 _currentImage，后续级别尺寸递减（例如 1/2, 1/4 ...）
    private readonly List<Bitmap> _mipmaps = new();

    public Bitmap Image => _currentImage;
    public bool ShowFixedCenterCrosshair { get => _showFixedCenterCrosshair; set { _showFixedCenterCrosshair = value; pictureEdit1.Invalidate(); } }
    public float Zoom => _zoom;

    public ShowDisplay()
    {
        InitializeComponent();
        InitBars();
        InitContextMenu();

        pictureEdit1.Properties.ShowMenu = false;
        pictureEdit1.Properties.AllowFocused = false;
        pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
        pictureEdit1.Paint += PictureEdit1_Paint;
        pictureEdit1.MouseWheel += PictureEdit1_MouseWheel;
        pictureEdit1.MouseDown += PictureEdit1_MouseDown;
        pictureEdit1.MouseMove += PictureEdit1_MouseMove;
        pictureEdit1.MouseUp += PictureEdit1_MouseUp;
        pictureEdit1.MouseLeave += (_, _) => { _cursorPoint = Point.Empty; pictureEdit1.Invalidate(); UpdateCoordStatus(null); };
        pictureEdit1.DoubleClick += PictureEdit1_DoubleClick; // 仅用于全屏退出

        SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        UpdateStyles();
    }

    private void InitBars()
    {
        try
        {
            _coordItem = new BarStaticItem { Caption = "X:- Y:-" };
            _zoomItem = new BarStaticItem { Caption = "Zoom:1.00" };
            barManager1.Items.Add(_coordItem);
            barManager1.Items.Add(_zoomItem);
            bar3.AddItem(_coordItem);
            bar3.AddItem(_zoomItem);
        }
        catch { }
    }

    // 右键菜单：增加全屏切换
    private void InitContextMenu()
    {
        _ctx = new ContextMenuStrip();
        _ctx.Items.Add("适应窗口(Fit)", null, (_, _) => FitToWindow());
        _fullscreenMenuItem = new ToolStripMenuItem("全屏显示(可双击退出)");
        _fullscreenMenuItem.Click += (_, _) => ToggleFullscreen();
        _ctx.Items.Add(_fullscreenMenuItem);
        var fixedCross = new ToolStripMenuItem("固定中心十字线") { Checked = _showFixedCenterCrosshair, CheckOnClick = true };
        fixedCross.CheckedChanged += (_, _) => { ShowFixedCenterCrosshair = fixedCross.Checked; };
        _ctx.Items.Add(fixedCross);
        _ctx.Items.Add(new ToolStripSeparator());
        _ctx.Items.Add("复制像素值", null, (_, _) => CopyPixelValue());
        _ctx.Items.Add("保存图像...", null, (_, _) => SaveImageAs());
    }

    #region 公共接口
    /// <summary>
    /// 显示图像，支持可选复制以防外部修改；自动适应窗口并刷新视图
    /// </summary>
    public void ShowImage(Bitmap bmp, bool copy = false)
    {
        if (IsDisposed) return;
        if (bmp == null)
        {
            SafeUI(() => ReplaceImage(null));
            return;
        }
        Bitmap toShow = copy ? (Bitmap)bmp.Clone() : bmp;
        SafeUI(() => { ReplaceImage(toShow); if (!_isFullscreen) FitToWindow(); }); // 全屏时保持当前视图
    }

    /// <summary>
    /// 清空显示
    /// </summary>
    public void Clear() => ShowImage(null);

    /// <summary>
    /// 复位到 1:1 并居中
    /// </summary>
    public void ResetView() => FitToWindow(); // 统一复位逻辑

    /// <summary>
    /// 按最小缩放比放大/缩小以完整显示整幅图
    /// </summary>
    public void FitToWindow()
    {
        if (_currentImage == null || pictureEdit1.ClientSize.Width <= 0 || pictureEdit1.ClientSize.Height <= 0) return;
        float zx = (float)pictureEdit1.ClientSize.Width / _currentImage.Width;
        float zy = (float)pictureEdit1.ClientSize.Height / _currentImage.Height;
        _zoom = Math.Min(zx, zy);
        if (_zoom <= 0) _zoom = 1f;
        CenterImage();
        pictureEdit1.Invalidate();
        UpdateZoomStatus();
    }
    #endregion

    #region 绘制与事件
    /// <summary>
    /// 自定义绘制：图像、十字线、信息叠加
    /// </summary>
    private void PictureEdit1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.None;
        e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
        e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
        e.Graphics.Clear(Color.Black);

        if (_currentImage != null)
        {
            // 根据当前缩放选择合适的 mip 级别（仅在缩小时使用低分辨率图以减轻实时大比例缩放压力）
            Bitmap drawBmp = SelectMipmapForCurrentZoom();
            int origW = _currentImage.Width;
            int origH = _currentImage.Height;
            float destW = origW * _zoom;
            float destH = origH * _zoom;
            // 直接使用目标矩形，保持坐标/缩放逻辑不变
            e.Graphics.DrawImage(drawBmp, new RectangleF(_pan.X, _pan.Y, destW, destH));
        }

        // 固定中心十字线（控件中心，不随图像缩放/平移变化）
        if (_showFixedCenterCrosshair)
        {
            PointF center = new PointF(pictureEdit1.ClientSize.Width / 2f, pictureEdit1.ClientSize.Height / 2f);
            using var penFixed = new Pen(Color.OrangeRed, 1f);
            e.Graphics.DrawLine(penFixed, 0, center.Y + 0.5f, pictureEdit1.Width, center.Y + 0.5f);
            e.Graphics.DrawLine(penFixed, center.X + 0.5f, 0, center.X + 0.5f, pictureEdit1.Height);
        }

        if (_currentImage != null)
        {
            var info = $"{_currentImage.Width}x{_currentImage.Height}  Zoom:{_zoom:F2}";
            using var b = new SolidBrush(Color.FromArgb(160, 0, 0, 0));
            var rect = new Rectangle(4, 4, TextRenderer.MeasureText(info, Font).Width + 8, Font.Height + 4);
            e.Graphics.FillRectangle(b, rect);
            TextRenderer.DrawText(e.Graphics, info, Font, new Point(rect.Left + 4, rect.Top + 2), Color.White);
        }
    }

    /// <summary>
    /// 滚轮缩放并围绕鼠标位置保持光标所指图像点不变
    /// </summary>
    private void PictureEdit1_MouseWheel(object sender, MouseEventArgs e)
    {
        if (_currentImage == null) return;
        float oldZoom = _zoom;
        _zoom = e.Delta > 0 ? _zoom * ZoomStep : _zoom / ZoomStep;
        if (_zoom < MinZoom) _zoom = MinZoom; else if (_zoom > MaxZoom) _zoom = MaxZoom;
        float scale = _zoom / oldZoom;
        // 围绕鼠标位置缩放：调整平移，让鼠标处图像点保持不动
        _pan = new PointF(e.X - (e.X - _pan.X) * scale, e.Y - (e.Y - _pan.Y) * scale);
        pictureEdit1.Invalidate();
        UpdateZoomStatus();
        UpdateCoordStatus(ConvertToImagePoint(e.Location));
    }

    /// <summary>
    /// 左键开始平移 / 右键弹出菜单
    /// </summary>
    private void PictureEdit1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            _panning = true;
            _lastMouse = e.Location;
            Cursor = Cursors.Hand;
        }
        else if (e.Button == MouseButtons.Right)
        {
            _ctx?.Show(pictureEdit1, e.Location);
        }
    }

    /// <summary>
    /// 移动更新：平移或仅刷新十字线及坐标显示
    /// </summary>
    private void PictureEdit1_MouseMove(object sender, MouseEventArgs e)
    {
        var old = _cursorPoint;
        _cursorPoint = e.Location;
        if (_panning)
        {
            var dx = e.X - _lastMouse.X;
            var dy = e.Y - _lastMouse.Y;
            _pan = new PointF(_pan.X + dx, _pan.Y + dy);
            _lastMouse = e.Location;
            pictureEdit1.Invalidate(); // 只有平移时重绘大图
        }
        // 非平移时不再整图 Invalidate，提高大图低倍率下的响应；仅更新状态栏
        UpdateCoordStatus(ConvertToImagePoint(e.Location));
    }

    /// <summary>
    /// 结束平移
    /// </summary>
    private void PictureEdit1_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            _panning = false;
            Cursor = Cursors.Default;
        }
    }

    /// <summary>
    /// 双击全屏显示/取消全屏
    /// </summary>
    private void PictureEdit1_DoubleClick(object sender, EventArgs e)
    {
        if (_isFullscreen)
        {
            ToggleFullscreen(); // 退出全屏
        }
        // 非全屏时忽略双击，防止误触
    }
    #endregion

    #region 全屏相关
    /// <summary>
    /// 切换全屏状态
    /// </summary>
    private void ToggleFullscreen()
    {
        if (_isFullscreen)
        {
            ExitFullscreen();
        }
        else
        {
            EnterFullscreen();
        }
    }

    /// <summary>
    /// 进入全屏显示
    /// </summary>
    private void EnterFullscreen()
    {
        if (_isFullscreen) return;
        _originalParent = Parent;
        if (_originalParent == null) return;
        _prevDock = Dock;
        _prevSize = Size;
        _prevLocation = Location;

        _fullscreenForm = new Form
        {
            FormBorderStyle = FormBorderStyle.None,
            WindowState = FormWindowState.Maximized,
            StartPosition = FormStartPosition.Manual,
            BackColor = Color.Black,
            TopMost = true,
            ShowInTaskbar = true
        };
        _fullscreenForm.KeyPreview = true;
        _fullscreenForm.KeyDown += (_, k) => { if (k.KeyCode == Keys.Escape) ToggleFullscreen(); };
        _fullscreenForm.FormClosing += (_, _) => { if (_isFullscreen) ExitFullscreen(); };

        Parent.Controls.Remove(this);
        Dock = DockStyle.Fill;
        _fullscreenForm.Controls.Add(this);
        _fullscreenForm.Show();

        _isFullscreen = true;
        if (_fullscreenMenuItem != null) _fullscreenMenuItem.Text = "取消全屏";

        // 进入全屏后自适应一次（放在异步确保尺寸已布局）
        BeginInvoke((Action)(() => FitToWindow()));
    }

    /// <summary>
    /// 退出全屏显示
    /// </summary>
    private void ExitFullscreen()
    {
        if (!_isFullscreen) return;
        try
        {
            if (_fullscreenForm != null)
            {
                _fullscreenForm.Controls.Remove(this);
            }
            if (_originalParent != null)
            {
                Dock = _prevDock;
                if (_prevDock == DockStyle.None)
                {
                    Size = _prevSize;
                    Location = _prevLocation;
                }
                _originalParent.Controls.Add(this);
            }
        }
        finally
        {
            _fullscreenForm?.Dispose();
            _fullscreenForm = null;
            _isFullscreen = false;
            if (_fullscreenMenuItem != null) _fullscreenMenuItem.Text = "全屏显示(可双击退出)";
            // 退出全屏后也自适应一次
            BeginInvoke((Action)(() => FitToWindow()));
        }
    }
    #endregion

    #region 辅助
    /// <summary>
    /// 根据当前缩放将图像居中
    /// </summary>
    private void CenterImage()
    {
        if (_currentImage == null) return;
        var w = _currentImage.Width * _zoom;
        var h = _currentImage.Height * _zoom;
        _pan = new PointF((pictureEdit1.ClientSize.Width - w) / 2f, (pictureEdit1.ClientSize.Height - h) / 2f);
    }

    /// <summary>
    /// UI 线程安全执行
    /// </summary>
    private void SafeUI(Action act)
    {
        if (IsDisposed) return;
        if (InvokeRequired)
        {
            try { BeginInvoke(act); } catch { }
        }
        else act();
    }

    /// <summary>
    /// 替换内部图像并释放旧引用，重置居中与状态显示
    /// </summary>
    private void ReplaceImage(Bitmap newBmp)
    {
        var old = Interlocked.Exchange(ref _currentImage, newBmp);
        DisposeMipmaps();
        BuildPixelCache(newBmp);
        BuildMipmaps(newBmp); // 构建缩略层
        CenterImage();
        pictureEdit1.Invalidate();
        if (old != null && !ReferenceEquals(old, newBmp))
        {
            try { old.Dispose(); } catch { }
        }
        UpdateZoomStatus();
        UpdateCoordStatus(null);
    }

    private void BuildPixelCache(Bitmap bmp)
    {
        _pixelBuf = null;
        if (bmp == null) return;
        var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
        var data = bmp.LockBits(rect, ImageLockMode.ReadOnly, bmp.PixelFormat);
        try
        {
            _stride = data.Stride;
            _fmt = bmp.PixelFormat;
            int total = Math.Abs(_stride) * bmp.Height;
            _pixelBuf = new byte[total];
            Marshal.Copy(data.Scan0, _pixelBuf, 0, total);
        }
        finally
        {
            bmp.UnlockBits(data);
        }
    }

    /// <summary>
    /// 构建多级缩略图（仅用于缩小时提升绘制性能）
    /// </summary>
    private void BuildMipmaps(Bitmap bmp)
    {
        if (bmp == null) return;
        try
        {
            const int MinSide = 256; // 停止递减的最小边
            const int MaxLevels = 8; // 上限
            int level = 0;
            int w = bmp.Width;
            int h = bmp.Height;
            Bitmap prev = bmp;
            while (level < MaxLevels)
            {
                w /= 2; h /= 2;
                if (w < MinSide && h < MinSide) break;
                if (w < 1 || h < 1) break;
                var down = new Bitmap(w, h, PixelFormat.Format24bppRgb);
                using (var g = Graphics.FromImage(down))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    g.DrawImage(prev, new Rectangle(0, 0, w, h));
                }
                _mipmaps.Add(down);
                prev = down;
                level++;
            }
        }
        catch { /* 忽略构建失败 */ }
    }

    private void DisposeMipmaps()
    {
        if (_mipmaps.Count == 0) return;
        foreach (var m in _mipmaps)
        {
            try { m.Dispose(); } catch { }
        }
        _mipmaps.Clear();
    }

    /// <summary>
    /// 根据当前缩放选择一个合适的 mip 级别（仅在 _zoom < 1 时使用）
    /// </summary>
    private Bitmap SelectMipmapForCurrentZoom()
    {
        if (_currentImage == null) return null;
        if (_zoom >= 1f || _mipmaps.Count == 0) return _currentImage;
        float targetWidth = _currentImage.Width * _zoom; // 目标显示宽
        Bitmap candidate = _currentImage; // 默认原图
        // 从大到小找第一个宽度<=目标宽度的缩略层（使得放大程度不大）
        for (int i = 0; i < _mipmaps.Count; i++)
        {
            var m = _mipmaps[i];
            if (m.Width <= targetWidth)
            {
                candidate = m; // 使用此层
                break;
            }
        }
        return candidate;
    }

    private Color GetPixelFast(int x, int y)
    {
        if (_pixelBuf == null) return Color.Empty;
        int bpp;
        switch (_fmt)
        {
            case PixelFormat.Format24bppRgb: bpp = 3; break;
            case PixelFormat.Format32bppArgb:
            case PixelFormat.Format32bppRgb:
            case PixelFormat.Format32bppPArgb: bpp = 4; break;
            default: return _currentImage.GetPixel(x, y);
        }
        int index = y * _stride + x * bpp;
        if (index < 0 || index + bpp > _pixelBuf.Length) return Color.Empty;
        byte b = _pixelBuf[index + 0];
        byte g = _pixelBuf[index + 1];
        byte r = _pixelBuf[index + 2];
        if (bpp == 4)
        {
            byte a = _pixelBuf[index + 3];
            return Color.FromArgb(a, r, g, b);
        }
        return Color.FromArgb(r, g, b);
    }

    private Point? ConvertToImagePoint(Point controlPt)
    {
        if (_currentImage == null) return null;
        var xImg = (controlPt.X - _pan.X) / _zoom;
        var yImg = (controlPt.Y - _pan.Y) / _zoom;
        int xi = (int)Math.Floor(xImg);
        int yi = (int)Math.Floor(yImg);
        if (xi < 0 || yi < 0 || xi >= _currentImage.Width || yi >= _currentImage.Height) return null;
        return new Point(xi, yi);
    }

    private void UpdateCoordStatus(Point? imgPt)
    {
        if (_coordItem == null) return;
        if (imgPt == null)
        {
            _coordItem.Caption = "X:- Y:-";
            _lastRgbCoord = null;
            return;
        }
        var p = imgPt.Value;
        // 直接同步读取像素（使用缓存），保证鼠标移动实时刷新
        Color c = GetPixelFast(p.X, p.Y);
        _lastRgbCoord = p;
        _lastRgbColor = c;
        _coordItem.Caption = $"X:{p.X} Y:{p.Y} RGB({c.R},{c.G},{c.B})";
    }

    /// <summary>
    /// 更新状态栏缩放显示
    /// </summary>
    private void UpdateZoomStatus()
    {
        if (_zoomItem == null) return;
        _zoomItem.Caption = $"Zoom:{_zoom:F2}";
    }

    /// <summary>
    /// 复制当前鼠标所在像素的坐标与 RGB 到剪贴板
    /// </summary>
    private void CopyPixelValue()
    {
        var pt = ConvertToImagePoint(_cursorPoint);
        if (pt == null || _currentImage == null) return;
        try
        {
            var p = pt.Value;
            var c = GetPixelFast(p.X, p.Y);
            var text = $"X:{p.X} Y:{p.Y} RGB({c.R},{c.G},{c.B})";
            Clipboard.SetText(text);
        }
        catch { }
    }

    /// <summary>
    /// 保存当前图像到文件（支持 PNG / JPEG / BMP）
    /// </summary>
    private void SaveImageAs()
    {
        if (_currentImage == null) return;
        using var dlg = new SaveFileDialog();
        dlg.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap|*.bmp|All Files|*.*";
        dlg.FileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".png";
        if (dlg.ShowDialog(this) == DialogResult.OK)
        {
            try
            {
                var ext = Path.GetExtension(dlg.FileName).ToLowerInvariant();
                ImageFormat fmt = ImageFormat.Png;
                if (ext == ".jpg" || ext == ".jpeg") fmt = ImageFormat.Jpeg;
                else if (ext == ".bmp") fmt = ImageFormat.Bmp;
                _currentImage.Save(dlg.FileName, fmt);
            }
            catch { }
        }
    }
    #endregion
}