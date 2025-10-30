using System;

namespace HardwareCommunication.Abstractions
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class CommProviderAttribute : Attribute
    {
        /// <summary>Provider 唯一名称（用于创建与持久化）</summary>
        public string Name { get; }
        /// <summary>对应的配置/测试视图类型（实现 ICommConfigView），可为 null</summary>
        public Type ConfigViewType { get; }
        /// <summary>UI 显示名称（可本地化），未提供则使用 Name</summary>
        public string DisplayName { get; }

        public CommProviderAttribute(string name)
        {
            Name = name;
            DisplayName = name;
        }

        public CommProviderAttribute(string name, Type configViewType)
        {
            Name = name;
            ConfigViewType = configViewType;
            DisplayName = name;
        }

        public CommProviderAttribute(string name, Type configViewType, string displayName)
        {
            Name = name;
            ConfigViewType = configViewType;
            DisplayName = string.IsNullOrEmpty(displayName) ? name : displayName;
        }
    }
}
