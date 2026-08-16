namespace Ocean_Desk_dv.UI
{
    partial class FrmLoading
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLoading));
            picLogoCeviche = new PictureBox();
            pictureBox1 = new PictureBox();
            lblAppName = new Label();
            lblStatus = new Label();
            progressbar = new ProgressBar();
            timerLoading = new System.Windows.Forms.Timer(components);
            label1 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox5 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picLogoCeviche).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            SuspendLayout();
            // 
            // picLogoCeviche
            // 
            picLogoCeviche.BackColor = Color.Transparent;
            picLogoCeviche.Image = Properties.Resources.LOGO;
            picLogoCeviche.Location = new Point(300, 120);
            picLogoCeviche.Name = "picLogoCeviche";
            picLogoCeviche.Size = new Size(204, 130);
            picLogoCeviche.SizeMode = PictureBoxSizeMode.Zoom;
            picLogoCeviche.TabIndex = 0;
            picLogoCeviche.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.Icon_Ocean_Desk;
            pictureBox1.Location = new Point(490, 69);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(188, 240);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lblAppName
            // 
            lblAppName.Font = new Font("Century Gothic", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = Color.DarkBlue;
            lblAppName.Location = new Point(241, 264);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(500, 45);
            lblAppName.TabIndex = 2;
            lblAppName.Text = "OCEAN DESK";
            lblAppName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.Gray;
            lblStatus.Location = new Point(241, 384);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(500, 40);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "Iniciando sistema...";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // progressbar
            // 
            progressbar.Location = new Point(241, 434);
            progressbar.Name = "progressbar";
            progressbar.Size = new Size(500, 20);
            progressbar.Style = ProgressBarStyle.Continuous;
            progressbar.TabIndex = 4;
            // 
            // timerLoading
            // 
            timerLoading.Interval = 50;
            timerLoading.Tick += timerLoading_Tick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DarkBlue;
            label1.Location = new Point(361, 321);
            label1.Name = "label1";
            label1.Size = new Size(275, 21);
            label1.TabIndex = 5;
            label1.Text = "Sistema de Gestión Comercial";
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkBlue;
            panel1.Location = new Point(504, 120);
            panel1.Name = "panel1";
            panel1.Size = new Size(10, 125);
            panel1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(294, 276);
            label2.Name = "label2";
            label2.Size = new Size(81, 19);
            label2.TabIndex = 10;
            label2.Text = "──────";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(603, 275);
            label3.Name = "label3";
            label3.Size = new Size(81, 19);
            label3.TabIndex = 11;
            label3.Text = "──────";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkBlue;
            panel2.Location = new Point(-2, -3);
            panel2.Name = "panel2";
            panel2.Size = new Size(988, 39);
            panel2.TabIndex = 12;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkBlue;
            panel3.Location = new Point(-2, 517);
            panel3.Name = "panel3";
            panel3.Size = new Size(988, 39);
            panel3.TabIndex = 13;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.sponge;
            pictureBox2.Location = new Point(-29, 42);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(182, 121);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = Properties.Resources.burbujas;
            pictureBox3.Location = new Point(806, 361);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(164, 134);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 15;
            pictureBox3.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(12, 334);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(206, 233);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 16;
            pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            pictureBox5.Image = (Image)resources.GetObject("pictureBox5.Image");
            pictureBox5.Location = new Point(821, -57);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(206, 214);
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.TabIndex = 17;
            pictureBox5.TabStop = false;
            // 
            // FrmLoading
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(982, 553);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(progressbar);
            Controls.Add(lblStatus);
            Controls.Add(lblAppName);
            Controls.Add(picLogoCeviche);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox4);
            Controls.Add(pictureBox5);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmLoading";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmLoading";
            Load += FrmLoading_Load;
            ((System.ComponentModel.ISupportInitialize)picLogoCeviche).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picLogoCeviche;
        private PictureBox pictureBox1;
        private Label lblAppName;
        private Label lblStatus;
        private ProgressBar progressbar;
        private System.Windows.Forms.Timer timerLoading;
        private Label label1;
        private Panel panel1;
        private Label label2;
        private Label label3;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
        private PictureBox pictureBox5;
    }
}