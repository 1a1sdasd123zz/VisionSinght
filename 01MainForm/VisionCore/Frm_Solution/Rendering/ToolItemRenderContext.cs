using System.Drawing;

namespace VisionCore.Frm_Solution.Rendering
{
    public class ToolItemRenderContext
    {
        public int IconSize { get; set; }
        public int IconDrawSize { get; set; }
        public int LeftPadding { get; set; }
        public int BetweenIndexAndName { get; set; }
        public int RightPadding { get; set; }

        public Font IndexFont { get; set; }
        public Font ResultFont { get; set; }
        public Font NameFont { get; set; }

        public Brush ElapsedBrush { get; set; }
        public Brush SuccessBrush { get; set; }
        public Brush FailBrush { get; set; }
        public Brush NameBrush { get; set; }
        public Brush RowBackBrush { get; set; }
        public Brush RowBackSelectedBrush { get; set; }
    }
}
