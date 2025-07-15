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
            panel3 = new Panel();
            menuStrip1 = new MenuStrip();
            BtAddCat = new FontAwesome.Sharp.IconMenuItem();
            BtUpdate = new FontAwesome.Sharp.IconMenuItem();
            BtDelete = new FontAwesome.Sharp.IconMenuItem();
            BtClose = new FontAwesome.Sharp.IconMenuItem();
            label1 = new Label();
            panel2 = new Panel();
            CategoryDtGvw = new DataGridView();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)CategoryDtGvw).BeginInit();
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
            menuStrip1.Items.AddRange(new ToolStripItem[] { BtAddCat, BtUpdate, BtDelete, BtClose });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(938, 36);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // BtAddCat
            // 
            BtAddCat.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtAddCat.IconChar = FontAwesome.Sharp.IconChar.Add;
            BtAddCat.IconColor = Color.Black;
            BtAddCat.IconFont = FontAwesome.Sharp.IconFont.Solid;
            BtAddCat.IconSize = 20;
            BtAddCat.Name = "BtAddCat";
            BtAddCat.Size = new Size(118, 32);
            BtAddCat.Text = "Agregar";
            BtAddCat.Click += BtAddCat_Click;
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
            BtUpdate.Click += BtUpdate_Click;
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
            BtDelete.Click += BtDelete_Click;
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
            BtClose.Click += BtClose_Click;
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
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(CategoryDtGvw);
            panel2.Location = new Point(0, 137);
            panel2.Name = "panel2";
            panel2.Size = new Size(938, 483);
            panel2.TabIndex = 1;
            // 
            // CategoryDtGvw
            // 
            CategoryDtGvw.AllowUserToAddRows = false;
            CategoryDtGvw.AllowUserToDeleteRows = false;
            CategoryDtGvw.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            CategoryDtGvw.Dock = DockStyle.Fill;
            CategoryDtGvw.Location = new Point(0, 0);
            CategoryDtGvw.Name = "CategoryDtGvw";
            CategoryDtGvw.ReadOnly = true;
            CategoryDtGvw.RowHeadersWidth = 51;
            CategoryDtGvw.Size = new Size(938, 483);
            CategoryDtGvw.TabIndex = 0;
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
            Load += CategoryFrm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)CategoryDtGvw).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private DataGridView CategoryDtGvw;
        private Label label1;
        private Panel panel3;
        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem BtClose;
        private FontAwesome.Sharp.IconMenuItem BtAddCat;
        private FontAwesome.Sharp.IconMenuItem BtUpdate;
        private FontAwesome.Sharp.IconMenuItem BtDelete;
    }
}