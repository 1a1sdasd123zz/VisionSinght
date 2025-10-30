using System;

namespace VisionCore.Linking
{
    /// <summary>
    /// 标记一个工具的属性为“可被其它工具链接”的变量。
    /// 放在具有公共 get 访问器的属性上。加载方案时由 <see cref="LinkRegistry"/> 反射收集。
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class LinkableVarAttribute : Attribute
    {
        /// <summary>用于 UI 展示的名称（若为空则回退到属性名）。</summary>
        public string DisplayName { get; }
        /// <summary>可选分类（UI 可用于分组/过滤）。</summary>
        public string Category { get; set; }
        /// <summary>描述或备注。</summary>
        public string Description { get; set; }
        /// <summary>声明该变量除本身类型外还可作为哪些兼容类型供目标筛选。</summary>
        public Type[] AsTypes { get; set; } = Array.Empty<Type>();
        /// <summary>是否为此工具的主输出（UI 可优先显示）。</summary>
        public bool IsPrimary { get; set; }

        public LinkableVarAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }
}
