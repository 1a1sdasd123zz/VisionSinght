namespace UniVision.Forms
{
    partial class Frm_Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.dev_MainBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btn_SolutionList = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btn_AddSolution = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btn_LoadSolution = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btn_SaveSolution = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btn_SolutionSaveAs = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btn_RunOnce = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btn_ContinuousRun = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btn_Stop = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btn_CreateVar = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btn_HardwareCamera = new DevExpress.XtraBars.BarLargeButtonItem();
            this.btn_HardwareComm = new DevExpress.XtraBars.BarLargeButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barSubItem2 = new DevExpress.XtraBars.BarSubItem();
            this.btn_Login = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Register = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Permission = new DevExpress.XtraBars.BarButtonItem();
            this.btn_System = new DevExpress.XtraBars.BarSubItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btn_DefaultLayout = new DevExpress.XtraBars.BarButtonItem();
            this.btn_SaveLayout = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dev_MainDockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel_PreConfig = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel_PreConfig_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel_ToolBar = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel_ToolBar_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel_Press = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel_Press_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel_Display = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel_Display_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelContainer2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel_Log = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel_Log_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel_HardwareState = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel_State_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dev_MainBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dev_MainDockManager)).BeginInit();
            this.panelContainer1.SuspendLayout();
            this.dockPanel_PreConfig.SuspendLayout();
            this.dockPanel_ToolBar.SuspendLayout();
            this.dockPanel_Press.SuspendLayout();
            this.dockPanel_Display.SuspendLayout();
            this.dockPanel_Display_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelContainer2.SuspendLayout();
            this.dockPanel_Log.SuspendLayout();
            this.dockPanel_HardwareState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // dev_MainBarManager
            // 
            this.dev_MainBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar2,
            this.bar3});
            this.dev_MainBarManager.DockControls.Add(this.barDockControlTop);
            this.dev_MainBarManager.DockControls.Add(this.barDockControlBottom);
            this.dev_MainBarManager.DockControls.Add(this.barDockControlLeft);
            this.dev_MainBarManager.DockControls.Add(this.barDockControlRight);
            this.dev_MainBarManager.DockManager = this.dev_MainDockManager;
            this.dev_MainBarManager.Form = this;
            this.dev_MainBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barSubItem1,
            this.btn_DefaultLayout,
            this.btn_SaveLayout,
            this.btn_System,
            this.barSubItem3,
            this.btn_SaveSolution,
            this.btn_AddSolution,
            this.btn_LoadSolution,
            this.btn_CreateVar,
            this.btn_HardwareCamera,
            this.btn_HardwareComm,
            this.btn_SolutionSaveAs,
            this.btn_RunOnce,
            this.btn_ContinuousRun,
            this.btn_Stop,
            this.barStaticItem1,
            this.btn_SolutionList,
            this.barSubItem2,
            this.btn_Login,
            this.btn_Register,
            this.btn_Permission});
            this.dev_MainBarManager.MainMenu = this.bar2;
            this.dev_MainBarManager.MaxItemId = 45;
            this.dev_MainBarManager.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "工具";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 1;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_SolutionList),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_AddSolution),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_LoadSolution),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_SaveSolution),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_SolutionSaveAs),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_RunOnce),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_ContinuousRun),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Stop),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_CreateVar),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_HardwareCamera),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_HardwareComm)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawBorder = false;
            this.bar1.Text = "工具";
            // 
            // btn_SolutionList
            // 
            this.btn_SolutionList.Caption = "方案列表";
            this.btn_SolutionList.Id = 40;
            this.btn_SolutionList.ImageOptions.SvgImage = global::UniVision.Properties.Resources.ActionCenterNotificationMirrored;
            this.btn_SolutionList.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btn_SolutionList.Name = "btn_SolutionList";
            this.btn_SolutionList.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_SolutionList_ItemClick);
            // 
            // btn_AddSolution
            // 
            this.btn_AddSolution.Caption = "新建空白方案";
            this.btn_AddSolution.Id = 17;
            this.btn_AddSolution.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_AddSolution.ImageOptions.SvgImage")));
            this.btn_AddSolution.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btn_AddSolution.Name = "btn_AddSolution";
            this.btn_AddSolution.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_AddSolution.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_AddSolution_ItemClick);
            // 
            // btn_LoadSolution
            // 
            this.btn_LoadSolution.Caption = "加载方案";
            this.btn_LoadSolution.Id = 18;
            this.btn_LoadSolution.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_LoadSolution.ImageOptions.SvgImage")));
            this.btn_LoadSolution.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btn_LoadSolution.Name = "btn_LoadSolution";
            this.btn_LoadSolution.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_LoadSolution_ItemClick);
            // 
            // btn_SaveSolution
            // 
            this.btn_SaveSolution.Caption = "保存方案";
            this.btn_SaveSolution.Id = 16;
            this.btn_SaveSolution.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_SaveSolution.ImageOptions.SvgImage")));
            this.btn_SaveSolution.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btn_SaveSolution.Name = "btn_SaveSolution";
            this.btn_SaveSolution.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_SaveSolution.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_SaveSolution_ItemClick);
            // 
            // btn_SolutionSaveAs
            // 
            this.btn_SolutionSaveAs.Caption = "方案另存为";
            this.btn_SolutionSaveAs.Id = 33;
            this.btn_SolutionSaveAs.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_SolutionSaveAs.ImageOptions.SvgImage")));
            this.btn_SolutionSaveAs.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btn_SolutionSaveAs.Name = "btn_SolutionSaveAs";
            this.btn_SolutionSaveAs.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btn_RunOnce
            // 
            this.btn_RunOnce.Caption = "单次执行";
            this.btn_RunOnce.Id = 35;
            this.btn_RunOnce.ImageOptions.SvgImage = global::UniVision.Properties.Resources.执行;
            this.btn_RunOnce.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.btn_RunOnce.Name = "btn_RunOnce";
            this.btn_RunOnce.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_RunOnce.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_RunOnce_ItemClick);
            // 
            // btn_ContinuousRun
            // 
            this.btn_ContinuousRun.Caption = "循环执行";
            this.btn_ContinuousRun.Id = 37;
            this.btn_ContinuousRun.ImageOptions.SvgImage = global::UniVision.Properties.Resources.循环;
            this.btn_ContinuousRun.ImageOptions.SvgImageSize = new System.Drawing.Size(32, 32);
            this.btn_ContinuousRun.Name = "btn_ContinuousRun";
            this.btn_ContinuousRun.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_ContinuousRun_ItemClick);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Caption = "停止";
            this.btn_Stop.Id = 38;
            this.btn_Stop.ImageOptions.SvgImage = global::UniVision.Properties.Resources.停止执行;
            this.btn_Stop.ItemInMenuAppearance.Disabled.BackColor = System.Drawing.Color.Transparent;
            this.btn_Stop.ItemInMenuAppearance.Disabled.Options.UseBackColor = true;
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_Stop.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Stop_ItemClick);
            // 
            // btn_CreateVar
            // 
            this.btn_CreateVar.Caption = "全局变量";
            this.btn_CreateVar.Id = 29;
            this.btn_CreateVar.ImageOptions.SvgImage = global::UniVision.Properties.Resources.查看变量;
            this.btn_CreateVar.Name = "btn_CreateVar";
            this.btn_CreateVar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_CreateVar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_CreateVar_ItemClick);
            // 
            // btn_HardwareCamera
            // 
            this.btn_HardwareCamera.Caption = "相机配置";
            this.btn_HardwareCamera.Id = 30;
            this.btn_HardwareCamera.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_HardwareCamera.ImageOptions.SvgImage")));
            this.btn_HardwareCamera.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btn_HardwareCamera.Name = "btn_HardwareCamera";
            this.btn_HardwareCamera.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btn_HardwareCamera.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_HardwareCamera_ItemClick);
            // 
            // btn_HardwareComm
            // 
            this.btn_HardwareComm.Caption = "通讯配置";
            this.btn_HardwareComm.Id = 31;
            this.btn_HardwareComm.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_HardwareComm.ImageOptions.SvgImage")));
            this.btn_HardwareComm.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btn_HardwareComm.Name = "btn_HardwareComm";
            this.btn_HardwareComm.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bar2
            // 
            this.bar2.BarName = "主菜单";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_System),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem3)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "主菜单";
            // 
            // barSubItem2
            // 
            this.barSubItem2.Caption = "用户(U)";
            this.barSubItem2.Id = 41;
            this.barSubItem2.ImageOptions.SvgImage = global::UniVision.Properties.Resources.用户;
            this.barSubItem2.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.barSubItem2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Login),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Register),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Permission)});
            this.barSubItem2.Name = "barSubItem2";
            this.barSubItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btn_Login
            // 
            this.btn_Login.Caption = "用户登录(L)";
            this.btn_Login.Id = 42;
            this.btn_Login.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Login.ImageOptions.SvgImage")));
            this.btn_Login.Name = "btn_Login";
            // 
            // btn_Register
            // 
            this.btn_Register.Caption = "用户注册(R)";
            this.btn_Register.Id = 43;
            this.btn_Register.ImageOptions.SvgImage = global::UniVision.Properties.Resources.用户注册;
            this.btn_Register.Name = "btn_Register";
            // 
            // btn_Permission
            // 
            this.btn_Permission.Caption = "用户权限(P)";
            this.btn_Permission.Id = 44;
            this.btn_Permission.ImageOptions.SvgImage = global::UniVision.Properties.Resources.用户权限;
            this.btn_Permission.Name = "btn_Permission";
            // 
            // btn_System
            // 
            this.btn_System.Caption = "系统(S)";
            this.btn_System.Id = 12;
            this.btn_System.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_System.ImageOptions.SvgImage")));
            this.btn_System.Name = "btn_System";
            this.btn_System.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "视图(V)";
            this.barSubItem1.Id = 7;
            this.barSubItem1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barSubItem1.ImageOptions.SvgImage")));
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_DefaultLayout),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_SaveLayout)});
            this.barSubItem1.Name = "barSubItem1";
            this.barSubItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btn_DefaultLayout
            // 
            this.btn_DefaultLayout.Caption = "默认布局";
            this.btn_DefaultLayout.Id = 8;
            this.btn_DefaultLayout.Name = "btn_DefaultLayout";
            this.btn_DefaultLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_DefaultLayout_ItemClick);
            // 
            // btn_SaveLayout
            // 
            this.btn_SaveLayout.Caption = "保存布局";
            this.btn_SaveLayout.Id = 9;
            this.btn_SaveLayout.Name = "btn_SaveLayout";
            this.btn_SaveLayout.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_SaveLayout_ItemClick);
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "帮助(Help)";
            this.barSubItem3.Id = 13;
            this.barSubItem3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("barSubItem3.ImageOptions.SvgImage")));
            this.barSubItem3.Name = "barSubItem3";
            this.barSubItem3.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // bar3
            // 
            this.bar3.BarName = "状态栏";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawBorder = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "状态栏";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "用户:无";
            this.barStaticItem1.Id = 39;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.dev_MainBarManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1327, 124);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 547);
            this.barDockControlBottom.Manager = this.dev_MainBarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1327, 33);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 124);
            this.barDockControlLeft.Manager = this.dev_MainBarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 423);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1327, 124);
            this.barDockControlRight.Manager = this.dev_MainBarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 423);
            // 
            // dev_MainDockManager
            // 
            this.dev_MainDockManager.Form = this;
            this.dev_MainDockManager.MenuManager = this.dev_MainBarManager;
            this.dev_MainDockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.panelContainer1,
            this.dockPanel_Press,
            this.dockPanel_Display,
            this.panelContainer2});
            this.dev_MainDockManager.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "System.Windows.Forms.StatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl",
            "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl",
            "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl"});
            // 
            // panelContainer1
            // 
            this.panelContainer1.Controls.Add(this.dockPanel_PreConfig);
            this.panelContainer1.Controls.Add(this.dockPanel_ToolBar);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.panelContainer1.ID = new System.Guid("32b62a6b-e699-493f-a4f9-d3f8103c9602");
            this.panelContainer1.Location = new System.Drawing.Point(0, 124);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(286, 200);
            this.panelContainer1.Size = new System.Drawing.Size(286, 423);
            this.panelContainer1.Text = "panelContainer1";
            // 
            // dockPanel_PreConfig
            // 
            this.dockPanel_PreConfig.Controls.Add(this.dockPanel_PreConfig_Container);
            this.dockPanel_PreConfig.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel_PreConfig.ID = new System.Guid("21e68503-0aea-4969-8018-3815e62bf299");
            this.dockPanel_PreConfig.Location = new System.Drawing.Point(0, 0);
            this.dockPanel_PreConfig.Name = "dockPanel_PreConfig";
            this.dockPanel_PreConfig.OriginalSize = new System.Drawing.Size(286, 175);
            this.dockPanel_PreConfig.Size = new System.Drawing.Size(286, 173);
            this.dockPanel_PreConfig.Text = "流程配置";
            // 
            // dockPanel_PreConfig_Container
            // 
            this.dockPanel_PreConfig_Container.Location = new System.Drawing.Point(4, 38);
            this.dockPanel_PreConfig_Container.Name = "dockPanel_PreConfig_Container";
            this.dockPanel_PreConfig_Container.Size = new System.Drawing.Size(275, 128);
            this.dockPanel_PreConfig_Container.TabIndex = 0;
            // 
            // dockPanel_ToolBar
            // 
            this.dockPanel_ToolBar.Controls.Add(this.dockPanel_ToolBar_Container);
            this.dockPanel_ToolBar.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel_ToolBar.ID = new System.Guid("2a363170-7f8d-4f46-ba15-d33731395098");
            this.dockPanel_ToolBar.Location = new System.Drawing.Point(0, 173);
            this.dockPanel_ToolBar.Name = "dockPanel_ToolBar";
            this.dockPanel_ToolBar.OriginalSize = new System.Drawing.Size(286, 254);
            this.dockPanel_ToolBar.Size = new System.Drawing.Size(286, 250);
            this.dockPanel_ToolBar.Text = "工具栏";
            // 
            // dockPanel_ToolBar_Container
            // 
            this.dockPanel_ToolBar_Container.Location = new System.Drawing.Point(4, 38);
            this.dockPanel_ToolBar_Container.Name = "dockPanel_ToolBar_Container";
            this.dockPanel_ToolBar_Container.Size = new System.Drawing.Size(275, 208);
            this.dockPanel_ToolBar_Container.TabIndex = 0;
            // 
            // dockPanel_Press
            // 
            this.dockPanel_Press.Controls.Add(this.dockPanel_Press_Container);
            this.dockPanel_Press.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel_Press.ID = new System.Guid("91d9be1f-fc87-4ae7-928f-5d2c2c5945b7");
            this.dockPanel_Press.Location = new System.Drawing.Point(286, 124);
            this.dockPanel_Press.Name = "dockPanel_Press";
            this.dockPanel_Press.OriginalSize = new System.Drawing.Size(262, 200);
            this.dockPanel_Press.Size = new System.Drawing.Size(262, 423);
            this.dockPanel_Press.Text = "流程栏";
            // 
            // dockPanel_Press_Container
            // 
            this.dockPanel_Press_Container.Location = new System.Drawing.Point(4, 38);
            this.dockPanel_Press_Container.Name = "dockPanel_Press_Container";
            this.dockPanel_Press_Container.Size = new System.Drawing.Size(251, 381);
            this.dockPanel_Press_Container.TabIndex = 0;
            // 
            // dockPanel_Display
            // 
            this.dockPanel_Display.Controls.Add(this.dockPanel_Display_Container);
            this.dockPanel_Display.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.dockPanel_Display.FloatVertical = true;
            this.dockPanel_Display.ID = new System.Guid("a70686f3-b22e-4226-b271-2796164acc5a");
            this.dockPanel_Display.Location = new System.Drawing.Point(548, 124);
            this.dockPanel_Display.Name = "dockPanel_Display";
            this.dockPanel_Display.OriginalSize = new System.Drawing.Size(200, 344);
            this.dockPanel_Display.Size = new System.Drawing.Size(779, 344);
            this.dockPanel_Display.Text = "显示";
            // 
            // dockPanel_Display_Container
            // 
            this.dockPanel_Display_Container.Controls.Add(this.panelControl1);
            this.dockPanel_Display_Container.Location = new System.Drawing.Point(4, 38);
            this.dockPanel_Display_Container.Name = "dockPanel_Display_Container";
            this.dockPanel_Display_Container.Size = new System.Drawing.Size(771, 299);
            this.dockPanel_Display_Container.TabIndex = 0;
            // 
            // panelControl1
            // 
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(771, 299);
            this.panelControl1.TabIndex = 0;
            // 
            // panelContainer2
            // 
            this.panelContainer2.ChildPanelOrientation = DevExpress.XtraBars.Docking.LayoutOrientation.Horizontal;
            this.panelContainer2.Controls.Add(this.dockPanel_Log);
            this.panelContainer2.Controls.Add(this.dockPanel_HardwareState);
            this.panelContainer2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.panelContainer2.FloatVertical = true;
            this.panelContainer2.ID = new System.Guid("ccc77060-0038-4d2c-9d6a-33ca44983355");
            this.panelContainer2.Location = new System.Drawing.Point(548, 468);
            this.panelContainer2.Name = "panelContainer2";
            this.panelContainer2.OriginalSize = new System.Drawing.Size(1570, 200);
            this.panelContainer2.Size = new System.Drawing.Size(779, 79);
            this.panelContainer2.Text = "panelContainer2";
            // 
            // dockPanel_Log
            // 
            this.dockPanel_Log.Controls.Add(this.dockPanel_Log_Container);
            this.dockPanel_Log.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel_Log.FloatVertical = true;
            this.dockPanel_Log.ID = new System.Guid("e48cb829-bc0c-4ef7-9f15-1da4ac7fce49");
            this.dockPanel_Log.Location = new System.Drawing.Point(0, 0);
            this.dockPanel_Log.Name = "dockPanel_Log";
            this.dockPanel_Log.OriginalSize = new System.Drawing.Size(648, 85);
            this.dockPanel_Log.Size = new System.Drawing.Size(648, 79);
            this.dockPanel_Log.Text = "日志栏";
            // 
            // dockPanel_Log_Container
            // 
            this.dockPanel_Log_Container.Location = new System.Drawing.Point(4, 38);
            this.dockPanel_Log_Container.Name = "dockPanel_Log_Container";
            this.dockPanel_Log_Container.Size = new System.Drawing.Size(637, 37);
            this.dockPanel_Log_Container.TabIndex = 0;
            // 
            // dockPanel_HardwareState
            // 
            this.dockPanel_HardwareState.Controls.Add(this.dockPanel_State_Container);
            this.dockPanel_HardwareState.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel_HardwareState.ID = new System.Guid("ce17dcae-4613-462a-8655-761e302ed488");
            this.dockPanel_HardwareState.Location = new System.Drawing.Point(648, 0);
            this.dockPanel_HardwareState.Name = "dockPanel_HardwareState";
            this.dockPanel_HardwareState.OriginalSize = new System.Drawing.Size(131, 85);
            this.dockPanel_HardwareState.Size = new System.Drawing.Size(131, 79);
            this.dockPanel_HardwareState.Text = "硬件状态栏";
            // 
            // dockPanel_State_Container
            // 
            this.dockPanel_State_Container.Location = new System.Drawing.Point(4, 38);
            this.dockPanel_State_Container.Name = "dockPanel_State_Container";
            this.dockPanel_State_Container.Size = new System.Drawing.Size(123, 37);
            this.dockPanel_State_Container.TabIndex = 0;
            // 
            // Frm_Main
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 580);
            this.Controls.Add(this.panelContainer2);
            this.Controls.Add(this.dockPanel_Display);
            this.Controls.Add(this.dockPanel_Press);
            this.Controls.Add(this.panelContainer1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Main_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Main_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dev_MainBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dev_MainDockManager)).EndInit();
            this.panelContainer1.ResumeLayout(false);
            this.dockPanel_PreConfig.ResumeLayout(false);
            this.dockPanel_ToolBar.ResumeLayout(false);
            this.dockPanel_Press.ResumeLayout(false);
            this.dockPanel_Display.ResumeLayout(false);
            this.dockPanel_Display_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelContainer2.ResumeLayout(false);
            this.dockPanel_Log.ResumeLayout(false);
            this.dockPanel_HardwareState.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager dev_MainBarManager;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.Docking.DockManager dev_MainDockManager;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel_Log;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel_Log_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel_Display;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel_Display_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel_Press;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel_Press_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel_HardwareState;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel_State_Container;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel_PreConfig;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel_PreConfig_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel_ToolBar;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel_ToolBar_Container;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer2;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btn_DefaultLayout;
        private DevExpress.XtraBars.BarButtonItem btn_SaveLayout;
        private DevExpress.XtraBars.BarSubItem btn_System;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarLargeButtonItem btn_SaveSolution;
        private DevExpress.XtraBars.BarLargeButtonItem btn_AddSolution;
        private DevExpress.XtraBars.BarLargeButtonItem btn_LoadSolution;
        private DevExpress.XtraBars.BarLargeButtonItem btn_CreateVar;
        private DevExpress.XtraBars.BarLargeButtonItem btn_HardwareCamera;
        private DevExpress.XtraBars.BarLargeButtonItem btn_HardwareComm;
        private DevExpress.XtraBars.BarLargeButtonItem btn_SolutionSaveAs;
        private DevExpress.XtraBars.BarLargeButtonItem btn_RunOnce;
        private DevExpress.XtraBars.BarLargeButtonItem btn_ContinuousRun;
        private DevExpress.XtraBars.BarLargeButtonItem btn_Stop;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarLargeButtonItem btn_SolutionList;
        private DevExpress.XtraBars.BarSubItem barSubItem2;
        private DevExpress.XtraBars.BarButtonItem btn_Login;
        private DevExpress.XtraBars.BarButtonItem btn_Register;
        private DevExpress.XtraBars.BarButtonItem btn_Permission;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}