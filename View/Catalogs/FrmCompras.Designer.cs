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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            pnlBarraCompras = new Panel();
            splCompras = new SplitContainer();
            dgvCompras = new DataGridView();
            pnlContenido = new Panel();
            colIdCompra = new DataGridViewTextBoxColumn();
            colFechaCompra = new DataGridViewTextBoxColumn();
            colProveedorCompra = new DataGridViewTextBoxColumn();
            colTotalCompra = new DataGridViewTextBoxColumn();
            colEstadoCompra = new DataGridViewTextBoxColumn();
            colRecibidaCompra = new DataGridViewTextBoxColumn();
            pnlDatosCompra = new Panel();
            lblProveedorCompra = new Label();
            cmbProveedorCompra = new ComboBox();
            lblFechaCompra = new Label();
            dtpFechaCompra = new DateTimePicker();
            lblDocumentoCompra = new Label();
            txtDocumentoCompra = new TextBox();
            lblNotasCompra = new Label();
            txtNotasCompra = new TextBox();
            btnNuevaCompra = new Button();
            cmbEstadoCompra = new ComboBox();
            dtpFechaCompraFiltro = new DateTimePicker();
            txtBuscarCompra = new TextBox();
            tlpBarraCompras = new TableLayoutPanel();
            pnlBarraCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splCompras).BeginInit();
            splCompras.Panel1.SuspendLayout();
            splCompras.Panel2.SuspendLayout();
            splCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCompras).BeginInit();
            pnlContenido.SuspendLayout();
            pnlDatosCompra.SuspendLayout();
            tlpBarraCompras.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBarraCompras
            // 
            pnlBarraCompras.Controls.Add(tlpBarraCompras);
            pnlBarraCompras.Dock = DockStyle.Top;
            pnlBarraCompras.Location = new Point(0, 0);
            pnlBarraCompras.Name = "pnlBarraCompras";
            pnlBarraCompras.Padding = new Padding(12, 8, 12, 8);
            pnlBarraCompras.Size = new Size(1179, 78);
            pnlBarraCompras.TabIndex = 3;
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
            // 
            // splCompras.Panel2
            // 
            splCompras.Panel2.BackColor = Color.FromArgb(14, 158, 45, 18);
            splCompras.Panel2.Controls.Add(pnlDatosCompra);
            splCompras.Size = new Size(1173, 729);
            splCompras.SplitterDistance = 768;
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
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 8.25F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.Padding = new Padding(6, 0, 0, 0);
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvCompras.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCompras.Columns.AddRange(new DataGridViewColumn[] { colIdCompra, colFechaCompra, colProveedorCompra, colTotalCompra, colEstadoCompra, colRecibidaCompra });
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
            dgvCompras.Size = new Size(768, 729);
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
            pnlContenido.Size = new Size(1179, 751);
            pnlContenido.TabIndex = 1;
            // 
            // colIdCompra
            // 
            colIdCompra.DataPropertyName = "PurchaseId";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colIdCompra.DefaultCellStyle = dataGridViewCellStyle3;
            colIdCompra.FillWeight = 65F;
            colIdCompra.HeaderText = "\tN.º";
            colIdCompra.MinimumWidth = 6;
            colIdCompra.Name = "colIdCompra";
            colIdCompra.ReadOnly = true;
            // 
            // colFechaCompra
            // 
            colFechaCompra.DataPropertyName = "PurchaseDate";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "dd/MM/yyyy";
            colFechaCompra.DefaultCellStyle = dataGridViewCellStyle4;
            colFechaCompra.FillWeight = 105F;
            colFechaCompra.HeaderText = "Fecha";
            colFechaCompra.MinimumWidth = 6;
            colFechaCompra.Name = "colFechaCompra";
            colFechaCompra.ReadOnly = true;
            // 
            // colProveedorCompra
            // 
            colProveedorCompra.DataPropertyName = "SupplierName";
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            colProveedorCompra.DefaultCellStyle = dataGridViewCellStyle5;
            colProveedorCompra.FillWeight = 180F;
            colProveedorCompra.HeaderText = "Proveedor";
            colProveedorCompra.MinimumWidth = 6;
            colProveedorCompra.Name = "colProveedorCompra";
            colProveedorCompra.ReadOnly = true;
            // 
            // colTotalCompra
            // 
            colTotalCompra.DataPropertyName = "Total";
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C$ #,##0.00";
            colTotalCompra.DefaultCellStyle = dataGridViewCellStyle6;
            colTotalCompra.FillWeight = 105F;
            colTotalCompra.HeaderText = "Total";
            colTotalCompra.MinimumWidth = 6;
            colTotalCompra.Name = "colTotalCompra";
            colTotalCompra.ReadOnly = true;
            // 
            // colEstadoCompra
            // 
            colEstadoCompra.DataPropertyName = "Status";
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colEstadoCompra.DefaultCellStyle = dataGridViewCellStyle7;
            colEstadoCompra.FillWeight = 105F;
            colEstadoCompra.HeaderText = "Estado";
            colEstadoCompra.MinimumWidth = 6;
            colEstadoCompra.Name = "colEstadoCompra";
            colEstadoCompra.ReadOnly = true;
            // 
            // colRecibidaCompra
            // 
            colRecibidaCompra.DataPropertyName = "ReceivedDate";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.Format = "dd/MM/yyyy";
            colRecibidaCompra.DefaultCellStyle = dataGridViewCellStyle8;
            colRecibidaCompra.FillWeight = 110F;
            colRecibidaCompra.HeaderText = "Recepción";
            colRecibidaCompra.MinimumWidth = 6;
            colRecibidaCompra.Name = "colRecibidaCompra";
            colRecibidaCompra.ReadOnly = true;
            // 
            // pnlDatosCompra
            // 
            pnlDatosCompra.BackColor = Color.White;
            pnlDatosCompra.Controls.Add(lblProveedorCompra);
            pnlDatosCompra.Controls.Add(cmbProveedorCompra);
            pnlDatosCompra.Controls.Add(lblFechaCompra);
            pnlDatosCompra.Controls.Add(dtpFechaCompra);
            pnlDatosCompra.Controls.Add(lblDocumentoCompra);
            pnlDatosCompra.Controls.Add(txtDocumentoCompra);
            pnlDatosCompra.Controls.Add(lblNotasCompra);
            pnlDatosCompra.Controls.Add(txtNotasCompra);
            pnlDatosCompra.Dock = DockStyle.Top;
            pnlDatosCompra.Location = new Point(0, 0);
            pnlDatosCompra.Name = "pnlDatosCompra";
            pnlDatosCompra.Padding = new Padding(12);
            pnlDatosCompra.Size = new Size(401, 250);
            pnlDatosCompra.TabIndex = 0;
            // 
            // lblProveedorCompra
            // 
            lblProveedorCompra.Dock = DockStyle.Top;
            lblProveedorCompra.ForeColor = Color.FromArgb(111, 119, 128);
            lblProveedorCompra.Location = new Point(12, 190);
            lblProveedorCompra.Name = "lblProveedorCompra";
            lblProveedorCompra.Size = new Size(377, 20);
            lblProveedorCompra.TabIndex = 0;
            lblProveedorCompra.Text = "Proveedor";
            // 
            // cmbProveedorCompra
            // 
            cmbProveedorCompra.Dock = DockStyle.Top;
            cmbProveedorCompra.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedorCompra.FormattingEnabled = true;
            cmbProveedorCompra.Location = new Point(12, 163);
            cmbProveedorCompra.Name = "cmbProveedorCompra";
            cmbProveedorCompra.Size = new Size(377, 27);
            cmbProveedorCompra.TabIndex = 1;
            // 
            // lblFechaCompra
            // 
            lblFechaCompra.Dock = DockStyle.Top;
            lblFechaCompra.ForeColor = Color.FromArgb(111, 119, 128);
            lblFechaCompra.Location = new Point(12, 143);
            lblFechaCompra.Name = "lblFechaCompra";
            lblFechaCompra.Size = new Size(377, 20);
            lblFechaCompra.TabIndex = 2;
            lblFechaCompra.Text = "Fecha de compra";
            // 
            // dtpFechaCompra
            // 
            dtpFechaCompra.Dock = DockStyle.Top;
            dtpFechaCompra.Format = DateTimePickerFormat.Short;
            dtpFechaCompra.Location = new Point(12, 119);
            dtpFechaCompra.Name = "dtpFechaCompra";
            dtpFechaCompra.Size = new Size(377, 24);
            dtpFechaCompra.TabIndex = 3;
            // 
            // lblDocumentoCompra
            // 
            lblDocumentoCompra.Dock = DockStyle.Top;
            lblDocumentoCompra.ForeColor = Color.FromArgb(111, 119, 128);
            lblDocumentoCompra.Location = new Point(12, 89);
            lblDocumentoCompra.Name = "lblDocumentoCompra";
            lblDocumentoCompra.Size = new Size(377, 30);
            lblDocumentoCompra.TabIndex = 4;
            lblDocumentoCompra.Text = "Documento/Factura del proveedor";
            lblDocumentoCompra.Click += label1_Click;
            // 
            // txtDocumentoCompra
            // 
            txtDocumentoCompra.Dock = DockStyle.Top;
            txtDocumentoCompra.Location = new Point(12, 65);
            txtDocumentoCompra.MaxLength = 50;
            txtDocumentoCompra.Name = "txtDocumentoCompra";
            txtDocumentoCompra.Size = new Size(377, 24);
            txtDocumentoCompra.TabIndex = 5;
            // 
            // lblNotasCompra
            // 
            lblNotasCompra.AutoSize = true;
            lblNotasCompra.Dock = DockStyle.Top;
            lblNotasCompra.ForeColor = Color.FromArgb(111, 119, 128);
            lblNotasCompra.Location = new Point(12, 46);
            lblNotasCompra.Name = "lblNotasCompra";
            lblNotasCompra.Size = new Size(48, 19);
            lblNotasCompra.TabIndex = 6;
            lblNotasCompra.Text = "Notas";
            // 
            // txtNotasCompra
            // 
            txtNotasCompra.Dock = DockStyle.Top;
            txtNotasCompra.Location = new Point(12, 12);
            txtNotasCompra.MaxLength = 250;
            txtNotasCompra.Multiline = true;
            txtNotasCompra.Name = "txtNotasCompra";
            txtNotasCompra.Size = new Size(377, 34);
            txtNotasCompra.TabIndex = 7;
            // 
            // btnNuevaCompra
            // 
            btnNuevaCompra.BackColor = Color.FromArgb(8, 126, 164);
            btnNuevaCompra.FlatAppearance.BorderSize = 0;
            btnNuevaCompra.FlatStyle = FlatStyle.Flat;
            btnNuevaCompra.ForeColor = Color.White;
            btnNuevaCompra.Location = new Point(1023, 3);
            btnNuevaCompra.Name = "btnNuevaCompra";
            btnNuevaCompra.Size = new Size(94, 25);
            btnNuevaCompra.TabIndex = 2;
            btnNuevaCompra.Text = "Nueva compra";
            btnNuevaCompra.UseVisualStyleBackColor = false;
            // 
            // cmbEstadoCompra
            // 
            cmbEstadoCompra.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEstadoCompra.FormattingEnabled = true;
            cmbEstadoCompra.Items.AddRange(new object[] { "Todos,", "Pendiente, ", "Recibida, ", "Anulada." });
            cmbEstadoCompra.Location = new Point(873, 3);
            cmbEstadoCompra.Name = "cmbEstadoCompra";
            cmbEstadoCompra.Size = new Size(144, 27);
            cmbEstadoCompra.TabIndex = 0;
            // 
            // dtpFechaCompraFiltro
            // 
            dtpFechaCompraFiltro.Font = new Font("Century Gothic", 9F);
            dtpFechaCompraFiltro.Format = DateTimePickerFormat.Short;
            dtpFechaCompraFiltro.Location = new Point(723, 3);
            dtpFechaCompraFiltro.Name = "dtpFechaCompraFiltro";
            dtpFechaCompraFiltro.Size = new Size(144, 26);
            dtpFechaCompraFiltro.TabIndex = 1;
            // 
            // txtBuscarCompra
            // 
            txtBuscarCompra.BorderStyle = BorderStyle.None;
            txtBuscarCompra.CausesValidation = false;
            txtBuscarCompra.Dock = DockStyle.Fill;
            txtBuscarCompra.Font = new Font("Century Gothic", 10.2F);
            txtBuscarCompra.Location = new Point(3, 3);
            txtBuscarCompra.Name = "txtBuscarCompra";
            txtBuscarCompra.Size = new Size(714, 21);
            txtBuscarCompra.TabIndex = 0;
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
            tlpBarraCompras.RowCount = 1;
            tlpBarraCompras.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBarraCompras.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpBarraCompras.Size = new Size(1155, 62);
            tlpBarraCompras.TabIndex = 1;
            // 
            // FrmCompras
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1179, 751);
            Controls.Add(pnlBarraCompras);
            Controls.Add(pnlContenido);
            Font = new Font("Century Gothic", 8.25F);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmCompras";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmCompras";
            pnlBarraCompras.ResumeLayout(false);
            splCompras.Panel1.ResumeLayout(false);
            splCompras.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splCompras).EndInit();
            splCompras.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCompras).EndInit();
            pnlContenido.ResumeLayout(false);
            pnlDatosCompra.ResumeLayout(false);
            pnlDatosCompra.PerformLayout();
            tlpBarraCompras.ResumeLayout(false);
            tlpBarraCompras.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBarraCompras;
        private SplitContainer splCompras;
        private Panel pnlContenido;
        private DataGridView dgvCompras;
        private DataGridViewTextBoxColumn colIdCompra;
        private DataGridViewTextBoxColumn colFechaCompra;
        private DataGridViewTextBoxColumn colProveedorCompra;
        private DataGridViewTextBoxColumn colTotalCompra;
        private DataGridViewTextBoxColumn colEstadoCompra;
        private DataGridViewTextBoxColumn colRecibidaCompra;
        private Panel pnlDatosCompra;
        private Label lblProveedorCompra;
        private DateTimePicker dtpFechaCompra;
        private Label lblFechaCompra;
        private ComboBox cmbProveedorCompra;
        private Label lblDocumentoCompra;
        private TextBox txtNotasCompra;
        private Label lblNotasCompra;
        private TextBox txtDocumentoCompra;
        private TableLayoutPanel tlpBarraCompras;
        private TextBox txtBuscarCompra;
        private DateTimePicker dtpFechaCompraFiltro;
        private ComboBox cmbEstadoCompra;
        private Button btnNuevaCompra;
    }
}