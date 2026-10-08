namespace Ocean_Desk_dv.View.Catalogs
{
    partial class FrmCompras
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
            pnlBarraCompras = new Panel();
            tlpBarraCompras = new TableLayoutPanel();
            txtBuscarCompra = new TextBox();
            dtpFechaCompraFiltro = new DateTimePicker();
            cmbEstadoCompra = new ComboBox();
            btnNuevaCompra = new Button();
            splCompras = new SplitContainer();
            dgvCompras = new DataGridView();
            pnlContenido = new Panel();
            pnlBarraCompras.SuspendLayout();
            tlpBarraCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splCompras).BeginInit();
            splCompras.Panel1.SuspendLayout();
            splCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).BeginInit();
            pnlContenido.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBarraCompras
            // 
            pnlBarraCompras.Controls.Add(tlpBarraCompras);
            pnlBarraCompras.Dock = DockStyle.Top;
            pnlBarraCompras.Location = new Point(0, 0);
            pnlBarraCompras.Name = "pnlBarraCompras";
            pnlBarraCompras.Padding = new Padding(12, 8, 12, 8);
            pnlBarraCompras.Size = new Size(800, 78);
            pnlBarraCompras.TabIndex = 3;
            // 
            // tlpBarraCompras
            // 
            tlpBarraCompras.ColumnCount = 4;
            tlpBarraCompras.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpBarraCompras.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpBarraCompras.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            tlpBarraCompras.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 135F));
            tlpBarraCompras.Controls.Add(txtBuscarCompra, 0, 0);
            tlpBarraCompras.Controls.Add(dtpFechaCompraFiltro, 1, 0);
            tlpBarraCompras.Controls.Add(cmbEstadoCompra, 2, 0);
            tlpBarraCompras.Controls.Add(btnNuevaCompra, 3, 0);
            tlpBarraCompras.Dock = DockStyle.Fill;
            tlpBarraCompras.Location = new Point(12, 8);
            tlpBarraCompras.Margin = new Padding(0);
            tlpBarraCompras.Name = "tlpBarraCompras";
            tlpBarraCompras.RowCount = 2;
            tlpBarraCompras.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpBarraCompras.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpBarraCompras.Size = new Size(776, 62);
            tlpBarraCompras.TabIndex = 1;
            // 
            // txtBuscarCompra
            // 
            txtBuscarCompra.BorderStyle = BorderStyle.None;
            txtBuscarCompra.CausesValidation = false;
            txtBuscarCompra.Font = new Font("Century Gothic", 10.2F);
            txtBuscarCompra.Location = new Point(3, 3);
            txtBuscarCompra.Name = "txtBuscarCompra";
            txtBuscarCompra.Size = new Size(125, 21);
            txtBuscarCompra.TabIndex = 0;
            // 
            // dtpFechaCompraFiltro
            // 
            dtpFechaCompraFiltro.Font = new Font("Century Gothic", 9F);
            dtpFechaCompraFiltro.Format = DateTimePickerFormat.Short;
            dtpFechaCompraFiltro.Location = new Point(344, 3);
            dtpFechaCompraFiltro.Name = "dtpFechaCompraFiltro";
            dtpFechaCompraFiltro.Size = new Size(144, 26);
            dtpFechaCompraFiltro.TabIndex = 1;
            // 
            // cmbEstadoCompra
            // 
            cmbEstadoCompra.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoCompra.FormattingEnabled = true;
            cmbEstadoCompra.Items.AddRange(new object[] { "Todos,", "Pendiente, ", "Recibida, ", "Anulada." });
            cmbEstadoCompra.Location = new Point(494, 3);
            cmbEstadoCompra.Name = "cmbEstadoCompra";
            cmbEstadoCompra.Size = new Size(144, 27);
            cmbEstadoCompra.TabIndex = 0;
            // 
            // btnNuevaCompra
            // 
            btnNuevaCompra.BackColor = Color.FromArgb(8, 126, 164);
            btnNuevaCompra.FlatAppearance.BorderSize = 0;
            btnNuevaCompra.FlatStyle = FlatStyle.Flat;
            btnNuevaCompra.ForeColor = Color.White;
            btnNuevaCompra.Location = new Point(644, 3);
            btnNuevaCompra.Name = "btnNuevaCompra";
            btnNuevaCompra.Size = new Size(94, 25);
            btnNuevaCompra.TabIndex = 2;
            btnNuevaCompra.Text = "Nueva compra";
            btnNuevaCompra.UseVisualStyleBackColor = false;
            // 
            // splCompras
            // 
            splCompras.Dock = DockStyle.Fill;
            splCompras.Location = new Point(3, 12);
            splCompras.Name = "splCompras";
            // 
            // splCompras.Panel1
            // 
            splCompras.Panel1.Controls.Add(dgvCompras);
            splCompras.Size = new Size(794, 428);
            splCompras.SplitterDistance = 520;
            splCompras.TabIndex = 0;
            // 
            // dgvCompras
            // 
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(14, 203, 255, 140);
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 9.8F);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(0, 1, 68, 219);
            dgvCompras.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCompras.BackgroundColor = Color.WhiteSmoke;
            dgvCompras.BorderStyle = BorderStyle.None;
            dgvCompras.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 1, 68, 219);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 9.25F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(6, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompras.Dock = DockStyle.Fill;
            dgvCompras.EnableHeadersVisualStyles = false;
            dgvCompras.GridColor = SystemColors.Menu;
            dgvCompras.Location = new Point(0, 0);
            dgvCompras.MultiSelect = false;
            dgvCompras.Name = "dgvCompras";
            dgvCompras.ReadOnly = true;
            dgvCompras.RowHeadersVisible = false;
            dgvCompras.RowHeadersWidth = 51;
            dgvCompras.RowTemplate.DefaultCellStyle.BackColor = Color.FromArgb(15, 54, 226, 215);
            dgvCompras.RowTemplate.DefaultCellStyle.Font = new Font("Century Gothic", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dgvCompras.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(0, 1, 68, 219);
            dgvCompras.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(13, 93, 139, 0);
            dgvCompras.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.FromArgb(0, 1, 68, 219);
            dgvCompras.RowTemplate.Height = 38;
            dgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompras.Size = new Size(520, 428);
            dgvCompras.TabIndex = 0;
            // 
            // pnlContenido
            // 
            pnlContenido.BackColor = Color.Transparent;
            pnlContenido.Controls.Add(splCompras);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(0, 0);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Padding = new Padding(3, 12, 3, 10);
            pnlContenido.Size = new Size(800, 450);
            pnlContenido.TabIndex = 1;
            // 
            // FrmCompras
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlBarraCompras);
            Controls.Add(pnlContenido);
            Font = new Font("Century Gothic", 8.25F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmCompras";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmCompras";
            pnlBarraCompras.ResumeLayout(false);
            tlpBarraCompras.ResumeLayout(false);
            tlpBarraCompras.PerformLayout();
            splCompras.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splCompras).EndInit();
            splCompras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCompras).EndInit();
            pnlContenido.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBarraCompras;
        private TableLayoutPanel tlpBarraCompras;
        private TextBox txtBuscarCompra;
        private DateTimePicker dtpFechaCompraFiltro;
        private ComboBox cmbEstadoCompra;
        private Button btnNuevaCompra;
        private SplitContainer splCompras;
        private Panel pnlContenido;
        private DataGridView dgvCompras;
    }
}