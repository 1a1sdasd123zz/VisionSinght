namespace LocalImage
{
    sealed partial class Frm_Local
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject9 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject10 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject11 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject12 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.panel_FileMode = new DevExpress.XtraEditors.PanelControl();
            this.pannel_FolderMode = new DevExpress.Utils.Layout.TablePanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chk_FolderMode = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.chk_Folder = new DevExpress.XtraEditors.CheckEdit();
            this.chk_File = new DevExpress.XtraEditors.CheckEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.showDisplay1 = new VisionCore.UserControls.ShowDisplay();
            this.btn_SelectFolder = new DevExpress.XtraEditors.ButtonEdit();
            this.btn_SelectFile = new DevExpress.XtraEditors.ButtonEdit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panel_FileMode)).BeginInit();
            this.panel_FileMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pannel_FolderMode)).BeginInit();
            this.pannel_FolderMode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_FolderMode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_Folder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_File.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
            this.splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
            this.splitContainerControl1.Panel2.SuspendLayout();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_SelectFolder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_SelectFile.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F)});
            this.tablePanel1.Controls.Add(this.groupControl2);
            this.tablePanel1.Controls.Add(this.groupControl1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 111.3333F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(515, 859);
            this.tablePanel1.TabIndex = 0;
            this.tablePanel1.UseSkinIndents = true;
            // 
            // groupControl2
            // 
            this.groupControl2.AppearanceCaption.ForeColor = System.Drawing.Color.White;
            this.groupControl2.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.tablePanel1.SetColumn(this.groupControl2, 0);
            this.groupControl2.Controls.Add(this.panel_FileMode);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(19, 129);
            this.groupControl2.Name = "groupControl2";
            this.tablePanel1.SetRow(this.groupControl2, 1);
            this.groupControl2.Size = new System.Drawing.Size(477, 711);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "加载模式";
            // 
            // panel_FileMode
            // 
            this.panel_FileMode.Controls.Add(this.pannel_FolderMode);
            this.panel_FileMode.Controls.Add(this.btn_SelectFile);
            this.panel_FileMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_FileMode.Location = new System.Drawing.Point(2, 34);
            this.panel_FileMode.Name = "panel_FileMode";
            this.panel_FileMode.Size = new System.Drawing.Size(473, 675);
            this.panel_FileMode.TabIndex = 2;
            // 
            // pannel_FolderMode
            // 
            this.pannel_FolderMode.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F)});
            this.pannel_FolderMode.Controls.Add(this.gridControl1);
            this.pannel_FolderMode.Controls.Add(this.panelControl1);
            this.pannel_FolderMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pannel_FolderMode.Location = new System.Drawing.Point(2, 2);
            this.pannel_FolderMode.Name = "pannel_FolderMode";
            this.pannel_FolderMode.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 68.66669F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.pannel_FolderMode.Size = new System.Drawing.Size(469, 671);
            this.pannel_FolderMode.TabIndex = 4;
            this.pannel_FolderMode.UseSkinIndents = true;
            // 
            // gridControl1
            // 
            this.pannel_FolderMode.SetColumn(this.gridControl1, 0);
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(19, 87);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.pannel_FolderMode.SetRow(this.gridControl1, 1);
            this.gridControl1.Size = new System.Drawing.Size(431, 565);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridView1.OptionsCustomization.AllowColumnResizing = false;
            this.gridView1.OptionsMenu.ShowConditionalFormattingItem = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.PaintStyleName = "Skin";
            // 
            // panelControl1
            // 
            this.panelControl1.AutoSize = true;
            this.pannel_FolderMode.SetColumn(this.panelControl1, 0);
            this.panelControl1.Controls.Add(this.btn_SelectFolder);
            this.panelControl1.Controls.Add(this.chk_FolderMode);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(19, 18);
            this.panelControl1.Name = "panelControl1";
            this.pannel_FolderMode.SetRow(this.panelControl1, 0);
            this.panelControl1.Size = new System.Drawing.Size(431, 63);
            this.panelControl1.TabIndex = 4;
            // 
            // chk_FolderMode
            // 
            this.chk_FolderMode.Location = new System.Drawing.Point(8, 11);
            this.chk_FolderMode.Name = "chk_FolderMode";
            this.chk_FolderMode.Properties.Caption = "循环";
            this.chk_FolderMode.Size = new System.Drawing.Size(65, 27);
            this.chk_FolderMode.TabIndex = 3;
            this.chk_FolderMode.ToolTip = "所有图片循环执行";
            // 
            // groupControl1
            // 
            this.groupControl1.AppearanceCaption.ForeColor = System.Drawing.Color.White;
            this.groupControl1.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.tablePanel1.SetColumn(this.groupControl1, 0);
            this.groupControl1.Controls.Add(this.chk_Folder);
            this.groupControl1.Controls.Add(this.chk_File);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(19, 18);
            this.groupControl1.Name = "groupControl1";
            this.tablePanel1.SetRow(this.groupControl1, 0);
            this.groupControl1.Size = new System.Drawing.Size(477, 105);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "加载模式";
            // 
            // chk_Folder
            // 
            this.chk_Folder.Location = new System.Drawing.Point(274, 55);
            this.chk_Folder.Name = "chk_Folder";
            this.chk_Folder.Properties.Caption = "文件目录";
            this.chk_Folder.Size = new System.Drawing.Size(112, 27);
            this.chk_Folder.TabIndex = 5;
            this.chk_Folder.CheckedChanged += new System.EventHandler(this.chk_Folder_CheckedChanged);
            // 
            // chk_File
            // 
            this.chk_File.Location = new System.Drawing.Point(60, 55);
            this.chk_File.Name = "chk_File";
            this.chk_File.Properties.Caption = "指定文件";
            this.chk_File.Size = new System.Drawing.Size(112, 27);
            this.chk_File.TabIndex = 4;
            this.chk_File.CheckedChanged += new System.EventHandler(this.chk_File_CheckedChanged);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            this.splitContainerControl1.Panel1.Controls.Add(this.tablePanel1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl3);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1338, 859);
            this.splitContainerControl1.SplitterPosition = 515;
            this.splitContainerControl1.TabIndex = 2;
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.showDisplay1);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(808, 859);
            this.panelControl3.TabIndex = 0;
            // 
            // showDisplay1
            // 
            this.showDisplay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showDisplay1.Location = new System.Drawing.Point(2, 2);
            this.showDisplay1.Name = "showDisplay1";
            this.showDisplay1.ShowFixedCenterCrosshair = false;
            this.showDisplay1.Size = new System.Drawing.Size(804, 855);
            this.showDisplay1.TabIndex = 0;
            // 
            // btn_SelectFolder
            // 
            this.btn_SelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SelectFolder.Location = new System.Drawing.Point(96, 10);
            this.btn_SelectFolder.Name = "btn_SelectFolder";
            this.btn_SelectFolder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject9, serializableAppearanceObject10, serializableAppearanceObject11, serializableAppearanceObject12, "选择文件", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btn_SelectFolder.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btn_SelectFolder_Properties_ButtonClick);
            this.btn_SelectFolder.Size = new System.Drawing.Size(322, 28);
            this.btn_SelectFolder.TabIndex = 6;
            // 
            // btn_SelectFile
            // 
            this.btn_SelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_SelectFile.Location = new System.Drawing.Point(27, 323);
            this.btn_SelectFile.Name = "btn_SelectFile";
            this.btn_SelectFile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "选择文件", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btn_SelectFile.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btn_SelectFile_Properties_ButtonClick);
            this.btn_SelectFile.Size = new System.Drawing.Size(430, 28);
            this.btn_SelectFile.TabIndex = 7;
            // 
            // Frm_Local
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 935);
            this.Controls.Add(this.splitContainerControl1);
            this.Name = "Frm_Local";
            this.Text = "Frm_Local";
            this.Controls.SetChildIndex(this.splitContainerControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panel_FileMode)).EndInit();
            this.panel_FileMode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pannel_FolderMode)).EndInit();
            this.pannel_FolderMode.ResumeLayout(false);
            this.pannel_FolderMode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chk_FolderMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chk_Folder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_File.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
            this.splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
            this.splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_SelectFolder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_SelectFile.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.PanelControl panel_FileMode;
        private DevExpress.Utils.Layout.TablePanel pannel_FolderMode;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.CheckEdit chk_FolderMode;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit chk_Folder;
        private DevExpress.XtraEditors.CheckEdit chk_File;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private VisionCore.UserControls.ShowDisplay showDisplay1;
        private DevExpress.XtraEditors.ButtonEdit btn_SelectFolder;
        private DevExpress.XtraEditors.ButtonEdit btn_SelectFile;
    }
}