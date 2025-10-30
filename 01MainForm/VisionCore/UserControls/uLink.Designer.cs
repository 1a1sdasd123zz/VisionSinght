namespace VisionCore.UserControls
{
    partial class uLink
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Clear = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Link = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txt_LinkPath = new DevExpress.XtraEditors.TextEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LinkPath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateBlue;
            this.panel1.Controls.Add(this.panelControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 49);
            this.panel1.TabIndex = 1;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.SlateBlue;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btn_Clear);
            this.panelControl1.Controls.Add(this.btn_Link);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.txt_LinkPath);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(448, 49);
            this.panelControl1.TabIndex = 2;
            // 
            // btn_Clear
            // 
            this.btn_Clear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Clear.ImageOptions.SvgImage = global::VisionCore.Properties.Resources.清空;
            this.btn_Clear.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btn_Clear.Location = new System.Drawing.Point(397, 9);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Clear.Size = new System.Drawing.Size(36, 30);
            this.btn_Clear.TabIndex = 3;
            this.btn_Clear.ToolTip = "清除链接";
            // 
            // btn_Link
            // 
            this.btn_Link.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Link.ImageOptions.SvgImage = global::VisionCore.Properties.Resources.链接;
            this.btn_Link.ImageOptions.SvgImageSize = new System.Drawing.Size(20, 20);
            this.btn_Link.Location = new System.Drawing.Point(345, 9);
            this.btn_Link.Name = "btn_Link";
            this.btn_Link.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Link.Size = new System.Drawing.Size(36, 30);
            this.btn_Link.TabIndex = 2;
            this.btn_Link.ToolTip = "链接数据";
            // 
            // labelControl1
            // 
            this.labelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl1.Location = new System.Drawing.Point(4, 14);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 22);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "链接数据";
            // 
            // txt_LinkPath
            // 
            this.txt_LinkPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_LinkPath.EditValue = "";
            this.txt_LinkPath.Location = new System.Drawing.Point(85, 11);
            this.txt_LinkPath.Name = "txt_LinkPath";
            this.txt_LinkPath.Properties.Appearance.BackColor = System.Drawing.Color.Black;
            this.txt_LinkPath.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.txt_LinkPath.Properties.Appearance.Options.UseBackColor = true;
            this.txt_LinkPath.Properties.Appearance.Options.UseForeColor = true;
            this.txt_LinkPath.Size = new System.Drawing.Size(255, 28);
            this.txt_LinkPath.TabIndex = 1;
            // 
            // uLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "uLink";
            this.Size = new System.Drawing.Size(448, 49);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_LinkPath.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txt_LinkPath;
        private DevExpress.XtraEditors.SimpleButton btn_Clear;
        private DevExpress.XtraEditors.SimpleButton btn_Link;
    }
}
