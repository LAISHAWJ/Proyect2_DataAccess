﻿namespace NorthwindApp_DA
{
    partial class SupplierFrm
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
            BtAdd = new FontAwesome.Sharp.IconMenuItem();
            BtUpdate = new FontAwesome.Sharp.IconMenuItem();
            BtDelete = new FontAwesome.Sharp.IconMenuItem();
            BtClose = new FontAwesome.Sharp.IconMenuItem();
            label1 = new Label();
            panel2 = new Panel();
            SuppDgv = new DataGridView();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SuppDgv).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(0, 74, 173);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-2, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(942, 445);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(menuStrip1);
            panel3.Location = new Point(3, 113);
            panel3.Name = "panel3";
            panel3.Size = new Size(936, 47);
            panel3.TabIndex = 2;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { BtAdd, BtUpdate, BtDelete, BtClose });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(936, 36);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // BtAdd
            // 
            BtAdd.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtAdd.IconChar = FontAwesome.Sharp.IconChar.Add;
            BtAdd.IconColor = Color.Black;
            BtAdd.IconFont = FontAwesome.Sharp.IconFont.Solid;
            BtAdd.IconSize = 20;
            BtAdd.Name = "BtAdd";
            BtAdd.Size = new Size(118, 32);
            BtAdd.Text = "Agregar";
            BtAdd.Click += BtAdd_Click;
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
            label1.Location = new Point(627, 10);
            label1.Name = "label1";
            label1.Size = new Size(299, 62);
            label1.TabIndex = 1;
            label1.Text = "SUPLIDORES";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(SuppDgv);
            panel2.Location = new Point(-2, 165);
            panel2.Name = "panel2";
            panel2.Size = new Size(939, 445);
            panel2.TabIndex = 1;
            // 
            // SuppDgv
            // 
            SuppDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SuppDgv.Dock = DockStyle.Fill;
            SuppDgv.Location = new Point(0, 0);
            SuppDgv.Name = "SuppDgv";
            SuppDgv.RowHeadersWidth = 51;
            SuppDgv.Size = new Size(939, 445);
            SuppDgv.TabIndex = 0;
            // 
            // SupplierFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(936, 610);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "SupplierFrm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += SupplierFrm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)SuppDgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label1;
        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem BtAdd;
        private FontAwesome.Sharp.IconMenuItem BtUpdate;
        private FontAwesome.Sharp.IconMenuItem BtDelete;
        private FontAwesome.Sharp.IconMenuItem BtClose;
        private DataGridView SuppDgv;
    }
}