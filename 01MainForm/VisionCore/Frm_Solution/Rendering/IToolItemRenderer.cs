using System.Drawing;
using System.Windows.Forms;

namespace VisionCore.Frm_Solution.Rendering
{
    public interface IToolItemRenderer
    {
        void Render(Graphics g, Rectangle fullRow, DrawTreeNodeEventArgs e, ToolItem node, ToolItemRenderContext ctx);
    }
}
