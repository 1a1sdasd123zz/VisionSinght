namespace VisionCore.ToolBase
{
    partial class Frm_ToolBase
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
            this.btn_Cancel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Confirm = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Run = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.txt_State = new DevExpress.XtraEditors.LabelControl();
            this.txt_Time = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Appearance.BackColor = System.Drawing.Color.Red;
            this.btn_Cancel.Appearance.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btn_Cancel.Appearance.Options.UseBackColor = true;
            this.btn_Cancel.Appearance.Options.UseFont = true;
            this.btn_Cancel.Location = new System.Drawing.Point(1321, 16);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(109, 44);
            this.btn_Cancel.TabIndex = 2;
            this.btn_Cancel.Text = "取消";
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Confirm.Appearance.BackColor = System.Drawing.Color.Lime;
            this.btn_Confirm.Appearance.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btn_Confirm.Appearance.Options.UseBackColor = true;
            this.btn_Confirm.Appearance.Options.UseFont = true;
            this.btn_Confirm.Location = new System.Drawing.Point(1202, 16);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(109, 44);
            this.btn_Confirm.TabIndex = 1;
            this.btn_Confirm.Text = "确定";
            // 
            // btn_Run
            // 
            this.btn_Run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Run.Appearance.BackColor = System.Drawing.Color.Blue;
            this.btn_Run.Appearance.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.btn_Run.Appearance.Options.UseBackColor = true;
            this.btn_Run.Appearance.Options.UseFont = true;
            this.btn_Run.Location = new System.Drawing.Point(1083, 16);
            this.btn_Run.Name = "btn_Run";
            this.btn_Run.Size = new System.Drawing.Size(109, 44);
            this.btn_Run.TabIndex = 0;
            this.btn_Run.Text = "执行";
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.SlateBlue;
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.Controls.Add(this.txt_State);
            this.panelControl2.Controls.Add(this.txt_Time);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.btn_Cancel);
            this.panelControl2.Controls.Add(this.btn_Run);
            this.panelControl2.Controls.Add(this.btn_Confirm);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 688);
            this.panelControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1445, 76);
            this.panelControl2.TabIndex = 1;
            // 
            // txt_State
            // 
            this.txt_State.Appearance.ForeColor = System.Drawing.Color.White;
            this.txt_State.Appearance.Options.UseForeColor = true;
            this.txt_State.Location = new System.Drawing.Point(68, 44);
            this.txt_State.Name = "txt_State";
            this.txt_State.Size = new System.Drawing.Size(59, 22);
            this.txt_State.TabIndex = 6;
            this.txt_State.Text = "NotRun";
            // 
            // txt_Time
            // 
            this.txt_Time.Location = new System.Drawing.Point(68, 11);
            this.txt_Time.Name = "txt_Time";
            this.txt_Time.Size = new System.Drawing.Size(39, 22);
            this.txt_Time.TabIndex = 5;
            this.txt_Time.Text = "0 ms";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(13, 44);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(42, 22);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "状态:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 11);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(42, 22);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "耗时:";
            // 
            // Frm_ToolBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 764);
            this.Controls.Add(this.panelControl2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 800);
            this.Name = "Frm_ToolBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_ToolBase";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btn_Cancel;
        private DevExpress.XtraEditors.SimpleButton btn_Confirm;
        private DevExpress.XtraEditors.SimpleButton btn_Run;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl txt_Time;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl txt_State;
    }
}