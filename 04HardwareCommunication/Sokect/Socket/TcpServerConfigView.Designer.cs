namespace SocketComm
{
    partial class TcpServerConfigView
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_SendMessage = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.btn_ClearSendText = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_ClearRe = new System.Windows.Forms.Button();
            this.tb_ReMessage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_IP = new System.Windows.Forms.TextBox();
            this.tb_Port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_Format = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(904, 728);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(898, 286);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.cb_Format);
            this.panel3.Controls.Add(this.tb_Port);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.tb_IP);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 587);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(898, 138);
            this.panel3.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_ClearSendText);
            this.groupBox1.Controls.Add(this.btn_Send);
            this.groupBox1.Controls.Add(this.tb_SendMessage);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(898, 286);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "发送数据";
            // 
            // tb_SendMessage
            // 
            this.tb_SendMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_SendMessage.Location = new System.Drawing.Point(3, 24);
            this.tb_SendMessage.Multiline = true;
            this.tb_SendMessage.Name = "tb_SendMessage";
            this.tb_SendMessage.Size = new System.Drawing.Size(892, 210);
            this.tb_SendMessage.TabIndex = 0;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(613, 241);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(117, 39);
            this.btn_Send.TabIndex = 1;
            this.btn_Send.Text = "发送";
            this.btn_Send.UseVisualStyleBackColor = true;
            // 
            // btn_ClearSendText
            // 
            this.btn_ClearSendText.Location = new System.Drawing.Point(749, 241);
            this.btn_ClearSendText.Name = "btn_ClearSendText";
            this.btn_ClearSendText.Size = new System.Drawing.Size(117, 39);
            this.btn_ClearSendText.TabIndex = 2;
            this.btn_ClearSendText.Text = "清空";
            this.btn_ClearSendText.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_ClearRe);
            this.groupBox2.Controls.Add(this.tb_ReMessage);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(898, 286);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "接收数据";
            // 
            // btn_ClearRe
            // 
            this.btn_ClearRe.Location = new System.Drawing.Point(749, 241);
            this.btn_ClearRe.Name = "btn_ClearRe";
            this.btn_ClearRe.Size = new System.Drawing.Size(117, 39);
            this.btn_ClearRe.TabIndex = 2;
            this.btn_ClearRe.Text = "清空";
            this.btn_ClearRe.UseVisualStyleBackColor = true;
            // 
            // tb_ReMessage
            // 
            this.tb_ReMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_ReMessage.Location = new System.Drawing.Point(3, 24);
            this.tb_ReMessage.Multiline = true;
            this.tb_ReMessage.Name = "tb_ReMessage";
            this.tb_ReMessage.Size = new System.Drawing.Size(892, 210);
            this.tb_ReMessage.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "目标IP";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tb_IP
            // 
            this.tb_IP.Location = new System.Drawing.Point(120, 30);
            this.tb_IP.Name = "tb_IP";
            this.tb_IP.Size = new System.Drawing.Size(270, 28);
            this.tb_IP.TabIndex = 1;
            // 
            // tb_Port
            // 
            this.tb_Port.Location = new System.Drawing.Point(120, 74);
            this.tb_Port.Name = "tb_Port";
            this.tb_Port.Size = new System.Drawing.Size(270, 28);
            this.tb_Port.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "端口";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_Format
            // 
            this.cb_Format.FormattingEnabled = true;
            this.cb_Format.Location = new System.Drawing.Point(542, 31);
            this.cb_Format.Name = "cb_Format";
            this.cb_Format.Size = new System.Drawing.Size(170, 26);
            this.cb_Format.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(449, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "编码格式";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TcpServerConfigView
            // 
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "TcpServerConfigView";
            this.Size = new System.Drawing.Size(904, 728);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_ClearRe;
        private System.Windows.Forms.TextBox tb_ReMessage;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_ClearSendText;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.TextBox tb_SendMessage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_Format;
        private System.Windows.Forms.TextBox tb_Port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_IP;
    }
}
