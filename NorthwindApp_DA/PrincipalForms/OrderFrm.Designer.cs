namespace NorthwindApp_DA
{
    partial class OrderFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderFrm));
            panel1 = new Panel();
            label1 = new Label();
            groupBox1 = new GroupBox();
            label17 = new Label();
            dateTimePicker3 = new DateTimePicker();
            label15 = new Label();
            dateTimePicker2 = new DateTimePicker();
            label14 = new Label();
            dateTimePicker1 = new DateTimePicker();
            TxtShipCountry = new TextBox();
            label8 = new Label();
            TxtCodePostalOrder = new TextBox();
            label7 = new Label();
            TxtRegionOrder = new TextBox();
            label6 = new Label();
            TxtCityOrder = new TextBox();
            label5 = new Label();
            TxtDirecOrder = new TextBox();
            label4 = new Label();
            EmpleadoCbx = new ComboBox();
            label2 = new Label();
            ClienteCbx = new ComboBox();
            label3 = new Label();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            panel3 = new Panel();
            menuStrip1 = new MenuStrip();
            BtCrearOrderDetail = new FontAwesome.Sharp.IconMenuItem();
            BtUpdateorder = new FontAwesome.Sharp.IconMenuItem();
            BtDeleteOrder = new FontAwesome.Sharp.IconMenuItem();
            panel4 = new Panel();
            BtSearch = new Button();
            FilterCbx = new ComboBox();
            label9 = new Label();
            groupBox2 = new GroupBox();
            TxtTotal = new TextBox();
            label11 = new Label();
            ShipViaCbx = new ComboBox();
            label10 = new Label();
            TxtFreight = new TextBox();
            label12 = new Label();
            TxtSubtotal = new TextBox();
            label13 = new Label();
            ShipNameCbx = new ComboBox();
            label16 = new Label();
            BtCancel = new Button();
            BtSave = new Button();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            menuStrip1.SuspendLayout();
            panel4.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 74, 173);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-2, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1062, 95);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(10, 17);
            label1.Name = "label1";
            label1.Size = new Size(236, 62);
            label1.TabIndex = 3;
            label1.Text = "ORDENES";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.Control;
            groupBox1.Controls.Add(label17);
            groupBox1.Controls.Add(dateTimePicker3);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(dateTimePicker2);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(TxtShipCountry);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(TxtCodePostalOrder);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(TxtRegionOrder);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(TxtCityOrder);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(TxtDirecOrder);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(EmpleadoCbx);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(ClienteCbx);
            groupBox1.Controls.Add(label3);
            groupBox1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(22, 106);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(945, 291);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "INGRESAR";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(29, 241);
            label17.Name = "label17";
            label17.Size = new Size(108, 25);
            label17.TabIndex = 19;
            label17.Text = "Fecha envío";
            // 
            // dateTimePicker3
            // 
            dateTimePicker3.CalendarFont = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker3.Location = new Point(147, 237);
            dateTimePicker3.Name = "dateTimePicker3";
            dateTimePicker3.Size = new Size(281, 34);
            dateTimePicker3.TabIndex = 18;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(29, 194);
            label15.Name = "label15";
            label15.Size = new Size(143, 25);
            label15.TabIndex = 17;
            label15.Text = "Fecha requerida";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.CalendarFont = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker2.Location = new Point(173, 190);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(255, 34);
            dateTimePicker2.TabIndex = 16;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(29, 145);
            label14.Name = "label14";
            label14.Size = new Size(112, 25);
            label14.TabIndex = 15;
            label14.Text = "Fecha orden";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarFont = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Location = new Point(147, 141);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(281, 34);
            dateTimePicker1.TabIndex = 14;
            // 
            // TxtShipCountry
            // 
            TxtShipCountry.Location = new Point(667, 237);
            TxtShipCountry.Name = "TxtShipCountry";
            TxtShipCountry.Size = new Size(240, 34);
            TxtShipCountry.TabIndex = 13;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(533, 243);
            label8.Name = "label8";
            label8.Size = new Size(122, 25);
            label8.TabIndex = 12;
            label8.Text = "País de envío";
            // 
            // TxtCodePostalOrder
            // 
            TxtCodePostalOrder.Location = new Point(667, 193);
            TxtCodePostalOrder.Name = "TxtCodePostalOrder";
            TxtCodePostalOrder.Size = new Size(240, 34);
            TxtCodePostalOrder.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(533, 199);
            label7.Name = "label7";
            label7.Size = new Size(128, 25);
            label7.TabIndex = 10;
            label7.Text = "Código Postal";
            // 
            // TxtRegionOrder
            // 
            TxtRegionOrder.Location = new Point(609, 146);
            TxtRegionOrder.Name = "TxtRegionOrder";
            TxtRegionOrder.Size = new Size(298, 34);
            TxtRegionOrder.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(533, 152);
            label6.Name = "label6";
            label6.Size = new Size(71, 25);
            label6.TabIndex = 8;
            label6.Text = "Región";
            // 
            // TxtCityOrder
            // 
            TxtCityOrder.Location = new Point(609, 96);
            TxtCityOrder.Name = "TxtCityOrder";
            TxtCityOrder.Size = new Size(298, 34);
            TxtCityOrder.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(533, 102);
            label5.Name = "label5";
            label5.Size = new Size(70, 25);
            label5.TabIndex = 6;
            label5.Text = "Ciudad";
            // 
            // TxtDirecOrder
            // 
            TxtDirecOrder.Location = new Point(632, 44);
            TxtDirecOrder.Name = "TxtDirecOrder";
            TxtDirecOrder.Size = new Size(275, 34);
            TxtDirecOrder.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(532, 49);
            label4.Name = "label4";
            label4.Size = new Size(90, 25);
            label4.TabIndex = 4;
            label4.Text = "Dirección";
            // 
            // EmpleadoCbx
            // 
            EmpleadoCbx.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EmpleadoCbx.FormattingEnabled = true;
            EmpleadoCbx.Location = new Point(130, 96);
            EmpleadoCbx.Name = "EmpleadoCbx";
            EmpleadoCbx.Size = new Size(298, 33);
            EmpleadoCbx.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 100);
            label2.Name = "label2";
            label2.Size = new Size(94, 25);
            label2.TabIndex = 2;
            label2.Text = "Empleado";
            // 
            // ClienteCbx
            // 
            ClienteCbx.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ClienteCbx.FormattingEnabled = true;
            ClienteCbx.Location = new Point(130, 48);
            ClienteCbx.Name = "ClienteCbx";
            ClienteCbx.Size = new Size(298, 33);
            ClienteCbx.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(53, 52);
            label3.Name = "label3";
            label3.Size = new Size(71, 25);
            label3.TabIndex = 0;
            label3.Text = "Cliente";
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(22, 484);
            panel2.Name = "panel2";
            panel2.Size = new Size(945, 320);
            panel2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(945, 320);
            dataGridView1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(192, 192, 255);
            panel3.Controls.Add(menuStrip1);
            panel3.Location = new Point(481, 426);
            panel3.Name = "panel3";
            panel3.Size = new Size(486, 36);
            panel3.TabIndex = 3;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.Lavender;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { BtCrearOrderDetail, BtUpdateorder, BtDeleteOrder });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(486, 36);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // BtCrearOrderDetail
            // 
            BtCrearOrderDetail.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtCrearOrderDetail.IconChar = FontAwesome.Sharp.IconChar.Tag;
            BtCrearOrderDetail.IconColor = Color.Black;
            BtCrearOrderDetail.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtCrearOrderDetail.Name = "BtCrearOrderDetail";
            BtCrearOrderDetail.Size = new Size(164, 32);
            BtCrearOrderDetail.Text = "Nueva orden";
            // 
            // BtUpdateorder
            // 
            BtUpdateorder.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtUpdateorder.IconChar = FontAwesome.Sharp.IconChar.Pencil;
            BtUpdateorder.IconColor = Color.Black;
            BtUpdateorder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtUpdateorder.Name = "BtUpdateorder";
            BtUpdateorder.Size = new Size(157, 32);
            BtUpdateorder.Text = "Editar orden";
            // 
            // BtDeleteOrder
            // 
            BtDeleteOrder.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtDeleteOrder.IconChar = FontAwesome.Sharp.IconChar.DeleteLeft;
            BtDeleteOrder.IconColor = Color.Black;
            BtDeleteOrder.IconFont = FontAwesome.Sharp.IconFont.Auto;
            BtDeleteOrder.Name = "BtDeleteOrder";
            BtDeleteOrder.Size = new Size(118, 32);
            BtDeleteOrder.Text = "Eliminar";
            // 
            // panel4
            // 
            panel4.BackColor = Color.Lavender;
            panel4.Controls.Add(BtSearch);
            panel4.Controls.Add(FilterCbx);
            panel4.Controls.Add(label9);
            panel4.Location = new Point(22, 426);
            panel4.Name = "panel4";
            panel4.Size = new Size(442, 36);
            panel4.TabIndex = 4;
            // 
            // BtSearch
            // 
            BtSearch.BackColor = Color.Lavender;
            BtSearch.Cursor = Cursors.Hand;
            BtSearch.FlatStyle = FlatStyle.Flat;
            BtSearch.ForeColor = Color.Lavender;
            BtSearch.Image = (Image)resources.GetObject("BtSearch.Image");
            BtSearch.Location = new Point(328, -1);
            BtSearch.Name = "BtSearch";
            BtSearch.Size = new Size(42, 36);
            BtSearch.TabIndex = 8;
            BtSearch.UseVisualStyleBackColor = false;
            // 
            // FilterCbx
            // 
            FilterCbx.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FilterCbx.FormattingEnabled = true;
            FilterCbx.Location = new Point(102, 4);
            FilterCbx.Name = "FilterCbx";
            FilterCbx.Size = new Size(208, 28);
            FilterCbx.TabIndex = 14;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(13, 8);
            label9.Name = "label9";
            label9.Size = new Size(82, 20);
            label9.TabIndex = 0;
            label9.Text = "Buscar por";
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.Control;
            groupBox2.Controls.Add(TxtTotal);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(ShipViaCbx);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(TxtFreight);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(TxtSubtotal);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(ShipNameCbx);
            groupBox2.Controls.Add(label16);
            groupBox2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(22, 806);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(945, 179);
            groupBox2.TabIndex = 5;
            groupBox2.TabStop = false;
            // 
            // TxtTotal
            // 
            TxtTotal.Location = new Point(754, 129);
            TxtTotal.Name = "TxtTotal";
            TxtTotal.Size = new Size(172, 34);
            TxtTotal.TabIndex = 15;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(672, 134);
            label11.Name = "label11";
            label11.Size = new Size(56, 25);
            label11.TabIndex = 14;
            label11.Text = "Total:";
            // 
            // ShipViaCbx
            // 
            ShipViaCbx.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ShipViaCbx.FormattingEnabled = true;
            ShipViaCbx.Location = new Point(141, 107);
            ShipViaCbx.Name = "ShipViaCbx";
            ShipViaCbx.Size = new Size(305, 33);
            ShipViaCbx.TabIndex = 13;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(20, 111);
            label10.Name = "label10";
            label10.Size = new Size(120, 25);
            label10.TabIndex = 12;
            label10.Text = "Transportista";
            // 
            // TxtFreight
            // 
            TxtFreight.Location = new Point(753, 79);
            TxtFreight.Name = "TxtFreight";
            TxtFreight.Size = new Size(172, 34);
            TxtFreight.TabIndex = 9;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(671, 84);
            label12.Name = "label12";
            label12.Size = new Size(73, 25);
            label12.TabIndex = 8;
            label12.Text = "Cargos:";
            // 
            // TxtSubtotal
            // 
            TxtSubtotal.Location = new Point(753, 29);
            TxtSubtotal.Name = "TxtSubtotal";
            TxtSubtotal.Size = new Size(172, 34);
            TxtSubtotal.TabIndex = 7;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(655, 34);
            label13.Name = "label13";
            label13.Size = new Size(87, 25);
            label13.TabIndex = 6;
            label13.Text = "Subtotal:";
            // 
            // ShipNameCbx
            // 
            ShipNameCbx.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ShipNameCbx.FormattingEnabled = true;
            ShipNameCbx.Location = new Point(140, 48);
            ShipNameCbx.Name = "ShipNameCbx";
            ShipNameCbx.Size = new Size(305, 33);
            ShipNameCbx.TabIndex = 1;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Yu Gothic UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(17, 52);
            label16.Name = "label16";
            label16.Size = new Size(114, 25);
            label16.TabIndex = 0;
            label16.Text = "Destinatario";
            // 
            // BtCancel
            // 
            BtCancel.Cursor = Cursors.Hand;
            BtCancel.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtCancel.Location = new Point(873, 1004);
            BtCancel.Name = "BtCancel";
            BtCancel.Size = new Size(94, 39);
            BtCancel.TabIndex = 36;
            BtCancel.Text = "Cancelar";
            BtCancel.UseVisualStyleBackColor = true;
            BtCancel.Click += BtCancel_Click;
            // 
            // BtSave
            // 
            BtSave.Cursor = Cursors.Hand;
            BtSave.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtSave.Location = new Point(773, 1004);
            BtSave.Name = "BtSave";
            BtSave.Size = new Size(94, 39);
            BtSave.TabIndex = 35;
            BtSave.Text = "Guardar";
            BtSave.UseVisualStyleBackColor = true;
            // 
            // OrderFrm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoScroll = true;
            AutoSize = true;
            ClientSize = new Size(991, 1055);
            Controls.Add(BtCancel);
            Controls.Add(BtSave);
            Controls.Add(groupBox2);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            MainMenuStrip = menuStrip1;
            Name = "OrderFrm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Load += OrderFrm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private GroupBox groupBox1;
        private Label label3;
        private ComboBox EmpleadoCbx;
        private Label label2;
        private ComboBox ClienteCbx;
        private Label label4;
        private TextBox TxtCodePostalOrder;
        private Label label7;
        private TextBox TxtRegionOrder;
        private Label label6;
        private TextBox TxtCityOrder;
        private Label label5;
        private TextBox TxtDirecOrder;
        private TextBox TxtShipCountry;
        private Label label8;
        private Panel panel2;
        private DataGridView dataGridView1;
        private Panel panel3;
        private MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem BtUpdateorder;
        private FontAwesome.Sharp.IconMenuItem BtCrearOrderDetail;
        private FontAwesome.Sharp.IconMenuItem BtDeleteOrder;
        private Panel panel4;
        private Label label9;
        private ComboBox FilterCbx;
        private Button BtSearch;
        private GroupBox groupBox2;
        private ComboBox ShipViaCbx;
        private Label label10;
        private TextBox TxtFreight;
        private Label label12;
        private TextBox TxtSubtotal;
        private Label label13;
        private ComboBox ShipNameCbx;
        private Label label16;
        private TextBox TxtTotal;
        private Label label11;
        private Button BtCancel;
        private Button BtSave;
        private DateTimePicker dateTimePicker1;
        private Label label14;
        private Label label17;
        private DateTimePicker dateTimePicker3;
        private Label label15;
        private DateTimePicker dateTimePicker2;
    }
}