namespace Ocean_Desk_dv.UI.MessageBox
{
    partial class FrmMessageBox
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
            pnlHeader = new Panel();
            lblTitle = new Label();
            btnClose = new Button();
            picIcon = new PictureBox();
            pnlBody = new Panel();
            lblMessage = new Label();
            pnlFooter = new Panel();
            pnlButtons = new Panel();
            btnAccept = new Button();
            btnCancel = new Button();
            pnlContainer = new Panel();
            pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picIcon).BeginInit();
            pnlBody.SuspendLayout();
            pnlFooter.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(8, 31, 63);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(picIcon);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(12, 0, 12, 0);
            pnlHeader.Size = new Size(460, 52);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(47, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(369, 52);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "⚠  Campo requerido";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Transparent;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(416, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(32, 52);
            btnClose.TabIndex = 1;
            btnClose.Text = "X";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // picIcon
            // 
            picIcon.BackColor = Color.Transparent;
            picIcon.Dock = DockStyle.Left;
            picIcon.Image = Properties.Resources.confirm;
            picIcon.Location = new Point(12, 0);
            picIcon.Margin = new Padding(0, 12, 8, 12);
            picIcon.Name = "picIcon";
            picIcon.Size = new Size(35, 52);
            picIcon.SizeMode = PictureBoxSizeMode.Zoom;
            picIcon.TabIndex = 0;
            picIcon.TabStop = false;
            // 
            // pnlBody
            // 
            pnlBody.AutoSize = true;
            pnlBody.BackColor = Color.White;
            pnlBody.Controls.Add(lblMessage);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 52);
            pnlBody.Name = "pnlBody";
            pnlBody.Padding = new Padding(20, 10, 20, 10);
            pnlBody.Size = new Size(460, 118);
            pnlBody.TabIndex = 1;
            // 
            // lblMessage
            // 
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMessage.ForeColor = Color.FromArgb(62, 70, 80);
            lblMessage.Location = new Point(20, 10);
            lblMessage.Margin = new Padding(0);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(420, 98);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Ingrese su nombre de usuario.";
            lblMessage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(245, 247, 250);
            pnlFooter.Controls.Add(pnlButtons);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 170);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Padding = new Padding(10, 10, 15, 10);
            pnlFooter.Size = new Size(460, 60);
            pnlFooter.TabIndex = 1;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnAccept);
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Dock = DockStyle.Right;
            pnlButtons.Location = new Point(205, 10);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(240, 40);
            pnlButtons.TabIndex = 2;
            // 
            // btnAccept
            // 
            btnAccept.BackColor = Color.FromArgb(8, 126, 164);
            btnAccept.Cursor = Cursors.Hand;
            btnAccept.Dock = DockStyle.Right;
            btnAccept.FlatAppearance.BorderSize = 0;
            btnAccept.FlatStyle = FlatStyle.Flat;
            btnAccept.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAccept.ForeColor = Color.White;
            btnAccept.Location = new Point(125, 0);
            btnAccept.Name = "btnAccept";
            btnAccept.Size = new Size(115, 40);
            btnAccept.TabIndex = 0;
            btnAccept.Text = "ACEPTAR";
            btnAccept.UseVisualStyleBackColor = false;
            btnAccept.Click += btnAccept_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.Dock = DockStyle.Left;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(115, 40);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "CANCELAR";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // pnlContainer
            // 
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 0);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(1);
            pnlContainer.Size = new Size(460, 230);
            pnlContainer.TabIndex = 1;
            // 
            // FrmMessageBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(221, 227, 232);
            ClientSize = new Size(460, 230);
            ControlBox = false;
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            Controls.Add(pnlContainer);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMessageBox";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmMessageBox";
            TopMost = true;
            Shown += FrmMessageBox_Shown;
            pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picIcon).EndInit();
            pnlBody.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private PictureBox picIcon;
        private Label lblTitle;
        private Button btnClose;
        private Panel pnlBody;
        private Label lblMessage;
        private Panel pnlFooter;
        private Button btnAccept;
        private Button btnCancel;
        private Panel pnlContainer;
        private Panel pnlButtons;
    }
}