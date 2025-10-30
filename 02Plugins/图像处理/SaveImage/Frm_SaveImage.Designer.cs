namespace SaveImage
{
    partial class Frm_SaveImage
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.chk_LinkPath = new DevExpress.XtraEditors.CheckEdit();
            this.uLink2 = new VisionCore.UserControls.uLink();
            this.chk_LocalPath = new DevExpress.XtraEditors.CheckEdit();
            this.btn_Select = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cmb_ImageFormat = new DevExpress.XtraEditors.ComboBoxEdit();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.uLink1 = new VisionCore.UserControls.uLink();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chk_LinkPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_LocalPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Select.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_ImageFormat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
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
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 203.3337F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(591, 688);
            this.tablePanel1.TabIndex = 2;
            this.tablePanel1.UseSkinIndents = true;
            // 
            // groupControl2
            // 
            this.tablePanel1.SetColumn(this.groupControl2, 0);
            this.groupControl2.Controls.Add(this.groupControl3);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.cmb_ImageFormat);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(19, 221);
            this.groupControl2.Name = "groupControl2";
            this.tablePanel1.SetRow(this.groupControl2, 1);
            this.groupControl2.Size = new System.Drawing.Size(553, 448);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "文件设置";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.chk_LinkPath);
            this.groupControl3.Controls.Add(this.uLink2);
            this.groupControl3.Controls.Add(this.chk_LocalPath);
            this.groupControl3.Controls.Add(this.btn_Select);
            this.groupControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl3.Location = new System.Drawing.Point(2, 34);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(549, 140);
            this.groupControl3.TabIndex = 11;
            this.groupControl3.Text = "保存路径";
            // 
            // chk_LinkPath
            // 
            this.chk_LinkPath.Location = new System.Drawing.Point(343, 45);
            this.chk_LinkPath.Name = "chk_LinkPath";
            this.chk_LinkPath.Properties.Caption = "链接数据";
            this.chk_LinkPath.Size = new System.Drawing.Size(112, 27);
            this.chk_LinkPath.TabIndex = 9;
            // 
            // uLink2
            // 
            this.uLink2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uLink2.Location = new System.Drawing.Point(5, 82);
            this.uLink2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uLink2.Name = "uLink2";
            this.uLink2.SelectedPath = "";
            this.uLink2.Size = new System.Drawing.Size(539, 54);
            this.uLink2.TabIndex = 1;
            this.uLink2.Visible = false;
            // 
            // chk_LocalPath
            // 
            this.chk_LocalPath.Location = new System.Drawing.Point(108, 45);
            this.chk_LocalPath.Name = "chk_LocalPath";
            this.chk_LocalPath.Properties.Caption = "本地路径";
            this.chk_LocalPath.Size = new System.Drawing.Size(112, 27);
            this.chk_LocalPath.TabIndex = 8;
            // 
            // btn_Select
            // 
            this.btn_Select.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Select.Location = new System.Drawing.Point(5, 97);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "选择文件", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.btn_Select.Properties.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btn_SelectFolder_Properties_ButtonClick);
            this.btn_Select.Size = new System.Drawing.Size(539, 28);
            this.btn_Select.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl4.Location = new System.Drawing.Point(16, 187);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(72, 22);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "图像格式";
            // 
            // cmb_ImageFormat
            // 
            this.cmb_ImageFormat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_ImageFormat.Location = new System.Drawing.Point(110, 185);
            this.cmb_ImageFormat.Name = "cmb_ImageFormat";
            this.cmb_ImageFormat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_ImageFormat.Size = new System.Drawing.Size(398, 28);
            this.cmb_ImageFormat.TabIndex = 9;
            // 
            // groupControl1
            // 
            this.tablePanel1.SetColumn(this.groupControl1, 0);
            this.groupControl1.Controls.Add(this.uLink1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(19, 18);
            this.groupControl1.Name = "groupControl1";
            this.tablePanel1.SetRow(this.groupControl1, 0);
            this.groupControl1.Size = new System.Drawing.Size(553, 197);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "图像设置";
            // 
            // uLink1
            // 
            this.uLink1.Location = new System.Drawing.Point(5, 49);
            this.uLink1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.uLink1.Name = "uLink1";
            this.uLink1.SelectedPath = "";
            this.uLink1.Size = new System.Drawing.Size(543, 49);
            this.uLink1.TabIndex = 0;
            // 
            // Frm_SaveImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 764);
            this.Controls.Add(this.tablePanel1);
            this.Name = "Frm_SaveImage";
            this.Text = "Frm_SaveImage";
            this.Controls.SetChildIndex(this.tablePanel1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chk_LinkPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_LocalPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Select.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_ImageFormat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private VisionCore.UserControls.uLink uLink1;
        private DevExpress.XtraEditors.ButtonEdit btn_Select;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_ImageFormat;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.CheckEdit chk_LinkPath;
        private VisionCore.UserControls.uLink uLink2;
        private DevExpress.XtraEditors.CheckEdit chk_LocalPath;
    }
}