using System;

namespace VisionCore.Linking
{
    /// <summary>
    /// 运行期描述一个可被链接的变量（由带 <see cref="LinkableVarAttribute"/> 的属性构建）。
    /// 被 <see cref="LinkRegistry"/> 缓存并供 UI / 绑定解析使用。
    /// </summary>
    public sealed class VariableDescriptor
    {
        /// <summary>内部唯一 Id。</summary>
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>所属流程标识（当前用流程名，后续可替换为真正 ID）。</summary>
        public string ProcessId { get; set; }
        /// <summary>所属工具标识（当前用工具名）。</summary>
        public string ToolId { get; set; }
        /// <summary>属性名。</summary>
        public string Name { get; set; }
        /// <summary>UI 展示名。</summary>
        public string DisplayName { get; set; }
        /// <summary>变量原始类型。</summary>
        public Type DataType { get; set; }
        /// <summary>兼容类型列表（来自特性 AsTypes）。</summary>
        public Type[] ExtraTypes { get; set; } = Array.Empty<Type>();
        /// <summary>分类。</summary>
        public string Category { get; set; }
        /// <summary>描述。</summary>
        public string Description { get; set; }
        /// <summary>获取当前值的委托（直接调用目标属性 get）。</summary>
        public Func<object> Getter { get; set; }

        /// <summary>规范化路径:  流程.工具.变量  用于持久化与查找。</summary>
        public string FullPath { get { return ProcessId + "." + ToolId + "." + Name; } }
    }
}
