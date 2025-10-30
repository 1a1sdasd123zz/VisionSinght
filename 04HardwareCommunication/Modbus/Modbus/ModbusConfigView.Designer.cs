namespace Modbus
{
    partial class ModbusConfigView
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
            this.txtHost = new System.Windows.Forms.TextBox();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.numConnTo = new System.Windows.Forms.NumericUpDown();
            this.numRecvTo = new System.Windows.Forms.NumericUpDown();
            this.numStation = new System.Windows.Forms.NumericUpDown();
            this.chkZeroBase = new System.Windows.Forms.CheckBox();
            this.cmbFormat = new System.Windows.Forms.ComboBox();
            this.chkStringSwap = new System.Windows.Forms.CheckBox();
            this.cmbChannel = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.numLen = new System.Windows.Forms.NumericUpDown();
            this.cmbEncoding = new System.Windows.Forms.ComboBox();
            this.btnReadU16 = new System.Windows.Forms.Button();
            this.btnWriteU16 = new System.Windows.Forms.Button();
            this.txtWriteVal = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.tableRoot = new System.Windows.Forms.TableLayoutPanel();
            this.line1 = new System.Windows.Forms.FlowLayoutPanel();
            this.line2 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConnTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRecvTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLen)).BeginInit();
            this.tableRoot.SuspendLayout();
            this.SuspendLayout();
            // txtHost
            this.txtHost.Text = "127.0.0.1"; this.txtHost.Width = 140;
            // numPort
            this.numPort.Minimum = 1; this.numPort.Maximum = 65535; this.numPort.Value = 502; this.numPort.Width = 90;
            // numConnTo
            this.numConnTo.Minimum = 100; this.numConnTo.Maximum = 120000; this.numConnTo.Value = 5000; this.numConnTo.Width = 90;
            // numRecvTo
            this.numRecvTo.Minimum = 100; this.numRecvTo.Maximum = 120000; this.numRecvTo.Value = 10000; this.numRecvTo.Width = 90;
            // numStation
            this.numStation.Minimum = 0; this.numStation.Maximum = 255; this.numStation.Value = 1; this.numStation.Width = 60;
            // chkZeroBase
            this.chkZeroBase.AutoSize = true; this.chkZeroBase.Text = "首地址从0开始";
            // cmbFormat
            this.cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbFormat.Width = 80; this.cmbFormat.Items.AddRange(new object[] { "CDAB", "ABCD", "BADC", "DCBA" }); this.cmbFormat.SelectedIndex = 0;
            // chkStringSwap
            this.chkStringSwap.AutoSize = true; this.chkStringSwap.Text = "字符串颠倒";
            // cmbChannel
            this.cmbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbChannel.Width = 90; this.cmbChannel.Items.AddRange(new object[] { "TcpIp" }); this.cmbChannel.SelectedIndex = 0;
            // btnConnect
            this.btnConnect.Text = "连接"; this.btnConnect.Width = 80;
            // btnDisconnect
            this.btnDisconnect.Text = "断开连接"; this.btnDisconnect.Width = 90; this.btnDisconnect.Enabled = false;
            // txtAddr
            this.txtAddr.Text = "40001"; this.txtAddr.Width = 120;
            // numLen
            this.numLen.Minimum = 1; this.numLen.Maximum = 100; this.numLen.Value = 10; this.numLen.Width = 80;
            // cmbEncoding
            this.cmbEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList; this.cmbEncoding.Width = 80; this.cmbEncoding.Items.AddRange(new object[] { "ASCII", "UTF8" }); this.cmbEncoding.SelectedIndex = 0;
            // btnReadU16
            this.btnReadU16.Text = "ushort读取"; this.btnReadU16.Width = 100;
            // btnWriteU16
            this.btnWriteU16.Text = "ushort写入"; this.btnWriteU16.Width = 100;
            // txtWriteVal
            this.txtWriteVal.Text = "1"; this.txtWriteVal.Width = 120;
            // txtResult
            this.txtResult.Multiline = true; this.txtResult.Dock = System.Windows.Forms.DockStyle.Fill; this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            // tableRoot
            this.tableRoot.ColumnCount = 1; this.tableRoot.RowCount = 3; this.tableRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableRoot.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            // line1
            this.line1.Dock = System.Windows.Forms.DockStyle.Fill; this.line1.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight; this.line1.AutoSize = true;
            this.line1.Controls.Add(new System.Windows.Forms.Label { Text = "Ip地址:", AutoSize = true }); this.line1.Controls.Add(this.txtHost);
            this.line1.Controls.Add(new System.Windows.Forms.Label { Text = "端口号:", AutoSize = true }); this.line1.Controls.Add(this.numPort);
            this.line1.Controls.Add(new System.Windows.Forms.Label { Text = "连接超时:", AutoSize = true }); this.line1.Controls.Add(this.numConnTo);
            this.line1.Controls.Add(new System.Windows.Forms.Label { Text = "接收超时:", AutoSize = true }); this.line1.Controls.Add(this.numRecvTo);
            this.line1.Controls.Add(new System.Windows.Forms.Label { Text = "站号:", AutoSize = true }); this.line1.Controls.Add(this.numStation);
            this.line1.Controls.Add(this.cmbFormat);
            this.line1.Controls.Add(this.chkStringSwap);
            this.line1.Controls.Add(new System.Windows.Forms.Label { Text = "管道:", AutoSize = true }); this.line1.Controls.Add(this.cmbChannel);
            this.line1.Controls.Add(this.btnConnect); this.line1.Controls.Add(this.btnDisconnect);
            // line2
            this.line2.Dock = System.Windows.Forms.DockStyle.Fill; this.line2.FlowDirection = System.Windows.Forms.FlowDirection.LeftToRight; this.line2.AutoSize = true;
            this.line2.Controls.Add(new System.Windows.Forms.Label { Text = "地址:", AutoSize = true }); this.line2.Controls.Add(this.txtAddr);
            this.line2.Controls.Add(new System.Windows.Forms.Label { Text = "长度:", AutoSize = true }); this.line2.Controls.Add(this.numLen);
            this.line2.Controls.Add(new System.Windows.Forms.Label { Text = "编码:", AutoSize = true }); this.line2.Controls.Add(this.cmbEncoding);
            this.line2.Controls.Add(this.btnReadU16);
            this.line2.Controls.Add(new System.Windows.Forms.Label { Text = "写入:", AutoSize = true }); this.line2.Controls.Add(this.txtWriteVal);
            this.line2.Controls.Add(this.btnWriteU16);

            this.tableRoot.Controls.Add(this.line1, 0, 0);
            this.tableRoot.Controls.Add(this.line2, 0, 1);
            this.tableRoot.Controls.Add(this.txtResult, 0, 2);

            this.Controls.Add(this.tableRoot);
            this.Name = "ModbusConfigView";
            this.Size = new System.Drawing.Size(760, 520);

            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numConnTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRecvTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLen)).EndInit();
            this.tableRoot.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.NumericUpDown numConnTo;
        private System.Windows.Forms.NumericUpDown numRecvTo;
        private System.Windows.Forms.NumericUpDown numStation;
        private System.Windows.Forms.CheckBox chkZeroBase;
        private System.Windows.Forms.ComboBox cmbFormat;
        private System.Windows.Forms.CheckBox chkStringSwap;
        private System.Windows.Forms.ComboBox cmbChannel;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.TextBox txtAddr;
        private System.Windows.Forms.NumericUpDown numLen;
        private System.Windows.Forms.ComboBox cmbEncoding;
        private System.Windows.Forms.Button btnReadU16;
        private System.Windows.Forms.Button btnWriteU16;
        private System.Windows.Forms.TextBox txtWriteVal;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TableLayoutPanel tableRoot;
        private System.Windows.Forms.FlowLayoutPanel line1;
        private System.Windows.Forms.FlowLayoutPanel line2;
    }
}
