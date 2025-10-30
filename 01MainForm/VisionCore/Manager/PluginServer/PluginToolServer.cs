using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DevExpress.Utils.Svg;
using VisionCore.PluginBase;
using VisionCore.ToolBase;

namespace VisionCore.Manager.PluginServer
{
    public sealed class PluginToolDescriptor
    {
        public string Name { get; private set; }
        public string Category { get; private set; }
        public Type ToolType { get; private set; }
        public string AssemblyName { get; private set; }
        public SvgImage Icon { get; private set; }

        public PluginToolDescriptor(string name, string category, Type toolType, string assemblyName, SvgImage icon)
        {
            Name = name ?? string.Empty;
            Category = category ?? string.Empty;
            ToolType = toolType ?? typeof(object);
            AssemblyName = assemblyName ?? string.Empty;
            Icon = icon;
        }
    }

    public static class PluginToolService
    {
        private static readonly string PlugInsDir = Path.Combine(Environment.CurrentDirectory, "Plugins\\Tool");

        private static readonly ConcurrentDictionary<string, PluginToolDescriptor> Cache = new ConcurrentDictionary<string, PluginToolDescriptor>(StringComparer.OrdinalIgnoreCase);
        private static volatile bool _initialized;
        private static readonly object InitLock = new object();
        private static bool _assemblyResolveHooked;

        public static void Init()
        {
            if (_initialized) return;
            lock (InitLock)
            {
                if (_initialized) return;
                HookAssemblyResolve();
                ScanPlugins();
                _initialized = true;
            }
        }

        public static IReadOnlyCollection<PluginToolDescriptor> GetAll() => Cache.Values.ToArray();

        private static void ScanPlugins()
        {
            Cache.Clear();
            if (!Directory.Exists(PlugInsDir)) return;

            var dllFiles = Directory.GetFiles(PlugInsDir, "*.dll", SearchOption.TopDirectoryOnly);
            if (dllFiles.Length == 0) return;

            Parallel.ForEach(dllFiles, dllPath =>
            {
                try
                {
                    var asm = Assembly.LoadFrom(dllPath);

                    foreach (var type in SafeGetTypes(asm))
                    {
                        if (!type.IsClass || type.IsAbstract) continue;
                        if (!typeof(ITool).IsAssignableFrom(type)) continue;

                        var cat = GetCategory(type);
                        var disp = GetDisplayName(type) ?? type.Name;
                        if (string.IsNullOrEmpty(cat)) cat = "未分类";

                        var icon = ResolveIconForTool(type, asm);

                        var desc = new PluginToolDescriptor(
                            disp,
                            cat,
                            type,
                            asm.GetName().Name ?? Path.GetFileNameWithoutExtension(dllPath),
                            icon
                        );
                        Cache.AddOrUpdate(desc.Name, desc, (_, _) => desc);
                    }
                }
                catch
                {
                }
            });
        }

        private static void HookAssemblyResolve()
        {
            if (_assemblyResolveHooked) return;
            AppDomain.CurrentDomain.AssemblyResolve += OnAssemblyResolve;
            _assemblyResolveHooked = true;
        }

        private static Assembly OnAssemblyResolve(object sender, ResolveEventArgs args)
        {
            try
            {
                var name = new AssemblyName(args.Name).Name + ".dll";
                var path = Path.Combine(PlugInsDir, name);
                if (File.Exists(path))
                {
                    return Assembly.LoadFrom(path);
                }
            }
            catch { }
            return null;
        }

        private static IEnumerable<Type> SafeGetTypes(Assembly asm)
        {
            try { return asm.GetTypes(); }
            catch (ReflectionTypeLoadException ex) { return ex.Types.Where(t => t != null); }
        }

        private static string GetCategory(MemberInfo type)
        {
            var attr = type.GetCustomAttribute<CategoryAttribute>(true);
            return attr != null ? (attr.Category ?? string.Empty).Trim() : string.Empty;
        }

        private static string GetDisplayName(MemberInfo type)
        {
            var attr = type.GetCustomAttribute<DisplayNameAttribute>(true);
            return attr != null ? (attr.DisplayName ?? string.Empty).Trim() : string.Empty;
        }

        private static SvgImage ResolveIconForTool(Type toolType, Assembly asm)
        {
            // 1) 静态属性 PluginIcon（DevExpress SvgImage）
            try
            {
                var pi = toolType.GetProperty("PluginIcon", BindingFlags.Public | BindingFlags.Static);
                if (pi != null && typeof(SvgImage).IsAssignableFrom(pi.PropertyType))
                {
                    var v = pi.GetValue(null, null) as SvgImage;
                    if (v != null) return v;
                }
            }
            catch
            {
                // ignored
            }

            // 2) ToolIconAttribute 指定的资源或相对路径
            try
            {
                var attr = toolType.GetCustomAttribute<ToolIconAttribute>(true);
                if (attr != null)
                {
                    if (!string.IsNullOrEmpty(attr.ResourceName))
                    {
                        // 精确名
                        using (var s = asm.GetManifestResourceStream(attr.ResourceName))
                        {
                            if (s != null) return SvgImage.FromStream(s);
                        }
                        // 尾部匹配（容错命名空间差异）
                        var resName = asm.GetManifestResourceNames()
                            .FirstOrDefault(n => n.EndsWith(attr.ResourceName, StringComparison.OrdinalIgnoreCase) || n.EndsWith(".Icon.svg", StringComparison.OrdinalIgnoreCase));
                        if (!string.IsNullOrEmpty(resName))
                        {
                            using var s = asm.GetManifestResourceStream(resName);
                            if (s != null) return SvgImage.FromStream(s);
                        }
                    }

                    if (!string.IsNullOrEmpty(attr.FileRelativePath))
                    {
                        var asmDir = Path.GetDirectoryName(asm.Location);
                        var file = Path.Combine(asmDir ?? string.Empty, attr.FileRelativePath);
                        if (File.Exists(file))
                        {
                            using var s = File.OpenRead(file);
                            return SvgImage.FromStream(s);
                        }
                    }
                }
            }
            catch
            {
                // ignored
            }

            // 3) 约定：尝试嵌入资源 "{Namespace}.Resources.Icon.svg" 或任意以 .Icon.svg 结尾
            try
            {
                var ns = toolType.Namespace ?? asm.GetName().Name;
                var expected = ns + ".Resources.Icon.svg";
                using (var s = asm.GetManifestResourceStream(expected))
                {
                    if (s != null) return SvgImage.FromStream(s);
                }
                var resName = asm.GetManifestResourceNames()
                    .FirstOrDefault(n => n.EndsWith(".Resources.Icon.svg", StringComparison.OrdinalIgnoreCase) || n.EndsWith(".Icon.svg", StringComparison.OrdinalIgnoreCase));
                if (!string.IsNullOrEmpty(resName))
                {
                    using var s = asm.GetManifestResourceStream(resName);
                    if (s != null) return SvgImage.FromStream(s);
                }
            }
            catch
            {
                // ignored
            }

            // 4) 默认回退到 VisionCore 内置图标，保证不为 null
            try
            {
                var coreAsm = typeof(PluginToolService).Assembly;
                using var s = coreAsm.GetManifestResourceStream("VisionCore.Resources.File.svg");
                if (s != null) return SvgImage.FromStream(s);
            }
            catch { }

            return null;
        }
    }
}
