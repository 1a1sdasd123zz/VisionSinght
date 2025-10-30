using System;
using System.Reflection;

namespace VisionCore.Linking
{
    /// <summary>
    /// 根据 <see cref="ToolLinkContext"/> 把源变量值写入工具目标属性。
    /// 当前实现为“执行前一次性推值”模式，可扩展为事件驱动更新。
    /// </summary>
    public sealed class LinkManager
    {
        public static LinkManager Instance { get; } = new LinkManager();
        private LinkManager() { }

        /// <summary>应用整个上下文的所有绑定。</summary>
        public void ApplyBindings(object tool, ToolLinkContext ctx)
        {
            if (tool == null || ctx == null) return;
            foreach (var b in ctx.Bindings) ApplyBinding(tool, b);
        }

        /// <summary>应用单条绑定：解析源变量并给目标属性赋值（做必要转换）。</summary>
        public void ApplyBinding(object tool, LinkBinding binding)
        {
            try
            {
                if (tool == null || binding == null || string.IsNullOrWhiteSpace(binding.TargetProperty) || string.IsNullOrWhiteSpace(binding.SourcePath)) return;
                var vd = LinkRegistry.Instance.Resolve(binding.SourcePath);
                if (vd == null) return;
                var prop = tool.GetType().GetProperty(binding.TargetProperty, BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
                if (prop == null || !prop.CanWrite) return;
                var value = LinkRegistry.Instance.GetValueConverted(vd, prop.PropertyType);
                prop.SetValue(tool, value, null);
            }
            catch { }
        }
    }
}
