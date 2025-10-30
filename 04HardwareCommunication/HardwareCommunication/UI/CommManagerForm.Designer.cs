namespace HardwareCommunication.UI
{
    partial class CommManagerForm
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.split = new System.Windows.Forms.SplitContainer();
            this.lst = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.rightHost = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
            this.split.Panel1.SuspendLayout();
            this.split.Panel2.SuspendLayout();
            this.split.SuspendLayout();
            this.SuspendLayout();
            // 
            // split
            // 
            this.split.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split.Location = new System.Drawing.Point(0, 0);
            this.split.Name = "split";
            // 
            // split.Panel1
            // 
            this.split.Panel1.Controls.Add(this.lst);
            this.split.Panel1.Controls.Add(this.btnAdd);
            // 
            // split.Panel2
            // 
            this.split.Panel2.Controls.Add(this.rightHost);
            this.split.Panel2.Controls.Add(this.lblTitle);
            this.split.Size = new System.Drawing.Size(1000, 650);
            this.split.SplitterDistance = 155;
            this.split.TabIndex = 0;
            // 
            // lst
            // 
            this.lst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lst.ItemHeight = 18;
            this.lst.Location = new System.Drawing.Point(0, 0);
            this.lst.Name = "lst";
            this.lst.Size = new System.Drawing.Size(155, 614);
            this.lst.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(0, 614);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(155, 36);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "+";
            // 
            // rightHost
            // 
            this.rightHost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightHost.Location = new System.Drawing.Point(0, 28);
            this.rightHost.Name = "rightHost";
            this.rightHost.Size = new System.Drawing.Size(841, 622);
            this.rightHost.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(841, 28);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CommManagerForm
            // 
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.split);
            this.Name = "CommManagerForm";
            this.Text = "通讯管理";
            this.split.Panel1.ResumeLayout(false);
            this.split.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
            this.split.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.SplitContainer split;
        private System.Windows.Forms.ListBox lst;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel rightHost;
        private System.Windows.Forms.Label lblTitle;
    }
}
