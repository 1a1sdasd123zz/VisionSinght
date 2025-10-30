using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using HardwareCommunication.Abstractions;

namespace HardwareCommunication.Runtime
{
    /// <summary>
    /// 通讯 Provider 工厂：
    /// - 启动时扫描已加载程序集上的 <see cref="CommProviderAttribute"/> 实现
    /// - AppDomain.AssemblyLoad 时增量注册
    /// - 通过 Provider 名称创建 <see cref="ICommChannel"/> 实例
    /// </summary>
    public static class CommFactory
    {
        private class ProviderInfo
        {
            public Type ChannelType;            // ICommChannel 实现
            public Type ConfigViewType;         // ICommConfigView 实现（可空）
            public string DisplayName;          // 用于 UI 展示
        }

        private static readonly ConcurrentDictionary<string, ProviderInfo> _providers = new ConcurrentDictionary<string, ProviderInfo>(StringComparer.OrdinalIgnoreCase);

        static CommFactory()
        {
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                RegisterFromAssembly(asm);
            }
            AppDomain.CurrentDomain.AssemblyLoad += (_, e) => RegisterFromAssembly(e.LoadedAssembly);
        }

        /// <summary>获取已注册 Provider 名称列表（用于持久化和创建）。</summary>
        public static List<string> GetProviderNames() => _providers.Keys.OrderBy(k => k).ToList();
        /// <summary>获取 Provider 的 UI 显示名称（未提供时返回 Provider 名）。</summary>
        public static string GetDisplayName(string provider)
            => _providers.TryGetValue(provider, out var p) ? (p.DisplayName ?? provider) : provider;
        /// <summary>尝试获取 Provider 对应的配置视图类型（可空）。</summary>
        public static Type GetConfigViewType(string provider)
            => _providers.TryGetValue(provider, out var p) ? p.ConfigViewType : null;

        /// <summary>
        /// 从程序集注册 Provider。
        /// </summary>
        public static void RegisterFromAssembly(Assembly asm)
        {
            try
            {
                foreach (var t in asm.GetTypes().Where(t => !t.IsAbstract && typeof(ICommChannel).IsAssignableFrom(t)))
                {
                    var attr = t.GetCustomAttribute<CommProviderAttribute>();
                    if (attr != null)
                    {
                        _providers[attr.Name] = new ProviderInfo
                        {
                            ChannelType = t,
                            ConfigViewType = attr.ConfigViewType,
                            DisplayName = attr.DisplayName
                        };
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// 创建通道实例。
        /// </summary>
        public static ICommChannel Create(string providerName, ICommParameters parameters)
        {
            if (providerName == null) return null;
            if (_providers.TryGetValue(providerName, out var p))
            {
                return (ICommChannel)Activator.CreateInstance(p.ChannelType, parameters);
            }
            return null;
        }

        /// <summary>
        /// 创建插件的配置视图实例（若插件提供）。
        /// </summary>
        public static ICommConfigView CreateConfigView(string providerName)
        {
            if (_providers.TryGetValue(providerName, out var p) && p.ConfigViewType != null)
            {
                return (ICommConfigView)Activator.CreateInstance(p.ConfigViewType);
            }
            return null;
        }
    }
}
