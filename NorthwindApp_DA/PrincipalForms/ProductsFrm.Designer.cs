namespace NorthwindApp_DA
{
    partial class ProductsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductsFrm));
            panel1 = new Panel();
            panel3 = new Panel();
            menuStrip1 = new MenuStrip();
            BtAdd = new FontAwesome.Sharp.IconMenuItem();
            BtUpdate = new FontAwesome.Sharp.IconMenuItem();
            BtDelete = new FontAwesome.Sharp.IconMenuItem();
            BtClose = new FontAwesome.Sharp.IconMenuItem();
            label1 = new Label();
            panel2 = new Panel();
            ProductDgv = new DataGridView();
            panel4 = new Panel();
            StatusCbx = new ComboBox();
            label4 = new Label();
            BtSearch = new Button();
            CmbxSup = new ComboBox();
            label3 = new Label();
            CmbxCat = new ComboBox();
            label2 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ProductDgv).BeginInit();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(0, 74, 173);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(990, 142);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(menuStrip1);
            panel3.Location = new Point(1, 92);
            panel3.Name = "panel3";
            panel3.Size = new Size(986, 41);
            panel3.TabIndex = 3;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { BtAdd, BtUpdate, BtDelete, BtClose });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(986, 36);
            menuStrip1.TabIndex = 2;
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
            label1.Location = new Point(672, 8);
            label1.Name = "label1";
            label1.Size = new Size(303, 62);
            label1.TabIndex = 2;
            label1.Text = "PRODUCTOS";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(ProductDgv);
            panel2.Location = new Point(0, 212);
            panel2.Name = "panel2";
            panel2.Size = new Size(987, 410);
            panel2.TabIndex = 1;
            // 
            // ProductDgv
            // 
            ProductDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ProductDgv.Dock = DockStyle.Fill;
            ProductDgv.Location = new Point(0, 0);
            ProductDgv.Name = "ProductDgv";
            ProductDgv.RowHeadersWidth = 51;
            ProductDgv.Size = new Size(987, 410);
            ProductDgv.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.AutoSize = true;
            panel4.BackColor = Color.Lavender;
            panel4.Controls.Add(StatusCbx);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(BtSearch);
            panel4.Controls.Add(CmbxSup);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(CmbxCat);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(0, 148);
            panel4.Name = "panel4";
            panel4.Size = new Size(987, 57);
            panel4.TabIndex = 2;
            // 
            // StatusCbx
            // 
            StatusCbx.FormattingEnabled = true;
            StatusCbx.Location = new Point(757, 13);
            StatusCbx.Name = "StatusCbx";
            StatusCbx.Size = new Size(168, 28);
            StatusCbx.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(684, 12);
            label4.Name = "label4";
            label4.Size = new Size(72, 28);
            label4.TabIndex = 8;
            label4.Text = "Estado";
            // 
            // BtSearch
            // 
            BtSearch.BackColor = Color.Lavender;
            BtSearch.Cursor = Cursors.Hand;
            BtSearch.FlatStyle = FlatStyle.Flat;
            BtSearch.ForeColor = Color.Lavender;
            BtSearch.Image = (Image)resources.GetObject("BtSearch.Image");
            BtSearch.Location = new Point(933, 3);
            BtSearch.Name = "BtSearch";
            BtSearch.Size = new Size(44, 48);
            BtSearch.TabIndex = 7;
            BtSearch.UseVisualStyleBackColor = false;
            BtSearch.Click += BtSearch_Click;
            // 
            // CmbxSup
            // 
            CmbxSup.FormattingEnabled = true;
            CmbxSup.Location = new Point(440, 13);
            CmbxSup.Name = "CmbxSup";
            CmbxSup.Size = new Size(231, 28);
            CmbxSup.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(348, 13);
            label3.Name = "label3";
            label3.Size = new Size(88, 28);
            label3.TabIndex = 2;
            label3.Text = "Suplidor";
            // 
            // CmbxCat
            // 
            CmbxCat.FormattingEnabled = true;
            CmbxCat.Location = new Point(108, 14);
            CmbxCat.Name = "CmbxCat";
            CmbxCat.Size = new Size(231, 28);
            CmbxCat.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(7, 14);
            label2.Name = "label2";
            label2.Size = new Size(98, 28);
            label2.TabIndex = 0;
            label2.Text = "Categoria";
            // 
            // ProductsFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(987, 622);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "ProductsFrm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += ProductsFrm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ProductDgv).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem BtAdd;
        private FontAwesome.Sharp.IconMenuItem BtUpdate;
        private FontAwesome.Sharp.IconMenuItem BtDelete;
        private FontAwesome.Sharp.IconMenuItem BtClose;
        private Panel panel4;
        private DataGridView ProductDgv;
        private Button BtSearch;
        private ComboBox CmbxSup;
        private Label label3;
        private ComboBox CmbxCat;
        private Label label2;
        private ComboBox StatusCbx;
        private Label label4;
    }
}