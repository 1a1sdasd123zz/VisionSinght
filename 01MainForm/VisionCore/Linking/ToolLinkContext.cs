using System;
using System.Collections.Generic;
using System.Linq;

namespace VisionCore.Linking
{
    /// <summary>
    /// 保存单个工具的输入属性链接集合。
    /// 序列化后用于方案持久化。
    /// </summary>
    [Serializable]
    public class ToolLinkContext
    {
        /// <summary>当前工具所有链接条目。</summary>
        public List<LinkBinding> Bindings { get; set; } = new List<LinkBinding>();

        /// <summary>获取某目标属性当前绑定的源变量路径（若不存在返回 null）。</summary>
        public string GetBindingPath(string targetProp)
        {
            LinkBinding b = Bindings.FirstOrDefault(x => x.TargetProperty == targetProp);
            return b != null ? b.SourcePath : null;
        }

        /// <summary>设置或移除某目标属性的链接。</summary>
        public void SetBinding(string targetProp, string sourcePath)
        {
            LinkBinding b = Bindings.FirstOrDefault(x => x.TargetProperty == targetProp);
            if (string.IsNullOrWhiteSpace(sourcePath))
            {
                if (b != null) Bindings.Remove(b);
                return;
            }
            if (b == null)
            {
                b = new LinkBinding { TargetProperty = targetProp, SourcePath = sourcePath };
                Bindings.Add(b);
            }
            else b.SourcePath = sourcePath;
        }
    }
}
