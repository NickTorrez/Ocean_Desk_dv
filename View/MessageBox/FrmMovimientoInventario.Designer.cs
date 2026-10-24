namespace Ocean_Desk_dv.View.MessageBox
{
    partial class FrmMovimientoInventario
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
            pnlDatosLote = new Panel();
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            lblSeleccion = new Label();
            pnlInfoContainer = new Panel();
            tlpProducto = new TableLayoutPanel();
            pnlUnidad = new Panel();
            lblResumenStock = new Label();
            lblUnidad = new Label();
            lblProducto = new Label();
            pnlInputContainer = new Panel();
            tlpInputInfo = new TableLayoutPanel();
            pnlLabelCodigo = new Panel();
            lblStockMinimo = new Label();
            pnlLableCantidad = new Panel();
            lblCantidad = new Label();
            pnlLabelVenicmiento = new Panel();
            lblVencimiento = new Label();
            pnlInputCantidad = new Panel();
            nudCantidad = new NumericUpDown();
            pnlInputStockMin = new Panel();
            nudStockMinimo = new NumericUpDown();
            pnlInputVencimiento = new Panel();
            dtpVencimiento = new DateTimePicker();
            pnlInputObservaciones = new Panel();
            txtObservaciones = new TextBox();
            lblObservaciones = new Label();
            pnlFooter = new Panel();
            tlpButtons = new TableLayoutPanel();
            pnlCancelar = new Panel();
            btnCancelar = new Button();
            pnlGuardar = new Panel();
            btnConfirmar = new Button();
            pnlDatosLote.SuspendLayout();
            pnlInfoContainer.SuspendLayout();
            tlpProducto.SuspendLayout();
            pnlUnidad.SuspendLayout();
            pnlInputContainer.SuspendLayout();
            tlpInputInfo.SuspendLayout();
            pnlLabelCodigo.SuspendLayout();
            pnlLableCantidad.SuspendLayout();
            pnlLabelVenicmiento.SuspendLayout();
            pnlInputCantidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            pnlInputStockMin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).BeginInit();
            pnlInputVencimiento.SuspendLayout();
            pnlInputObservaciones.SuspendLayout();
            pnlFooter.SuspendLayout();
            tlpButtons.SuspendLayout();
            pnlCancelar.SuspendLayout();
            pnlGuardar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlDatosLote
            // 
            pnlDatosLote.BackColor = Color.FromArgb(8, 31, 63);
            pnlDatosLote.Controls.Add(lblSubtitulo);
            pnlDatosLote.Controls.Add(lblTitulo);
            pnlDatosLote.Dock = DockStyle.Top;
            pnlDatosLote.Location = new Point(0, 0);
            pnlDatosLote.Name = "pnlDatosLote";
            pnlDatosLote.Padding = new Padding(15, 15, 10, 10);
            pnlDatosLote.Size = new Size(698, 78);
            pnlDatosLote.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Dock = DockStyle.Top;
            lblSubtitulo.ForeColor = Color.LightGray;
            lblSubtitulo.Location = new Point(15, 42);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(673, 20);
            lblSubtitulo.TabIndex = 0;
            lblSubtitulo.Text = "Gestión de inventario";
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(673, 27);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Registrar movimiento";
            // 
            // lblSeleccion
            // 
            lblSeleccion.Dock = DockStyle.Top;
            lblSeleccion.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSeleccion.Location = new Point(15, 15);
            lblSeleccion.Name = "lblSeleccion";
            lblSeleccion.Size = new Size(668, 21);
            lblSeleccion.TabIndex = 1;
            lblSeleccion.Text = "Ingrediente Seleccionado";
            // 
            // pnlInfoContainer
            // 
            pnlInfoContainer.BackColor = Color.White;
            pnlInfoContainer.Controls.Add(tlpProducto);
            pnlInfoContainer.Controls.Add(lblProducto);
            pnlInfoContainer.Controls.Add(lblSeleccion);
            pnlInfoContainer.Dock = DockStyle.Top;
            pnlInfoContainer.Location = new Point(0, 78);
            pnlInfoContainer.Name = "pnlInfoContainer";
            pnlInfoContainer.Padding = new Padding(15);
            pnlInfoContainer.Size = new Size(698, 95);
            pnlInfoContainer.TabIndex = 1;
            // 
            // tlpProducto
            // 
            tlpProducto.ColumnCount = 1;
            tlpProducto.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpProducto.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpProducto.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpProducto.Controls.Add(pnlUnidad, 0, 0);
            tlpProducto.Dock = DockStyle.Top;
            tlpProducto.Location = new Point(15, 56);
            tlpProducto.Name = "tlpProducto";
            tlpProducto.RowCount = 1;
            tlpProducto.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpProducto.Size = new Size(668, 33);
            tlpProducto.TabIndex = 3;
            // 
            // pnlUnidad
            // 
            pnlUnidad.Controls.Add(lblResumenStock);
            pnlUnidad.Controls.Add(lblUnidad);
            pnlUnidad.Dock = DockStyle.Fill;
            pnlUnidad.Location = new Point(3, 3);
            pnlUnidad.Name = "pnlUnidad";
            pnlUnidad.Size = new Size(662, 27);
            pnlUnidad.TabIndex = 0;
            // 
            // lblResumenStock
            // 
            lblResumenStock.Dock = DockStyle.Left;
            lblResumenStock.Location = new Point(210, 0);
            lblResumenStock.Name = "lblResumenStock";
            lblResumenStock.Size = new Size(317, 27);
            lblResumenStock.TabIndex = 1;
            lblResumenStock.Text = "Stock actual: —";
            lblResumenStock.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUnidad
            // 
            lblUnidad.Dock = DockStyle.Left;
            lblUnidad.Location = new Point(0, 0);
            lblUnidad.Name = "lblUnidad";
            lblUnidad.Size = new Size(210, 27);
            lblUnidad.TabIndex = 0;
            lblUnidad.Text = "Unidad: —";
            lblUnidad.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblProducto
            // 
            lblProducto.Dock = DockStyle.Top;
            lblProducto.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProducto.Location = new Point(15, 36);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(668, 20);
            lblProducto.TabIndex = 2;
            lblProducto.Text = "ING-GARLIC · Garlic";
            // 
            // pnlInputContainer
            // 
            pnlInputContainer.Controls.Add(tlpInputInfo);
            pnlInputContainer.Controls.Add(pnlInputObservaciones);
            pnlInputContainer.Dock = DockStyle.Fill;
            pnlInputContainer.Location = new Point(0, 173);
            pnlInputContainer.Name = "pnlInputContainer";
            pnlInputContainer.Padding = new Padding(15, 5, 15, 5);
            pnlInputContainer.Size = new Size(698, 267);
            pnlInputContainer.TabIndex = 2;
            // 
            // tlpInputInfo
            // 
            tlpInputInfo.ColumnCount = 2;
            tlpInputInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpInputInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpInputInfo.Controls.Add(pnlLabelCodigo, 0, 2);
            tlpInputInfo.Controls.Add(pnlLableCantidad, 0, 0);
            tlpInputInfo.Controls.Add(pnlLabelVenicmiento, 1, 2);
            tlpInputInfo.Controls.Add(pnlInputCantidad, 0, 1);
            tlpInputInfo.Controls.Add(pnlInputStockMin, 0, 3);
            tlpInputInfo.Controls.Add(pnlInputVencimiento, 1, 3);
            tlpInputInfo.Dock = DockStyle.Fill;
            tlpInputInfo.Location = new Point(15, 5);
            tlpInputInfo.Name = "tlpInputInfo";
            tlpInputInfo.RowCount = 4;
            tlpInputInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 13.333333F));
            tlpInputInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpInputInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 13.333333F));
            tlpInputInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            tlpInputInfo.Size = new Size(668, 162);
            tlpInputInfo.TabIndex = 0;
            // 
            // pnlLabelCodigo
            // 
            pnlLabelCodigo.Controls.Add(lblStockMinimo);
            pnlLabelCodigo.Dock = DockStyle.Fill;
            pnlLabelCodigo.Location = new Point(3, 83);
            pnlLabelCodigo.Name = "pnlLabelCodigo";
            pnlLabelCodigo.Padding = new Padding(5, 0, 0, 0);
            pnlLabelCodigo.Size = new Size(328, 26);
            pnlLabelCodigo.TabIndex = 6;
            // 
            // lblStockMinimo
            // 
            lblStockMinimo.Dock = DockStyle.Fill;
            lblStockMinimo.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStockMinimo.Location = new Point(5, 0);
            lblStockMinimo.Name = "lblStockMinimo";
            lblStockMinimo.Size = new Size(323, 26);
            lblStockMinimo.TabIndex = 1;
            lblStockMinimo.Text = "Stock Mínimo";
            lblStockMinimo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlLableCantidad
            // 
            pnlLableCantidad.Controls.Add(lblCantidad);
            pnlLableCantidad.Dock = DockStyle.Fill;
            pnlLableCantidad.Location = new Point(3, 3);
            pnlLableCantidad.Name = "pnlLableCantidad";
            pnlLableCantidad.Padding = new Padding(5, 0, 0, 0);
            pnlLableCantidad.Size = new Size(328, 26);
            pnlLableCantidad.TabIndex = 5;
            // 
            // lblCantidad
            // 
            lblCantidad.Dock = DockStyle.Fill;
            lblCantidad.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidad.Location = new Point(5, 0);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(323, 26);
            lblCantidad.TabIndex = 0;
            lblCantidad.Text = "Cantidad recibida";
            lblCantidad.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlLabelVenicmiento
            // 
            pnlLabelVenicmiento.Controls.Add(lblVencimiento);
            pnlLabelVenicmiento.Dock = DockStyle.Fill;
            pnlLabelVenicmiento.Location = new Point(337, 83);
            pnlLabelVenicmiento.Name = "pnlLabelVenicmiento";
            pnlLabelVenicmiento.Padding = new Padding(5, 0, 0, 0);
            pnlLabelVenicmiento.Size = new Size(328, 26);
            pnlLabelVenicmiento.TabIndex = 7;
            // 
            // lblVencimiento
            // 
            lblVencimiento.Dock = DockStyle.Fill;
            lblVencimiento.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVencimiento.Location = new Point(5, 0);
            lblVencimiento.Name = "lblVencimiento";
            lblVencimiento.Size = new Size(323, 26);
            lblVencimiento.TabIndex = 2;
            lblVencimiento.Text = "Vencimiento";
            lblVencimiento.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlInputCantidad
            // 
            pnlInputCantidad.Controls.Add(nudCantidad);
            pnlInputCantidad.Dock = DockStyle.Fill;
            pnlInputCantidad.Location = new Point(3, 35);
            pnlInputCantidad.Name = "pnlInputCantidad";
            pnlInputCantidad.Padding = new Padding(5, 8, 5, 0);
            pnlInputCantidad.Size = new Size(328, 42);
            pnlInputCantidad.TabIndex = 9;
            // 
            // nudCantidad
            // 
            nudCantidad.DecimalPlaces = 4;
            nudCantidad.Dock = DockStyle.Fill;
            nudCantidad.Location = new Point(5, 8);
            nudCantidad.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(318, 26);
            nudCantidad.TabIndex = 0;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // pnlInputStockMin
            // 
            pnlInputStockMin.Controls.Add(nudStockMinimo);
            pnlInputStockMin.Dock = DockStyle.Fill;
            pnlInputStockMin.Location = new Point(3, 115);
            pnlInputStockMin.Name = "pnlInputStockMin";
            pnlInputStockMin.Padding = new Padding(5, 8, 5, 0);
            pnlInputStockMin.Size = new Size(328, 44);
            pnlInputStockMin.TabIndex = 10;
            // 
            // nudStockMinimo
            // 
            nudStockMinimo.DecimalPlaces = 4;
            nudStockMinimo.Dock = DockStyle.Fill;
            nudStockMinimo.Location = new Point(5, 8);
            nudStockMinimo.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudStockMinimo.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudStockMinimo.Name = "nudStockMinimo";
            nudStockMinimo.Size = new Size(318, 26);
            nudStockMinimo.TabIndex = 1;
            nudStockMinimo.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // pnlInputVencimiento
            // 
            pnlInputVencimiento.Controls.Add(dtpVencimiento);
            pnlInputVencimiento.Dock = DockStyle.Fill;
            pnlInputVencimiento.Location = new Point(337, 115);
            pnlInputVencimiento.Name = "pnlInputVencimiento";
            pnlInputVencimiento.Padding = new Padding(5, 8, 5, 0);
            pnlInputVencimiento.Size = new Size(328, 44);
            pnlInputVencimiento.TabIndex = 11;
            // 
            // dtpVencimiento
            // 
            dtpVencimiento.Checked = false;
            dtpVencimiento.Dock = DockStyle.Fill;
            dtpVencimiento.Format = DateTimePickerFormat.Short;
            dtpVencimiento.Location = new Point(5, 8);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.ShowCheckBox = true;
            dtpVencimiento.Size = new Size(318, 26);
            dtpVencimiento.TabIndex = 0;
            // 
            // pnlInputObservaciones
            // 
            pnlInputObservaciones.Controls.Add(txtObservaciones);
            pnlInputObservaciones.Controls.Add(lblObservaciones);
            pnlInputObservaciones.Dock = DockStyle.Bottom;
            pnlInputObservaciones.Location = new Point(15, 167);
            pnlInputObservaciones.Name = "pnlInputObservaciones";
            pnlInputObservaciones.Padding = new Padding(5);
            pnlInputObservaciones.Size = new Size(668, 95);
            pnlInputObservaciones.TabIndex = 12;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Dock = DockStyle.Fill;
            txtObservaciones.Location = new Point(5, 33);
            txtObservaciones.MaxLength = 500;
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(658, 57);
            txtObservaciones.TabIndex = 0;
            // 
            // lblObservaciones
            // 
            lblObservaciones.Dock = DockStyle.Top;
            lblObservaciones.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblObservaciones.Location = new Point(5, 5);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(658, 28);
            lblObservaciones.TabIndex = 3;
            lblObservaciones.Text = "Observaciones";
            lblObservaciones.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(245, 247, 250);
            pnlFooter.Controls.Add(tlpButtons);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 440);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Padding = new Padding(0, 3, 15, 3);
            pnlFooter.Size = new Size(698, 50);
            pnlFooter.TabIndex = 1;
            // 
            // tlpButtons
            // 
            tlpButtons.ColumnCount = 2;
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpButtons.Controls.Add(pnlCancelar, 0, 0);
            tlpButtons.Controls.Add(pnlGuardar, 1, 0);
            tlpButtons.Dock = DockStyle.Right;
            tlpButtons.Location = new Point(317, 3);
            tlpButtons.Name = "tlpButtons";
            tlpButtons.RowCount = 1;
            tlpButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpButtons.Size = new Size(366, 44);
            tlpButtons.TabIndex = 5;
            // 
            // pnlCancelar
            // 
            pnlCancelar.Controls.Add(btnCancelar);
            pnlCancelar.Dock = DockStyle.Fill;
            pnlCancelar.Location = new Point(3, 3);
            pnlCancelar.Name = "pnlCancelar";
            pnlCancelar.Size = new Size(140, 38);
            pnlCancelar.TabIndex = 0;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.Dock = DockStyle.Fill;
            btnCancelar.FlatAppearance.BorderSize = 0;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(0, 0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(140, 38);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // pnlGuardar
            // 
            pnlGuardar.Controls.Add(btnConfirmar);
            pnlGuardar.Dock = DockStyle.Fill;
            pnlGuardar.Location = new Point(149, 3);
            pnlGuardar.Name = "pnlGuardar";
            pnlGuardar.Size = new Size(214, 38);
            pnlGuardar.TabIndex = 1;
            // 
            // btnConfirmar
            // 
            btnConfirmar.BackColor = Color.FromArgb(8, 126, 164);
            btnConfirmar.Cursor = Cursors.Hand;
            btnConfirmar.Dock = DockStyle.Fill;
            btnConfirmar.FlatAppearance.BorderSize = 0;
            btnConfirmar.FlatStyle = FlatStyle.Flat;
            btnConfirmar.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnConfirmar.ForeColor = Color.White;
            btnConfirmar.Location = new Point(0, 0);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(214, 38);
            btnConfirmar.TabIndex = 0;
            btnConfirmar.Text = "GUARDAR";
            btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // FrmMovimientoInventario
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(698, 490);
            Controls.Add(pnlInputContainer);
            Controls.Add(pnlFooter);
            Controls.Add(pnlInfoContainer);
            Controls.Add(pnlDatosLote);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMovimientoInventario";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmMovimientoInventario";
            pnlDatosLote.ResumeLayout(false);
            pnlInfoContainer.ResumeLayout(false);
            tlpProducto.ResumeLayout(false);
            pnlUnidad.ResumeLayout(false);
            pnlInputContainer.ResumeLayout(false);
            tlpInputInfo.ResumeLayout(false);
            pnlLabelCodigo.ResumeLayout(false);
            pnlLableCantidad.ResumeLayout(false);
            pnlLabelVenicmiento.ResumeLayout(false);
            pnlInputCantidad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            pnlInputStockMin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).EndInit();
            pnlInputVencimiento.ResumeLayout(false);
            pnlInputObservaciones.ResumeLayout(false);
            pnlInputObservaciones.PerformLayout();
            pnlFooter.ResumeLayout(false);
            tlpButtons.ResumeLayout(false);
            pnlCancelar.ResumeLayout(false);
            pnlGuardar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlDatosLote;
        private Label lblTitulo;
        private Label lblSubtitulo;
        private Label lblSeleccion;
        private Panel pnlInfoContainer;
        private Label lblProducto;
        private TableLayoutPanel tlpProducto;
        private Panel pnlUnidad;
        private Label lblUnidad;
        private Label lblResumenStock;
        private Panel pnlInputContainer;
        private TableLayoutPanel tlpInputInfo;
        private Panel pnlLabelCodigo;
        private Label lblStockMinimo;
        private Panel pnlLableCantidad;
        private Label lblCantidad;
        private Panel pnlLabelVenicmiento;
        private Label lblVencimiento;
        private Label lblObservaciones;
        private Panel pnlInputCantidad;
        private Panel pnlInputStockMin;
        private Panel pnlInputVencimiento;
        private Panel pnlInputObservaciones;
        private TextBox txtObservaciones;
        private NumericUpDown nudCantidad;
        private DateTimePicker dtpVencimiento;
        private Panel pnlFooter;
        private TableLayoutPanel tlpButtons;
        private Panel pnlCancelar;
        private Button btnCancelar;
        private Panel pnlGuardar;
        private Button btnConfirmar;
        private NumericUpDown nudStockMinimo;
    }
}