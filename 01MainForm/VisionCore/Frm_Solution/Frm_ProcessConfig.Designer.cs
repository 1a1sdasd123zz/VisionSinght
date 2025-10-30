namespace VisionCore.Frm_Solution
{
    partial class Frm_ProcessConfig
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            this.bar_Main = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btn_Add = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Remove = new DevExpress.XtraBars.BarButtonItem();
            this.btn_AddFile = new DevExpress.XtraBars.BarButtonItem();
            this.btn_RemoveFile = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.mbtn_Copy = new DevExpress.XtraBars.BarButtonItem();
            this.mbtn_Paste = new DevExpress.XtraBars.BarButtonItem();
            this.tree_PressTree = new System.Windows.Forms.TreeView();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            this.mbtn_Remove = new DevExpress.XtraBars.BarButtonItem();
            this.mbtn_ReName = new DevExpress.XtraBars.BarButtonItem();
            this.mbtn_Enable = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.bar_Main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // bar_Main
            // 
            this.bar_Main.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.bar_Main.DockControls.Add(this.barDockControlTop);
            this.bar_Main.DockControls.Add(this.barDockControlBottom);
            this.bar_Main.DockControls.Add(this.barDockControlLeft);
            this.bar_Main.DockControls.Add(this.barDockControlRight);
            this.bar_Main.Form = this;
            this.bar_Main.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btn_Add,
            this.btn_Remove,
            this.btn_AddFile,
            this.btn_RemoveFile,
            this.mbtn_Copy,
            this.mbtn_Paste,
            this.mbtn_Remove,
            this.mbtn_ReName,
            this.mbtn_Enable});
            this.bar_Main.MainMenu = this.bar2;
            this.bar_Main.MaxItemId = 24;
            // 
            // bar2
            // 
            this.bar2.BarName = "主菜单";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Add),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_Remove),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_AddFile),
            new DevExpress.XtraBars.LinkPersistInfo(this.btn_RemoveFile)});
            this.bar2.OptionsBar.DrawBorder = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "主菜单";
            // 
            // btn_Add
            // 
            this.btn_Add.Id = 4;
            this.btn_Add.ImageOptions.SvgImage = global::VisionCore.Properties.Resources.添加流程;
            this.btn_Add.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btn_Add.Name = "btn_Add";
            toolTipItem1.Text = "添加流程";
            superToolTip1.Items.Add(toolTipItem1);
            this.btn_Add.SuperTip = superToolTip1;
            this.btn_Add.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Add_ItemClick);
            // 
            // btn_Remove
            // 
            this.btn_Remove.Id = 5;
            this.btn_Remove.ImageOptions.SvgImage = global::VisionCore.Properties.Resources.删除流程;
            this.btn_Remove.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btn_Remove.Name = "btn_Remove";
            toolTipItem2.Text = "删除流程";
            superToolTip2.Items.Add(toolTipItem2);
            this.btn_Remove.SuperTip = superToolTip2;
            this.btn_Remove.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Remove_ItemClick);
            // 
            // btn_AddFile
            // 
            this.btn_AddFile.Id = 6;
            this.btn_AddFile.ImageOptions.SvgImage = global::VisionCore.Properties.Resources.添加文件夹;
            this.btn_AddFile.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btn_AddFile.Name = "btn_AddFile";
            toolTipItem3.Text = "添加文件夹";
            superToolTip3.Items.Add(toolTipItem3);
            this.btn_AddFile.SuperTip = superToolTip3;
            this.btn_AddFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_AddFile_ItemClick);
            // 
            // btn_RemoveFile
            // 
            this.btn_RemoveFile.Id = 8;
            this.btn_RemoveFile.ImageOptions.SvgImage = global::VisionCore.Properties.Resources.删除文件夹;
            this.btn_RemoveFile.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btn_RemoveFile.Name = "btn_RemoveFile";
            toolTipItem4.Text = "删除文件夹";
            superToolTip4.Items.Add(toolTipItem4);
            this.btn_RemoveFile.SuperTip = superToolTip4;
            this.btn_RemoveFile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_RemoveFile_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.barDockControlTop.Appearance.Options.UseBackColor = true;
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.bar_Main;
            this.barDockControlTop.Size = new System.Drawing.Size(379, 46);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 734);
            this.barDockControlBottom.Manager = this.bar_Main;
            this.barDockControlBottom.Size = new System.Drawing.Size(379, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 46);
            this.barDockControlLeft.Manager = this.bar_Main;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 688);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(379, 46);
            this.barDockControlRight.Manager = this.bar_Main;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 688);
            // 
            // mbtn_Copy
            // 
            this.mbtn_Copy.Caption = "复制";
            this.mbtn_Copy.Id = 19;
            this.mbtn_Copy.Name = "mbtn_Copy";
            // 
            // mbtn_Paste
            // 
            this.mbtn_Paste.Caption = "粘贴";
            this.mbtn_Paste.Id = 20;
            this.mbtn_Paste.Name = "mbtn_Paste";
            // 
            // tree_PressTree
            // 
            this.tree_PressTree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tree_PressTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_PressTree.Location = new System.Drawing.Point(0, 46);
            this.tree_PressTree.Name = "tree_PressTree";
            this.tree_PressTree.Size = new System.Drawing.Size(379, 688);
            this.tree_PressTree.TabIndex = 4;
            // 
            // popupMenu1
            // 
            this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mbtn_Copy),
            new DevExpress.XtraBars.LinkPersistInfo(this.mbtn_Paste),
            new DevExpress.XtraBars.LinkPersistInfo(this.mbtn_Remove),
            new DevExpress.XtraBars.LinkPersistInfo(this.mbtn_ReName),
            new DevExpress.XtraBars.LinkPersistInfo(this.mbtn_Enable)});
            this.popupMenu1.Manager = this.bar_Main;
            this.popupMenu1.Name = "popupMenu1";
            // 
            // mbtn_Remove
            // 
            this.mbtn_Remove.Caption = "删除";
            this.mbtn_Remove.Id = 21;
            this.mbtn_Remove.Name = "mbtn_Remove";
            // 
            // mbtn_ReName
            // 
            this.mbtn_ReName.Caption = "重命名";
            this.mbtn_ReName.Id = 22;
            this.mbtn_ReName.Name = "mbtn_ReName";
            // 
            // mbtn_Enable
            // 
            this.mbtn_Enable.Caption = "禁用";
            this.mbtn_Enable.Id = 23;
            this.mbtn_Enable.Name = "mbtn_Enable";
            // 
            // Frm_ProcessConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tree_PressTree);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.LookAndFeel.SkinName = "The Bezier";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Frm_ProcessConfig";
            this.Size = new System.Drawing.Size(379, 734);
            this.Load += new System.EventHandler(this.Frm_PressConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bar_Main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager bar_Main;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btn_Add;
        private DevExpress.XtraBars.BarButtonItem btn_Remove;
        private DevExpress.XtraBars.BarButtonItem btn_AddFile;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btn_RemoveFile;
        private System.Windows.Forms.TreeView tree_PressTree;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem mbtn_Copy;
        private DevExpress.XtraBars.BarButtonItem mbtn_Paste;
        private DevExpress.XtraBars.BarButtonItem mbtn_Remove;
        private DevExpress.XtraBars.BarButtonItem mbtn_ReName;
        private DevExpress.XtraBars.BarButtonItem mbtn_Enable;
    }
}
