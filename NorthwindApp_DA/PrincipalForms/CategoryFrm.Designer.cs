namespace NorthwindApp_DA
{
    partial class CategoryFrm
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
            panel1 = new Panel();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            panel3 = new Panel();
            menuStrip1 = new MenuStrip();
            BtClose = new FontAwesome.Sharp.IconMenuItem();
            BtDelete = new FontAwesome.Sharp.IconMenuItem();
            BtUpdate = new FontAwesome.Sharp.IconMenuItem();
            iconMenuItem3 = new FontAwesome.Sharp.IconMenuItem();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(0, 74, 173);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(941, 139);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(0, 137);
            panel2.Name = "panel2";
            panel2.Size = new Size(938, 483);
            panel2.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(938, 483);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(623, 9);
            label1.Name = "label1";
            label1.Size = new Size(306, 62);
            label1.TabIndex = 0;
            label1.Text = "CATEGORIAS";
            label1.TextAlign = ContentAlignment.TopRight;
            label1.Click += this.label1_Click;
            // 
            // panel3
            // 
            panel3.AutoSize = true;
            panel3.Controls.Add(menuStrip1);
            panel3.Location = new Point(0, 85);
            panel3.Name = "panel3";
            panel3.Size = new Size(938, 46);
            panel3.TabIndex = 1;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { iconMenuItem3, BtUpdate, BtDelete, BtClose });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(938, 36);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // BtClose
            // 
            BtClose.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtClose.IconChar = FontAwesome.Sharp.IconChar.Close;
            BtClose.IconColor = Color.Black;
            BtClose.IconFont = FontAwesome.Sharp.IconFont.Solid;
            BtClose.IconSize = 20;
            BtClose.Name = "BtClose";
            BtClose.Size = new Size(100, 32);
            BtClose.Text = "Cerrar";
            // 
            // BtDelete
            // 
            BtDelete.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtDelete.IconChar = FontAwesome.Sharp.IconChar.DeleteLeft;
            BtDelete.IconColor = Color.Black;
            BtDelete.IconFont = FontAwesome.Sharp.IconFont.Solid;
            BtDelete.IconSize = 20;
            BtDelete.Name = "BtDelete";
            BtDelete.Size = new Size(118, 32);
            BtDelete.Text = "Eliminar";
            // 
            // BtUpdate
            // 
            BtUpdate.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtUpdate.IconChar = FontAwesome.Sharp.IconChar.Upload;
            BtUpdate.IconColor = Color.Black;
            BtUpdate.IconFont = FontAwesome.Sharp.IconFont.Solid;
            BtUpdate.IconSize = 20;
            BtUpdate.Name = "BtUpdate";
            BtUpdate.Size = new Size(133, 32);
            BtUpdate.Text = "Actualizar";
            // 
            // iconMenuItem3
            // 
            iconMenuItem3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            iconMenuItem3.IconChar = FontAwesome.Sharp.IconChar.Add;
            iconMenuItem3.IconColor = Color.Black;
            iconMenuItem3.IconFont = FontAwesome.Sharp.IconFont.Solid;
            iconMenuItem3.IconSize = 20;
            iconMenuItem3.Name = "iconMenuItem3";
            iconMenuItem3.Size = new Size(118, 32);
            iconMenuItem3.Text = "Agregar";
            // 
            // CategoryFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(938, 620);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "CategoryFrm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Label label1;
        private Panel panel3;
        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem BtClose;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem3;
        private FontAwesome.Sharp.IconMenuItem BtUpdate;
        private FontAwesome.Sharp.IconMenuItem BtDelete;
    }
}