using System.Drawing;
using System.Windows.Forms;
using VisionCore.Solution;
using VisionCore.ToolBase; // 新增：用于 ITool 引用

namespace VisionCore.Frm_Solution
{
    /// <summary>
    /// 流程树中的工具节点
    /// </summary>
    public class ToolItem : TreeNode
    {
        public ToolRef Ref { get; }
        public Bitmap IconBitmap { get; set; }

        // 运行状态扩展
        public long LastElapsedMs { get; set; } = 0; // 上次运行耗时
        public bool? LastSuccess { get; set; } // null=未运行, true=成功, false=失败
        public bool IsRunning { get; set; } // 新增: 是否正在运行(用于动画)
        public int SpinnerFrame { get; set; } // 新增: 当前动画帧编号

        // 实例缓存（双击打开配置界面时使用）
        public ITool Instance { get; set; }

        public ToolItem(ToolRef r, Bitmap icon)
            : base(r?.Name)
        {
            Ref = r;
            IconBitmap = icon;
        }
    }
}
