namespace NorthwindApp_Final.PrincipalForms
{
    partial class OrderDetailsFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDetailsFrm));
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            BtClose = new Button();
            BtSearch = new Button();
            TxtFiltroOrderD = new TextBox();
            label2 = new Label();
            panel3 = new Panel();
            OrderDetailDgv = new DataGridView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)OrderDetailDgv).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 74, 173);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(976, 93);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(13, 13);
            label1.Name = "label1";
            label1.Size = new Size(553, 62);
            label1.TabIndex = 4;
            label1.Text = "ÓRDENES REGISTRADAS";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Lavender;
            panel2.Controls.Add(BtClose);
            panel2.Controls.Add(BtSearch);
            panel2.Controls.Add(TxtFiltroOrderD);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(-1, 103);
            panel2.Name = "panel2";
            panel2.Size = new Size(976, 45);
            panel2.TabIndex = 1;
            // 
            // BtClose
            // 
            BtClose.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtClose.ForeColor = Color.Red;
            BtClose.Location = new Point(879, 5);
            BtClose.Name = "BtClose";
            BtClose.Size = new Size(85, 35);
            BtClose.TabIndex = 10;
            BtClose.Text = "Cerrar";
            BtClose.UseVisualStyleBackColor = true;
            BtClose.Click += BtClose_Click;
            // 
            // BtSearch
            // 
            BtSearch.BackColor = Color.Lavender;
            BtSearch.Cursor = Cursors.Hand;
            BtSearch.FlatStyle = FlatStyle.Flat;
            BtSearch.ForeColor = Color.Lavender;
            BtSearch.Image = (Image)resources.GetObject("BtSearch.Image");
            BtSearch.Location = new Point(395, 1);
            BtSearch.Name = "BtSearch";
            BtSearch.Size = new Size(42, 41);
            BtSearch.TabIndex = 9;
            BtSearch.UseVisualStyleBackColor = false;
            BtSearch.Click += BtSearch_Click_1;
            // 
            // TxtFiltroOrderD
            // 
            TxtFiltroOrderD.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtFiltroOrderD.Location = new Point(116, 8);
            TxtFiltroOrderD.Name = "TxtFiltroOrderD";
            TxtFiltroOrderD.Size = new Size(267, 30);
            TxtFiltroOrderD.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(18, 11);
            label2.Name = "label2";
            label2.Size = new Size(91, 23);
            label2.TabIndex = 0;
            label2.Text = "Buscar por";
            // 
            // panel3
            // 
            panel3.Controls.Add(OrderDetailDgv);
            panel3.Location = new Point(-1, 164);
            panel3.Name = "panel3";
            panel3.Size = new Size(976, 406);
            panel3.TabIndex = 2;
            // 
            // OrderDetailDgv
            // 
            OrderDetailDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            OrderDetailDgv.Dock = DockStyle.Fill;
            OrderDetailDgv.Location = new Point(0, 0);
            OrderDetailDgv.Name = "OrderDetailDgv";
            OrderDetailDgv.RowHeadersWidth = 51;
            OrderDetailDgv.Size = new Size(976, 406);
            OrderDetailDgv.TabIndex = 0;
            // 
            // OrderDetailsFrm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(975, 565);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "OrderDetailsFrm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += OrderDetailsFrm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)OrderDetailDgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private TextBox TxtFiltroOrderD;
        private Label label2;
        private Button BtSearch;
        private Panel panel3;
        private DataGridView OrderDetailDgv;
        private Button BtClose;
    }
}