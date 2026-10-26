namespace Ocean_Desk_dv.View.MessageBox
{
    partial class FrmAgregarIngredienteCompra
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
            pnlContainer = new Panel();
            tlpInputInfo = new TableLayoutPanel();
            pnlLabelCodigo = new Panel();
            lblCantidad = new Label();
            pnlLableCantidad = new Panel();
            lblIngrediente = new Label();
            pnlLabelVenicmiento = new Panel();
            lblCostoUnitario = new Label();
            pnlInputIngrediente = new Panel();
            txtNombreIngrediente = new TextBox();
            pnlLine = new Panel();
            pnlInputStockMin = new Panel();
            nudStockMinimo = new NumericUpDown();
            pnlInputVencimiento = new Panel();
            nudCosto = new NumericUpDown();
            panel1 = new Panel();
            lblLote = new Label();
            panel2 = new Panel();
            txtLote = new TextBox();
            panel3 = new Panel();
            pnlLabelVencimiento = new Panel();
            lblVencimiento = new Label();
            pnlInputVencer = new Panel();
            dtpVencimiento = new DateTimePicker();
            pnlLabelUnidad = new Panel();
            lblUnidadMedida = new Label();
            pnlInputUnidad = new Panel();
            cmbUnidadMedida = new ComboBox();
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
            pnlContainer.SuspendLayout();
            tlpInputInfo.SuspendLayout();
            pnlLabelCodigo.SuspendLayout();
            pnlLableCantidad.SuspendLayout();
            pnlLabelVenicmiento.SuspendLayout();
            pnlInputIngrediente.SuspendLayout();
            pnlInputStockMin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).BeginInit();
            pnlInputVencimiento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCosto).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            pnlLabelVencimiento.SuspendLayout();
            pnlInputVencer.SuspendLayout();
            pnlLabelUnidad.SuspendLayout();
            pnlInputUnidad.SuspendLayout();
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
            pnlDatosLote.Size = new Size(518, 78);
            pnlDatosLote.TabIndex = 1;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Dock = DockStyle.Top;
            lblSubtitulo.ForeColor = Color.LightGray;
            lblSubtitulo.Location = new Point(15, 42);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(493, 20);
            lblSubtitulo.TabIndex = 0;
            lblSubtitulo.Text = "Productos comprados al proveedor";
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(493, 27);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Agregar Productos";
            // 
            // pnlContainer
            // 
            pnlContainer.Controls.Add(tlpInputInfo);
            pnlContainer.Controls.Add(pnlInputObservaciones);
            pnlContainer.Controls.Add(pnlFooter);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 78);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(5);
            pnlContainer.Size = new Size(518, 492);
            pnlContainer.TabIndex = 2;
            // 
            // tlpInputInfo
            // 
            tlpInputInfo.ColumnCount = 2;
            tlpInputInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53.1496F));
            tlpInputInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.8503952F));
            tlpInputInfo.Controls.Add(pnlLabelCodigo, 0, 2);
            tlpInputInfo.Controls.Add(pnlLableCantidad, 0, 0);
            tlpInputInfo.Controls.Add(pnlLabelVenicmiento, 1, 2);
            tlpInputInfo.Controls.Add(pnlInputIngrediente, 0, 1);
            tlpInputInfo.Controls.Add(pnlInputStockMin, 0, 3);
            tlpInputInfo.Controls.Add(pnlInputVencimiento, 1, 3);
            tlpInputInfo.Controls.Add(panel1, 0, 4);
            tlpInputInfo.Controls.Add(panel2, 0, 5);
            tlpInputInfo.Controls.Add(pnlLabelVencimiento, 0, 6);
            tlpInputInfo.Controls.Add(pnlInputVencer, 0, 7);
            tlpInputInfo.Controls.Add(pnlLabelUnidad, 1, 0);
            tlpInputInfo.Controls.Add(pnlInputUnidad, 1, 1);
            tlpInputInfo.Dock = DockStyle.Fill;
            tlpInputInfo.Location = new Point(5, 5);
            tlpInputInfo.Name = "tlpInputInfo";
            tlpInputInfo.RowCount = 8;
            tlpInputInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 7.7977314F));
            tlpInputInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 12.1875F));
            tlpInputInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 8.125F));
            tlpInputInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 13.125F));
            tlpInputInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 9.6875F));
            tlpInputInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 10.625F));
            tlpInputInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 9.375F));
            tlpInputInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 9.150327F));
            tlpInputInfo.Size = new Size(508, 327);
            tlpInputInfo.TabIndex = 1;
            // 
            // pnlLabelCodigo
            // 
            pnlLabelCodigo.Controls.Add(lblCantidad);
            pnlLabelCodigo.Dock = DockStyle.Fill;
            pnlLabelCodigo.Location = new Point(3, 83);
            pnlLabelCodigo.Name = "pnlLabelCodigo";
            pnlLabelCodigo.Padding = new Padding(5, 0, 0, 0);
            pnlLabelCodigo.Size = new Size(263, 27);
            pnlLabelCodigo.TabIndex = 6;
            // 
            // lblCantidad
            // 
            lblCantidad.Dock = DockStyle.Fill;
            lblCantidad.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidad.Location = new Point(5, 0);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(258, 27);
            lblCantidad.TabIndex = 1;
            lblCantidad.Text = "Cantidad";
            lblCantidad.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlLableCantidad
            // 
            pnlLableCantidad.Controls.Add(lblIngrediente);
            pnlLableCantidad.Dock = DockStyle.Fill;
            pnlLableCantidad.Location = new Point(3, 3);
            pnlLableCantidad.Name = "pnlLableCantidad";
            pnlLableCantidad.Padding = new Padding(5, 0, 0, 0);
            pnlLableCantidad.Size = new Size(263, 25);
            pnlLableCantidad.TabIndex = 5;
            // 
            // lblIngrediente
            // 
            lblIngrediente.Dock = DockStyle.Fill;
            lblIngrediente.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIngrediente.Location = new Point(5, 0);
            lblIngrediente.Name = "lblIngrediente";
            lblIngrediente.Size = new Size(258, 25);
            lblIngrediente.TabIndex = 0;
            lblIngrediente.Text = "Ingrediente";
            lblIngrediente.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlLabelVenicmiento
            // 
            pnlLabelVenicmiento.Controls.Add(lblCostoUnitario);
            pnlLabelVenicmiento.Dock = DockStyle.Fill;
            pnlLabelVenicmiento.Location = new Point(272, 83);
            pnlLabelVenicmiento.Name = "pnlLabelVenicmiento";
            pnlLabelVenicmiento.Padding = new Padding(5, 0, 0, 0);
            pnlLabelVenicmiento.Size = new Size(233, 27);
            pnlLabelVenicmiento.TabIndex = 7;
            // 
            // lblCostoUnitario
            // 
            lblCostoUnitario.Dock = DockStyle.Fill;
            lblCostoUnitario.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCostoUnitario.Location = new Point(5, 0);
            lblCostoUnitario.Name = "lblCostoUnitario";
            lblCostoUnitario.Size = new Size(228, 27);
            lblCostoUnitario.TabIndex = 2;
            lblCostoUnitario.Text = "Costo Unitario (C$)";
            lblCostoUnitario.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlInputIngrediente
            // 
            pnlInputIngrediente.Controls.Add(txtNombreIngrediente);
            pnlInputIngrediente.Controls.Add(pnlLine);
            pnlInputIngrediente.Dock = DockStyle.Fill;
            pnlInputIngrediente.Location = new Point(3, 34);
            pnlInputIngrediente.Name = "pnlInputIngrediente";
            pnlInputIngrediente.Padding = new Padding(5, 8, 5, 12);
            pnlInputIngrediente.Size = new Size(263, 43);
            pnlInputIngrediente.TabIndex = 9;
            // 
            // txtNombreIngrediente
            // 
            txtNombreIngrediente.BorderStyle = BorderStyle.None;
            txtNombreIngrediente.Dock = DockStyle.Top;
            txtNombreIngrediente.Location = new Point(5, 8);
            txtNombreIngrediente.Name = "txtNombreIngrediente";
            txtNombreIngrediente.PlaceholderText = "Ingrese Ingrediente...";
            txtNombreIngrediente.Size = new Size(253, 19);
            txtNombreIngrediente.TabIndex = 8;
            // 
            // pnlLine
            // 
            pnlLine.BackColor = Color.MidnightBlue;
            pnlLine.Dock = DockStyle.Bottom;
            pnlLine.Location = new Point(5, 29);
            pnlLine.Name = "pnlLine";
            pnlLine.Size = new Size(253, 2);
            pnlLine.TabIndex = 9;
            // 
            // pnlInputStockMin
            // 
            pnlInputStockMin.Controls.Add(nudStockMinimo);
            pnlInputStockMin.Dock = DockStyle.Fill;
            pnlInputStockMin.Location = new Point(3, 116);
            pnlInputStockMin.Name = "pnlInputStockMin";
            pnlInputStockMin.Padding = new Padding(5, 8, 5, 0);
            pnlInputStockMin.Size = new Size(263, 47);
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
            nudStockMinimo.Size = new Size(253, 26);
            nudStockMinimo.TabIndex = 1;
            nudStockMinimo.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // pnlInputVencimiento
            // 
            pnlInputVencimiento.Controls.Add(nudCosto);
            pnlInputVencimiento.Dock = DockStyle.Fill;
            pnlInputVencimiento.Location = new Point(272, 116);
            pnlInputVencimiento.Name = "pnlInputVencimiento";
            pnlInputVencimiento.Padding = new Padding(5, 8, 5, 0);
            pnlInputVencimiento.Size = new Size(233, 47);
            pnlInputVencimiento.TabIndex = 11;
            // 
            // nudCosto
            // 
            nudCosto.DecimalPlaces = 4;
            nudCosto.Dock = DockStyle.Fill;
            nudCosto.Location = new Point(5, 8);
            nudCosto.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudCosto.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCosto.Name = "nudCosto";
            nudCosto.Size = new Size(223, 26);
            nudCosto.TabIndex = 2;
            nudCosto.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // panel1
            // 
            panel1.Controls.Add(lblLote);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 169);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(5, 0, 0, 0);
            panel1.Size = new Size(263, 33);
            panel1.TabIndex = 12;
            // 
            // lblLote
            // 
            lblLote.Dock = DockStyle.Fill;
            lblLote.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLote.Location = new Point(5, 0);
            lblLote.Name = "lblLote";
            lblLote.Size = new Size(258, 33);
            lblLote.TabIndex = 2;
            lblLote.Text = "Código de lote (opcional)";
            lblLote.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            panel2.Controls.Add(txtLote);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 208);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(5, 5, 5, 10);
            panel2.Size = new Size(263, 37);
            panel2.TabIndex = 13;
            // 
            // txtLote
            // 
            txtLote.BorderStyle = BorderStyle.None;
            txtLote.Dock = DockStyle.Top;
            txtLote.Location = new Point(5, 5);
            txtLote.Name = "txtLote";
            txtLote.PlaceholderText = "Ingrese Ingrediente...";
            txtLote.Size = new Size(253, 19);
            txtLote.TabIndex = 8;
            // 
            // panel3
            // 
            panel3.BackColor = Color.MidnightBlue;
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(5, 25);
            panel3.Name = "panel3";
            panel3.Size = new Size(253, 2);
            panel3.TabIndex = 9;
            // 
            // pnlLabelVencimiento
            // 
            pnlLabelVencimiento.Controls.Add(lblVencimiento);
            pnlLabelVencimiento.Dock = DockStyle.Fill;
            pnlLabelVencimiento.Location = new Point(3, 251);
            pnlLabelVencimiento.Name = "pnlLabelVencimiento";
            pnlLabelVencimiento.Padding = new Padding(5, 0, 0, 0);
            pnlLabelVencimiento.Size = new Size(263, 32);
            pnlLabelVencimiento.TabIndex = 14;
            // 
            // lblVencimiento
            // 
            lblVencimiento.Dock = DockStyle.Fill;
            lblVencimiento.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVencimiento.Location = new Point(5, 0);
            lblVencimiento.Name = "lblVencimiento";
            lblVencimiento.Size = new Size(258, 32);
            lblVencimiento.TabIndex = 2;
            lblVencimiento.Text = "Fecha de vencimiento (opcional)";
            lblVencimiento.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlInputVencer
            // 
            pnlInputVencer.Controls.Add(dtpVencimiento);
            pnlInputVencer.Dock = DockStyle.Fill;
            pnlInputVencer.Location = new Point(3, 289);
            pnlInputVencer.Name = "pnlInputVencer";
            pnlInputVencer.Padding = new Padding(5, 8, 5, 10);
            pnlInputVencer.Size = new Size(263, 35);
            pnlInputVencer.TabIndex = 15;
            // 
            // dtpVencimiento
            // 
            dtpVencimiento.Checked = false;
            dtpVencimiento.Dock = DockStyle.Fill;
            dtpVencimiento.Format = DateTimePickerFormat.Short;
            dtpVencimiento.Location = new Point(5, 8);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.ShowCheckBox = true;
            dtpVencimiento.Size = new Size(253, 26);
            dtpVencimiento.TabIndex = 0;
            // 
            // pnlLabelUnidad
            // 
            pnlLabelUnidad.Controls.Add(lblUnidadMedida);
            pnlLabelUnidad.Location = new Point(272, 3);
            pnlLabelUnidad.Name = "pnlLabelUnidad";
            pnlLabelUnidad.Padding = new Padding(5, 0, 0, 0);
            pnlLabelUnidad.Size = new Size(233, 25);
            pnlLabelUnidad.TabIndex = 16;
            // 
            // lblUnidadMedida
            // 
            lblUnidadMedida.Dock = DockStyle.Top;
            lblUnidadMedida.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUnidadMedida.Location = new Point(5, 0);
            lblUnidadMedida.Name = "lblUnidadMedida";
            lblUnidadMedida.Size = new Size(228, 25);
            lblUnidadMedida.TabIndex = 1;
            lblUnidadMedida.Text = "Unidad de Medida";
            lblUnidadMedida.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlInputUnidad
            // 
            pnlInputUnidad.Controls.Add(cmbUnidadMedida);
            pnlInputUnidad.Location = new Point(272, 34);
            pnlInputUnidad.Name = "pnlInputUnidad";
            pnlInputUnidad.Padding = new Padding(5, 8, 5, 0);
            pnlInputUnidad.Size = new Size(233, 43);
            pnlInputUnidad.TabIndex = 17;
            // 
            // cmbUnidadMedida
            // 
            cmbUnidadMedida.Dock = DockStyle.Fill;
            cmbUnidadMedida.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnidadMedida.FormattingEnabled = true;
            cmbUnidadMedida.Location = new Point(5, 8);
            cmbUnidadMedida.Name = "cmbUnidadMedida";
            cmbUnidadMedida.Size = new Size(223, 28);
            cmbUnidadMedida.TabIndex = 2;
            // 
            // pnlInputObservaciones
            // 
            pnlInputObservaciones.Controls.Add(txtObservaciones);
            pnlInputObservaciones.Controls.Add(lblObservaciones);
            pnlInputObservaciones.Dock = DockStyle.Bottom;
            pnlInputObservaciones.Location = new Point(5, 332);
            pnlInputObservaciones.Name = "pnlInputObservaciones";
            pnlInputObservaciones.Padding = new Padding(5);
            pnlInputObservaciones.Size = new Size(508, 95);
            pnlInputObservaciones.TabIndex = 13;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Dock = DockStyle.Fill;
            txtObservaciones.Location = new Point(5, 33);
            txtObservaciones.MaxLength = 500;
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(498, 57);
            txtObservaciones.TabIndex = 0;
            // 
            // lblObservaciones
            // 
            lblObservaciones.Dock = DockStyle.Top;
            lblObservaciones.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblObservaciones.Location = new Point(5, 5);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(498, 28);
            lblObservaciones.TabIndex = 3;
            lblObservaciones.Text = "Observaciones (Opcional)";
            lblObservaciones.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(245, 247, 250);
            pnlFooter.Controls.Add(tlpButtons);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(5, 427);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Padding = new Padding(0, 3, 15, 3);
            pnlFooter.Size = new Size(508, 60);
            pnlFooter.TabIndex = 15;
            // 
            // tlpButtons
            // 
            tlpButtons.ColumnCount = 2;
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpButtons.Controls.Add(pnlCancelar, 0, 0);
            tlpButtons.Controls.Add(pnlGuardar, 1, 0);
            tlpButtons.Dock = DockStyle.Right;
            tlpButtons.Location = new Point(127, 3);
            tlpButtons.Name = "tlpButtons";
            tlpButtons.RowCount = 1;
            tlpButtons.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpButtons.Size = new Size(366, 54);
            tlpButtons.TabIndex = 5;
            // 
            // pnlCancelar
            // 
            pnlCancelar.Controls.Add(btnCancelar);
            pnlCancelar.Dock = DockStyle.Fill;
            pnlCancelar.Location = new Point(3, 3);
            pnlCancelar.Name = "pnlCancelar";
            pnlCancelar.Size = new Size(140, 48);
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
            btnCancelar.Size = new Size(140, 48);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "✕ CANCELAR";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // pnlGuardar
            // 
            pnlGuardar.Controls.Add(btnConfirmar);
            pnlGuardar.Dock = DockStyle.Fill;
            pnlGuardar.Location = new Point(149, 3);
            pnlGuardar.Name = "pnlGuardar";
            pnlGuardar.Size = new Size(214, 48);
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
            btnConfirmar.Size = new Size(214, 48);
            btnConfirmar.TabIndex = 0;
            btnConfirmar.Text = "+ AGREGAR PRODUCTO";
            btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // FrmAgregarIngredienteCompra
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(518, 570);
            Controls.Add(pnlContainer);
            Controls.Add(pnlDatosLote);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAgregarIngredienteCompra";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmAgregarIngredienteCompra";
            pnlDatosLote.ResumeLayout(false);
            pnlContainer.ResumeLayout(false);
            tlpInputInfo.ResumeLayout(false);
            pnlLabelCodigo.ResumeLayout(false);
            pnlLableCantidad.ResumeLayout(false);
            pnlLabelVenicmiento.ResumeLayout(false);
            pnlInputIngrediente.ResumeLayout(false);
            pnlInputIngrediente.PerformLayout();
            pnlInputStockMin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudStockMinimo).EndInit();
            pnlInputVencimiento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudCosto).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlLabelVencimiento.ResumeLayout(false);
            pnlInputVencer.ResumeLayout(false);
            pnlLabelUnidad.ResumeLayout(false);
            pnlInputUnidad.ResumeLayout(false);
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
        private Label lblSubtitulo;
        private Label lblTitulo;
        private Panel pnlContainer;
        private TableLayoutPanel tlpInputInfo;
        private Panel pnlLabelCodigo;
        private Label lblCantidad;
        private Panel pnlLableCantidad;
        private Label lblIngrediente;
        private Panel pnlLabelVenicmiento;
        private Label lblCostoUnitario;
        private Panel pnlInputIngrediente;
        private Panel pnlInputStockMin;
        private NumericUpDown nudStockMinimo;
        private Panel pnlInputVencimiento;
        private TextBox txtNombreIngrediente;
        private Panel pnlLine;
        private NumericUpDown nudCosto;
        private Panel panel1;
        private Label lblLote;
        private Panel panel2;
        private TextBox txtLote;
        private Panel panel3;
        private Panel pnlLabelVencimiento;
        private Label lblVencimiento;
        private Panel pnlInputVencer;
        private DateTimePicker dtpVencimiento;
        private Panel pnlInputObservaciones;
        private TextBox txtObservaciones;
        private Label lblObservaciones;
        private Panel pnlFooter;
        private TableLayoutPanel tlpButtons;
        private Panel pnlCancelar;
        private Button btnCancelar;
        private Panel pnlGuardar;
        private Button btnConfirmar;
        private Panel pnlLabelUnidad;
        private Panel pnlInputUnidad;
        private Label lblUnidadMedida;
        private ComboBox cmbUnidadMedida;
    }
}