namespace NorthwindApp_DA.CrearEditRegisFrm
{
    partial class OrderCrearFrm
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
            panel2 = new Panel();
            label2 = new Label();
            panel3 = new Panel();
            ProductOrderDgv = new DataGridView();
            label3 = new Label();
            label4 = new Label();
            TxtCantidad = new TextBox();
            TxtDescuento = new TextBox();
            BtCrear = new Button();
            BtCerrar = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ProductOrderDgv).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(0, 74, 173);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(814, 86);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(10, 11);
            label1.Name = "label1";
            label1.Size = new Size(392, 62);
            label1.TabIndex = 4;
            label1.Text = "CREAR ORDENES";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Lavender;
            panel2.Controls.Add(label2);
            panel2.Location = new Point(0, 112);
            panel2.Name = "panel2";
            panel2.Size = new Size(814, 33);
            panel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ActiveCaptionText;
            label2.Location = new Point(11, 4);
            label2.Name = "label2";
            label2.Size = new Size(119, 25);
            label2.TabIndex = 5;
            label2.Text = "PRODUCTOS";
            label2.TextAlign = ContentAlignment.TopRight;
            // 
            // panel3
            // 
            panel3.Controls.Add(ProductOrderDgv);
            panel3.Location = new Point(0, 145);
            panel3.Name = "panel3";
            panel3.Size = new Size(814, 337);
            panel3.TabIndex = 2;
            // 
            // ProductOrderDgv
            // 
            ProductOrderDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ProductOrderDgv.Dock = DockStyle.Fill;
            ProductOrderDgv.Location = new Point(0, 0);
            ProductOrderDgv.Name = "ProductOrderDgv";
            ProductOrderDgv.RowHeadersWidth = 51;
            ProductOrderDgv.Size = new Size(814, 337);
            ProductOrderDgv.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(15, 504);
            label3.Name = "label3";
            label3.Size = new Size(92, 28);
            label3.TabIndex = 3;
            label3.Text = "Cantidad";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(343, 505);
            label4.Name = "label4";
            label4.Size = new Size(109, 28);
            label4.TabIndex = 4;
            label4.Text = "Descuento";
            // 
            // TxtCantidad
            // 
            TxtCantidad.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtCantidad.Location = new Point(113, 501);
            TxtCantidad.Name = "TxtCantidad";
            TxtCantidad.Size = new Size(212, 34);
            TxtCantidad.TabIndex = 5;
            // 
            // TxtDescuento
            // 
            TxtDescuento.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtDescuento.Location = new Point(455, 502);
            TxtDescuento.Name = "TxtDescuento";
            TxtDescuento.Size = new Size(212, 34);
            TxtDescuento.TabIndex = 6;
            // 
            // BtCrear
            // 
            BtCrear.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtCrear.Location = new Point(603, 560);
            BtCrear.Name = "BtCrear";
            BtCrear.Size = new Size(98, 37);
            BtCrear.TabIndex = 7;
            BtCrear.Text = "Crear";
            BtCrear.UseVisualStyleBackColor = true;
            BtCrear.Click += BtCrear_Click;
            // 
            // BtCerrar
            // 
            BtCerrar.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtCerrar.ForeColor = Color.Red;
            BtCerrar.Location = new Point(707, 560);
            BtCerrar.Name = "BtCerrar";
            BtCerrar.Size = new Size(98, 37);
            BtCerrar.TabIndex = 8;
            BtCerrar.Text = "Cerrar";
            BtCerrar.UseVisualStyleBackColor = true;
            BtCerrar.Click += button1_Click;
            // 
            // OrderCrearFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(814, 609);
            Controls.Add(BtCerrar);
            Controls.Add(BtCrear);
            Controls.Add(TxtDescuento);
            Controls.Add(TxtCantidad);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "OrderCrearFrm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ProductOrderDgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Panel panel3;
        private DataGridView ProductOrderDgv;
        private Label label3;
        private Label label4;
        private TextBox TxtCantidad;
        private TextBox TxtDescuento;
        private Button BtCrear;
        private Button BtCerrar;
    }
}