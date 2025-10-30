using System;

namespace VisionCore.PluginBase
{
    /// <summary>
    /// 声明工具图标的加载方式：
    /// 1) ResourceName：嵌入资源名（推荐）。
    /// 2) FileRelativePath：相对插件程序集目录的文件路径（默认 Resources\\Icon.svg）。
    /// 可二选一，若两者都提供优先使用 ResourceName。
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class ToolIconAttribute : Attribute
    {
        public string ResourceName { get; }
        public string FileRelativePath { get; }

        //资源生成操作：嵌入的资源（Embedded Resource）
        public ToolIconAttribute(string resourceName = null, string fileRelativePath = "Resources\\Icon.svg")
        {
            ResourceName = resourceName;
            FileRelativePath = fileRelativePath;
        }
    }

    /// <summary>
    /// 标记该工具是一个容器工具（例如 条件分支、并行流程等），可以包含子工具。
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public sealed class ToolContainerAttribute : Attribute { }
}
