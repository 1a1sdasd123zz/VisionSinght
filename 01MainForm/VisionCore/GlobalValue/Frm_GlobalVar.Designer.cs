namespace VisionCore.GlobarValue
{
    partial class Frm_GlobalVar
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_AddInt = new System.Windows.Forms.Button();
            this.btn_AddIntArray = new System.Windows.Forms.Button();
            this.btn_AddDoubleArray = new System.Windows.Forms.Button();
            this.btn_AddDouble = new System.Windows.Forms.Button();
            this.btn_AddStringArray = new System.Windows.Forms.Button();
            this.btn_AddString = new System.Windows.Forms.Button();
            this.btn_AddBoolArray = new System.Windows.Forms.Button();
            this.btn_AddBool = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Up = new System.Windows.Forms.Button();
            this.btn_Down = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVarName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAnnotation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 74.03958F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.96042F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(853, 585);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.btn_Down);
            this.panel1.Controls.Add(this.btn_Up);
            this.panel1.Controls.Add(this.btn_Remove);
            this.panel1.Controls.Add(this.btn_AddBoolArray);
            this.panel1.Controls.Add(this.btn_AddBool);
            this.panel1.Controls.Add(this.btn_AddStringArray);
            this.panel1.Controls.Add(this.btn_AddString);
            this.panel1.Controls.Add(this.btn_AddDoubleArray);
            this.panel1.Controls.Add(this.btn_AddDouble);
            this.panel1.Controls.Add(this.btn_AddIntArray);
            this.panel1.Controls.Add(this.btn_AddInt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(634, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(216, 579);
            this.panel1.TabIndex = 0;
            // 
            // btn_AddInt
            // 
            this.btn_AddInt.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_AddInt.Location = new System.Drawing.Point(13, 32);
            this.btn_AddInt.Name = "btn_AddInt";
            this.btn_AddInt.Size = new System.Drawing.Size(90, 34);
            this.btn_AddInt.TabIndex = 0;
            this.btn_AddInt.Text = "Int";
            this.btn_AddInt.UseVisualStyleBackColor = false;
            // 
            // btn_AddIntArray
            // 
            this.btn_AddIntArray.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_AddIntArray.Location = new System.Drawing.Point(116, 32);
            this.btn_AddIntArray.Name = "btn_AddIntArray";
            this.btn_AddIntArray.Size = new System.Drawing.Size(90, 34);
            this.btn_AddIntArray.TabIndex = 1;
            this.btn_AddIntArray.Text = "Int[]";
            this.btn_AddIntArray.UseVisualStyleBackColor = false;
            // 
            // btn_AddDoubleArray
            // 
            this.btn_AddDoubleArray.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_AddDoubleArray.Location = new System.Drawing.Point(116, 81);
            this.btn_AddDoubleArray.Name = "btn_AddDoubleArray";
            this.btn_AddDoubleArray.Size = new System.Drawing.Size(90, 34);
            this.btn_AddDoubleArray.TabIndex = 3;
            this.btn_AddDoubleArray.Text = "Double[]";
            this.btn_AddDoubleArray.UseVisualStyleBackColor = false;
            // 
            // btn_AddDouble
            // 
            this.btn_AddDouble.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_AddDouble.Location = new System.Drawing.Point(13, 81);
            this.btn_AddDouble.Name = "btn_AddDouble";
            this.btn_AddDouble.Size = new System.Drawing.Size(90, 34);
            this.btn_AddDouble.TabIndex = 2;
            this.btn_AddDouble.Text = "Double";
            this.btn_AddDouble.UseVisualStyleBackColor = false;
            // 
            // btn_AddStringArray
            // 
            this.btn_AddStringArray.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_AddStringArray.Location = new System.Drawing.Point(116, 132);
            this.btn_AddStringArray.Name = "btn_AddStringArray";
            this.btn_AddStringArray.Size = new System.Drawing.Size(90, 34);
            this.btn_AddStringArray.TabIndex = 5;
            this.btn_AddStringArray.Text = "String[]";
            this.btn_AddStringArray.UseVisualStyleBackColor = false;
            // 
            // btn_AddString
            // 
            this.btn_AddString.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_AddString.Location = new System.Drawing.Point(13, 132);
            this.btn_AddString.Name = "btn_AddString";
            this.btn_AddString.Size = new System.Drawing.Size(90, 34);
            this.btn_AddString.TabIndex = 4;
            this.btn_AddString.Text = "String";
            this.btn_AddString.UseVisualStyleBackColor = false;
            // 
            // btn_AddBoolArray
            // 
            this.btn_AddBoolArray.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_AddBoolArray.Location = new System.Drawing.Point(116, 184);
            this.btn_AddBoolArray.Name = "btn_AddBoolArray";
            this.btn_AddBoolArray.Size = new System.Drawing.Size(90, 34);
            this.btn_AddBoolArray.TabIndex = 7;
            this.btn_AddBoolArray.Text = "Bool[]";
            this.btn_AddBoolArray.UseVisualStyleBackColor = false;
            // 
            // btn_AddBool
            // 
            this.btn_AddBool.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_AddBool.Location = new System.Drawing.Point(13, 184);
            this.btn_AddBool.Name = "btn_AddBool";
            this.btn_AddBool.Size = new System.Drawing.Size(90, 34);
            this.btn_AddBool.TabIndex = 6;
            this.btn_AddBool.Text = "Bool";
            this.btn_AddBool.UseVisualStyleBackColor = false;
            // 
            // btn_Remove
            // 
            this.btn_Remove.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_Remove.Location = new System.Drawing.Point(63, 303);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(90, 34);
            this.btn_Remove.TabIndex = 8;
            this.btn_Remove.Text = "删除";
            this.btn_Remove.UseVisualStyleBackColor = false;
            // 
            // btn_Up
            // 
            this.btn_Up.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_Up.Location = new System.Drawing.Point(63, 360);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(90, 34);
            this.btn_Up.TabIndex = 9;
            this.btn_Up.Text = "上移";
            this.btn_Up.UseVisualStyleBackColor = false;
            // 
            // btn_Down
            // 
            this.btn_Down.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_Down.Location = new System.Drawing.Point(63, 423);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(90, 34);
            this.btn_Down.TabIndex = 10;
            this.btn_Down.Text = "下移";
            this.btn_Down.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.48607F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.513932F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(859, 646);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_Confirm.Location = new System.Drawing.Point(619, 6);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(90, 34);
            this.btn_Confirm.TabIndex = 11;
            this.btn_Confirm.Text = "确定";
            this.btn_Confirm.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.btn_Cancel);
            this.panel2.Controls.Add(this.btn_Confirm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 594);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(853, 49);
            this.panel2.TabIndex = 1;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_Cancel.Location = new System.Drawing.Point(738, 6);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(90, 34);
            this.btn_Cancel.TabIndex = 12;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndex,
            this.colType,
            this.colVarName,
            this.colValue,
            this.colAnnotation});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(625, 579);
            this.dataGridView1.TabIndex = 1;
            // 
            // colIndex
            // 
            this.colIndex.HeaderText = "索引";
            this.colIndex.MinimumWidth = 8;
            this.colIndex.Name = "colIndex";
            this.colIndex.ReadOnly = true;
            this.colIndex.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colIndex.Width = 50;
            // 
            // colType
            // 
            this.colType.HeaderText = "类型";
            this.colType.MinimumWidth = 8;
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colType.Width = 80;
            // 
            // colVarName
            // 
            this.colVarName.HeaderText = "名称";
            this.colVarName.MinimumWidth = 8;
            this.colVarName.Name = "colVarName";
            this.colVarName.Width = 150;
            // 
            // colValue
            // 
            this.colValue.HeaderText = "值";
            this.colValue.MinimumWidth = 8;
            this.colValue.Name = "colValue";
            this.colValue.Width = 150;
            // 
            // colAnnotation
            // 
            this.colAnnotation.HeaderText = "注释";
            this.colAnnotation.MinimumWidth = 8;
            this.colAnnotation.Name = "colAnnotation";
            this.colAnnotation.Width = 150;
            // 
            // Frm_GlobalVar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(859, 646);
            this.Controls.Add(this.tableLayoutPanel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_GlobalVar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "全局变量";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_AddStringArray;
        private System.Windows.Forms.Button btn_AddString;
        private System.Windows.Forms.Button btn_AddDoubleArray;
        private System.Windows.Forms.Button btn_AddDouble;
        private System.Windows.Forms.Button btn_AddIntArray;
        private System.Windows.Forms.Button btn_AddInt;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.Button btn_Up;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_AddBoolArray;
        private System.Windows.Forms.Button btn_AddBool;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVarName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAnnotation;
    }
}