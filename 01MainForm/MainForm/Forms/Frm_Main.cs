using Logger;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using VisionCore.Frm_HardwareState;
using VisionCore.Frm_ToolBar;
using VisionCore.Manager.CameraManager;
using VisionCore.Manager.PluginManager;


namespace UniVision.Forms;

public partial class Frm_Main : DevExpress.XtraEditors.XtraForm
{
    private readonly string _layoutPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Layouts", "MainDockLayout.xml");


    private Frm_Splash splash;

    #region 界面控件

    private Frm_Log frm_Log;
    private Frm_ToolBar frm_ToolBar;
    private Frm_HardwareState frm_HardwareState;

    #endregion

    public Frm_Main()
    {
        InitializeComponent();

        InitControls();
    }



    private void Frm_Main_Load(object sender, EventArgs e)
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

        ApplyDockLayout();
        InitFormUI();

        DevExpress.XtraEditors.WindowsFormsSettings.ForceDirectXPaint();
        DevExpress.XtraEditors.WindowsFormsSettings.SetDPIAware();
        ShowInTaskbar = true;

        splash.Close();
        WindowState = FormWindowState.Maximized;
    }

    #region 初始化界面控件

    private void InitControls()
    {
        #region 设置BarManager的控件的初始化状态
        //禁用运行时动态添加和删除Bar和BarItem的功能
        dev_MainBarManager.AllowCustomization = false;
        dev_MainBarManager.AllowQuickCustomization = false;


        barDockControlTop.BackColor = Color.SlateBlue;

        #endregion

    }
    #endregion

    #region 初始化界面布局


    private void ApplyDockLayout()
    {
        dev_MainDockManager.BeginUpdate();
        try
        {
            // 尝试恢复上次布局
            if (File.Exists(_layoutPath))
            {
                dev_MainDockManager.RestoreLayoutFromXml(_layoutPath);
                return;
            }

            // 1) 左侧面板组（流程配置 + 工具栏）
            panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            panelContainer1.Width = 286; // 设定左侧宽度

            // 2) 流程栏
            dockPanel_Press.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            dockPanel_Press.Width = 262; // 设定流程栏宽度

            // 3) 顶部显示区
            dockPanel_Display.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            dockPanel_Display.Height = 470; // 设定顶部高度

            // 4) 底部日志+硬件状态容器
            panelContainer2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            panelContainer2.Height = 200; // 底部总高度

            // panelContainer2 内为水平排列（已在 Designer 设置），通过设定子面板宽度来控制比例
            // 例如：日志占 70%，硬件状态占 30%
            var total = Math.Max(1, panelContainer2.Width);
            dockPanel_Log.Width = (int)(total * 0.7);
            dockPanel_HardwareState.Width = total - dockPanel_Log.Width;
        }
        finally
        {
            dev_MainDockManager.EndUpdate();
        }
    }

    /// <summary>
    /// 界面布局初始化
    /// </summary>
    private void InitFormUI()
    {
        //日志栏
        frm_Log = new Frm_Log();
        frm_Log.Dock = DockStyle.Fill;
        dockPanel_Log_Container.Controls.Add(frm_Log);
        //工具栏
        frm_ToolBar = new Frm_ToolBar();
        frm_ToolBar.Dock = DockStyle.Fill;
        dockPanel_ToolBar_Container.Controls.Add(frm_ToolBar);
        //硬件状态栏
        frm_HardwareState = new Frm_HardwareState();
        frm_HardwareState.Dock = DockStyle.Fill;
        dockPanel_State_Container.Controls.Add(frm_HardwareState);
    }

    #endregion

    private void btn_HardwareCamera_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        var frm = new Frm_Camera2D();
        frm.ShowDialog();
    }

    private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
    {
        // 关闭前确认
        if (MessageBox.Show("是否确定退出软件？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
        {
            e.Cancel = true;
            return;
        }
    }

    private void Frm_Main_FormClosed(object sender, FormClosedEventArgs e)
    {
        CameraManager.Instance.UnInitialize();
    }

    private void btn_DefaultLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        ApplyDockLayout();
    }

    private void btn_SaveLayout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        try
        {
            var dir = Path.GetDirectoryName(_layoutPath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            dev_MainDockManager.SaveLayoutToXml(_layoutPath);
        }
        catch (Exception ex)
        {
            LogHelper.Error(ex,"保存布局异常");
        }
    }
}