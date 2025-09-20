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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.dev_MainBarManager = new DevExpress.XtraBars.BarManager(this.components);
            this.dx_ToolBar = new DevExpress.XtraBars.Bar();
            this.dev_MainStatusBar = new DevExpress.XtraBars.Bar();
            this.dev_MainMenuBar = new DevExpress.XtraBars.Bar();
            this.btn_Login = new DevExpress.XtraBars.BarButtonItem();
            this.btn_View = new DevExpress.XtraBars.BarSubItem();
            this.btn_DefaultView = new DevExpress.XtraBars.BarButtonItem();
            this.btn_ShowTool = new DevExpress.XtraBars.BarCheckItem();
            this.btn_HardwareCamera = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.dev_MainDockManager = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.dockPanel6 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel7 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel8 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel9 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel_Log = new DevExpress.XtraBars.Docking.DockPanel();
            this.repositoryItemCheckedComboBoxEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel3 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel4 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel4_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel5 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel5_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            ((System.ComponentModel.ISupportInitialize)(this.dev_MainBarManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dev_MainDockManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            this.dockPanel3.SuspendLayout();
            this.dockPanel4.SuspendLayout();
            this.dockPanel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // dev_MainBarManager
            // 
            this.dev_MainBarManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.dx_ToolBar,
            this.dev_MainStatusBar,
            this.dev_MainMenuBar});
            this.dev_MainBarManager.DockControls.Add(this.barDockControlTop);
            this.dev_MainBarManager.DockControls.Add(this.barDockControlBottom);
            this.dev_MainBarManager.DockControls.Add(this.barDockControlLeft);
            this.dev_MainBarManager.DockControls.Add(this.barDockControlRight);
            this.dev_MainBarManager.DockManager = this.dev_MainDockManager;
            this.dev_MainBarManager.Form = this;
            this.dev_MainBarManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_Login,
            this.btn_View,
            this.btn_DefaultView,
            this.btn_ShowTool,
            this.btn_HardwareCamera});
            this.dev_MainBarManager.MainMenu = this.dev_MainMenuBar;
            this.dev_MainBarManager.MaxItemId = 18;
            this.dev_MainBarManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckedComboBoxEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemCheckEdit2,
            this.repositoryItemCheckEdit3,
            this.repositoryItemCheckEdit4});
            this.dev_MainBarManager.StatusBar = this.dev_MainStatusBar;
            // 
            // dx_ToolBar
            // 
            this.dx_ToolBar.BarName = "工具";
            this.dx_ToolBar.DockCol = 0;
            this.dx_ToolBar.DockRow = 1;
            this.dx_ToolBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.dx_ToolBar.OptionsBar.DrawBorder = false;
            this.dx_ToolBar.Text = "工具";
            // 
            // dev_MainStatusBar
            // 
            this.dev_MainStatusBar.BarName = "状态栏";
            this.dev_MainStatusBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.dev_MainStatusBar.DockCol = 0;
            this.dev_MainStatusBar.DockRow = 0;
            this.dev_MainStatusBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.dev_MainStatusBar.OptionsBar.AllowQuickCustomization = false;
            this.dev_MainStatusBar.OptionsBar.DrawBorder = false;
            this.dev_MainStatusBar.OptionsBar.DrawDragBorder = false;
            this.dev_MainStatusBar.OptionsBar.MultiLine = true;
            this.dev_MainStatusBar.OptionsBar.UseWholeRow = true;
            this.dev_MainStatusBar.Text = "主菜单";
            // 
            // dev_MainMenuBar
            // 
            this.dev_MainMenuBar.BarName = "主菜单";
            this.dev_MainMenuBar.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Top;
            this.dev_MainMenuBar.DockCol = 0;
            this.dev_MainMenuBar.DockRow = 0;
            this.dev_MainMenuBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.dev_MainMenuBar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Login),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_View),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_HardwareCamera)});
            this.dev_MainMenuBar.OptionsBar.AllowQuickCustomization = false;
            this.dev_MainMenuBar.OptionsBar.DrawDragBorder = false;
            this.dev_MainMenuBar.OptionsBar.MultiLine = true;
            this.dev_MainMenuBar.OptionsBar.UseWholeRow = true;
            this.dev_MainMenuBar.Text = "状态栏";
            // 
            // btn_Login
            // 
            this.btn_Login.Caption = "登录";
            this.btn_Login.Id = 0;
            this.btn_Login.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Login.ImageOptions.SvgImage")));
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            toolTipItem1.Text = "登录";
            superToolTip1.Items.Add(toolTipItem1);
            this.btn_Login.SuperTip = superToolTip1;
            // 
            // btn_View
            // 
            this.btn_View.Caption = "视图";
            this.btn_View.Id = 5;
            this.btn_View.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_DefaultView),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_ShowTool)});
            this.btn_View.Name = "btn_View";
            // 
            // btn_DefaultView
            // 
            this.btn_DefaultView.Caption = "默认视图";
            this.btn_DefaultView.Id = 6;
            this.btn_DefaultView.Name = "btn_DefaultView";
            // 
            // btn_ShowTool
            // 
            this.btn_ShowTool.Caption = "工具栏视图";
            this.btn_ShowTool.Id = 14;
            this.btn_ShowTool.Name = "btn_ShowTool";
            // 
            // btn_HardwareCamera
            // 
            this.btn_HardwareCamera.Caption = "相机模块";
            this.btn_HardwareCamera.Id = 17;
            this.btn_HardwareCamera.Name = "btn_HardwareCamera";
            this.btn_HardwareCamera.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_HardwareCamera_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.dev_MainBarManager;
            this.barDockControlTop.Size = new System.Drawing.Size(1327, 55);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 885);
            this.barDockControlBottom.Manager = this.dev_MainBarManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(1327, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 55);
            this.barDockControlLeft.Manager = this.dev_MainBarManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 830);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1327, 55);
            this.barDockControlRight.Manager = this.dev_MainBarManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 830);
            // 
            // dev_MainDockManager
            // 
            this.dev_MainDockManager.Form = this;
            this.dev_MainDockManager.MenuManager = this.dev_MainBarManager;
            this.dev_MainDockManager.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.dockPanel6,
            this.dockPanel7,
            this.dockPanel8,
            this.dockPanel9,
            this.dockPanel_Log});
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
            // dockPanel6
            // 
            this.dockPanel6.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel6.ID = new System.Guid("62a04ff1-d691-43b1-a2bc-8b4683ed0b1a");
            this.dockPanel6.Location = new System.Drawing.Point(0, 55);
            this.dockPanel6.Name = "dockPanel6";
            this.dockPanel6.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel6.Size = new System.Drawing.Size(200, 830);
            this.dockPanel6.Text = "工具栏";
            // 
            // dockPanel7
            // 
            this.dockPanel7.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel7.ID = new System.Guid("721b19ba-e49d-401d-8aa4-512545f36408");
            this.dockPanel7.Location = new System.Drawing.Point(200, 55);
            this.dockPanel7.Name = "dockPanel7";
            this.dockPanel7.OriginalSize = new System.Drawing.Size(264, 200);
            this.dockPanel7.Size = new System.Drawing.Size(264, 830);
            this.dockPanel7.Text = "流程栏";
            // 
            // dockPanel8
            // 
            this.dockPanel8.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.dockPanel8.FloatVertical = true;
            this.dockPanel8.ID = new System.Guid("fb5b1396-3ac9-4820-93f2-1ccd7a5708a0");
            this.dockPanel8.Location = new System.Drawing.Point(464, 55);
            this.dockPanel8.Name = "dockPanel8";
            this.dockPanel8.OriginalSize = new System.Drawing.Size(200, 748);
            this.dockPanel8.Size = new System.Drawing.Size(863, 748);
            this.dockPanel8.Text = "显示";
            // 
            // dockPanel9
            // 
            this.dockPanel9.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            this.dockPanel9.ID = new System.Guid("3055d933-9df8-462b-b59b-bc49bb673561");
            this.dockPanel9.Location = new System.Drawing.Point(1001, 803);
            this.dockPanel9.Name = "dockPanel9";
            this.dockPanel9.OriginalSize = new System.Drawing.Size(326, 200);
            this.dockPanel9.Size = new System.Drawing.Size(326, 82);
            this.dockPanel9.Text = "硬件状态";
            // 
            // dockPanel_Log
            // 
            this.dockPanel_Log.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel_Log.FloatVertical = true;
            this.dockPanel_Log.ID = new System.Guid("a8f203f8-ceee-43f0-94dc-333a9064d704");
            this.dockPanel_Log.Location = new System.Drawing.Point(464, 803);
            this.dockPanel_Log.Name = "dockPanel_Log";
            this.dockPanel_Log.OriginalSize = new System.Drawing.Size(1328, 200);
            this.dockPanel_Log.Size = new System.Drawing.Size(537, 82);
            this.dockPanel_Log.Text = "信息栏";
            // 
            // repositoryItemCheckedComboBoxEdit1
            // 
            this.repositoryItemCheckedComboBoxEdit1.AutoHeight = false;
            this.repositoryItemCheckedComboBoxEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCheckedComboBoxEdit1.Name = "repositoryItemCheckedComboBoxEdit1";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel1.ID = new System.Guid("982d2e33-8c9b-4811-bbe9-8e5ec489d2c9");
            this.dockPanel1.Location = new System.Drawing.Point(0, 55);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(200, 748);
            this.dockPanel1.Text = "dockPanel1";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 38);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(189, 706);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel2.ID = new System.Guid("be7fd746-a182-4eb1-9329-c9cd9a3e64cd");
            this.dockPanel2.Location = new System.Drawing.Point(200, 55);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel2.Size = new System.Drawing.Size(200, 748);
            this.dockPanel2.Text = "dockPanel2";
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 38);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(189, 706);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // dockPanel3
            // 
            this.dockPanel3.Controls.Add(this.dockPanel3_Container);
            this.dockPanel3.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel3.ID = new System.Guid("b4fe882b-ece4-4a72-bbe1-c2892fbad5fd");
            this.dockPanel3.Location = new System.Drawing.Point(400, 55);
            this.dockPanel3.Name = "dockPanel3";
            this.dockPanel3.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel3.Size = new System.Drawing.Size(200, 748);
            this.dockPanel3.Text = "dockPanel3";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Location = new System.Drawing.Point(4, 38);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(189, 706);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // dockPanel4
            // 
            this.dockPanel4.Controls.Add(this.dockPanel4_Container);
            this.dockPanel4.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel4.ID = new System.Guid("d9363b6f-7add-43ac-97cc-f9727fbb313c");
            this.dockPanel4.Location = new System.Drawing.Point(600, 55);
            this.dockPanel4.Name = "dockPanel4";
            this.dockPanel4.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel4.Size = new System.Drawing.Size(200, 748);
            this.dockPanel4.Text = "dockPanel4";
            // 
            // dockPanel4_Container
            // 
            this.dockPanel4_Container.Location = new System.Drawing.Point(4, 38);
            this.dockPanel4_Container.Name = "dockPanel4_Container";
            this.dockPanel4_Container.Size = new System.Drawing.Size(189, 706);
            this.dockPanel4_Container.TabIndex = 0;
            // 
            // dockPanel5
            // 
            this.dockPanel5.Controls.Add(this.dockPanel5_Container);
            this.dockPanel5.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel5.ID = new System.Guid("21088ebf-93b0-4323-9448-bc8f0e068fa7");
            this.dockPanel5.Location = new System.Drawing.Point(800, 55);
            this.dockPanel5.Name = "dockPanel5";
            this.dockPanel5.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel5.Size = new System.Drawing.Size(200, 748);
            this.dockPanel5.Text = "dockPanel5";
            // 
            // dockPanel5_Container
            // 
            this.dockPanel5_Container.Location = new System.Drawing.Point(4, 38);
            this.dockPanel5_Container.Name = "dockPanel5_Container";
            this.dockPanel5_Container.Size = new System.Drawing.Size(189, 706);
            this.dockPanel5_Container.TabIndex = 0;
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1327, 905);
            this.Controls.Add(this.dockPanel_Log);
            this.Controls.Add(this.dockPanel9);
            this.Controls.Add(this.dockPanel8);
            this.Controls.Add(this.dockPanel7);
            this.Controls.Add(this.dockPanel6);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Main_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dev_MainBarManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dev_MainDockManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckedComboBoxEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel3.ResumeLayout(false);
            this.dockPanel4.ResumeLayout(false);
            this.dockPanel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager dev_MainBarManager;
        private DevExpress.XtraBars.Bar dx_ToolBar;
        private DevExpress.XtraBars.Bar dev_MainStatusBar;
        private DevExpress.XtraBars.Bar dev_MainMenuBar;
        private DevExpress.XtraBars.BarButtonItem btn_Login;
        private DevExpress.XtraBars.BarSubItem btn_View;
        private DevExpress.XtraBars.BarButtonItem btn_DefaultView;
        private DevExpress.XtraBars.BarCheckItem btn_ShowTool;
        private DevExpress.XtraBars.BarButtonItem btn_HardwareCamera;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckedComboBoxEdit repositoryItemCheckedComboBoxEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraBars.Docking.DockManager dev_MainDockManager;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel_Log;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel9;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel8;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel7;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel6;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel3;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel4;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel4_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel5;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel5_Container;
        
    }
}