namespace NorthwindApp_Final.CrearEditRegisFrm
{
    partial class ShipperCrearFrm
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
            TxtCompanyName = new TextBox();
            label2 = new Label();
            TxtTel = new TextBox();
            label10 = new Label();
            BtCancel = new Button();
            BtSave = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 74, 173);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -2);
            panel1.Name = "panel1";
            panel1.Size = new Size(627, 89);
            panel1.TabIndex = 4;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(8, 14);
            label1.Name = "label1";
            label1.Size = new Size(416, 62);
            label1.TabIndex = 2;
            label1.Text = "TRANSPORTISTAS";
            label1.TextAlign = ContentAlignment.TopRight;
            // 
            // TxtCompanyName
            // 
            TxtCompanyName.Font = new Font("Yu Gothic UI", 12F);
            TxtCompanyName.Location = new Point(214, 116);
            TxtCompanyName.Name = "TxtCompanyName";
            TxtCompanyName.Size = new Size(380, 34);
            TxtCompanyName.TabIndex = 35;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label2.Location = new Point(18, 119);
            label2.Name = "label2";
            label2.Size = new Size(184, 28);
            label2.TabIndex = 34;
            label2.Text = "Nombre Compañía";
            // 
            // TxtTel
            // 
            TxtTel.Font = new Font("Yu Gothic UI", 12F);
            TxtTel.Location = new Point(214, 170);
            TxtTel.Name = "TxtTel";
            TxtTel.Size = new Size(380, 34);
            TxtTel.TabIndex = 53;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold);
            label10.Location = new Point(18, 170);
            label10.Name = "label10";
            label10.Size = new Size(91, 28);
            label10.TabIndex = 52;
            label10.Text = "Teléfono";
            // 
            // BtCancel
            // 
            BtCancel.Cursor = Cursors.Hand;
            BtCancel.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtCancel.Location = new Point(500, 220);
            BtCancel.Name = "BtCancel";
            BtCancel.Size = new Size(94, 39);
            BtCancel.TabIndex = 57;
            BtCancel.Text = "Cancelar";
            BtCancel.UseVisualStyleBackColor = true;
            BtCancel.Click += BtCancel_Click;
            // 
            // BtSave
            // 
            BtSave.Cursor = Cursors.Hand;
            BtSave.Font = new Font("Yu Gothic UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtSave.Location = new Point(400, 220);
            BtSave.Name = "BtSave";
            BtSave.Size = new Size(94, 39);
            BtSave.TabIndex = 56;
            BtSave.Text = "Guardar";
            BtSave.UseVisualStyleBackColor = true;
            BtSave.Click += BtSave_Click;
            // 
            // ShipperCrearFrm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 285);
            Controls.Add(BtCancel);
            Controls.Add(BtSave);
            Controls.Add(TxtTel);
            Controls.Add(label10);
            Controls.Add(TxtCompanyName);
            Controls.Add(label2);
            Controls.Add(panel1);
            Name = "ShipperCrearFrm";
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
        private TextBox TxtCompanyName;
        private Label label2;
        private TextBox TxtTel;
        private Label label10;
        private Button BtCancel;
        private Button BtSave;
    }
}