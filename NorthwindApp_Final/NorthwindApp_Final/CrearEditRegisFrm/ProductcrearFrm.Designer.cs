namespace NorthwindApp_Final.CrearEditRegisFrm
{
    partial class ProductcrearFrm
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
            label1 = new Label();
            TxtNameProduct = new TextBox();
            label2 = new Label();
            SuppCmbx = new ComboBox();
            label5 = new Label();
            CategCmbx = new ComboBox();
            label4 = new Label();
            TxtQuantityPerUnit = new TextBox();
            label3 = new Label();
            TxtUnitPrice = new TextBox();
            label6 = new Label();
            TxtUnitsInStock = new TextBox();
            label7 = new Label();
            TxtUnitsOnOrder = new TextBox();
            label8 = new Label();
            TxtReorderLevel = new TextBox();
            label9 = new Label();
            DiscontCbx = new CheckBox();
            BtCancel = new Button();
            BtSave = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 74, 173);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-2, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(692, 95);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(303, 62);
            label1.TabIndex = 2;
            label1.Text = "PRODUCTOS";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // TxtNameProduct
            // 
            TxtNameProduct.Font = new Font("Yu Gothic UI", 12F);
            TxtNameProduct.Location = new Point(111, 121);
            TxtNameProduct.Name = "TxtNameProduct";
            TxtNameProduct.Size = new Size(400, 34);
            TxtNameProduct.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label2.Location = new Point(12, 124);
            label2.Name = "label2";
            label2.Size = new Size(93, 28);
            label2.TabIndex = 5;
            label2.Text = "Nombre ";
            // 
            // SuppCmbx
            // 
            SuppCmbx.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            SuppCmbx.FormattingEnabled = true;
            SuppCmbx.Items.AddRange(new object[] { "Activo", "Eliminado" });
            SuppCmbx.Location = new Point(124, 238);
            SuppCmbx.Name = "SuppCmbx";
            SuppCmbx.Size = new Size(387, 35);
            SuppCmbx.TabIndex = 20;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(12, 241);
            label5.Name = "label5";
            label5.Size = new Size(88, 28);
            label5.TabIndex = 19;
            label5.Text = "Suplidor";
            // 
            // CategCmbx
            // 
            CategCmbx.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CategCmbx.FormattingEnabled = true;
            CategCmbx.Items.AddRange(new object[] { "Activo", "Eliminado" });
            CategCmbx.Location = new Point(124, 178);
            CategCmbx.Name = "CategCmbx";
            CategCmbx.Size = new Size(387, 35);
            CategCmbx.TabIndex = 18;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 181);
            label4.Name = "label4";
            label4.Size = new Size(98, 28);
            label4.TabIndex = 17;
            label4.Text = "Categoria";
            // 
            // TxtQuantityPerUnit
            // 
            TxtQuantityPerUnit.Font = new Font("Yu Gothic UI", 12F);
            TxtQuantityPerUnit.Location = new Point(218, 306);
            TxtQuantityPerUnit.Name = "TxtQuantityPerUnit";
            TxtQuantityPerUnit.Size = new Size(293, 34);
            TxtQuantityPerUnit.TabIndex = 22;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label3.Location = new Point(12, 308);
            label3.Name = "label3";
            label3.Size = new Size(200, 28);
            label3.TabIndex = 21;
            label3.Text = "Cantidad por Unidad";
            // 
            // TxtUnitPrice
            // 
            TxtUnitPrice.Font = new Font("Yu Gothic UI", 12F);
            TxtUnitPrice.Location = new Point(218, 366);
            TxtUnitPrice.Name = "TxtUnitPrice";
            TxtUnitPrice.Size = new Size(293, 34);
            TxtUnitPrice.TabIndex = 24;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label6.Location = new Point(12, 369);
            label6.Name = "label6";
            label6.Size = new Size(146, 28);
            label6.TabIndex = 23;
            label6.Text = "Precio Unitario";
            // 
            // TxtUnitsInStock
            // 
            TxtUnitsInStock.Font = new Font("Yu Gothic UI", 12F);
            TxtUnitsInStock.Location = new Point(218, 426);
            TxtUnitsInStock.Name = "TxtUnitsInStock";
            TxtUnitsInStock.Size = new Size(293, 34);
            TxtUnitsInStock.TabIndex = 26;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label7.Location = new Point(12, 429);
            label7.Name = "label7";
            label7.Size = new Size(182, 28);
            label7.TabIndex = 25;
            label7.Text = "Unidades en Stock";
            // 
            // TxtUnitsOnOrder
            // 
            TxtUnitsOnOrder.Font = new Font("Yu Gothic UI", 12F);
            TxtUnitsOnOrder.Location = new Point(218, 491);
            TxtUnitsOnOrder.Name = "TxtUnitsOnOrder";
            TxtUnitsOnOrder.Size = new Size(293, 34);
            TxtUnitsOnOrder.TabIndex = 28;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label8.Location = new Point(12, 494);
            label8.Name = "label8";
            label8.Size = new Size(186, 28);
            label8.TabIndex = 27;
            label8.Text = "Unidades en orden";
            // 
            // TxtReorderLevel
            // 
            TxtReorderLevel.Font = new Font("Yu Gothic UI", 12F);
            TxtReorderLevel.Location = new Point(218, 553);
            TxtReorderLevel.Name = "TxtReorderLevel";
            TxtReorderLevel.Size = new Size(293, 34);
            TxtReorderLevel.TabIndex = 30;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label9.Location = new Point(12, 556);
            label9.Name = "label9";
            label9.Size = new Size(165, 28);
            label9.TabIndex = 29;
            label9.Text = "Nivel de reorden";
            // 
            // DiscontCbx
            // 
            DiscontCbx.AutoSize = true;
            DiscontCbx.Cursor = Cursors.Hand;
            DiscontCbx.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DiscontCbx.Location = new Point(364, 613);
            DiscontCbx.Margin = new Padding(5);
            DiscontCbx.Name = "DiscontCbx";
            DiscontCbx.Size = new Size(147, 27);
            DiscontCbx.TabIndex = 32;
            DiscontCbx.Text = "Descontinuado";
            DiscontCbx.UseVisualStyleBackColor = true;
            // 
            // BtCancel
            // 
            BtCancel.Cursor = Cursors.Hand;
            BtCancel.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtCancel.Location = new Point(124, 650);
            BtCancel.Name = "BtCancel";
            BtCancel.Size = new Size(94, 39);
            BtCancel.TabIndex = 34;
            BtCancel.Text = "Cancelar";
            BtCancel.UseVisualStyleBackColor = true;
            BtCancel.Click += BtCancel_Click;
            // 
            // BtSave
            // 
            BtSave.Cursor = Cursors.Hand;
            BtSave.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtSave.Location = new Point(24, 650);
            BtSave.Name = "BtSave";
            BtSave.Size = new Size(94, 39);
            BtSave.TabIndex = 33;
            BtSave.Text = "Guardar";
            BtSave.UseVisualStyleBackColor = true;
            BtSave.Click += BtSave_Click;
            // 
            // ProductcrearFrm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(542, 711);
            Controls.Add(BtCancel);
            Controls.Add(BtSave);
            Controls.Add(DiscontCbx);
            Controls.Add(TxtReorderLevel);
            Controls.Add(label9);
            Controls.Add(TxtUnitsOnOrder);
            Controls.Add(label8);
            Controls.Add(TxtUnitsInStock);
            Controls.Add(label7);
            Controls.Add(TxtUnitPrice);
            Controls.Add(label6);
            Controls.Add(TxtQuantityPerUnit);
            Controls.Add(label3);
            Controls.Add(SuppCmbx);
            Controls.Add(label5);
            Controls.Add(CategCmbx);
            Controls.Add(label4);
            Controls.Add(TxtNameProduct);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "ProductcrearFrm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox TxtNameProduct;
        private Label label2;
        private ComboBox SuppCmbx;
        private Label label5;
        private ComboBox CategCmbx;
        private Label label4;
        private TextBox TxtQuantityPerUnit;
        private Label label3;
        private TextBox TxtUnitPrice;
        private Label label6;
        private TextBox TxtUnitsInStock;
        private Label label7;
        private TextBox TxtUnitsOnOrder;
        private Label label8;
        private TextBox TxtReorderLevel;
        private Label label9;
        private CheckBox DiscontCbx;
        private Button BtCancel;
        private Button BtSave;
    }
}