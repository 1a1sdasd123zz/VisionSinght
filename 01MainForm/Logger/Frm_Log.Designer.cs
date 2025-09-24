namespace Logger
{
    partial class Frm_Log
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Log));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.col_Time = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Type = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_LogMessage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_Info = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Warning = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Error = new DevExpress.XtraEditors.SimpleButton();
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.xtraTabControl1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.xtraTabControl1.Appearance.Options.UseBackColor = true;
            this.xtraTabControl1.Appearance.Options.UseBorderColor = true;
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(563, 790);
            this.xtraTabControl1.TabIndex = 0;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Appearance.Header.BackColor = System.Drawing.Color.Black;
            this.xtraTabPage1.Appearance.Header.ForeColor = System.Drawing.Color.Black;
            this.xtraTabPage1.Appearance.Header.Options.UseBackColor = true;
            this.xtraTabPage1.Appearance.Header.Options.UseForeColor = true;
            this.xtraTabPage1.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Black;
            this.xtraTabPage1.Appearance.HeaderActive.Options.UseBackColor = true;
            this.xtraTabPage1.Appearance.HeaderActive.Options.UseBorderColor = true;
            this.xtraTabPage1.Appearance.HeaderActive.Options.UseForeColor = true;
            this.xtraTabPage1.Appearance.HeaderDisabled.ForeColor = System.Drawing.Color.Black;
            this.xtraTabPage1.Appearance.HeaderDisabled.Options.UseForeColor = true;
            this.xtraTabPage1.Appearance.HeaderHotTracked.ForeColor = System.Drawing.Color.Black;
            this.xtraTabPage1.Appearance.HeaderHotTracked.Options.UseBackColor = true;
            this.xtraTabPage1.Appearance.HeaderHotTracked.Options.UseBorderColor = true;
            this.xtraTabPage1.Appearance.HeaderHotTracked.Options.UseForeColor = true;
            this.xtraTabPage1.Appearance.PageClient.BackColor = System.Drawing.Color.Black;
            this.xtraTabPage1.Appearance.PageClient.ForeColor = System.Drawing.Color.Black;
            this.xtraTabPage1.Appearance.PageClient.Options.UseBackColor = true;
            this.xtraTabPage1.Appearance.PageClient.Options.UseBorderColor = true;
            this.xtraTabPage1.Appearance.PageClient.Options.UseForeColor = true;
            this.xtraTabPage1.Controls.Add(this.tableLayoutPanel1);
            this.xtraTabPage1.Controls.Add(this.memoEdit1);
            this.xtraTabPage1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(561, 752);
            this.xtraTabPage1.Text = "[日志信息]";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gridControl1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(561, 752);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 52);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(555, 697);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.Black;
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.col_Time,
            this.col_Type,
            this.col_LogMessage});
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
            // col_Time
            // 
            this.col_Time.AppearanceCell.BackColor = System.Drawing.Color.Black;
            this.col_Time.AppearanceCell.ForeColor = System.Drawing.Color.Lime;
            this.col_Time.AppearanceCell.Options.UseBackColor = true;
            this.col_Time.AppearanceCell.Options.UseForeColor = true;
            this.col_Time.AppearanceHeader.BackColor = System.Drawing.Color.Black;
            this.col_Time.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.col_Time.AppearanceHeader.ForeColor = System.Drawing.Color.White;
            this.col_Time.AppearanceHeader.Options.UseBackColor = true;
            this.col_Time.AppearanceHeader.Options.UseFont = true;
            this.col_Time.AppearanceHeader.Options.UseForeColor = true;
            this.col_Time.Caption = "时间";
            this.col_Time.FieldName = "Time";
            this.col_Time.MaxWidth = 200;
            this.col_Time.MinWidth = 30;
            this.col_Time.Name = "col_Time";
            this.col_Time.Visible = true;
            this.col_Time.VisibleIndex = 0;
            this.col_Time.Width = 200;
            // 
            // col_Type
            // 
            this.col_Type.AppearanceCell.BackColor = System.Drawing.Color.Black;
            this.col_Type.AppearanceCell.ForeColor = System.Drawing.Color.Lime;
            this.col_Type.AppearanceCell.Options.UseBackColor = true;
            this.col_Type.AppearanceCell.Options.UseForeColor = true;
            this.col_Type.AppearanceHeader.BackColor = System.Drawing.Color.Black;
            this.col_Type.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.col_Type.AppearanceHeader.Options.UseBackColor = true;
            this.col_Type.AppearanceHeader.Options.UseFont = true;
            this.col_Type.Caption = "类型";
            this.col_Type.FieldName = "Type";
            this.col_Type.MaxWidth = 100;
            this.col_Type.MinWidth = 10;
            this.col_Type.Name = "col_Type";
            this.col_Type.Visible = true;
            this.col_Type.VisibleIndex = 1;
            this.col_Type.Width = 77;
            // 
            // col_LogMessage
            // 
            this.col_LogMessage.AppearanceCell.BackColor = System.Drawing.Color.Black;
            this.col_LogMessage.AppearanceCell.ForeColor = System.Drawing.Color.Lime;
            this.col_LogMessage.AppearanceCell.Options.UseBackColor = true;
            this.col_LogMessage.AppearanceCell.Options.UseForeColor = true;
            this.col_LogMessage.AppearanceHeader.BackColor = System.Drawing.Color.Black;
            this.col_LogMessage.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.col_LogMessage.AppearanceHeader.Options.UseBackColor = true;
            this.col_LogMessage.AppearanceHeader.Options.UseFont = true;
            this.col_LogMessage.Caption = "日志内容";
            this.col_LogMessage.FieldName = "Content";
            this.col_LogMessage.MinWidth = 100;
            this.col_LogMessage.Name = "col_LogMessage";
            this.col_LogMessage.Visible = true;
            this.col_LogMessage.VisibleIndex = 2;
            this.col_LogMessage.Width = 276;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanel1.Controls.Add(this.btn_Info);
            this.flowLayoutPanel1.Controls.Add(this.btn_Warning);
            this.flowLayoutPanel1.Controls.Add(this.btn_Error);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(555, 43);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // btn_Info
            // 
            this.btn_Info.Appearance.BackColor = System.Drawing.SystemColors.GrayText;
            this.btn_Info.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_Info.Appearance.Options.UseBackColor = true;
            this.btn_Info.Appearance.Options.UseForeColor = true;
            this.btn_Info.Appearance.Options.UseTextOptions = true;
            this.btn_Info.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btn_Info.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Info.ImageOptions.Image")));
            this.btn_Info.Location = new System.Drawing.Point(3, 3);
            this.btn_Info.Name = "btn_Info";
            this.btn_Info.Size = new System.Drawing.Size(150, 35);
            this.btn_Info.TabIndex = 0;
            this.btn_Info.Text = "信息";
            // 
            // btn_Warning
            // 
            this.btn_Warning.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Warning.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_Warning.Appearance.Options.UseBackColor = true;
            this.btn_Warning.Appearance.Options.UseForeColor = true;
            this.btn_Warning.Appearance.Options.UseTextOptions = true;
            this.btn_Warning.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btn_Warning.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Warning.ImageOptions.Image")));
            this.btn_Warning.Location = new System.Drawing.Point(159, 3);
            this.btn_Warning.Name = "btn_Warning";
            this.btn_Warning.Size = new System.Drawing.Size(150, 35);
            this.btn_Warning.TabIndex = 1;
            this.btn_Warning.Text = "警告";
            // 
            // btn_Error
            // 
            this.btn_Error.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_Error.Appearance.ForeColor = System.Drawing.Color.White;
            this.btn_Error.Appearance.Options.UseBackColor = true;
            this.btn_Error.Appearance.Options.UseForeColor = true;
            this.btn_Error.Appearance.Options.UseTextOptions = true;
            this.btn_Error.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.btn_Error.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Error.ImageOptions.Image")));
            this.btn_Error.Location = new System.Drawing.Point(315, 3);
            this.btn_Error.Name = "btn_Error";
            this.btn_Error.Size = new System.Drawing.Size(150, 35);
            this.btn_Error.TabIndex = 2;
            this.btn_Error.Text = "错误";
            // 
            // memoEdit1
            // 
            this.memoEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit1.Location = new System.Drawing.Point(0, 0);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(561, 752);
            this.memoEdit1.TabIndex = 0;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Appearance.Header.BackColor = System.Drawing.Color.Black;
            this.xtraTabPage2.Appearance.Header.ForeColor = System.Drawing.Color.Black;
            this.xtraTabPage2.Appearance.Header.Options.UseBackColor = true;
            this.xtraTabPage2.Appearance.Header.Options.UseForeColor = true;
            this.xtraTabPage2.Appearance.HeaderActive.ForeColor = System.Drawing.Color.Black;
            this.xtraTabPage2.Appearance.HeaderActive.Options.UseBackColor = true;
            this.xtraTabPage2.Appearance.HeaderActive.Options.UseBorderColor = true;
            this.xtraTabPage2.Appearance.HeaderActive.Options.UseForeColor = true;
            this.xtraTabPage2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.xtraTabPage2.Size = new System.Drawing.Size(561, 752);
            this.xtraTabPage2.Text = "[数据栏]";
            // 
            // Frm_Log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Name = "Frm_Log";
            this.Size = new System.Drawing.Size(563, 790);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.SimpleButton btn_Error;
        private DevExpress.XtraEditors.SimpleButton btn_Warning;
        private DevExpress.XtraEditors.SimpleButton btn_Info;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn col_Time;
        private DevExpress.XtraGrid.Columns.GridColumn col_Type;
        private DevExpress.XtraGrid.Columns.GridColumn col_Content;
        private DevExpress.XtraGrid.Columns.GridColumn col_LogMessage;
    }
}
