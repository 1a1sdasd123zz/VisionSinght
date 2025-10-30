using System;
using System.Drawing;
using System.Windows.Forms;

namespace VisionCore.Frm_Solution.Rendering
{
    /// <summary>
    /// 默认渲染器：
    /// 负责一行 ToolItem 的完整绘制，包括：背景、高亮、索引、名称、耗时/结果文本以及“运行中”动画。
    /// 
    /// 可修改点：
    /// 1. 指示结果符号 (当前使用 √ / ×)。如需改成 OK / NG -> 修改 Render 内的 rStr 赋值。
    /// 2. 动画样式 (当前为 12 点环形淡入淡出)。如需换成 8 点或其它形状，修改 DrawSpinner 中的常量或进一步重写该方法。
    /// 3. 行布局（左右间距、图标大小）来自 ToolItemRenderContext，可在外部初始化时注入不同参数实现主题切换。
    /// </summary>
    public class DefaultToolItemRenderer : IToolItemRenderer
    {
        #region Spinner 可调常量
        // 修改下列常量即可快速调节“旋转环形”动画外观：
        private const int SpinnerDotCount = 8;      // 点数量 (示例: 8 / 10 / 12)。改成 8 时：改常量并确保计时器取模与此一致 (外部 Frm_ProcessBar 里 SpinnerFrame % 12 -> 也改成 % SpinnerDotCount)。
        private const int SpinnerOuterRadius = 10;   // 圆环半径 (整体大小)
        private const int SpinnerDotRadius = 5;      // 单个点半径 (实际绘制直径为 *2)
        private const int SpinnerActiveAlpha = 235;  // 最亮点透明度 (0~255)
        private const int SpinnerMinAlpha = 50;      // 最暗点透明度 (0~255)
        private const int SpinnerAreaWidth = 80;     // 在行尾占用的水平宽度 (调整以适配不同点数 / 半径)
        private static readonly Color SpinnerBaseColor = Color.FromArgb(88, 158, 255); // 基础色，可换成主题色
        private const int SpinnerBrightnessBoost = 40; // 亮度提升幅度 (根据衰减系数附加在 RGB 上)
        private const int SpinnerFalloffSpan = 8;    // 亮度衰减跨度(越小衰减越快)。点数量减小时可适当减小，如 8 点可尝试 6。
        #endregion

        public void Render(Graphics g, Rectangle fullRow, DrawTreeNodeEventArgs e, ToolItem node, ToolItemRenderContext ctx)
        {
            g.FillRectangle((e.State & TreeNodeStates.Selected) != 0 ? ctx.RowBackSelectedBrush : ctx.RowBackBrush, fullRow);
            if (node == null) { e.DrawDefault = true; return; }

            // 开启抗锯齿以提升动画圆点与文本边缘平滑度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int x = fullRow.Left + ctx.LeftPadding;
            int iconY = fullRow.Top + (fullRow.Height - ctx.IconDrawSize) / 2;
            if (node.IconBitmap != null)
                g.DrawImage(node.IconBitmap, new Rectangle(x, iconY, ctx.IconDrawSize, ctx.IconDrawSize));
            x += ctx.IconSize;

            // 序号 (1-based)
            int index = node.Index + 1;
            string idxStr = index + ".";
            var idxSize = TextRenderer.MeasureText(g, idxStr, ctx.IndexFont, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding);
            g.DrawString(idxStr, ctx.IndexFont, Brushes.LightGray, x, fullRow.Top + (fullRow.Height - idxSize.Height) / 2);
            x += idxSize.Width + ctx.BetweenIndexAndName;

            // 工具名称
            string name = node.Text;
            var nameSize = TextRenderer.MeasureText(g, name, ctx.NameFont, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding);
            g.DrawString(name, ctx.NameFont, ctx.NameBrush, x, fullRow.Top + (fullRow.Height - nameSize.Height) / 2);

            int rightBase = fullRow.Right - ctx.RightPadding;
            if (node.IsRunning)
            {
                DrawSpinner(g, fullRow, rightBase, node.SpinnerFrame); // 运行中：只绘制动画，不显示耗时/结果
            }
            else
            {
                // 耗时
                string timeStr = (node.LastElapsedMs > 0 ? node.LastElapsedMs.ToString() : "0") + "ms";
                var timeSize = TextRenderer.MeasureText(g, timeStr, ctx.ResultFont, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding);
                int rightX = rightBase - timeSize.Width;
                g.DrawString(timeStr, ctx.ResultFont, ctx.ElapsedBrush, rightX, fullRow.Top + (fullRow.Height - timeSize.Height) / 2);

                // 结果 √ 或 × 
                if (node.LastSuccess != null)
                {
                    string rStr = node.LastSuccess.Value ? "√" : "×";
                    var rSize = TextRenderer.MeasureText(g, rStr, ctx.ResultFont, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding);
                    rightX -= 6 + rSize.Width; // 间隔 6px
                    g.DrawString(rStr, ctx.ResultFont, node.LastSuccess.Value ? ctx.SuccessBrush : ctx.FailBrush, rightX, fullRow.Top + (fullRow.Height - rSize.Height) / 2);
                }
            }

            if ((e.State & TreeNodeStates.Focused) != 0)
                ControlPaint.DrawFocusRectangle(g, fullRow);
        }

        /// <summary>
        /// 绘制环形旋转点阵加载动画。
        /// 修改点说明：
        /// - 点数量: SpinnerDotCount (同时需保证外部计时器对 SpinnerFrame 取模一致)。
        /// - 半径: SpinnerOuterRadius 控制环大小, SpinnerDotRadius 控制单点大小。
        /// - 颜色/亮度: SpinnerBaseColor、SpinnerBrightnessBoost、Alpha 常量。
        /// - 衰减速度: SpinnerFalloffSpan (越小亮暗变化越快)。
        /// - 占位宽度: SpinnerAreaWidth (行尾预留区域)。
        /// 如果想做“条形”“直线”或“波浪”动画，可重写本方法逻辑生成不同的点坐标列表后绘制。
        /// </summary>
        private void DrawSpinner(Graphics g, Rectangle row, int rightBase, int frame)
        {
            int cx = rightBase - SpinnerAreaWidth / 2;       // 动画区域水平中心
            int cy = row.Top + row.Height / 2;               // 垂直中心
            int activeIndex = frame % SpinnerDotCount;       // 当前高亮点索引

            for (int i = 0; i < SpinnerDotCount; i++)
            {
                // 角度：以正上方(-90°)为起点顺时针分布
                double angle = -Math.PI / 2 + (Math.PI * 2 / SpinnerDotCount) * i;
                int px = (int)(cx + Math.Cos(angle) * SpinnerOuterRadius);
                int py = (int)(cy + Math.Sin(angle) * SpinnerOuterRadius);

                // 距离当前高亮点的“环形距离” -> 用于亮度衰减
                int delta = (i - activeIndex + SpinnerDotCount) % SpinnerDotCount;
                double falloff = Math.Max(0, 1.0 - delta / (double)SpinnerFalloffSpan);

                int alpha = (int)(SpinnerMinAlpha + (SpinnerActiveAlpha - SpinnerMinAlpha) * falloff);
                alpha = Math.Min(255, Math.Max(0, alpha));

                int r = Math.Min(255, (int)(SpinnerBaseColor.R + SpinnerBrightnessBoost * falloff));
                int gCol = Math.Min(255, (int)(SpinnerBaseColor.G + SpinnerBrightnessBoost * falloff));
                int b = Math.Min(255, (int)(SpinnerBaseColor.B + SpinnerBrightnessBoost * falloff));

                using var br = new SolidBrush(Color.FromArgb(alpha, r, gCol, b));
                g.FillEllipse(br, px - SpinnerDotRadius, py - SpinnerDotRadius, SpinnerDotRadius * 2, SpinnerDotRadius * 2);
            }
        }
    }
}
