namespace CevicheSys_Pro_2.UI.Catalogs
{
    partial class FrmGastos
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
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlRegistroGastos = new Panel();
            btnEditarEgreso = new Button();
            txtMonto = new TextBox();
            txtConcepto = new TextBox();
            cmbTipoGasto = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            dtpFechaGasto = new DateTimePicker();
            label2 = new Label();
            btnLimpiarEgreso = new Button();
            btnEliminarEgreso = new Button();
            btnGuardarEgreso = new Button();
            pnlLista = new Panel();
            dgvGastos = new DataGridView();
            pnlFiltrar = new Panel();
            btnFiltrarEgreso = new Button();
            dtpFin = new DateTimePicker();
            dtpInicio = new DateTimePicker();
            tableLayoutPanel1.SuspendLayout();
            pnlRegistroGastos.SuspendLayout();
            pnlLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGastos).BeginInit();
            pnlFiltrar.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.Controls.Add(pnlRegistroGastos, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlLista, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(962, 603);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlRegistroGastos
            // 
            pnlRegistroGastos.BorderStyle = BorderStyle.FixedSingle;
            pnlRegistroGastos.Controls.Add(btnEditarEgreso);
            pnlRegistroGastos.Controls.Add(txtMonto);
            pnlRegistroGastos.Controls.Add(txtConcepto);
            pnlRegistroGastos.Controls.Add(cmbTipoGasto);
            pnlRegistroGastos.Controls.Add(label5);
            pnlRegistroGastos.Controls.Add(label4);
            pnlRegistroGastos.Controls.Add(label3);
            pnlRegistroGastos.Controls.Add(label1);
            pnlRegistroGastos.Controls.Add(dtpFechaGasto);
            pnlRegistroGastos.Controls.Add(label2);
            pnlRegistroGastos.Controls.Add(btnLimpiarEgreso);
            pnlRegistroGastos.Controls.Add(btnEliminarEgreso);
            pnlRegistroGastos.Controls.Add(btnGuardarEgreso);
            pnlRegistroGastos.Dock = DockStyle.Fill;
            pnlRegistroGastos.Location = new Point(3, 3);
            pnlRegistroGastos.Name = "pnlRegistroGastos";
            pnlRegistroGastos.Size = new Size(330, 597);
            pnlRegistroGastos.TabIndex = 0;
            // 
            // btnEditarEgreso
            // 
            btnEditarEgreso.Anchor = AnchorStyles.None;
            btnEditarEgreso.BackColor = Color.FromArgb(0, 123, 255);
            btnEditarEgreso.Cursor = Cursors.Hand;
            btnEditarEgreso.FlatStyle = FlatStyle.Flat;
            btnEditarEgreso.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditarEgreso.ForeColor = Color.White;
            btnEditarEgreso.Location = new Point(168, 436);
            btnEditarEgreso.Name = "btnEditarEgreso";
            btnEditarEgreso.Size = new Size(150, 70);
            btnEditarEgreso.TabIndex = 22;
            btnEditarEgreso.Text = "Editar Egreso";
            btnEditarEgreso.UseVisualStyleBackColor = false;
            btnEditarEgreso.Click += btnEditarEgreso_Click;
            // 
            // txtMonto
            // 
            txtMonto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtMonto.Font = new Font("Century Gothic", 9F);
            txtMonto.Location = new Point(123, 341);
            txtMonto.MaxLength = 12;
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(195, 26);
            txtMonto.TabIndex = 19;
            txtMonto.TextAlign = HorizontalAlignment.Right;
            txtMonto.Enter += TextBox_Enter;
            txtMonto.Leave += TextBox_Leave;
            // 
            // txtConcepto
            // 
            txtConcepto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtConcepto.Font = new Font("Century Gothic", 9F);
            txtConcepto.Location = new Point(12, 220);
            txtConcepto.MaxLength = 255;
            txtConcepto.Multiline = true;
            txtConcepto.Name = "txtConcepto";
            txtConcepto.Size = new Size(306, 100);
            txtConcepto.TabIndex = 18;
            txtConcepto.Enter += TextBox_Enter;
            txtConcepto.Leave += TextBox_Leave;
            // 
            // cmbTipoGasto
            // 
            cmbTipoGasto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbTipoGasto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoGasto.Font = new Font("Century Gothic", 9F);
            cmbTipoGasto.FormattingEnabled = true;
            cmbTipoGasto.Items.AddRange(new object[] { "Compras", "Servicios Basicos", "Salarios" });
            cmbTipoGasto.Location = new Point(123, 152);
            cmbTipoGasto.Name = "cmbTipoGasto";
            cmbTipoGasto.Size = new Size(195, 28);
            cmbTipoGasto.TabIndex = 17;
            cmbTipoGasto.Enter += TextBox_Enter;
            cmbTipoGasto.Leave += TextBox_Leave;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label5.Location = new Point(12, 345);
            label5.Name = "label5";
            label5.Size = new Size(93, 18);
            label5.TabIndex = 16;
            label5.Text = "Monto Total";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label4.Location = new Point(9, 191);
            label4.Name = "label4";
            label4.Size = new Size(83, 18);
            label4.TabIndex = 15;
            label4.Text = "Concepto";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 156);
            label3.Name = "label3";
            label3.Size = new Size(109, 18);
            label3.TabIndex = 14;
            label3.Text = "Tipo de Gasto";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 108);
            label1.Name = "label1";
            label1.Size = new Size(54, 18);
            label1.TabIndex = 13;
            label1.Text = "Fecha";
            // 
            // dtpFechaGasto
            // 
            dtpFechaGasto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpFechaGasto.Font = new Font("Century Gothic", 9F);
            dtpFechaGasto.Format = DateTimePickerFormat.Short;
            dtpFechaGasto.Location = new Point(123, 102);
            dtpFechaGasto.Name = "dtpFechaGasto";
            dtpFechaGasto.RightToLeft = RightToLeft.No;
            dtpFechaGasto.Size = new Size(195, 26);
            dtpFechaGasto.TabIndex = 12;
            dtpFechaGasto.Enter += TextBox_Enter;
            dtpFechaGasto.Leave += TextBox_Leave;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(56, 41);
            label2.Name = "label2";
            label2.Size = new Size(218, 27);
            label2.TabIndex = 11;
            label2.Text = "Registro de Gastos";
            // 
            // btnLimpiarEgreso
            // 
            btnLimpiarEgreso.Anchor = AnchorStyles.None;
            btnLimpiarEgreso.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiarEgreso.Cursor = Cursors.Hand;
            btnLimpiarEgreso.FlatStyle = FlatStyle.Flat;
            btnLimpiarEgreso.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnLimpiarEgreso.ForeColor = Color.White;
            btnLimpiarEgreso.Location = new Point(168, 512);
            btnLimpiarEgreso.Name = "btnLimpiarEgreso";
            btnLimpiarEgreso.Size = new Size(150, 70);
            btnLimpiarEgreso.TabIndex = 10;
            btnLimpiarEgreso.Text = "Limpiar";
            btnLimpiarEgreso.UseVisualStyleBackColor = false;
            btnLimpiarEgreso.Click += btnLimpiarEgreso_Click;
            // 
            // btnEliminarEgreso
            // 
            btnEliminarEgreso.Anchor = AnchorStyles.None;
            btnEliminarEgreso.BackColor = Color.FromArgb(220, 53, 69);
            btnEliminarEgreso.Cursor = Cursors.Hand;
            btnEliminarEgreso.FlatStyle = FlatStyle.Flat;
            btnEliminarEgreso.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnEliminarEgreso.ForeColor = Color.White;
            btnEliminarEgreso.Location = new Point(12, 512);
            btnEliminarEgreso.Name = "btnEliminarEgreso";
            btnEliminarEgreso.Size = new Size(150, 70);
            btnEliminarEgreso.TabIndex = 9;
            btnEliminarEgreso.Text = "Anular Gasto";
            btnEliminarEgreso.UseVisualStyleBackColor = false;
            btnEliminarEgreso.Click += btnEliminarEgreso_Click;
            // 
            // btnGuardarEgreso
            // 
            btnGuardarEgreso.Anchor = AnchorStyles.None;
            btnGuardarEgreso.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardarEgreso.Cursor = Cursors.Hand;
            btnGuardarEgreso.FlatStyle = FlatStyle.Flat;
            btnGuardarEgreso.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnGuardarEgreso.ForeColor = Color.White;
            btnGuardarEgreso.Location = new Point(12, 436);
            btnGuardarEgreso.Name = "btnGuardarEgreso";
            btnGuardarEgreso.Size = new Size(150, 70);
            btnGuardarEgreso.TabIndex = 8;
            btnGuardarEgreso.Text = "Registrar Egreso";
            btnGuardarEgreso.UseVisualStyleBackColor = false;
            btnGuardarEgreso.Click += btnGuardarEgreso_Click;
            // 
            // pnlLista
            // 
            pnlLista.BorderStyle = BorderStyle.FixedSingle;
            pnlLista.Controls.Add(dgvGastos);
            pnlLista.Controls.Add(pnlFiltrar);
            pnlLista.Dock = DockStyle.Fill;
            pnlLista.Location = new Point(339, 3);
            pnlLista.Name = "pnlLista";
            pnlLista.Size = new Size(620, 597);
            pnlLista.TabIndex = 1;
            // 
            // dgvGastos
            // 
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dgvGastos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvGastos.BackgroundColor = Color.WhiteSmoke;
            dgvGastos.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 91, 150);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvGastos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvGastos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGastos.Dock = DockStyle.Fill;
            dgvGastos.Location = new Point(0, 115);
            dgvGastos.Name = "dgvGastos";
            dgvGastos.RowHeadersWidth = 51;
            dgvGastos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGastos.Size = new Size(618, 480);
            dgvGastos.TabIndex = 2;
            dgvGastos.CellClick += dgvGastos_CellClick;
            // 
            // pnlFiltrar
            // 
            pnlFiltrar.Controls.Add(btnFiltrarEgreso);
            pnlFiltrar.Controls.Add(dtpFin);
            pnlFiltrar.Controls.Add(dtpInicio);
            pnlFiltrar.Dock = DockStyle.Top;
            pnlFiltrar.Location = new Point(0, 0);
            pnlFiltrar.Name = "pnlFiltrar";
            pnlFiltrar.Size = new Size(618, 115);
            pnlFiltrar.TabIndex = 0;
            // 
            // btnFiltrarEgreso
            // 
            btnFiltrarEgreso.Anchor = AnchorStyles.None;
            btnFiltrarEgreso.BackColor = Color.FromArgb(247, 127, 0);
            btnFiltrarEgreso.FlatStyle = FlatStyle.Flat;
            btnFiltrarEgreso.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFiltrarEgreso.ForeColor = Color.White;
            btnFiltrarEgreso.Location = new Point(232, 49);
            btnFiltrarEgreso.Name = "btnFiltrarEgreso";
            btnFiltrarEgreso.Size = new Size(154, 51);
            btnFiltrarEgreso.TabIndex = 2;
            btnFiltrarEgreso.Text = "Filtrar Gastos";
            btnFiltrarEgreso.UseVisualStyleBackColor = false;
            btnFiltrarEgreso.Click += btnFiltrarEgreso_Click;
            // 
            // dtpFin
            // 
            dtpFin.Font = new Font("Century Gothic", 9F);
            dtpFin.Format = DateTimePickerFormat.Short;
            dtpFin.Location = new Point(344, 17);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(250, 26);
            dtpFin.TabIndex = 1;
            dtpFin.ValueChanged += dtpFin_ValueChanged;
            // 
            // dtpInicio
            // 
            dtpInicio.Font = new Font("Century Gothic", 9F);
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Location = new Point(27, 17);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(250, 26);
            dtpInicio.TabIndex = 0;
            // 
            // FrmGastos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(962, 603);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmGastos";
            Text = "FrmGastos";
            Load += FrmGastos_Load;
            tableLayoutPanel1.ResumeLayout(false);
            pnlRegistroGastos.ResumeLayout(false);
            pnlRegistroGastos.PerformLayout();
            pnlLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGastos).EndInit();
            pnlFiltrar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlRegistroGastos;
        private Panel pnlLista;
        private Panel pnlFiltrar;
        private Button btnLimpiarEgreso;
        private Button btnEliminarEgreso;
        private Button btnGuardarEgreso;
        private Label label2;
        private TextBox txtMonto;
        private TextBox txtConcepto;
        private ComboBox cmbTipoGasto;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private DateTimePicker dtpFechaGasto;
        private Button btnFiltrarEgreso;
        private DateTimePicker dtpFin;
        private DateTimePicker dtpInicio;
        private Button btnEditarEgreso;
        private DataGridView dgvGastos;
    }
}
