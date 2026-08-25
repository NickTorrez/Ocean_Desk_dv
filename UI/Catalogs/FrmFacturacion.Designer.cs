namespace Ocean_Desk_dv.UI.Catalogs
{
    partial class FrmFacturacion
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlFilters = new Panel();
            tlpFilters = new TableLayoutPanel();
            pnlSearch = new Panel();
            panel1 = new Panel();
            textBox1 = new TextBox();
            picSearch = new PictureBox();
            pnlDesde = new Panel();
            dateTimePicker1 = new DateTimePicker();
            lblDesde = new Label();
            pnlHasta = new Panel();
            dateTimePicker2 = new DateTimePicker();
            lblHasta = new Label();
            pnlEstado = new Panel();
            cmbEstado = new ComboBox();
            lblEstado = new Label();
            pnlListado = new Panel();
            dgvFacturas = new DataGridView();
            pnlActions = new Panel();
            btnVerDetalle = new Button();
            pnlFilters.SuspendLayout();
            tlpFilters.SuspendLayout();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).BeginInit();
            pnlDesde.SuspendLayout();
            pnlHasta.SuspendLayout();
            pnlEstado.SuspendLayout();
            pnlListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            pnlActions.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFilters
            // 
            pnlFilters.BackColor = Color.White;
            pnlFilters.Controls.Add(tlpFilters);
            pnlFilters.Dock = DockStyle.Top;
            pnlFilters.Location = new Point(0, 0);
            pnlFilters.Name = "pnlFilters";
            pnlFilters.Padding = new Padding(15, 10, 15, 10);
            pnlFilters.Size = new Size(940, 85);
            pnlFilters.TabIndex = 0;
            // 
            // tlpFilters
            // 
            tlpFilters.ColumnCount = 4;
            tlpFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 41F));
            tlpFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tlpFilters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19F));
            tlpFilters.Controls.Add(pnlSearch, 0, 0);
            tlpFilters.Controls.Add(pnlDesde, 1, 0);
            tlpFilters.Controls.Add(pnlHasta, 2, 0);
            tlpFilters.Controls.Add(pnlEstado, 3, 0);
            tlpFilters.Dock = DockStyle.Fill;
            tlpFilters.Location = new Point(15, 10);
            tlpFilters.Margin = new Padding(0);
            tlpFilters.Name = "tlpFilters";
            tlpFilters.Padding = new Padding(0, 3, 0, 3);
            tlpFilters.RowCount = 1;
            tlpFilters.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpFilters.Size = new Size(910, 65);
            tlpFilters.TabIndex = 0;
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(panel1);
            pnlSearch.Controls.Add(textBox1);
            pnlSearch.Controls.Add(picSearch);
            pnlSearch.Dock = DockStyle.Fill;
            pnlSearch.Location = new Point(3, 6);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(367, 53);
            pnlSearch.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.Location = new Point(54, 42);
            panel1.Name = "panel1";
            panel1.Size = new Size(290, 2);
            panel1.TabIndex = 2;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(54, 19);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Buscar Producto...";
            textBox1.Size = new Size(290, 21);
            textBox1.TabIndex = 1;
            // 
            // picSearch
            // 
            picSearch.Image = Properties.Resources.search_32;
            picSearch.Location = new Point(13, 13);
            picSearch.Name = "picSearch";
            picSearch.Size = new Size(35, 35);
            picSearch.TabIndex = 0;
            picSearch.TabStop = false;
            // 
            // pnlDesde
            // 
            pnlDesde.Controls.Add(dateTimePicker1);
            pnlDesde.Controls.Add(lblDesde);
            pnlDesde.Dock = DockStyle.Fill;
            pnlDesde.Location = new Point(376, 6);
            pnlDesde.Name = "pnlDesde";
            pnlDesde.Padding = new Padding(0, 3, 0, 3);
            pnlDesde.Size = new Size(176, 53);
            pnlDesde.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Dock = DockStyle.Fill;
            dateTimePicker1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(0, 23);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(176, 26);
            dateTimePicker1.TabIndex = 0;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Dock = DockStyle.Top;
            lblDesde.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDesde.Location = new Point(0, 3);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(60, 20);
            lblDesde.TabIndex = 1;
            lblDesde.Text = "Desde:";
            // 
            // pnlHasta
            // 
            pnlHasta.Controls.Add(dateTimePicker2);
            pnlHasta.Controls.Add(lblHasta);
            pnlHasta.Location = new Point(558, 6);
            pnlHasta.Name = "pnlHasta";
            pnlHasta.Padding = new Padding(0, 3, 0, 3);
            pnlHasta.Size = new Size(176, 53);
            pnlHasta.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Dock = DockStyle.Fill;
            dateTimePicker2.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(0, 23);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(176, 26);
            dateTimePicker2.TabIndex = 0;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Dock = DockStyle.Top;
            lblHasta.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblHasta.Location = new Point(0, 3);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(54, 20);
            lblHasta.TabIndex = 1;
            lblHasta.Text = "Hasta:";
            // 
            // pnlEstado
            // 
            pnlEstado.Controls.Add(cmbEstado);
            pnlEstado.Controls.Add(lblEstado);
            pnlEstado.Dock = DockStyle.Fill;
            pnlEstado.Location = new Point(740, 6);
            pnlEstado.Name = "pnlEstado";
            pnlEstado.Padding = new Padding(0, 3, 0, 3);
            pnlEstado.Size = new Size(167, 53);
            pnlEstado.TabIndex = 3;
            // 
            // cmbEstado
            // 
            cmbEstado.Dock = DockStyle.Fill;
            cmbEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstado.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Items.AddRange(new object[] { "Todos", "", "Pagada", "", "Anulada" });
            cmbEstado.Location = new Point(0, 23);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(167, 28);
            cmbEstado.TabIndex = 4;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Dock = DockStyle.Top;
            lblEstado.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstado.Location = new Point(0, 3);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(62, 20);
            lblEstado.TabIndex = 3;
            lblEstado.Text = "Estado:";
            // 
            // pnlListado
            // 
            pnlListado.BackColor = Color.Transparent;
            pnlListado.Controls.Add(dgvFacturas);
            pnlListado.Controls.Add(pnlActions);
            pnlListado.Dock = DockStyle.Fill;
            pnlListado.Location = new Point(0, 85);
            pnlListado.Name = "pnlListado";
            pnlListado.Padding = new Padding(0, 15, 0, 10);
            pnlListado.Size = new Size(940, 745);
            pnlListado.TabIndex = 1;
            // 
            // dgvFacturas
            // 
            dgvFacturas.AllowUserToAddRows = false;
            dgvFacturas.AllowUserToDeleteRows = false;
            dgvFacturas.AllowUserToResizeRows = false;
            dgvFacturas.BackgroundColor = Color.White;
            dgvFacturas.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvFacturas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Dock = DockStyle.Fill;
            dgvFacturas.Location = new Point(0, 15);
            dgvFacturas.MultiSelect = false;
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvFacturas.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvFacturas.RowHeadersVisible = false;
            dgvFacturas.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(8, 31, 63);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(224, 234, 240);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(8, 31, 63);
            dgvFacturas.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturas.Size = new Size(940, 655);
            dgvFacturas.TabIndex = 0;
            // 
            // pnlActions
            // 
            pnlActions.BackColor = Color.White;
            pnlActions.Controls.Add(btnVerDetalle);
            pnlActions.Dock = DockStyle.Bottom;
            pnlActions.Location = new Point(0, 670);
            pnlActions.Name = "pnlActions";
            pnlActions.Padding = new Padding(10, 10, 0, 0);
            pnlActions.Size = new Size(940, 65);
            pnlActions.TabIndex = 1;
            // 
            // btnVerDetalle
            // 
            btnVerDetalle.BackColor = Color.FromArgb(238, 243, 247);
            btnVerDetalle.Location = new Point(618, 23);
            btnVerDetalle.Name = "btnVerDetalle";
            btnVerDetalle.Size = new Size(120, 38);
            btnVerDetalle.TabIndex = 0;
            btnVerDetalle.Text = "button1";
            btnVerDetalle.UseVisualStyleBackColor = false;
            // 
            // FrmFacturacion
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(940, 830);
            Controls.Add(pnlListado);
            Controls.Add(pnlFilters);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmFacturacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmFacturacion";
            pnlFilters.ResumeLayout(false);
            tlpFilters.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picSearch).EndInit();
            pnlDesde.ResumeLayout(false);
            pnlDesde.PerformLayout();
            pnlHasta.ResumeLayout(false);
            pnlHasta.PerformLayout();
            pnlEstado.ResumeLayout(false);
            pnlEstado.PerformLayout();
            pnlListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            pnlActions.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFilters;
        private TableLayoutPanel tlpFilters;
        private Panel pnlSearch;
        private PictureBox picSearch;
        private TextBox textBox1;
        private Panel panel1;
        private Panel pnlDesde;
        private Panel pnlHasta;
        private Label lblDesde;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label lblHasta;
        private Panel pnlEstado;
        private ComboBox cmbEstado;
        private Label lblEstado;
        private Panel pnlListado;
        private DataGridView dgvFacturas;
        private Panel pnlActions;
        private Button btnVerDetalle;
    }
}