using Logger;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraBars;
using VisionCore.Frm_HardwareState;
using VisionCore.Frm_Solution;
using VisionCore.Manager.CameraManager;
using VisionCore.Solution;
using System.Linq;
using VisionCore.Manager.PluginServer;


namespace UniVision.Forms;

public partial class Frm_Main : DevExpress.XtraEditors.XtraForm
{
    private readonly string _layoutPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Layouts", "MainDockLayout.xml");

    private Frm_Splash splash;

    #region 界面控件
    private Frm_Log frm_Log;
    private Frm_ToolBar frm_ToolBar;
    private Frm_ProcessConfig frm_PressConfig;
    private Frm_ProcessBar frm_PressBar;
    private Frm_HardwareState frm_HardwareState;
    #endregion

    public Frm_Main()
    {
        InitializeComponent();
        InitControls();
        SolutionManager.Instance.CurrentSolutionChanged += OnCurrentSolutionChanged;
    }

    private void Frm_Main_Load(object sender, EventArgs e)
    {
        // 显示加载界面
        splash = new Frm_Splash();
        splash.Show();
        splash.Refresh();

        splash.SetProgress(10, "正在加载相机插件...");
        CameraPluginServer.Instance.LoadPlugins();

        splash.SetProgress(30, "正在加载工具插件...");
        PluginToolService.Init();

        splash.SetProgress(40, "正在加载解决方案列表...");
        SolutionManager.Instance.LoadDefaultSolution();

        splash.SetProgress(70, "初始化界面...");
        ApplyDockLayout();
        InitFormUI();

        // 先绑定流程选择事件
        if (frm_PressConfig != null && frm_PressBar != null)
            frm_PressConfig.SelectedProcessChanged += path => frm_PressBar.ShowProcess(path);

        RefreshCurrentSolutionUI();

        // 将工具插件填充到工具栏
        try { frm_ToolBar?.LoadPluginsToGallery(); } catch { }

        // 若加载后仍未触发（例如无流程），显式清空流程栏
        if (frm_PressBar != null && frm_PressConfig != null && frm_PressConfig.SolutionMgr != null)
        {
            if (!frm_PressConfig.SolutionMgr.Data.Root.OfType<ProcessItem>().Any() &&
                !frm_PressConfig.SolutionMgr.Data.Root.SelectMany(r => (r as VisionCore.Solution.ProcessFolder)?.Children ?? new System.Collections.Generic.List<VisionCore.Solution.ProcessNode>()).OfType<VisionCore.Solution.ProcessItem>().Any())
            {
                frm_PressBar.ShowProcess(null);
            }
        }

        splash.SetProgress(95, "完成设置...");

        DevExpress.XtraEditors.WindowsFormsSettings.ForceDirectXPaint();
        DevExpress.XtraEditors.WindowsFormsSettings.SetDPIAware();
        ShowInTaskbar = true;

        splash.Close();
        WindowState = FormWindowState.Maximized;

        // 订阅运行状态变化，仅用于更新主界面按钮状态
        if (frm_PressBar != null)
        {
            frm_PressBar.RunStateChanged += (isRunning, isLoop) => UpdateRunButtons();
        }

        // 初始化按钮状态
        UpdateRunButtons();
    }

    private void UpdateRunButtons()
    {
        if (frm_PressBar == null)
        {
            btn_RunOnce.Enabled = false;
            btn_ContinuousRun.Enabled = false;
            btn_Stop.Enabled = false;
            return;
        }

        // 主界面独立控制逻辑: 运行中(单次或循环) -> 只能停止
        if (!frm_PressBar.IsRunning)
        {
            btn_RunOnce.Enabled = true;
            btn_ContinuousRun.Enabled = true;
            btn_Stop.Enabled = false;
        }
        else
        {
            btn_RunOnce.Enabled = false;
            btn_ContinuousRun.Enabled = false;
            btn_Stop.Enabled = true;
        }
    }

    private void OnCurrentSolutionChanged(Solution sol)
    {
        RefreshCurrentSolutionUI();
    }

    private void RefreshCurrentSolutionUI()
    {
        try
        {
            var cur = SolutionManager.Instance.CurrentSolution;
            if (cur == null) return;
            if (frm_PressConfig == null)
                return;
            frm_PressConfig.FromSolution(cur);
            frm_PressConfig.SolutionMgr = cur;
            frm_PressBar?.BindSolution(cur);
        }
        catch (Exception ex)
        {
            LogHelper.Error(ex, "刷新方案界面失败");
        }
    }

    #region 初始化界面控件

    private void InitControls()
    {
        dev_MainBarManager.AllowCustomization = false;
        dev_MainBarManager.AllowQuickCustomization = false;

        foreach (BarItem item in dev_MainBarManager.Items)
        {
            item.ItemAppearance.Hovered.BackColor = Color.DarkGreen;
            item.ItemAppearance.Pressed.BackColor = Color.Teal;
        }
    }

    #endregion

    #region 初始化界面布局


    private void ApplyDockLayout()
    {
        dev_MainDockManager.BeginUpdate();
        try
        {
            if (File.Exists(_layoutPath))
            {
                dev_MainDockManager.RestoreLayoutFromXml(_layoutPath);
                return;
            }
            panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            panelContainer1.Width = 286;
            dockPanel_Press.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            dockPanel_Press.Width = 262;
            dockPanel_Display.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            dockPanel_Display.Height = 470;
            panelContainer2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom;
            panelContainer2.Height = 200;
            var total = Math.Max(1, panelContainer2.Width);
            dockPanel_Log.Width = (int)(total * 0.7);
            dockPanel_HardwareState.Width = total - dockPanel_Log.Width;
        }
        finally
        {
            dev_MainDockManager.EndUpdate();
        }
    }

    private void InitFormUI()
    {
        frm_Log = new Frm_Log { Dock = DockStyle.Fill };
        dockPanel_Log_Container.Controls.Add(frm_Log);

        frm_ToolBar = new Frm_ToolBar { Dock = DockStyle.Fill };
        dockPanel_ToolBar_Container.Controls.Add(frm_ToolBar);

        frm_PressBar = new Frm_ProcessBar { Dock = DockStyle.Fill };
        dockPanel_Press_Container.Controls.Add(frm_PressBar);

        frm_PressConfig = new Frm_ProcessConfig { Dock = DockStyle.Fill };
        dockPanel_PreConfig_Container.Controls.Add(frm_PressConfig);

        frm_HardwareState = new Frm_HardwareState { Dock = DockStyle.Fill };
        dockPanel_State_Container.Controls.Add(frm_HardwareState);
    }

    #endregion

    private void btn_HardwareCamera_ItemClick(object sender, ItemClickEventArgs e)
    {
        using var frm = new Frm_Camera2D();
        frm.ShowDialog();
    }

    private void Frm_Main_FormClosing(object sender, FormClosingEventArgs e)
    {
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

    private void btn_DefaultLayout_ItemClick(object sender, ItemClickEventArgs e) => ApplyDockLayout();

    private void btn_SaveLayout_ItemClick(object sender, ItemClickEventArgs e)
    {
        try
        {
            var dir = Path.GetDirectoryName(_layoutPath);
            if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) Directory.CreateDirectory(dir);
            dev_MainDockManager.SaveLayoutToXml(_layoutPath);
        }
        catch (Exception ex)
        {
            LogHelper.Error(ex, "保存布局异常");
        }
    }

    private void btn_SolutionList_ItemClick(object sender, ItemClickEventArgs e)
    {
        using var frm = new Frm_SolutionList();
        frm.OpenSolutionRequested += sol =>
        {
            var info = SolutionManager.Instance.Solutions.FirstOrDefault(s => s.Name == sol.Data.Name);
            if (info != null) SolutionManager.Instance.OpenSolution(info);
        };
        frm.ShowDialog();
    }

    private void btn_AddSolution_ItemClick(object sender, ItemClickEventArgs e)
    {
        try
        {
            // 预留：新建方案逻辑
        }
        catch (Exception ex)
        {
            LogHelper.Error(ex, "新建方案失败");
            MessageBox.Show("新建方案失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btn_SaveSolution_ItemClick(object sender, ItemClickEventArgs e)
    {
        try
        {
            var cur = SolutionManager.Instance.CurrentSolution;
            if (cur == null) return;
            SolutionManager.Instance.SaveSolution(cur);
            MessageBox.Show("保存方案成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            LogHelper.Error(ex, "保存方案失败");
            MessageBox.Show("保存方案失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btn_LoadSolution_ItemClick(object sender, ItemClickEventArgs e)
    {
        try
        {
            SolutionManager.Instance.LoadDefaultSolution();
            MessageBox.Show("加载默认方案成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            LogHelper.Error(ex, "加载方案失败");
            MessageBox.Show("加载方案失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    // 主界面运行控制按钮事件 (仅业务调用 + 状态刷新)
    private void btn_RunOnce_ItemClick(object sender, ItemClickEventArgs e)
    {
        frm_PressBar?.RunAllOnce();
        UpdateRunButtons();
    }

    private void btn_ContinuousRun_ItemClick(object sender, ItemClickEventArgs e)
    {
        frm_PressBar?.StartLoopAll();
        UpdateRunButtons();
    }

    private void btn_Stop_ItemClick(object sender, ItemClickEventArgs e)
    {
        frm_PressBar?.StopRun();
        UpdateRunButtons();
    }

    private void btn_CreateVar_ItemClick(object sender, ItemClickEventArgs e)
    {
        using var frm = new VisionCore.GlobarValue.Frm_GlobalVar();
        frm.ShowDialog();
    }
}