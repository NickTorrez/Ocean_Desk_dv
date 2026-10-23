namespace Ocean_Desk_dv.View.MessageBox
{
    partial class FrmEntradaInventario
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
            lblSubtitulo = new Label();
            lblTitulo = new Label();
            pnlContainer = new Panel();
            pnlObservaciones = new Panel();
            txtObservaciones = new TextBox();
            lblObservaciones = new Label();
            pnlVencimiento = new Panel();
            dtpVencimiento = new DateTimePicker();
            lblVencimiento = new Label();
            pnlCantidad = new Panel();
            nudCantidad = new NumericUpDown();
            lblCantidad = new Label();
            pnlUnidadMedida = new Panel();
            cmbUnidadMedida = new ComboBox();
            lblUnidadMedida = new Label();
            pnlCodigo = new Panel();
            panel3 = new Panel();
            txtCodigoProducto = new TextBox();
            lblCodigoProducto = new Label();
            pnlIngrediente = new Panel();
            txtNombreIngrediente = new TextBox();
            pnlLine = new Panel();
            lblNombreIngrediente = new Label();
            pnlFooter = new Panel();
            tlpButtons = new TableLayoutPanel();
            pnlCancelar = new Panel();
            btnCancelar = new Button();
            pnlGuardar = new Panel();
            btnConfirmar = new Button();
            pnlHeader.SuspendLayout();
            pnlContainer.SuspendLayout();
            pnlObservaciones.SuspendLayout();
            pnlVencimiento.SuspendLayout();
            pnlCantidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            pnlUnidadMedida.SuspendLayout();
            pnlCodigo.SuspendLayout();
            pnlIngrediente.SuspendLayout();
            pnlFooter.SuspendLayout();
            tlpButtons.SuspendLayout();
            pnlCancelar.SuspendLayout();
            pnlGuardar.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(8, 31, 63);
            pnlHeader.Controls.Add(lblSubtitulo);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(17, 15, 11, 10);
            pnlHeader.Size = new Size(690, 78);
            pnlHeader.TabIndex = 1;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.Dock = DockStyle.Bottom;
            lblSubtitulo.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitulo.ForeColor = Color.LightGray;
            lblSubtitulo.Location = new Point(17, 48);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(662, 20);
            lblSubtitulo.TabIndex = 0;
            lblSubtitulo.Text = "Gestión de Inventario";
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(17, 15);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(662, 27);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Registrar Entrada de Ingredientes";
            // 
            // pnlContainer
            // 
            pnlContainer.Controls.Add(pnlObservaciones);
            pnlContainer.Controls.Add(pnlVencimiento);
            pnlContainer.Controls.Add(pnlCantidad);
            pnlContainer.Controls.Add(pnlUnidadMedida);
            pnlContainer.Controls.Add(pnlCodigo);
            pnlContainer.Controls.Add(pnlIngrediente);
            pnlContainer.Dock = DockStyle.Fill;
            pnlContainer.Location = new Point(0, 78);
            pnlContainer.Name = "pnlContainer";
            pnlContainer.Padding = new Padding(5);
            pnlContainer.Size = new Size(690, 462);
            pnlContainer.TabIndex = 0;
            // 
            // pnlObservaciones
            // 
            pnlObservaciones.Controls.Add(txtObservaciones);
            pnlObservaciones.Controls.Add(lblObservaciones);
            pnlObservaciones.Dock = DockStyle.Fill;
            pnlObservaciones.Location = new Point(5, 355);
            pnlObservaciones.Name = "pnlObservaciones";
            pnlObservaciones.Padding = new Padding(17, 15, 17, 5);
            pnlObservaciones.Size = new Size(680, 102);
            pnlObservaciones.TabIndex = 13;
            // 
            // txtObservaciones
            // 
            txtObservaciones.Dock = DockStyle.Fill;
            txtObservaciones.Location = new Point(17, 40);
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.PlaceholderText = "Ingrese algun dato de relevancia...";
            txtObservaciones.ScrollBars = ScrollBars.Vertical;
            txtObservaciones.Size = new Size(646, 57);
            txtObservaciones.TabIndex = 8;
            // 
            // lblObservaciones
            // 
            lblObservaciones.Dock = DockStyle.Top;
            lblObservaciones.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblObservaciones.Location = new Point(17, 15);
            lblObservaciones.Name = "lblObservaciones";
            lblObservaciones.Size = new Size(646, 25);
            lblObservaciones.TabIndex = 0;
            lblObservaciones.Text = "Observaciones (Opcional)";
            // 
            // pnlVencimiento
            // 
            pnlVencimiento.Controls.Add(dtpVencimiento);
            pnlVencimiento.Controls.Add(lblVencimiento);
            pnlVencimiento.Dock = DockStyle.Top;
            pnlVencimiento.Location = new Point(5, 285);
            pnlVencimiento.Name = "pnlVencimiento";
            pnlVencimiento.Padding = new Padding(17, 15, 17, 15);
            pnlVencimiento.Size = new Size(680, 70);
            pnlVencimiento.TabIndex = 12;
            // 
            // dtpVencimiento
            // 
            dtpVencimiento.Dock = DockStyle.Left;
            dtpVencimiento.Format = DateTimePickerFormat.Short;
            dtpVencimiento.Location = new Point(17, 40);
            dtpVencimiento.Name = "dtpVencimiento";
            dtpVencimiento.ShowCheckBox = true;
            dtpVencimiento.Size = new Size(420, 26);
            dtpVencimiento.TabIndex = 1;
            // 
            // lblVencimiento
            // 
            lblVencimiento.Dock = DockStyle.Top;
            lblVencimiento.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVencimiento.Location = new Point(17, 15);
            lblVencimiento.Name = "lblVencimiento";
            lblVencimiento.Size = new Size(646, 25);
            lblVencimiento.TabIndex = 0;
            lblVencimiento.Text = "Fecha de Vencimiento (Opcional)";
            // 
            // pnlCantidad
            // 
            pnlCantidad.Controls.Add(nudCantidad);
            pnlCantidad.Controls.Add(lblCantidad);
            pnlCantidad.Dock = DockStyle.Top;
            pnlCantidad.Location = new Point(5, 215);
            pnlCantidad.Name = "pnlCantidad";
            pnlCantidad.Padding = new Padding(17, 15, 17, 15);
            pnlCantidad.Size = new Size(680, 70);
            pnlCantidad.TabIndex = 11;
            // 
            // nudCantidad
            // 
            nudCantidad.DecimalPlaces = 4;
            nudCantidad.Dock = DockStyle.Left;
            nudCantidad.Location = new Point(17, 40);
            nudCantidad.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(420, 26);
            nudCantidad.TabIndex = 1;
            nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblCantidad
            // 
            lblCantidad.Dock = DockStyle.Top;
            lblCantidad.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidad.Location = new Point(17, 15);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(646, 25);
            lblCantidad.TabIndex = 0;
            lblCantidad.Text = "Cantidad Recibida";
            // 
            // pnlUnidadMedida
            // 
            pnlUnidadMedida.Controls.Add(cmbUnidadMedida);
            pnlUnidadMedida.Controls.Add(lblUnidadMedida);
            pnlUnidadMedida.Dock = DockStyle.Top;
            pnlUnidadMedida.Location = new Point(5, 145);
            pnlUnidadMedida.Name = "pnlUnidadMedida";
            pnlUnidadMedida.Padding = new Padding(17, 15, 17, 15);
            pnlUnidadMedida.Size = new Size(680, 70);
            pnlUnidadMedida.TabIndex = 10;
            // 
            // cmbUnidadMedida
            // 
            cmbUnidadMedida.Dock = DockStyle.Left;
            cmbUnidadMedida.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUnidadMedida.FormattingEnabled = true;
            cmbUnidadMedida.Location = new Point(17, 40);
            cmbUnidadMedida.Name = "cmbUnidadMedida";
            cmbUnidadMedida.Size = new Size(420, 28);
            cmbUnidadMedida.TabIndex = 1;
            // 
            // lblUnidadMedida
            // 
            lblUnidadMedida.Dock = DockStyle.Top;
            lblUnidadMedida.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUnidadMedida.Location = new Point(17, 15);
            lblUnidadMedida.Name = "lblUnidadMedida";
            lblUnidadMedida.Size = new Size(646, 25);
            lblUnidadMedida.TabIndex = 0;
            lblUnidadMedida.Text = "Unidad de Medida";
            // 
            // pnlCodigo
            // 
            pnlCodigo.Controls.Add(panel3);
            pnlCodigo.Controls.Add(txtCodigoProducto);
            pnlCodigo.Controls.Add(lblCodigoProducto);
            pnlCodigo.Dock = DockStyle.Top;
            pnlCodigo.Location = new Point(5, 75);
            pnlCodigo.Name = "pnlCodigo";
            pnlCodigo.Padding = new Padding(17, 15, 17, 15);
            pnlCodigo.Size = new Size(680, 70);
            pnlCodigo.TabIndex = 9;
            // 
            // panel3
            // 
            panel3.BackColor = Color.MidnightBlue;
            panel3.Location = new Point(18, 63);
            panel3.Name = "panel3";
            panel3.Size = new Size(422, 2);
            panel3.TabIndex = 9;
            // 
            // txtCodigoProducto
            // 
            txtCodigoProducto.BorderStyle = BorderStyle.None;
            txtCodigoProducto.Dock = DockStyle.Left;
            txtCodigoProducto.Location = new Point(17, 40);
            txtCodigoProducto.Name = "txtCodigoProducto";
            txtCodigoProducto.PlaceholderText = "Ingrese Codigo del Ingrediente...";
            txtCodigoProducto.Size = new Size(420, 19);
            txtCodigoProducto.TabIndex = 8;
            // 
            // lblCodigoProducto
            // 
            lblCodigoProducto.Dock = DockStyle.Top;
            lblCodigoProducto.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCodigoProducto.Location = new Point(17, 15);
            lblCodigoProducto.Name = "lblCodigoProducto";
            lblCodigoProducto.Size = new Size(646, 25);
            lblCodigoProducto.TabIndex = 0;
            lblCodigoProducto.Text = "Código del Producto";
            // 
            // pnlIngrediente
            // 
            pnlIngrediente.Controls.Add(txtNombreIngrediente);
            pnlIngrediente.Controls.Add(pnlLine);
            pnlIngrediente.Controls.Add(lblNombreIngrediente);
            pnlIngrediente.Dock = DockStyle.Top;
            pnlIngrediente.Location = new Point(5, 5);
            pnlIngrediente.Name = "pnlIngrediente";
            pnlIngrediente.Padding = new Padding(17, 15, 17, 15);
            pnlIngrediente.Size = new Size(680, 70);
            pnlIngrediente.TabIndex = 8;
            // 
            // txtNombreIngrediente
            // 
            txtNombreIngrediente.BorderStyle = BorderStyle.None;
            txtNombreIngrediente.Dock = DockStyle.Left;
            txtNombreIngrediente.Location = new Point(17, 40);
            txtNombreIngrediente.Name = "txtNombreIngrediente";
            txtNombreIngrediente.PlaceholderText = "Ingrese Nombre dle Ingrediente...";
            txtNombreIngrediente.Size = new Size(420, 19);
            txtNombreIngrediente.TabIndex = 1;
            // 
            // pnlLine
            // 
            pnlLine.BackColor = Color.MidnightBlue;
            pnlLine.Location = new Point(17, 63);
            pnlLine.Name = "pnlLine";
            pnlLine.Size = new Size(422, 2);
            pnlLine.TabIndex = 7;
            // 
            // lblNombreIngrediente
            // 
            lblNombreIngrediente.Dock = DockStyle.Top;
            lblNombreIngrediente.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNombreIngrediente.Location = new Point(17, 15);
            lblNombreIngrediente.Name = "lblNombreIngrediente";
            lblNombreIngrediente.Size = new Size(646, 25);
            lblNombreIngrediente.TabIndex = 0;
            lblNombreIngrediente.Text = "Ingrediente:";
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(245, 247, 250);
            pnlFooter.Controls.Add(tlpButtons);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 540);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Padding = new Padding(0, 3, 15, 3);
            pnlFooter.Size = new Size(690, 60);
            pnlFooter.TabIndex = 14;
            // 
            // tlpButtons
            // 
            tlpButtons.ColumnCount = 2;
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpButtons.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpButtons.Controls.Add(pnlCancelar, 0, 0);
            tlpButtons.Controls.Add(pnlGuardar, 1, 0);
            tlpButtons.Dock = DockStyle.Right;
            tlpButtons.Location = new Point(309, 3);
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
            btnCancelar.Text = "CANCELAR";
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
            btnConfirmar.Text = "REGISTRAR ENTRADA";
            btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // FrmEntradaInventario
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(690, 600);
            Controls.Add(pnlContainer);
            Controls.Add(pnlFooter);
            Controls.Add(pnlHeader);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmEntradaInventario";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmEntradaInventario";
            pnlHeader.ResumeLayout(false);
            pnlContainer.ResumeLayout(false);
            pnlObservaciones.ResumeLayout(false);
            pnlObservaciones.PerformLayout();
            pnlVencimiento.ResumeLayout(false);
            pnlCantidad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            pnlUnidadMedida.ResumeLayout(false);
            pnlCodigo.ResumeLayout(false);
            pnlCodigo.PerformLayout();
            pnlIngrediente.ResumeLayout(false);
            pnlIngrediente.PerformLayout();
            pnlFooter.ResumeLayout(false);
            tlpButtons.ResumeLayout(false);
            pnlCancelar.ResumeLayout(false);
            pnlGuardar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblSubtitulo;
        private Label lblTitulo;
        private Panel pnlContainer;
        private TextBox txtNombreIngrediente;
        private Label lblNombreIngrediente;
        private Panel pnlLine;
        private Panel pnlIngrediente;
        private Panel pnlCodigo;
        private Label lblCodigoProducto;
        private TextBox txtCodigoProducto;
        private Panel panel3;
        private Panel pnlUnidadMedida;
        private ComboBox cmbUnidadMedida;
        private Label lblUnidadMedida;
        private Panel pnlCantidad;
        private Label lblCantidad;
        private NumericUpDown nudCantidad;
        private Panel pnlVencimiento;
        private DateTimePicker dtpVencimiento;
        private Label lblVencimiento;
        private Panel pnlObservaciones;
        private Label lblObservaciones;
        private TextBox txtObservaciones;
        private Panel pnlFooter;
        private TableLayoutPanel tlpButtons;
        private Panel pnlCancelar;
        private Button btnCancelar;
        private Panel pnlGuardar;
        private Button btnConfirmar;
    }
}