namespace NorthwindApp_Final.PrincipalForms
{
    partial class MenuFrm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuFrm));
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            BtCategory = new FontAwesome.Sharp.IconMenuItem();
            BtProducts = new FontAwesome.Sharp.IconMenuItem();
            BtSupplier = new FontAwesome.Sharp.IconMenuItem();
            BtAllOrder = new FontAwesome.Sharp.IconMenuItem();
            BtCrearOrder = new FontAwesome.Sharp.IconMenuItem();
            BtViewOrder = new FontAwesome.Sharp.IconMenuItem();
            BtEntidadesPlus = new FontAwesome.Sharp.IconMenuItem();
            BtEmployee = new FontAwesome.Sharp.IconMenuItem();
            BtCustomer = new FontAwesome.Sharp.IconMenuItem();
            BtShipper = new FontAwesome.Sharp.IconMenuItem();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 96);
            panel2.Name = "panel2";
            panel2.Size = new Size(968, 514);
            panel2.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(968, 514);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.FromArgb(0, 74, 173);
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { BtCategory, BtProducts, BtSupplier, BtAllOrder, BtEntidadesPlus });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(968, 96);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // BtCategory
            // 
            BtCategory.CheckOnClick = true;
            BtCategory.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtCategory.ForeColor = SystemColors.ButtonHighlight;
            BtCategory.IconChar = FontAwesome.Sharp.IconChar.ListSquares;
            BtCategory.IconColor = SystemColors.ButtonHighlight;
            BtCategory.IconFont = FontAwesome.Sharp.IconFont.Solid;
            BtCategory.IconSize = 60;
            BtCategory.ImageScaling = ToolStripItemImageScaling.None;
            BtCategory.Name = "BtCategory";
            BtCategory.Size = new Size(131, 92);
            BtCategory.Text = "CATEGORIA";
            BtCategory.TextImageRelation = TextImageRelation.ImageAboveText;
            BtCategory.Click += BtCategory_Click;
            // 
            // BtProducts
            // 
            BtProducts.BackColor = Color.FromArgb(0, 74, 173);
            BtProducts.CheckOnClick = true;
            BtProducts.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtProducts.ForeColor = SystemColors.ButtonHighlight;
            BtProducts.IconChar = FontAwesome.Sharp.IconChar.Box;
            BtProducts.IconColor = SystemColors.ButtonHighlight;
            BtProducts.IconFont = FontAwesome.Sharp.IconFont.Solid;
            BtProducts.IconSize = 60;
            BtProducts.ImageScaling = ToolStripItemImageScaling.None;
            BtProducts.Name = "BtProducts";
            BtProducts.Size = new Size(142, 92);
            BtProducts.Text = "PRODUCTOS";
            BtProducts.TextImageRelation = TextImageRelation.ImageAboveText;
            BtProducts.Click += BtProducts_Click;
            // 
            // BtSupplier
            // 
            BtSupplier.CheckOnClick = true;
            BtSupplier.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtSupplier.ForeColor = SystemColors.ButtonHighlight;
            BtSupplier.IconChar = FontAwesome.Sharp.IconChar.Truck;
            BtSupplier.IconColor = SystemColors.ButtonHighlight;
            BtSupplier.IconFont = FontAwesome.Sharp.IconFont.Solid;
            BtSupplier.IconSize = 60;
            BtSupplier.ImageScaling = ToolStripItemImageScaling.None;
            BtSupplier.Name = "BtSupplier";
            BtSupplier.Size = new Size(141, 92);
            BtSupplier.Text = "SUPLIDORES";
            BtSupplier.TextImageRelation = TextImageRelation.ImageAboveText;
            BtSupplier.Click += BtSupplier_Click;
            // 
            // BtAllOrder
            // 
            BtAllOrder.CheckOnClick = true;
            BtAllOrder.DropDownItems.AddRange(new ToolStripItem[] { BtCrearOrder, BtViewOrder });
            BtAllOrder.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtAllOrder.ForeColor = SystemColors.ButtonHighlight;
            BtAllOrder.IconChar = FontAwesome.Sharp.IconChar.BoxesPacking;
            BtAllOrder.IconColor = SystemColors.ButtonHighlight;
            BtAllOrder.IconFont = FontAwesome.Sharp.IconFont.Solid;
            BtAllOrder.IconSize = 60;
            BtAllOrder.ImageScaling = ToolStripItemImageScaling.None;
            BtAllOrder.Name = "BtAllOrder";
            BtAllOrder.Size = new Size(113, 92);
            BtAllOrder.Text = "ORDENES";
            BtAllOrder.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // BtCrearOrder
            // 
            BtCrearOrder.IconChar = FontAwesome.Sharp.IconChar.Edit;
            BtCrearOrder.IconColor = Color.Black;
            BtCrearOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtCrearOrder.Name = "BtCrearOrder";
            BtCrearOrder.Size = new Size(284, 32);
            BtCrearOrder.Text = "Crear orden";
            BtCrearOrder.Click += BtCrearOrder_Click;
            // 
            // BtViewOrder
            // 
            BtViewOrder.IconChar = FontAwesome.Sharp.IconChar.ListSquares;
            BtViewOrder.IconColor = Color.Black;
            BtViewOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtViewOrder.Name = "BtViewOrder";
            BtViewOrder.Size = new Size(284, 32);
            BtViewOrder.Text = "Ver orden registrada";
            BtViewOrder.Click += BtViewOrder_Click;
            // 
            // BtEntidadesPlus
            // 
            BtEntidadesPlus.CheckOnClick = true;
            BtEntidadesPlus.DropDownItems.AddRange(new ToolStripItem[] { BtEmployee, BtCustomer, BtShipper });
            BtEntidadesPlus.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtEntidadesPlus.ForeColor = SystemColors.ButtonHighlight;
            BtEntidadesPlus.IconChar = FontAwesome.Sharp.IconChar.EllipsisH;
            BtEntidadesPlus.IconColor = SystemColors.ButtonHighlight;
            BtEntidadesPlus.IconFont = FontAwesome.Sharp.IconFont.Solid;
            BtEntidadesPlus.IconSize = 60;
            BtEntidadesPlus.ImageScaling = ToolStripItemImageScaling.None;
            BtEntidadesPlus.Name = "BtEntidadesPlus";
            BtEntidadesPlus.Size = new Size(90, 92);
            BtEntidadesPlus.Text = "OTROS";
            BtEntidadesPlus.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // BtEmployee
            // 
            BtEmployee.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup;
            BtEmployee.IconColor = Color.Black;
            BtEmployee.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtEmployee.Name = "BtEmployee";
            BtEmployee.Size = new Size(223, 32);
            BtEmployee.Text = "Empleados";
            BtEmployee.Click += BtEmployee_Click;
            // 
            // BtCustomer
            // 
            BtCustomer.IconChar = FontAwesome.Sharp.IconChar.PeopleLine;
            BtCustomer.IconColor = Color.Black;
            BtCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtCustomer.Name = "BtCustomer";
            BtCustomer.Size = new Size(223, 32);
            BtCustomer.Text = "Clientes";
            BtCustomer.Click += BtCustomer_Click;
            // 
            // BtShipper
            // 
            BtShipper.IconChar = FontAwesome.Sharp.IconChar.PeopleCarryBox;
            BtShipper.IconColor = Color.Black;
            BtShipper.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtShipper.Name = "BtShipper";
            BtShipper.Size = new Size(223, 32);
            BtShipper.Text = "Transportistas";
            BtShipper.Click += BtShipper_Click;
            // 
            // MenuFrm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(968, 610);
            Controls.Add(panel2);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MenuFrm";
            StartPosition = FormStartPosition.CenterScreen;
            FormClosing += MenuFrm_FormClosing;
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel2;
        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem BtCategory;
        private FontAwesome.Sharp.IconMenuItem BtProducts;
        private FontAwesome.Sharp.IconMenuItem BtSupplier;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconMenuItem BtAllOrder;
        private FontAwesome.Sharp.IconMenuItem BtViewOrder;
        private FontAwesome.Sharp.IconMenuItem BtCrearOrder;
        private FontAwesome.Sharp.IconMenuItem BtEntidadesPlus;
        private FontAwesome.Sharp.IconMenuItem BtEmployee;
        private FontAwesome.Sharp.IconMenuItem BtCustomer;
        private FontAwesome.Sharp.IconMenuItem BtShipper;
    }
}
