using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HardwareCommunication.Runtime
{
    /// <summary>
    /// 动态插件加载器：从指定目录加载通讯插件程序集（.dll），并注册到 CommFactory。
    /// 默认目录：AppDomain.BaseDirectory\Plugins\Comm
    /// </summary>
    public static class PluginLoader
    {
        /// <summary>
        /// 默认插件目录（相对当前进程目录）。
        /// 例如：bin\Debug\Plugins\Comm
        /// </summary>
        public static string DefaultPluginFolder => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins", "Comm");

        /// <summary>
        /// 从默认目录加载全部插件。
        /// </summary>
        public static void LoadAll() => LoadFrom(DefaultPluginFolder);

        /// <summary>
        /// 从指定目录加载所有 .dll 插件，并调用 CommFactory.RegisterFromAssembly 进行注册。
        /// </summary>
        public static void LoadFrom(string folder)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(folder) || !Directory.Exists(folder)) return;
                var loadedLocations = AppDomain.CurrentDomain.GetAssemblies()
                    .Select(a => SafeLocation(a)).Where(p => !string.IsNullOrEmpty(p)).ToHashSet(StringComparer.OrdinalIgnoreCase);

                foreach (var dll in Directory.EnumerateFiles(folder, "*.dll", SearchOption.AllDirectories))
                {
                    try
                    {
                        if (loadedLocations.Contains(dll)) continue; // 已加载同路径
                        var asm = Assembly.LoadFrom(dll);
                        CommFactory.RegisterFromAssembly(asm);
                    }
                    catch { /* 忽略单个插件加载异常 */ }
                }
            }
            catch { }
        }

        private static string SafeLocation(Assembly a)
        {
            try { return a.Location; } catch { return null; }
        }
    }
}
