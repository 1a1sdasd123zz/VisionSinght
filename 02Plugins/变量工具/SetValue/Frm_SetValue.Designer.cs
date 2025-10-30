namespace SetValue
{
    partial class Frm_SetValue
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Remove = new System.Windows.Forms.Button();
            this.btn_Up = new System.Windows.Forms.Button();
            this.btn_Down = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.31142F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.688581F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1445, 688);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Down);
            this.panel1.Controls.Add(this.btn_Up);
            this.panel1.Controls.Add(this.btn_Remove);
            this.panel1.Controls.Add(this.btn_Add);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1308, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(134, 682);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1299, 682);
            this.panel2.TabIndex = 1;
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_Add.ForeColor = System.Drawing.Color.Black;
            this.btn_Add.Location = new System.Drawing.Point(22, 39);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(98, 36);
            this.btn_Add.TabIndex = 0;
            this.btn_Add.Text = "添加";
            this.btn_Add.UseVisualStyleBackColor = false;
            // 
            // btn_Remove
            // 
            this.btn_Remove.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_Remove.ForeColor = System.Drawing.Color.Black;
            this.btn_Remove.Location = new System.Drawing.Point(22, 121);
            this.btn_Remove.Name = "btn_Remove";
            this.btn_Remove.Size = new System.Drawing.Size(98, 36);
            this.btn_Remove.TabIndex = 1;
            this.btn_Remove.Text = "删除";
            this.btn_Remove.UseVisualStyleBackColor = false;
            // 
            // btn_Up
            // 
            this.btn_Up.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_Up.ForeColor = System.Drawing.Color.Black;
            this.btn_Up.Location = new System.Drawing.Point(22, 221);
            this.btn_Up.Name = "btn_Up";
            this.btn_Up.Size = new System.Drawing.Size(98, 36);
            this.btn_Up.TabIndex = 2;
            this.btn_Up.Text = "上移";
            this.btn_Up.UseVisualStyleBackColor = false;
            // 
            // btn_Down
            // 
            this.btn_Down.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btn_Down.ForeColor = System.Drawing.Color.Black;
            this.btn_Down.Location = new System.Drawing.Point(22, 310);
            this.btn_Down.Name = "btn_Down";
            this.btn_Down.Size = new System.Drawing.Size(98, 36);
            this.btn_Down.TabIndex = 3;
            this.btn_Down.Text = "下移";
            this.btn_Down.UseVisualStyleBackColor = false;
            // 
            // Frm_SetValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1445, 764);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Frm_SetValue";
            this.Text = "变量设置";
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Down;
        private System.Windows.Forms.Button btn_Up;
        private System.Windows.Forms.Button btn_Remove;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Panel panel2;
    }
}