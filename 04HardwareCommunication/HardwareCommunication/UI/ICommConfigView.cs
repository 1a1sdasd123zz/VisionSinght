using System.Windows.Forms;
using HardwareCommunication.Abstractions;

namespace HardwareCommunication.Abstractions
{
    /// <summary>
    /// 由通讯插件实现的“配置与测试”视图接口。
    /// 插件负责：
    /// - 返回承载其专有参数与测试控件的 <see cref="Control"/>
    /// - 提供将 UI 值应用回 <see cref="ICommParameters"/> 的方法（保存）
    /// - 提供将 <see cref="ICommParameters"/> 显示到界面的方法（加载）
    /// - 可选：提供“连接/断开/发送/读写”等测试行为
    /// </summary>
    public interface ICommConfigView
    {
        /// <summary>底层通道（由宿主注入/或在 Apply 时创建）</summary>
        ICommChannel Channel { get; }
        /// <summary>获取承载配置与测试的控件</summary>
        Control GetControl();
        /// <summary>将当前 UI 状态应用到参数对象</summary>
        void ApplyTo(ICommParameters parameters);
        /// <summary>将参数对象加载到界面</summary>
        void LoadFrom(ICommParameters parameters);
    }
}
