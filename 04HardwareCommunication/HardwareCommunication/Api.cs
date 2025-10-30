using System.Windows.Forms;
using HardwareCommunication.Runtime;
using HardwareCommunication.UI;

namespace HardwareCommunication
{
    /// <summary>
    /// 对外简易 API：
    /// - 加载通讯插件（默认目录：bin\Debug\Plugins\Comm 或运行目录下 Plugins\Comm）
    /// - 打开通讯配置窗口
    /// </summary>
    public static class Api
    {
        /// <summary>
        /// 扫描并加载默认插件目录。
        /// </summary>
        public static void LoadPlugins() => PluginLoader.LoadAll();

        /// <summary>
        /// 扫描并加载指定目录的插件。
        /// </summary>
        public static void LoadPlugins(string folder) => PluginLoader.LoadFrom(folder);

        /// <summary>
        /// 打开通讯配置窗口（阻塞 ShowDialog）。
        /// 内部会确保先扫描默认插件目录，以便在无需宿主显式调用的情况下也能展示插件视图。
        /// </summary>
        public static void OpenCommManagerDialog()
        {
            PluginLoader.LoadAll();
            using (var frm = new CommManagerForm())
            {
                frm.ShowDialog();
            }
        }
    }
}
