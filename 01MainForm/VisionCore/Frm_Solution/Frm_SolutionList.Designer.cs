namespace VisionCore.Frm_Solution
{
    partial class Frm_SolutionList
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_SetStart = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Delete = new DevExpress.XtraEditors.SimpleButton();
            this.btn_AddCur = new DevExpress.XtraEditors.SimpleButton();
            this.btn_AddNew = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Open = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.tablePanel1.SetColumn(this.gridControl1, 0);
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(19, 18);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.tablePanel1.SetRow(this.gridControl1, 0);
            this.gridControl1.Size = new System.Drawing.Size(828, 660);
            this.gridControl1.TabIndex = 4;
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
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 51.05F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 8.95F)});
            this.tablePanel1.Controls.Add(this.panelControl1);
            this.tablePanel1.Controls.Add(this.gridControl1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(1012, 697);
            this.tablePanel1.TabIndex = 5;
            this.tablePanel1.UseSkinIndents = true;
            // 
            // panelControl1
            // 
            this.tablePanel1.SetColumn(this.panelControl1, 1);
            this.panelControl1.Controls.Add(this.btn_SetStart);
            this.panelControl1.Controls.Add(this.btn_Delete);
            this.panelControl1.Controls.Add(this.btn_AddCur);
            this.panelControl1.Controls.Add(this.btn_AddNew);
            this.panelControl1.Controls.Add(this.btn_Open);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(853, 18);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel1.SetRow(this.panelControl1, 0);
            this.panelControl1.Size = new System.Drawing.Size(140, 660);
            this.panelControl1.TabIndex = 5;
            // 
            // btn_SetStart
            // 
            this.btn_SetStart.Appearance.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_SetStart.Appearance.Options.UseBackColor = true;
            this.btn_SetStart.Location = new System.Drawing.Point(14, 219);
            this.btn_SetStart.Name = "btn_SetStart";
            this.btn_SetStart.Size = new System.Drawing.Size(112, 34);
            this.btn_SetStart.TabIndex = 5;
            this.btn_SetStart.Text = "设为默认";
            this.btn_SetStart.Click += new System.EventHandler(this.btn_SetStart_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.Appearance.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_Delete.Appearance.Options.UseBackColor = true;
            this.btn_Delete.Location = new System.Drawing.Point(14, 276);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(112, 34);
            this.btn_Delete.TabIndex = 4;
            this.btn_Delete.Text = "删除方案";
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_AddCur
            // 
            this.btn_AddCur.Appearance.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_AddCur.Appearance.Options.UseBackColor = true;
            this.btn_AddCur.Location = new System.Drawing.Point(14, 158);
            this.btn_AddCur.Name = "btn_AddCur";
            this.btn_AddCur.Size = new System.Drawing.Size(112, 34);
            this.btn_AddCur.TabIndex = 3;
            this.btn_AddCur.Text = "复制选中";
            this.btn_AddCur.Click += new System.EventHandler(this.btn_AddCur_Click);
            // 
            // btn_AddNew
            // 
            this.btn_AddNew.Appearance.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_AddNew.Appearance.Options.UseBackColor = true;
            this.btn_AddNew.Location = new System.Drawing.Point(14, 97);
            this.btn_AddNew.Name = "btn_AddNew";
            this.btn_AddNew.Size = new System.Drawing.Size(112, 34);
            this.btn_AddNew.TabIndex = 2;
            this.btn_AddNew.Text = "添加空白";
            this.btn_AddNew.Click += new System.EventHandler(this.btn_AddNew_Click);
            // 
            // btn_Open
            // 
            this.btn_Open.Appearance.BackColor = System.Drawing.Color.SlateBlue;
            this.btn_Open.Appearance.Options.UseBackColor = true;
            this.btn_Open.Location = new System.Drawing.Point(14, 36);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(112, 34);
            this.btn_Open.TabIndex = 0;
            this.btn_Open.Text = "打开方案";
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // Frm_SolutionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 697);
            this.Controls.Add(this.tablePanel1);
            this.IconOptions.SvgImage = global::VisionCore.Properties.Resources.ActionCenterNotificationMirrored;
            this.Name = "Frm_SolutionList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "方案列表";
            this.Load += new System.EventHandler(this.Frm_SolutionList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_Delete;
        private DevExpress.XtraEditors.SimpleButton btn_AddCur;
        private DevExpress.XtraEditors.SimpleButton btn_AddNew;
        private DevExpress.XtraEditors.SimpleButton btn_Open;
        private DevExpress.XtraEditors.SimpleButton btn_SetStart;
    }
}