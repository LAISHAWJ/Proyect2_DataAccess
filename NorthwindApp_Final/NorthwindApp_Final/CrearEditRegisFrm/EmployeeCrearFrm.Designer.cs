namespace NorthwindApp_Final.CrearEditRegisFrm
{
    partial class EmployeeCrearFrm
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
            TxtDateTimHire = new DateTimePicker();
            label7 = new Label();
            groupBox1 = new GroupBox();
            TxtTitleCortes = new TextBox();
            label16 = new Label();
            TxtExt = new TextBox();
            label14 = new Label();
            TxtPhone = new TextBox();
            label13 = new Label();
            TxtDateTimBirth = new DateTimePicker();
            label6 = new Label();
            TxtLastNames = new TextBox();
            label3 = new Label();
            TxtNames = new TextBox();
            label2 = new Label();
            groupBox2 = new GroupBox();
            TxtCountry = new TextBox();
            label12 = new Label();
            TxtCodePostal = new TextBox();
            label11 = new Label();
            TxtRegion = new TextBox();
            label10 = new Label();
            TxtCity = new TextBox();
            label9 = new Label();
            TxtDirec = new TextBox();
            label8 = new Label();
            groupBox3 = new GroupBox();
            TxtTitle = new TextBox();
            label4 = new Label();
            groupBox4 = new GroupBox();
            label15 = new Label();
            TxtNotes = new TextBox();
            label5 = new Label();
            BtSubir = new Button();
            PbxEmployee = new PictureBox();
            BtCancel = new Button();
            BtSave = new Button();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbxEmployee).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 74, 173);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(1, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(1229, 95);
            panel1.TabIndex = 25;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(12, 17);
            label1.Name = "label1";
            label1.Size = new Size(296, 62);
            label1.TabIndex = 2;
            label1.Text = "EMPLEADOS";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // TxtDateTimHire
            // 
            TxtDateTimHire.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtDateTimHire.Location = new Point(119, 49);
            TxtDateTimHire.Name = "TxtDateTimHire";
            TxtDateTimHire.Size = new Size(360, 30);
            TxtDateTimHire.TabIndex = 50;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label7.Location = new Point(13, 50);
            label7.Name = "label7";
            label7.Size = new Size(91, 28);
            label7.TabIndex = 49;
            label7.Text = "Contrato";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TxtTitleCortes);
            groupBox1.Controls.Add(label16);
            groupBox1.Controls.Add(TxtExt);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(TxtPhone);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(TxtDateTimBirth);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(TxtLastNames);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(TxtNames);
            groupBox1.Controls.Add(label2);
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(35, 104);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(518, 369);
            groupBox1.TabIndex = 65;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información personal";
            // 
            // TxtTitleCortes
            // 
            TxtTitleCortes.Font = new Font("Yu Gothic UI", 12F);
            TxtTitleCortes.Location = new Point(160, 153);
            TxtTitleCortes.Name = "TxtTitleCortes";
            TxtTitleCortes.Size = new Size(338, 34);
            TxtTitleCortes.TabIndex = 33;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label16.Location = new Point(16, 156);
            label16.Name = "label16";
            label16.Size = new Size(143, 28);
            label16.TabIndex = 68;
            label16.Text = "Título Cortesía";
            // 
            // TxtExt
            // 
            TxtExt.Font = new Font("Yu Gothic UI", 12F);
            TxtExt.Location = new Point(160, 299);
            TxtExt.Name = "TxtExt";
            TxtExt.Size = new Size(339, 34);
            TxtExt.TabIndex = 64;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label14.Location = new Point(16, 302);
            label14.Name = "label14";
            label14.Size = new Size(100, 28);
            label14.TabIndex = 63;
            label14.Text = "Extensión";
            // 
            // TxtPhone
            // 
            TxtPhone.Font = new Font("Yu Gothic UI", 12F);
            TxtPhone.Location = new Point(160, 248);
            TxtPhone.Name = "TxtPhone";
            TxtPhone.Size = new Size(338, 34);
            TxtPhone.TabIndex = 62;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label13.Location = new Point(16, 251);
            label13.Name = "label13";
            label13.Size = new Size(91, 28);
            label13.TabIndex = 61;
            label13.Text = "Teléfono";
            // 
            // TxtDateTimBirth
            // 
            TxtDateTimBirth.CalendarFont = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtDateTimBirth.Location = new Point(160, 203);
            TxtDateTimBirth.Name = "TxtDateTimBirth";
            TxtDateTimBirth.Size = new Size(338, 30);
            TxtDateTimBirth.TabIndex = 50;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label6.Location = new Point(16, 202);
            label6.Name = "label6";
            label6.Size = new Size(125, 28);
            label6.TabIndex = 49;
            label6.Text = "Cumpleaños";
            // 
            // TxtLastNames
            // 
            TxtLastNames.Font = new Font("Yu Gothic UI", 12F);
            TxtLastNames.Location = new Point(118, 97);
            TxtLastNames.Name = "TxtLastNames";
            TxtLastNames.Size = new Size(380, 34);
            TxtLastNames.TabIndex = 32;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label3.Location = new Point(16, 100);
            label3.Name = "label3";
            label3.Size = new Size(96, 28);
            label3.TabIndex = 32;
            label3.Text = "Apellidos";
            label3.Click += label3_Click;
            // 
            // TxtNames
            // 
            TxtNames.Font = new Font("Yu Gothic UI", 12F);
            TxtNames.Location = new Point(118, 46);
            TxtNames.Name = "TxtNames";
            TxtNames.Size = new Size(380, 34);
            TxtNames.TabIndex = 31;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label2.Location = new Point(16, 49);
            label2.Name = "label2";
            label2.Size = new Size(96, 28);
            label2.TabIndex = 30;
            label2.Text = "Nombres";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(TxtCountry);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(TxtCodePostal);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(TxtRegion);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(TxtCity);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(TxtDirec);
            groupBox2.Controls.Add(label8);
            groupBox2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(35, 485);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(518, 314);
            groupBox2.TabIndex = 68;
            groupBox2.TabStop = false;
            groupBox2.Text = "Direcciones";
            // 
            // TxtCountry
            // 
            TxtCountry.Font = new Font("Yu Gothic UI", 12F);
            TxtCountry.Location = new Point(174, 247);
            TxtCountry.Name = "TxtCountry";
            TxtCountry.Size = new Size(326, 34);
            TxtCountry.TabIndex = 68;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label12.Location = new Point(22, 250);
            label12.Name = "label12";
            label12.Size = new Size(48, 28);
            label12.TabIndex = 67;
            label12.Text = "País";
            // 
            // TxtCodePostal
            // 
            TxtCodePostal.Font = new Font("Yu Gothic UI", 12F);
            TxtCodePostal.Location = new Point(174, 194);
            TxtCodePostal.Name = "TxtCodePostal";
            TxtCodePostal.Size = new Size(326, 34);
            TxtCodePostal.TabIndex = 66;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label11.Location = new Point(22, 197);
            label11.Name = "label11";
            label11.Size = new Size(138, 28);
            label11.TabIndex = 65;
            label11.Text = "Código postal";
            // 
            // TxtRegion
            // 
            TxtRegion.Font = new Font("Yu Gothic UI", 12F);
            TxtRegion.Location = new Point(172, 142);
            TxtRegion.Name = "TxtRegion";
            TxtRegion.Size = new Size(326, 34);
            TxtRegion.TabIndex = 64;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label10.Location = new Point(20, 145);
            label10.Name = "label10";
            label10.Size = new Size(76, 28);
            label10.TabIndex = 63;
            label10.Text = "Región";
            // 
            // TxtCity
            // 
            TxtCity.Font = new Font("Yu Gothic UI", 12F);
            TxtCity.Location = new Point(172, 91);
            TxtCity.Name = "TxtCity";
            TxtCity.Size = new Size(326, 34);
            TxtCity.TabIndex = 62;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label9.Location = new Point(20, 94);
            label9.Name = "label9";
            label9.Size = new Size(75, 28);
            label9.TabIndex = 61;
            label9.Text = "Ciudad";
            // 
            // TxtDirec
            // 
            TxtDirec.Font = new Font("Yu Gothic UI", 12F);
            TxtDirec.Location = new Point(173, 39);
            TxtDirec.Name = "TxtDirec";
            TxtDirec.Size = new Size(326, 34);
            TxtDirec.TabIndex = 60;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label8.Location = new Point(21, 42);
            label8.Name = "label8";
            label8.Size = new Size(96, 28);
            label8.TabIndex = 59;
            label8.Text = "Dirección";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(TxtTitle);
            groupBox3.Controls.Add(label4);
            groupBox3.Controls.Add(TxtDateTimHire);
            groupBox3.Controls.Add(label7);
            groupBox3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox3.Location = new Point(582, 104);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(505, 166);
            groupBox3.TabIndex = 69;
            groupBox3.TabStop = false;
            groupBox3.Text = "Información laboral";
            // 
            // TxtTitle
            // 
            TxtTitle.Font = new Font("Yu Gothic UI", 12F);
            TxtTitle.Location = new Point(119, 105);
            TxtTitle.Name = "TxtTitle";
            TxtTitle.Size = new Size(360, 34);
            TxtTitle.TabIndex = 52;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label4.Location = new Point(13, 108);
            label4.Name = "label4";
            label4.Size = new Size(75, 28);
            label4.TabIndex = 51;
            label4.Text = "Puesto";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label15);
            groupBox4.Controls.Add(TxtNotes);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(BtSubir);
            groupBox4.Controls.Add(PbxEmployee);
            groupBox4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox4.Location = new Point(584, 289);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(503, 510);
            groupBox4.TabIndex = 70;
            groupBox4.TabStop = false;
            groupBox4.Text = "Información adicional";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label15.Location = new Point(15, 324);
            label15.Name = "label15";
            label15.Size = new Size(103, 28);
            label15.TabIndex = 66;
            label15.Text = "Educación";
            // 
            // TxtNotes
            // 
            TxtNotes.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtNotes.Location = new Point(131, 321);
            TxtNotes.Multiline = true;
            TxtNotes.Name = "TxtNotes";
            TxtNotes.ScrollBars = ScrollBars.Both;
            TxtNotes.Size = new Size(346, 134);
            TxtNotes.TabIndex = 80;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(11, 39);
            label5.Name = "label5";
            label5.Size = new Size(177, 28);
            label5.TabIndex = 10;
            label5.Text = "Imagen Empleado";
            // 
            // BtSubir
            // 
            BtSubir.Cursor = Cursors.Hand;
            BtSubir.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtSubir.Location = new Point(277, 249);
            BtSubir.Name = "BtSubir";
            BtSubir.Size = new Size(86, 32);
            BtSubir.TabIndex = 9;
            BtSubir.Text = "Subir";
            BtSubir.UseVisualStyleBackColor = true;
            BtSubir.Click += BtSubir_Click;
            // 
            // PbxEmployee
            // 
            PbxEmployee.BackColor = SystemColors.ActiveCaption;
            PbxEmployee.Location = new Point(207, 37);
            PbxEmployee.Name = "PbxEmployee";
            PbxEmployee.Size = new Size(215, 196);
            PbxEmployee.SizeMode = PictureBoxSizeMode.StretchImage;
            PbxEmployee.TabIndex = 8;
            PbxEmployee.TabStop = false;
            // 
            // BtCancel
            // 
            BtCancel.Cursor = Cursors.Hand;
            BtCancel.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtCancel.Location = new Point(992, 812);
            BtCancel.Name = "BtCancel";
            BtCancel.Size = new Size(94, 39);
            BtCancel.TabIndex = 72;
            BtCancel.Text = "Cancelar";
            BtCancel.UseVisualStyleBackColor = true;
            BtCancel.Click += BtCancel_Click;
            // 
            // BtSave
            // 
            BtSave.Cursor = Cursors.Hand;
            BtSave.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtSave.Location = new Point(892, 812);
            BtSave.Name = "BtSave";
            BtSave.Size = new Size(94, 39);
            BtSave.TabIndex = 71;
            BtSave.Text = "Guardar";
            BtSave.UseVisualStyleBackColor = true;
            BtSave.Click += BtSave_Click;
            // 
            // EmployeeCrearFrm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1116, 866);
            Controls.Add(BtCancel);
            Controls.Add(BtSave);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel1);
            Name = "EmployeeCrearFrm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PbxEmployee).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel1;
        private Label label1;
        private DateTimePicker TxtDateTimHire;
        private Label label7;
        private GroupBox groupBox1;
        private TextBox TxtLastNames;
        private Label label3;
        private TextBox TxtNames;
        private Label label2;
        private DateTimePicker TxtDateTimBirth;
        private Label label6;
        private TextBox TxtExt;
        private Label label14;
        private TextBox TxtPhone;
        private Label label13;
        private GroupBox groupBox2;
        private TextBox TxtTitleCortes;
        private Label label16;
        private TextBox TxtCountry;
        private Label label12;
        private TextBox TxtCodePostal;
        private Label label11;
        private TextBox TxtRegion;
        private Label label10;
        private TextBox TxtCity;
        private Label label9;
        private TextBox TxtDirec;
        private Label label8;
        private GroupBox groupBox3;
        private TextBox TxtTitle;
        private Label label4;
        private GroupBox groupBox4;
        private Button BtSubir;
        private PictureBox PbxEmployee;
        private Label label15;
        private TextBox TxtNotes;
        private Label label5;
        private Button BtCancel;
        private Button BtSave;
    }
}