using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.Utils.Svg;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.ViewInfo;
using VisionCore.Manager.PluginServer;
using VisionCore.PluginBase;

namespace VisionCore.Frm_Solution;

public partial class Frm_ToolBar : UserControl
{
    private bool _dragging;
    private Point _dragStart;
    private GalleryItem _dragItem;

    public Frm_ToolBar()
    {
        InitializeComponent();
        // 启用拖拽：使用控件级鼠标事件计算命中项
        this.galleryControl1.MouseDown += (s, e) =>
        {
            _dragging = false;
            _dragItem = HitItem(e.Location);
            _dragStart = e.Location;
        };
        this.galleryControl1.MouseMove += (s, e) =>
        {
            if (e.Button == MouseButtons.Left && !_dragging && _dragItem != null)
            {
                var dx = System.Math.Abs(e.X - _dragStart.X);
                var dy = System.Math.Abs(e.Y - _dragStart.Y);
                if (dx >= SystemInformation.DragSize.Width || dy >= SystemInformation.DragSize.Height)
                {
                    _dragging = true;
                    BeginDrag(_dragItem);
                }
            }
        };
        this.galleryControl1.MouseUp += (s, e) => { _dragging = false; _dragItem = null; };
        this.galleryControl1.Gallery.ItemDoubleClick += (s, e) => BeginDrag(e.Item);
    }

    private GalleryItem HitItem(Point pt)
    {
        var hi = this.galleryControl1.CalcHitInfo(pt);
        return hi?.GalleryItem;
    }

    private void BeginDrag(GalleryItem item)
    {
        if (item == null) return;
        // 优先从 Tag 读取类型，兼容旧数据从 Hint 读取
        var typeName = item.Tag as string ?? item.Hint;
        var data = new ToolDragData
        {
            DisplayName = item.Caption,
            AssemblyQualifiedType = typeName
        };
        var dd = new DataObject(typeof(ToolDragData).FullName, data);
        DoDragDrop(dd, DragDropEffects.Copy);
    }

    public void LoadPluginsToGallery()
    {
        var svgSize = new Size(32, 32);
        this.galleryControl1.Gallery.ImageSize = svgSize;
        this.galleryControl1.Gallery.ItemImageLayout = DevExpress.Utils.Drawing.ImageLayoutMode.ZoomInside;

        var all = PluginToolService.GetAll();
        var groups = this.galleryControl1.Gallery.Groups;
        var map = groups.ToDictionary(g => g.Caption);

        foreach (var byCat in all.GroupBy(p => p.Category))
        {
            if (!map.TryGetValue(byCat.Key, out var group))
            {
                group = new GalleryItemGroup { Caption = byCat.Key };
                groups.Add(group);
                map[byCat.Key] = group;
            }

            foreach (var desc in byCat)
            {
                var item = new GalleryItem
                {
                    Caption = desc.Name,
                    // 不再使用 Hint 暴露内部类型，改放入 Tag
                    Hint = null,
                    Tag = desc.ToolType.AssemblyQualifiedName
                };
                if (desc.Icon != null)
                {
                    item.ImageOptions.SvgImage = desc.Icon;
                    item.ImageOptions.SvgImageSize = svgSize;
                }
                group.Items.Add(item);
            }
        }
    }
}