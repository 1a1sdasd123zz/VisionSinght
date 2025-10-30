namespace VisionCore.Frm_Solution
{
    partial class Frm_ProcessBar
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bar_Main = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btn_Start = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Continuous = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Stop = new DevExpress.XtraBars.BarButtonItem();
            this.txt_ProName = new DevExpress.XtraBars.BarStaticItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.txt_Time = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.repositoryItemFontEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemFontEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tree_PressTree = new System.Windows.Forms.TreeView();
            this.popupMenuTool = new DevExpress.XtraBars.PopupMenu(this.components);
            this.btn_SetEnable = new DevExpress.XtraBars.BarButtonItem();
            this.btn_RemoveTool = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuTool)).BeginInit();
            this.SuspendLayout();
            // 
            // bar_Main
            // 
            this.bar_Main.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.bar_Main.DockControls.Add(this.barDockControlTop);
            this.bar_Main.DockControls.Add(this.barDockControlBottom);
            this.bar_Main.DockControls.Add(this.barDockControlLeft);
            this.bar_Main.DockControls.Add(this.barDockControlRight);
            this.bar_Main.Form = this;
            this.bar_Main.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_Start,
            this.btn_Continuous,
            this.btn_Stop,
            this.barStaticItem1,
            this.txt_Time,
            this.txt_ProName});
            this.bar_Main.MainMenu = this.bar2;
            this.bar_Main.MaxItemId = 17;
            this.bar_Main.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTimeEdit1,
            this.repositoryItemFontEdit1});
            this.bar_Main.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "主菜单";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Start),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Continuous),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Stop),
            new DevExpress.XtraBars.LinkPersistInfo(this.txt_ProName)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "主菜单";
            // 
            // btn_Start
            // 
            this.btn_Start.Id = 4;
            this.btn_Start.ImageOptions.SvgImage = global::VisionCore.Properties.Resources.开始执行;
            this.btn_Start.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btn_Start.Name = "btn_Start";
            // 
            // btn_Continuous
            // 
            this.btn_Continuous.Id = 5;
            this.btn_Continuous.ImageOptions.SvgImage = global::VisionCore.Properties.Resources.循环执行;
            this.btn_Continuous.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btn_Continuous.Name = "btn_Continuous";
            // 
            // btn_Stop
            // 
            this.btn_Stop.Id = 6;
            this.btn_Stop.ImageOptions.SvgImage = global::VisionCore.Properties.Resources.停止执行;
            this.btn_Stop.ImageOptions.SvgImageSize = new System.Drawing.Size(24, 24);
            this.btn_Stop.Name = "btn_Stop";
            // 
            // txt_ProName
            // 
            this.txt_ProName.Caption = "barStaticItem2";
            this.txt_ProName.Id = 16;
            this.txt_ProName.Name = "txt_ProName";
            // 
            // bar3
            // 
            this.bar3.BarName = "状态栏";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barStaticItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.txt_Time)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawBorder = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "状态栏";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "流程耗时:";
            this.barStaticItem1.Id = 13;
            this.barStaticItem1.ItemAppearance.Normal.ForeColor = System.Drawing.Color.White;
            this.barStaticItem1.ItemAppearance.Normal.Options.UseForeColor = true;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // txt_Time
            // 
            this.txt_Time.Caption = "0ms";
            this.txt_Time.Id = 14;
            this.txt_Time.ItemAppearance.Normal.ForeColor = System.Drawing.Color.White;
            this.txt_Time.ItemAppearance.Normal.Options.UseForeColor = true;
            this.txt_Time.Name = "txt_Time";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.barDockControlTop.Appearance.Options.UseBackColor = true;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.bar_Main;
            this.barDockControlTop.Size = new System.Drawing.Size(368, 66);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.barDockControlBottom.Appearance.Options.UseBackColor = true;
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 664);
            this.barDockControlBottom.Manager = this.bar_Main;
            this.barDockControlBottom.Size = new System.Drawing.Size(368, 33);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 66);
            this.barDockControlLeft.Manager = this.bar_Main;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 598);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(368, 66);
            this.barDockControlRight.Manager = this.bar_Main;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 598);
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // repositoryItemFontEdit1
            // 
            this.repositoryItemFontEdit1.AutoHeight = false;
            this.repositoryItemFontEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemFontEdit1.Name = "repositoryItemFontEdit1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.tree_PressTree);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 66);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(368, 598);
            this.panelControl1.TabIndex = 4;
            // 
            // tree_PressTree
            // 
            this.tree_PressTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tree_PressTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_PressTree.Location = new System.Drawing.Point(2, 2);
            this.tree_PressTree.Name = "tree_PressTree";
            this.tree_PressTree.Size = new System.Drawing.Size(364, 594);
            this.tree_PressTree.TabIndex = 0;
            // 
            // popupMenuTool
            // 
            this.popupMenuTool.Manager = this.bar_Main;
            this.popupMenuTool.Name = "popupMenuTool";
            this.popupMenuTool.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_SetEnable),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_RemoveTool)});
            // 
            // btn_SetEnable
            // 
            this.btn_SetEnable.Caption = "禁用";
            this.btn_SetEnable.Id = 50;
            this.btn_SetEnable.Name = "btn_SetEnable";
            // 
            // btn_RemoveTool
            // 
            this.btn_RemoveTool.Caption = "删除工具";
            this.btn_RemoveTool.Id = 51;
            this.btn_RemoveTool.Name = "btn_RemoveTool";
            // 
            // Frm_ProcessBar
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Frm_ProcessBar";
            this.Size = new System.Drawing.Size(368, 697);
            ((System.ComponentModel.ISupportInitialize)(this.bar_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenuTool)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager bar_Main;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarButtonItem btn_Start;
        private DevExpress.XtraBars.BarButtonItem btn_Continuous;
        private DevExpress.XtraBars.BarButtonItem btn_Stop;
        private System.Windows.Forms.TreeView tree_PressTree;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemFontEdit repositoryItemFontEdit1;
        private DevExpress.XtraBars.BarStaticItem txt_Time;
        private DevExpress.XtraBars.BarStaticItem txt_ProName;
        private DevExpress.XtraBars.PopupMenu popupMenuTool;
        private DevExpress.XtraBars.BarButtonItem btn_SetEnable;
        private DevExpress.XtraBars.BarButtonItem btn_RemoveTool;
    }
}
