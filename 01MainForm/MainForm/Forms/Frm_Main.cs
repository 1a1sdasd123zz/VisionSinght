using System.Windows.Forms;
using Logger;
using VisionCore.Manager.CameraManager;
using VisionCore.Manager.PluginManager;

namespace UniVision.Forms;

public partial class Frm_Main : DevExpress.XtraEditors.XtraForm
{

    #region 界面控件
    private Logger.Frm_Log frm_Log;

    #endregion
    public Frm_Main()
    {
        InitializeComponent();
    }

    private Frm_Splash splash;

    private void Frm_Main_Load(object sender, System.EventArgs e)
    {
        // 显示加载界面
        splash = new Frm_Splash();
        splash.Show();
        splash.Refresh();

        // 同步加载资源
        splash.SetProgress(10, "正在加载相机插件...");
        CameraPluginManager.Instance.LoadPlugins();

        splash.SetProgress(40, "正在加载硬件配置...");
        // TODO: 加载其他硬件相关配置
        // 例如：HardwareConfigManager.Instance.Load();
        var __ = CameraManager.Instance;
        //splash.SetProgress(60, "正在打开相机硬件...");
        //foreach (var config in HardwareCameraNet.DeviceFactory.Instance.GetAllUserConfigs())
        //{
        //    splash.SetProgress(70, $"正在打开相机：{config.SerialNumber}");
        //    // TODO: 打开相机硬件
        //    // CameraManager.Instance.CreateCamera(config.PluginTypeName, config.SerialNumber)?.Open();
        //}

        splash.SetProgress(80, "正在加载解决方案...");
        // TODO: 加载解决方案相关资源
        // SolutionManager.Instance.Load();

        splash.SetProgress(100, "加载完成");
        LogHelper.Info("程序启动");
        frm_Log = new Frm_Log();
        frm_Log.Dock = DockStyle.Fill;
        dockPanel_Log.Controls.Add(frm_Log);

        splash.Close();
        WindowState = FormWindowState.Maximized;
        DevExpress.XtraEditors.WindowsFormsSettings.ForceDirectXPaint();
        DevExpress.XtraEditors.WindowsFormsSettings.SetDPIAware();
        ShowInTaskbar = true;
        
        
    }

    private void btn_HardwareCamera_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        var frm = new Frm_Camera2D();
        frm.ShowDialog();
    }

    private void Frm_Main_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
    {
        //CameraManager.Instance.UnInitialize();
    }
}