using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VisionCore.ToolBase
{
    /// <summary>
    /// 工具元数据特性。<br/>
    /// 作用：为插件工具提供统一的名称 / 分类 / 描述 / 图标 / 版本等声明信息，
    /// 由 <see cref="ToolFactory"/> 在启动时扫描并缓存，降低新增工具的接入成本。
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ToolAttribute : Attribute
    {
        /// <summary>显示名称（用于工具面板 / 拖拽源）。</summary>
        public string Name { get; }
        /// <summary>分类（面板按分类分组）。</summary>
        public string Category { get; }
        /// <summary>描述（可用于提示或文档）。</summary>
        public string Description { get; set; }
        /// <summary>内嵌资源或相对路径的 SVG 图标资源名。</summary>
        public string IconResource { get; set; }
        /// <summary>工具版本（用于未来兼容策略）。</summary>
        public string Version { get; set; } = "1.0";
        /// <summary>默认启用状态。</summary>
        public bool DefaultEnable { get; set; } = true;
        public ToolAttribute(string name, string category)
        {
            Name = name;
            Category = category;
        }
    }

    /// <summary>
    /// 扫描得到的工具描述对象，供 UI / 工厂 / 代码逻辑使用的只读模型。
    /// </summary>
    public sealed class ToolDescriptor
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string IconResource { get; set; }
        public string Version { get; set; }
        public bool DefaultEnable { get; set; }
        public Type ToolType { get; set; }
    }

    /// <summary>
    /// 工具工厂：集中负责
    /// <list type="bullet">
    /// <item>扫描已加载程序集，发现带 <see cref="ToolAttribute"/> 的工具类型</item>
    /// <item>缓存元数据 <see cref="ToolDescriptor"/></item>
    /// <item>安全实例化工具（隔离反射异常）</item>
    /// <item>提供按引用信息复原实例的 TryCreate 方法</item>
    /// </list>
    /// </summary>
    public static class ToolFactory
    {
        private static readonly ConcurrentDictionary<string, ToolDescriptor> _descriptorsByName = new();
        private static bool _scanned;
        private static readonly object _scanLock = new();

        /// <summary>全部已发现的工具描述集合（只读快照）。</summary>
        public static IReadOnlyCollection<ToolDescriptor> Descriptors
        {
            get
            {
                EnsureScanned();
                return _descriptorsByName.Values.ToList();
            }
        }

        /// <summary>
        /// 直接通过类型创建实例（不做名称映射），失败返回 null。
        /// </summary>
        public static ITool CreateByType(Type toolType)
        {
            if (toolType == null) return null;
            try { return Activator.CreateInstance(toolType) as ITool; }
            catch { return null; }
        }

        /// <summary>
        /// 根据引用信息尝试创建实例：
        /// 1) 优先使用 AssemblyQualifiedType 精确定位
        /// 2) 退回通过 TypeKey 与元数据名称匹配
        /// </summary>
        public static bool TryCreate(ToolRefLike tref, out ITool tool)
        {
            tool = null;
            if (tref == null) return false;
            EnsureScanned();

            // 精确类型
            Type type = null;
            if (!string.IsNullOrWhiteSpace(tref.AssemblyQualifiedType))
                type = Type.GetType(tref.AssemblyQualifiedType, false);

            // 名称匹配（解决命名空间调整或版本差异）
            if (type == null && !string.IsNullOrWhiteSpace(tref.TypeKey))
            {
                type = _descriptorsByName.Values.FirstOrDefault(d => string.Equals(d.Name, tref.TypeKey, StringComparison.OrdinalIgnoreCase))?.ToolType;
            }
            if (type == null) return false;

            tool = CreateByType(type);
            if (tool == null) return false;

            // 回填名称（引用里未显式指定时）
            if (string.IsNullOrWhiteSpace(tref.Name) && _descriptorsByName.TryGetValue(type.FullName, out var d))
                tref.Name = d.Name;
            return true;
        }

        /// <summary>获取指定类型的描述（可能为 null）。</summary>
        public static ToolDescriptor GetDescriptor(Type t)
        {
            EnsureScanned();
            if (t == null) return null;
            _descriptorsByName.TryGetValue(t.FullName, out var d);
            return d;
        }

        private static void EnsureScanned()
        {
            if (_scanned) return;
            lock (_scanLock)
            {
                if (_scanned) return;
                ScanAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                _scanned = true;
            }
        }

        /// <summary>
        /// 扫描所有已加载程序集，收集实现 <see cref="ITool"/> 且带 <see cref="ToolAttribute"/> 的具体类型。
        /// </summary>
        private static void ScanAssemblies(IEnumerable<Assembly> assemblies)
        {
            foreach (var asm in assemblies)
            {
                Type[] types;
                try { types = asm.GetTypes(); }
                catch (ReflectionTypeLoadException ex) { types = ex.Types.Where(x => x != null).ToArray(); }
                catch { continue; }

                foreach (var t in types)
                {
                    if (t == null || t.IsAbstract || !typeof(ITool).IsAssignableFrom(t)) continue;
                    var attr = t.GetCustomAttribute<ToolAttribute>(false);
                    if (attr == null) continue;
                    var desc = new ToolDescriptor
                    {
                        Name = attr.Name,
                        Category = attr.Category,
                        Description = attr.Description,
                        IconResource = attr.IconResource,
                        Version = attr.Version,
                        DefaultEnable = attr.DefaultEnable,
                        ToolType = t
                    };
                    _descriptorsByName[t.FullName] = desc;
                }
            }
        }
    }

    /// <summary>
    /// 供 <see cref="ToolFactory"/> 使用的最小引用模型，避免直接依赖 Solution 层的 ToolRef 造成循环引用。
    /// </summary>
    public class ToolRefLike
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string TypeKey { get; set; }
        public string AssemblyQualifiedType { get; set; }
    }
}
