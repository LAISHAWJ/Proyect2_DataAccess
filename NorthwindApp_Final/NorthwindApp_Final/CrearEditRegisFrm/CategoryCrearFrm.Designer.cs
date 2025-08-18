namespace NorthwindApp_Final.CrearEditRegisFrm
{
    partial class CategoryCrearFrm
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
            label2 = new Label();
            TxtNameCat = new TextBox();
            TxtDescripCat = new TextBox();
            label3 = new Label();
            label4 = new Label();
            PbxCat = new PictureBox();
            BtSubir = new Button();
            BtSave = new Button();
            BtCancel = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PbxCat).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.BackColor = Color.FromArgb(0, 74, 173);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(-2, -1);
            panel1.Name = "panel1";
            panel1.Size = new Size(586, 87);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(7, 10);
            label1.Name = "label1";
            label1.Size = new Size(280, 62);
            label1.TabIndex = 1;
            label1.Text = "CATEGORIA";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 118);
            label2.Name = "label2";
            label2.Size = new Size(101, 31);
            label2.TabIndex = 1;
            label2.Text = "Nombre";
            // 
            // TxtNameCat
            // 
            TxtNameCat.Font = new Font("Yu Gothic UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtNameCat.Location = new Point(119, 114);
            TxtNameCat.Name = "TxtNameCat";
            TxtNameCat.Size = new Size(400, 38);
            TxtNameCat.TabIndex = 2;
            // 
            // TxtDescripCat
            // 
            TxtDescripCat.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxtDescripCat.Location = new Point(153, 186);
            TxtDescripCat.Multiline = true;
            TxtDescripCat.Name = "TxtDescripCat";
            TxtDescripCat.Size = new Size(365, 70);
            TxtDescripCat.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 181);
            label3.Name = "label3";
            label3.Size = new Size(137, 31);
            label3.TabIndex = 3;
            label3.Text = "Descripción";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(11, 287);
            label4.Name = "label4";
            label4.Size = new Size(216, 31);
            label4.TabIndex = 5;
            label4.Text = "Seleccionar imagen";
            // 
            // PbxCat
            // 
            PbxCat.BackColor = SystemColors.ActiveCaption;
            PbxCat.Location = new Point(234, 294);
            PbxCat.Name = "PbxCat";
            PbxCat.Size = new Size(285, 280);
            PbxCat.SizeMode = PictureBoxSizeMode.StretchImage;
            PbxCat.TabIndex = 6;
            PbxCat.TabStop = false;
            // 
            // BtSubir
            // 
            BtSubir.Cursor = Cursors.Hand;
            BtSubir.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtSubir.Location = new Point(335, 585);
            BtSubir.Name = "BtSubir";
            BtSubir.Size = new Size(94, 39);
            BtSubir.TabIndex = 7;
            BtSubir.Text = "Subir";
            BtSubir.UseVisualStyleBackColor = true;
            BtSubir.Click += BtSubir_Click;
            // 
            // BtSave
            // 
            BtSave.Cursor = Cursors.Hand;
            BtSave.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtSave.Location = new Point(19, 658);
            BtSave.Name = "BtSave";
            BtSave.Size = new Size(94, 39);
            BtSave.TabIndex = 8;
            BtSave.Text = "Guardar";
            BtSave.UseVisualStyleBackColor = true;
            BtSave.Click += BtSave_Click;
            // 
            // BtCancel
            // 
            BtCancel.Cursor = Cursors.Hand;
            BtCancel.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtCancel.Location = new Point(119, 658);
            BtCancel.Name = "BtCancel";
            BtCancel.Size = new Size(94, 39);
            BtCancel.TabIndex = 9;
            BtCancel.Text = "Cancelar";
            BtCancel.UseVisualStyleBackColor = true;
            BtCancel.Click += BtCancel_Click;
            // 
            // CategoryCrearFrm
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(582, 712);
            Controls.Add(BtCancel);
            Controls.Add(BtSave);
            Controls.Add(BtSubir);
            Controls.Add(PbxCat);
            Controls.Add(label4);
            Controls.Add(TxtDescripCat);
            Controls.Add(label3);
            Controls.Add(TxtNameCat);
            Controls.Add(label2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "CategoryCrearFrm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PbxCat).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox TxtNameCat;
        private TextBox TxtDescripCat;
        private Label label3;
        private Label label4;
        private PictureBox PbxCat;
        private Button BtSubir;
        private Button BtSave;
        private Button BtCancel;
    }
}