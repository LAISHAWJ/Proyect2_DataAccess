namespace NorthwindApp_Final.PrincipalForms
{
    partial class CustomerFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerFrm));
            panel1 = new Panel();
            panel4 = new Panel();
            TxtBuscarId = new TextBox();
            BtSearch = new Button();
            label2 = new Label();
            panel2 = new Panel();
            DtGVwCustomer = new DataGridView();
            panel3 = new Panel();
            menuStrip1 = new MenuStrip();
            BtAdd = new FontAwesome.Sharp.IconMenuItem();
            BtUpdate = new FontAwesome.Sharp.IconMenuItem();
            BtDelete = new FontAwesome.Sharp.IconMenuItem();
            BtClose = new FontAwesome.Sharp.IconMenuItem();
            label1 = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DtGVwCustomer).BeginInit();
            panel3.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(0, 74, 173);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-1, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1010, 672);
            panel1.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.AutoSize = true;
            panel4.BackColor = Color.Lavender;
            panel4.Controls.Add(TxtBuscarId);
            panel4.Controls.Add(BtSearch);
            panel4.Controls.Add(label2);
            panel4.Location = new Point(0, 156);
            panel4.Name = "panel4";
            panel4.Size = new Size(1007, 54);
            panel4.TabIndex = 4;
            // 
            // TxtBuscarId
            // 
            TxtBuscarId.Location = new Point(94, 14);
            TxtBuscarId.Name = "TxtBuscarId";
            TxtBuscarId.Size = new Size(228, 27);
            TxtBuscarId.TabIndex = 8;
            // 
            // BtSearch
            // 
            BtSearch.BackColor = Color.Lavender;
            BtSearch.Cursor = Cursors.Hand;
            BtSearch.FlatStyle = FlatStyle.Flat;
            BtSearch.ForeColor = Color.Lavender;
            BtSearch.Image = (Image)resources.GetObject("BtSearch.Image");
            BtSearch.Location = new Point(327, 3);
            BtSearch.Name = "BtSearch";
            BtSearch.Size = new Size(44, 48);
            BtSearch.TabIndex = 7;
            BtSearch.UseVisualStyleBackColor = false;
            BtSearch.Click += BtSearch_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(17, 13);
            label2.Name = "label2";
            label2.Size = new Size(71, 28);
            label2.TabIndex = 0;
            label2.Text = "Buscar";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DimGray;
            panel2.Controls.Add(DtGVwCustomer);
            panel2.Location = new Point(-1, 213);
            panel2.Name = "panel2";
            panel2.Size = new Size(1008, 456);
            panel2.TabIndex = 3;
            // 
            // DtGVwCustomer
            // 
            DtGVwCustomer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DtGVwCustomer.Dock = DockStyle.Fill;
            DtGVwCustomer.Location = new Point(0, 0);
            DtGVwCustomer.Name = "DtGVwCustomer";
            DtGVwCustomer.RowHeadersWidth = 51;
            DtGVwCustomer.Size = new Size(1008, 456);
            DtGVwCustomer.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Controls.Add(menuStrip1);
            panel3.Location = new Point(3, 113);
            panel3.Name = "panel3";
            panel3.Size = new Size(1004, 47);
            panel3.TabIndex = 2;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { BtAdd, BtUpdate, BtDelete, BtClose });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1004, 36);
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
            label1.Location = new Point(761, 18);
            label1.Name = "label1";
            label1.Size = new Size(229, 62);
            label1.TabIndex = 1;
            label1.Text = "CLIENTES";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // CustomerFrm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1009, 664);
            Controls.Add(panel1);
            Name = "CustomerFrm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += CustomerFrm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DtGVwCustomer).EndInit();
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
        private DataGridView DtGVwCustomer;
        private Panel panel3;
        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem BtAdd;
        private FontAwesome.Sharp.IconMenuItem BtUpdate;
        private FontAwesome.Sharp.IconMenuItem BtDelete;
        private FontAwesome.Sharp.IconMenuItem BtClose;
        private Label label1;
        private Panel panel4;
        private TextBox TxtBuscarId;
        private Button BtSearch;
        private Label label2;
    }
}