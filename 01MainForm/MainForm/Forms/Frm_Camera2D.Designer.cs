namespace UniVision.Forms
{
    partial class Frm_Camera2D
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        ///// <summary>
        ///// Clean up any resources being used.
        ///// </summary>
        ///// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Camera2D));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabPanel_Main = new DevExpress.Utils.Layout.TablePanel();
            this.split_Display = new DevExpress.XtraEditors.SplitContainerControl();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_Continuous = new DevExpress.XtraEditors.SimpleButton();
            this.btn_TriggerOnce = new DevExpress.XtraEditors.SimpleButton();
            this.btn_DisConnect = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Connect = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.dgv_CameraConfig = new System.Windows.Forms.DataGridView();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.cmb_TriggerSource = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txt_MaxExposure = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.chk_HardTrigger = new DevExpress.XtraEditors.CheckEdit();
            this.txt_MaxGain = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Exposure = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txt_Gain = new DevExpress.XtraEditors.SpinEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.Txt_Sn = new DevExpress.XtraEditors.TextEdit();
            this.pnl_DevInfo = new DevExpress.XtraEditors.PanelControl();
            this.btn_Remove = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Add = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.cmb_SnList = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cmb_Manufacturers = new DevExpress.XtraEditors.ComboBoxEdit();
            this.pictureEdit_Display = new DevExpress.XtraEditors.PictureEdit();
            this.panel_DisplayHost = new System.Windows.Forms.Panel();
            this.col_SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_Expain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tabPanel_Main)).BeginInit();
            this.tabPanel_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Display)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.split_Display.Panel1)).BeginInit();
            this.split_Display.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Display.Panel2)).BeginInit();
            this.split_Display.Panel2.SuspendLayout();
            this.split_Display.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CameraConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_TriggerSource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_HardTrigger.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Exposure.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Gain.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Sn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_DevInfo)).BeginInit();
            this.pnl_DevInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_SnList.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Manufacturers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_Display.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPanel_Main
            // 
            this.tabPanel_Main.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F)});
            this.tabPanel_Main.Controls.Add(this.split_Display);
            this.tabPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPanel_Main.Location = new System.Drawing.Point(0, 0);
            this.tabPanel_Main.Name = "tabPanel_Main";
            this.tabPanel_Main.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 602.0003F)});
            this.tabPanel_Main.Size = new System.Drawing.Size(1412, 715);
            this.tabPanel_Main.TabIndex = 3;
            this.tabPanel_Main.UseSkinIndents = true;
            // 
            // split_Display
            // 
            this.split_Display.Appearance.BackColor = System.Drawing.Color.SlateBlue;
            this.split_Display.Appearance.BorderColor = System.Drawing.Color.SlateBlue;
            this.split_Display.Appearance.Options.UseBackColor = true;
            this.split_Display.Appearance.Options.UseBorderColor = true;
            this.split_Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_Display.Location = new System.Drawing.Point(19, 18);
            this.split_Display.Name = "split_Display";
            // 
            // split_Display.Panel1
            // 
            this.split_Display.Panel1.Appearance.BackColor = System.Drawing.Color.SlateBlue;
            this.split_Display.Panel1.Appearance.Options.UseBackColor = true;
            this.split_Display.Panel1.Controls.Add(this.tablePanel1);
            this.split_Display.Panel1.Text = "Panel1";
            // 
            // split_Display.Panel2
            // 
            this.split_Display.Panel2.Appearance.BackColor = System.Drawing.Color.SlateBlue;
            this.split_Display.Panel2.Appearance.Options.UseBackColor = true;
            this.split_Display.Panel2.Controls.Add(this.pictureEdit_Display);
            this.split_Display.Panel2.Text = "Panel2";
            this.split_Display.Size = new System.Drawing.Size(1373, 683);
            this.split_Display.SplitterPosition = 621;
            this.split_Display.TabIndex = 2;
            // 
            // tablePanel1
            // 
            this.tablePanel1.AutoSize = true;
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablePanel1.Controls.Add(this.panelControl1);
            this.tablePanel1.Controls.Add(this.panelControl3);
            this.tablePanel1.Controls.Add(this.panelControl2);
            this.tablePanel1.Controls.Add(this.pnl_DevInfo);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 130.6667F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 206.6669F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 224.666F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(621, 683);
            this.tablePanel1.TabIndex = 0;
            this.tablePanel1.UseSkinIndents = true;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.panelControl1, 0);
            this.panelControl1.Controls.Add(this.btn_Continuous);
            this.panelControl1.Controls.Add(this.btn_TriggerOnce);
            this.panelControl1.Controls.Add(this.btn_DisConnect);
            this.panelControl1.Controls.Add(this.btn_Connect);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(19, 581);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel1.SetRow(this.panelControl1, 3);
            this.panelControl1.Size = new System.Drawing.Size(583, 83);
            this.panelControl1.TabIndex = 14;
            // 
            // btn_Continuous
            // 
            this.btn_Continuous.Appearance.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_Continuous.Appearance.Options.UseBackColor = true;
            this.btn_Continuous.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Continuous.Location = new System.Drawing.Point(440, 21);
            this.btn_Continuous.Name = "btn_Continuous";
            this.btn_Continuous.Size = new System.Drawing.Size(112, 34);
            this.btn_Continuous.TabIndex = 3;
            this.btn_Continuous.Text = "连续采集";
            this.btn_Continuous.Click += new System.EventHandler(this.btn_Continuous_Click);
            // 
            // btn_TriggerOnce
            // 
            this.btn_TriggerOnce.Appearance.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_TriggerOnce.Appearance.Options.UseBackColor = true;
            this.btn_TriggerOnce.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TriggerOnce.Location = new System.Drawing.Point(306, 21);
            this.btn_TriggerOnce.Name = "btn_TriggerOnce";
            this.btn_TriggerOnce.Size = new System.Drawing.Size(112, 34);
            this.btn_TriggerOnce.TabIndex = 2;
            this.btn_TriggerOnce.Text = "软触发一次";
            this.btn_TriggerOnce.Click += new System.EventHandler(this.btn_TriggerOnce_Click);
            // 
            // btn_DisConnect
            // 
            this.btn_DisConnect.Appearance.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_DisConnect.Appearance.Options.UseBackColor = true;
            this.btn_DisConnect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_DisConnect.Location = new System.Drawing.Point(157, 21);
            this.btn_DisConnect.Name = "btn_DisConnect";
            this.btn_DisConnect.Size = new System.Drawing.Size(112, 34);
            this.btn_DisConnect.TabIndex = 1;
            this.btn_DisConnect.Text = "断开";
            this.btn_DisConnect.Click += new System.EventHandler(this.btn_DisConnect_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.Appearance.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_Connect.Appearance.Options.UseBackColor = true;
            this.btn_Connect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Connect.Location = new System.Drawing.Point(12, 21);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(112, 34);
            this.btn_Connect.TabIndex = 0;
            this.btn_Connect.Text = "连接";
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelControl3.Appearance.Options.UseBackColor = true;
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.panelControl3, 0);
            this.panelControl3.Controls.Add(this.dgv_CameraConfig);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(19, 149);
            this.panelControl3.Name = "panelControl3";
            this.tablePanel1.SetRow(this.panelControl3, 1);
            this.panelControl3.Size = new System.Drawing.Size(583, 201);
            this.panelControl3.TabIndex = 25;
            // 
            // dgv_CameraConfig
            // 
            this.dgv_CameraConfig.AllowUserToAddRows = false;
            this.dgv_CameraConfig.AllowUserToDeleteRows = false;
            this.dgv_CameraConfig.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_CameraConfig.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_CameraConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_CameraConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_SerialNumber,
            this.col_Manufacturer,
            this.col_Expain});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 9F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_CameraConfig.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_CameraConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_CameraConfig.EnableHeadersVisualStyles = false;
            this.dgv_CameraConfig.GridColor = System.Drawing.Color.White;
            this.dgv_CameraConfig.Location = new System.Drawing.Point(0, 0);
            this.dgv_CameraConfig.Name = "dgv_CameraConfig";
            this.dgv_CameraConfig.RowHeadersVisible = false;
            this.dgv_CameraConfig.RowHeadersWidth = 62;
            this.dgv_CameraConfig.RowTemplate.Height = 30;
            this.dgv_CameraConfig.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_CameraConfig.Size = new System.Drawing.Size(583, 201);
            this.dgv_CameraConfig.TabIndex = 0;
            this.dgv_CameraConfig.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CameraConfig_CellValueChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelControl2.Appearance.Options.UseBackColor = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.panelControl2, 0);
            this.panelControl2.Controls.Add(this.cmb_TriggerSource);
            this.panelControl2.Controls.Add(this.txt_MaxExposure);
            this.panelControl2.Controls.Add(this.labelControl9);
            this.panelControl2.Controls.Add(this.labelControl8);
            this.panelControl2.Controls.Add(this.labelControl7);
            this.panelControl2.Controls.Add(this.chk_HardTrigger);
            this.panelControl2.Controls.Add(this.txt_MaxGain);
            this.panelControl2.Controls.Add(this.labelControl5);
            this.panelControl2.Controls.Add(this.txt_Exposure);
            this.panelControl2.Controls.Add(this.labelControl4);
            this.panelControl2.Controls.Add(this.txt_Gain);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.labelControl2);
            this.panelControl2.Controls.Add(this.Txt_Sn);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(19, 356);
            this.panelControl2.Name = "panelControl2";
            this.tablePanel1.SetRow(this.panelControl2, 2);
            this.panelControl2.Size = new System.Drawing.Size(583, 219);
            this.panelControl2.TabIndex = 13;
            // 
            // cmb_TriggerSource
            // 
            this.cmb_TriggerSource.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_TriggerSource.Location = new System.Drawing.Point(200, 61);
            this.cmb_TriggerSource.Name = "cmb_TriggerSource";
            this.cmb_TriggerSource.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmb_TriggerSource.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.cmb_TriggerSource.Properties.Appearance.Options.UseBackColor = true;
            this.cmb_TriggerSource.Properties.Appearance.Options.UseForeColor = true;
            this.cmb_TriggerSource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_TriggerSource.Properties.DropDownRows = 3;
            this.cmb_TriggerSource.Properties.PopupSizeable = true;
            this.cmb_TriggerSource.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmb_TriggerSource.Size = new System.Drawing.Size(140, 28);
            this.cmb_TriggerSource.TabIndex = 19;
            this.cmb_TriggerSource.SelectedIndexChanged += new System.EventHandler(this.cmb_TriggerSource_SelectedIndexChanged);
            // 
            // txt_MaxExposure
            // 
            this.txt_MaxExposure.Appearance.ForeColor = System.Drawing.Color.White;
            this.txt_MaxExposure.Appearance.Options.UseForeColor = true;
            this.txt_MaxExposure.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txt_MaxExposure.Location = new System.Drawing.Point(443, 118);
            this.txt_MaxExposure.Name = "txt_MaxExposure";
            this.txt_MaxExposure.Size = new System.Drawing.Size(10, 22);
            this.txt_MaxExposure.TabIndex = 18;
            this.txt_MaxExposure.Text = "0";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl9.Appearance.Options.UseForeColor = true;
            this.labelControl9.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.labelControl9.Location = new System.Drawing.Point(348, 118);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(78, 22);
            this.labelControl9.TabIndex = 17;
            this.labelControl9.Text = "最大曝光:";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl8.Appearance.Options.UseForeColor = true;
            this.labelControl8.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.labelControl8.Location = new System.Drawing.Point(234, 119);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(18, 22);
            this.labelControl8.TabIndex = 16;
            this.labelControl8.Text = "us";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl7.Appearance.Options.UseForeColor = true;
            this.labelControl7.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.labelControl7.Location = new System.Drawing.Point(234, 163);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(20, 22);
            this.labelControl7.TabIndex = 15;
            this.labelControl7.Text = "db";
            // 
            // chk_HardTrigger
            // 
            this.chk_HardTrigger.Location = new System.Drawing.Point(102, 61);
            this.chk_HardTrigger.Name = "chk_HardTrigger";
            this.chk_HardTrigger.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.chk_HardTrigger.Properties.Appearance.Options.UseForeColor = true;
            this.chk_HardTrigger.Properties.Caption = "硬触发";
            this.chk_HardTrigger.Size = new System.Drawing.Size(92, 27);
            this.chk_HardTrigger.TabIndex = 14;
            this.chk_HardTrigger.CheckedChanged += new System.EventHandler(this.chk_HardTrigger_CheckedChanged);
            // 
            // txt_MaxGain
            // 
            this.txt_MaxGain.Appearance.ForeColor = System.Drawing.Color.White;
            this.txt_MaxGain.Appearance.Options.UseForeColor = true;
            this.txt_MaxGain.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.txt_MaxGain.Location = new System.Drawing.Point(443, 162);
            this.txt_MaxGain.Name = "txt_MaxGain";
            this.txt_MaxGain.Size = new System.Drawing.Size(10, 22);
            this.txt_MaxGain.TabIndex = 12;
            this.txt_MaxGain.Text = "0";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl5.Appearance.Options.UseForeColor = true;
            this.labelControl5.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.labelControl5.Location = new System.Drawing.Point(348, 162);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(78, 22);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "最大增益:";
            // 
            // txt_Exposure
            // 
            this.txt_Exposure.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_Exposure.Location = new System.Drawing.Point(102, 117);
            this.txt_Exposure.Name = "txt_Exposure";
            this.txt_Exposure.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Exposure.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.txt_Exposure.Properties.Appearance.Options.UseBackColor = true;
            this.txt_Exposure.Properties.Appearance.Options.UseForeColor = true;
            this.txt_Exposure.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_Exposure.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txt_Exposure.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txt_Exposure.Properties.MaskSettings.Set("mask", "f3");
            this.txt_Exposure.Properties.MaxValue = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.txt_Exposure.Size = new System.Drawing.Size(123, 28);
            this.txt_Exposure.TabIndex = 7;
            this.txt_Exposure.EditValueChanged += new System.EventHandler(this.txt_Exposure_EditValueChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.labelControl4.Location = new System.Drawing.Point(39, 162);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(36, 22);
            this.labelControl4.TabIndex = 10;
            this.labelControl4.Text = "增益";
            // 
            // txt_Gain
            // 
            this.txt_Gain.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txt_Gain.Location = new System.Drawing.Point(102, 161);
            this.txt_Gain.Name = "txt_Gain";
            this.txt_Gain.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txt_Gain.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.txt_Gain.Properties.Appearance.Options.UseBackColor = true;
            this.txt_Gain.Properties.Appearance.Options.UseForeColor = true;
            this.txt_Gain.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txt_Gain.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txt_Gain.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.NumericMaskManager));
            this.txt_Gain.Properties.MaskSettings.Set("mask", "f3");
            this.txt_Gain.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txt_Gain.Size = new System.Drawing.Size(123, 28);
            this.txt_Gain.TabIndex = 9;
            this.txt_Gain.EditValueChanged += new System.EventHandler(this.txt_Gain_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(8, 16);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 22);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "序列号";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.labelControl3.Location = new System.Drawing.Point(39, 118);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 22);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "曝光";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.LineStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.labelControl2.Location = new System.Drawing.Point(8, 61);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 22);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "触发模式";
            // 
            // Txt_Sn
            // 
            this.Txt_Sn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Txt_Sn.Location = new System.Drawing.Point(102, 16);
            this.Txt_Sn.Name = "Txt_Sn";
            this.Txt_Sn.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Txt_Sn.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.Txt_Sn.Properties.Appearance.Options.UseBackColor = true;
            this.Txt_Sn.Properties.Appearance.Options.UseForeColor = true;
            this.Txt_Sn.Size = new System.Drawing.Size(238, 28);
            this.Txt_Sn.TabIndex = 4;
            // 
            // pnl_DevInfo
            // 
            this.pnl_DevInfo.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnl_DevInfo.Appearance.Options.UseBackColor = true;
            this.pnl_DevInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tablePanel1.SetColumn(this.pnl_DevInfo, 0);
            this.pnl_DevInfo.Controls.Add(this.btn_Remove);
            this.pnl_DevInfo.Controls.Add(this.btn_Add);
            this.pnl_DevInfo.Controls.Add(this.labelControl10);
            this.pnl_DevInfo.Controls.Add(this.cmb_SnList);
            this.pnl_DevInfo.Controls.Add(this.labelControl6);
            this.pnl_DevInfo.Controls.Add(this.cmb_Manufacturers);
            this.pnl_DevInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_DevInfo.Location = new System.Drawing.Point(19, 18);
            this.pnl_DevInfo.Name = "pnl_DevInfo";
            this.tablePanel1.SetRow(this.pnl_DevInfo, 0);
            this.pnl_DevInfo.Size = new System.Drawing.Size(583, 125);
            this.pnl_DevInfo.TabIndex = 3;
            // 
            // btn_Remove
            // 
            this.btn_Remove.Appearance.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_Remove.Appearance.ForeColor = System.Drawing.Color.SlateBlue;
            this.btn_Remove.Appearance.Options.UseBackColor = true;
            this.btn_Remove.Appearance.Options.UseForeColor = true;
            this.btn_Remove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Remove.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Remove.ImageOptions.Image")));
            this.btn_Remove.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Remove.Location = new System.Drawing.Point(413, 62);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(40, 34);
            this.btn_Remove.TabIndex = 10;
            this.btn_Remove.ToolTip = "删除相机";
            this.btn_Remove.Click += new System.EventHandler(this.btn_Remove_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Appearance.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_Add.Appearance.ForeColor = System.Drawing.Color.SlateBlue;
            this.btn_Add.Appearance.Options.UseBackColor = true;
            this.btn_Add.Appearance.Options.UseForeColor = true;
            this.btn_Add.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Add.ImageOptions.Image")));
            this.btn_Add.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btn_Add.Location = new System.Drawing.Point(358, 62);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(40, 34);
            this.btn_Add.TabIndex = 9;
            this.btn_Add.ToolTip = "添加相机";
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl10.Appearance.Options.UseForeColor = true;
            this.labelControl10.Location = new System.Drawing.Point(12, 69);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(72, 22);
            this.labelControl10.TabIndex = 7;
            this.labelControl10.Text = "相机列表";
            // 
            // cmb_SnList
            // 
            this.cmb_SnList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_SnList.Location = new System.Drawing.Point(102, 66);
            this.cmb_SnList.Name = "cmb_SnList";
            this.cmb_SnList.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmb_SnList.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.cmb_SnList.Properties.Appearance.Options.UseBackColor = true;
            this.cmb_SnList.Properties.Appearance.Options.UseForeColor = true;
            this.cmb_SnList.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_SnList.Properties.DropDownRows = 20;
            this.cmb_SnList.Properties.PopupSizeable = true;
            this.cmb_SnList.Size = new System.Drawing.Size(238, 28);
            this.cmb_SnList.TabIndex = 8;
            this.cmb_SnList.SelectedIndexChanged += new System.EventHandler(this.cmb_SnList_SelectedIndexChanged);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl6.Appearance.Options.UseForeColor = true;
            this.labelControl6.Location = new System.Drawing.Point(12, 18);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(72, 22);
            this.labelControl6.TabIndex = 5;
            this.labelControl6.Text = "相机品牌";
            // 
            // cmb_Manufacturers
            // 
            this.cmb_Manufacturers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmb_Manufacturers.Location = new System.Drawing.Point(102, 15);
            this.cmb_Manufacturers.Name = "cmb_Manufacturers";
            this.cmb_Manufacturers.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmb_Manufacturers.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.cmb_Manufacturers.Properties.Appearance.Options.UseBackColor = true;
            this.cmb_Manufacturers.Properties.Appearance.Options.UseForeColor = true;
            this.cmb_Manufacturers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmb_Manufacturers.Properties.DropDownRows = 10;
            this.cmb_Manufacturers.Properties.PopupSizeable = true;
            this.cmb_Manufacturers.Size = new System.Drawing.Size(238, 28);
            this.cmb_Manufacturers.TabIndex = 6;
            this.cmb_Manufacturers.SelectedIndexChanged += new System.EventHandler(this.cmb_Manufacturers_SelectedIndexChanged);
            // 
            // pictureEdit_Display
            // 
            this.pictureEdit_Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit_Display.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit_Display.Name = "pictureEdit_Display";
            this.pictureEdit_Display.Properties.ShowMenu = false;
            this.pictureEdit_Display.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit_Display.Size = new System.Drawing.Size(737, 683);
            this.pictureEdit_Display.TabIndex = 0;
            // 
            // panel_DisplayHost
            // 
            this.panel_DisplayHost.Location = new System.Drawing.Point(0, 0);
            this.panel_DisplayHost.Name = "panel_DisplayHost";
            this.panel_DisplayHost.Size = new System.Drawing.Size(200, 100);
            this.panel_DisplayHost.TabIndex = 0;
            // 
            // col_SerialNumber
            // 
            this.col_SerialNumber.DataPropertyName = "SerialNumber";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.col_SerialNumber.DefaultCellStyle = dataGridViewCellStyle2;
            this.col_SerialNumber.HeaderText = "序列号";
            this.col_SerialNumber.MinimumWidth = 8;
            this.col_SerialNumber.Name = "col_SerialNumber";
            this.col_SerialNumber.ReadOnly = true;
            this.col_SerialNumber.Width = 150;
            // 
            // col_Manufacturer
            // 
            this.col_Manufacturer.DataPropertyName = "Manufacturer";
            this.col_Manufacturer.HeaderText = "厂商";
            this.col_Manufacturer.MinimumWidth = 8;
            this.col_Manufacturer.Name = "col_Manufacturer";
            this.col_Manufacturer.ReadOnly = true;
            this.col_Manufacturer.Width = 150;
            // 
            // col_Expain
            // 
            this.col_Expain.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_Expain.DataPropertyName = "Expain";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.col_Expain.DefaultCellStyle = dataGridViewCellStyle3;
            this.col_Expain.HeaderText = "备注";
            this.col_Expain.MinimumWidth = 8;
            this.col_Expain.Name = "col_Expain";
            // 
            // Frm_Camera2D
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1412, 715);
            this.Controls.Add(this.tabPanel_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Frm_Camera2D";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "相机配置界面";
            this.Load += new System.EventHandler(this.Frm_Camera2D_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabPanel_Main)).EndInit();
            this.tabPanel_Main.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Display.Panel1)).EndInit();
            this.split_Display.Panel1.ResumeLayout(false);
            this.split_Display.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.split_Display.Panel2)).EndInit();
            this.split_Display.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_Display)).EndInit();
            this.split_Display.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_CameraConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_TriggerSource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_HardTrigger.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Exposure.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_Gain.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_Sn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl_DevInfo)).EndInit();
            this.pnl_DevInfo.ResumeLayout(false);
            this.pnl_DevInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_SnList.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmb_Manufacturers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit_Display.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tabPanel_Main;
        private DevExpress.XtraEditors.SplitContainerControl split_Display;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Continuous;
        private DevExpress.XtraEditors.SimpleButton btn_TriggerOnce;
        private DevExpress.XtraEditors.SimpleButton btn_DisConnect;
        private DevExpress.XtraEditors.SimpleButton btn_Connect;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_TriggerSource;
        private DevExpress.XtraEditors.LabelControl txt_MaxExposure;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.CheckEdit chk_HardTrigger;
        private DevExpress.XtraEditors.LabelControl txt_MaxGain;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SpinEdit txt_Exposure;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SpinEdit txt_Gain;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit Txt_Sn;
        private DevExpress.XtraEditors.PanelControl pnl_DevInfo;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_SnList;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit cmb_Manufacturers;
        private System.Windows.Forms.Panel panel_DisplayHost;
        private DevExpress.XtraEditors.PictureEdit pictureEdit_Display;
        private DevExpress.XtraEditors.SimpleButton btn_Add;
        private DevExpress.XtraEditors.SimpleButton btn_Remove;
        private System.Windows.Forms.DataGridView dgv_CameraConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Manufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_Expain;
    }
}