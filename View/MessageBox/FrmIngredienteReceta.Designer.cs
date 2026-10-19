namespace Ocean_Desk_dv.View.MessageBox
{
    partial class FrmIngredienteReceta
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
            lblTitulo = new Label();
            lblDescripcion = new Label();
            pnlHeader = new Panel();
            pnlIngredientes = new Panel();
            tlpIngrediente = new TableLayoutPanel();
            pnlLabel = new Panel();
            lblIngrediente = new Label();
            pnlCombo = new Panel();
            cmbIngrediente = new ComboBox();
            pnlLabelCantidad = new Panel();
            lblCantidad = new Label();
            pnlNumeric = new Panel();
            nudCantidad = new NumericUpDown();
            pnlUnidadMedida = new Panel();
            lblAyuda = new Label();
            lblNotas = new Label();
            textBox1 = new TextBox();
            pnlInputNotas = new Panel();
            pnlContainerNotas = new Panel();
            panel1 = new Panel();
            pnlPie = new Panel();
            pnlButtons = new Panel();
            btnAccept = new Button();
            btnCancel = new Button();
            pnlHeader.SuspendLayout();
            pnlIngredientes.SuspendLayout();
            tlpIngrediente.SuspendLayout();
            pnlLabel.SuspendLayout();
            pnlCombo.SuspendLayout();
            pnlLabelCantidad.SuspendLayout();
            pnlNumeric.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
            pnlUnidadMedida.SuspendLayout();
            pnlInputNotas.SuspendLayout();
            pnlContainerNotas.SuspendLayout();
            panel1.SuspendLayout();
            pnlPie.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(10, 10);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(620, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Agregar ingrediente";
            // 
            // lblDescripcion
            // 
            lblDescripcion.BackColor = Color.Transparent;
            lblDescripcion.Dock = DockStyle.Top;
            lblDescripcion.ForeColor = Color.LightGray;
            lblDescripcion.Location = new Point(10, 42);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(620, 25);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Selecciona un ingrediente y define la cantidad.";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(8, 31, 63);
            pnlHeader.Controls.Add(lblDescripcion);
            pnlHeader.Controls.Add(lblTitulo);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(10);
            pnlHeader.Size = new Size(640, 81);
            pnlHeader.TabIndex = 2;
            // 
            // pnlIngredientes
            // 
            pnlIngredientes.BackColor = Color.White;
            pnlIngredientes.Controls.Add(tlpIngrediente);
            pnlIngredientes.Dock = DockStyle.Top;
            pnlIngredientes.Location = new Point(0, 81);
            pnlIngredientes.Name = "pnlIngredientes";
            pnlIngredientes.Size = new Size(640, 116);
            pnlIngredientes.TabIndex = 3;
            // 
            // tlpIngrediente
            // 
            tlpIngrediente.ColumnCount = 2;
            tlpIngrediente.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tlpIngrediente.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tlpIngrediente.Controls.Add(pnlLabel, 0, 0);
            tlpIngrediente.Controls.Add(pnlCombo, 1, 0);
            tlpIngrediente.Controls.Add(pnlLabelCantidad, 0, 1);
            tlpIngrediente.Controls.Add(pnlNumeric, 1, 1);
            tlpIngrediente.Controls.Add(pnlUnidadMedida, 1, 2);
            tlpIngrediente.Dock = DockStyle.Fill;
            tlpIngrediente.Location = new Point(0, 0);
            tlpIngrediente.Name = "tlpIngrediente";
            tlpIngrediente.RowCount = 3;
            tlpIngrediente.RowStyles.Add(new RowStyle(SizeType.Percent, 39.8305054F));
            tlpIngrediente.RowStyles.Add(new RowStyle(SizeType.Percent, 36.4406776F));
            tlpIngrediente.RowStyles.Add(new RowStyle(SizeType.Percent, 23.72882F));
            tlpIngrediente.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpIngrediente.Size = new Size(640, 116);
            tlpIngrediente.TabIndex = 0;
            // 
            // pnlLabel
            // 
            pnlLabel.Controls.Add(lblIngrediente);
            pnlLabel.Dock = DockStyle.Fill;
            pnlLabel.Location = new Point(3, 3);
            pnlLabel.Name = "pnlLabel";
            pnlLabel.Size = new Size(186, 40);
            pnlLabel.TabIndex = 0;
            // 
            // lblIngrediente
            // 
            lblIngrediente.Dock = DockStyle.Fill;
            lblIngrediente.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIngrediente.Location = new Point(0, 0);
            lblIngrediente.Name = "lblIngrediente";
            lblIngrediente.Size = new Size(186, 40);
            lblIngrediente.TabIndex = 0;
            lblIngrediente.Text = "Ingrediente:";
            lblIngrediente.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlCombo
            // 
            pnlCombo.Controls.Add(cmbIngrediente);
            pnlCombo.Dock = DockStyle.Fill;
            pnlCombo.Location = new Point(195, 3);
            pnlCombo.Name = "pnlCombo";
            pnlCombo.Padding = new Padding(5, 5, 20, 5);
            pnlCombo.Size = new Size(442, 40);
            pnlCombo.TabIndex = 1;
            // 
            // cmbIngrediente
            // 
            cmbIngrediente.Dock = DockStyle.Fill;
            cmbIngrediente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIngrediente.FormattingEnabled = true;
            cmbIngrediente.Location = new Point(5, 5);
            cmbIngrediente.Name = "cmbIngrediente";
            cmbIngrediente.Size = new Size(417, 28);
            cmbIngrediente.TabIndex = 1;
            // 
            // pnlLabelCantidad
            // 
            pnlLabelCantidad.Controls.Add(lblCantidad);
            pnlLabelCantidad.Dock = DockStyle.Fill;
            pnlLabelCantidad.Location = new Point(3, 49);
            pnlLabelCantidad.Name = "pnlLabelCantidad";
            pnlLabelCantidad.Size = new Size(186, 36);
            pnlLabelCantidad.TabIndex = 2;
            // 
            // lblCantidad
            // 
            lblCantidad.Dock = DockStyle.Fill;
            lblCantidad.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCantidad.Location = new Point(0, 0);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(186, 36);
            lblCantidad.TabIndex = 1;
            lblCantidad.Text = "Cantidad y Unidad:";
            lblCantidad.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnlNumeric
            // 
            pnlNumeric.Controls.Add(nudCantidad);
            pnlNumeric.Dock = DockStyle.Fill;
            pnlNumeric.Location = new Point(195, 49);
            pnlNumeric.Name = "pnlNumeric";
            pnlNumeric.Padding = new Padding(5, 5, 20, 5);
            pnlNumeric.Size = new Size(442, 36);
            pnlNumeric.TabIndex = 3;
            // 
            // nudCantidad
            // 
            nudCantidad.DecimalPlaces = 4;
            nudCantidad.Dock = DockStyle.Fill;
            nudCantidad.Location = new Point(5, 5);
            nudCantidad.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudCantidad.Name = "nudCantidad";
            nudCantidad.Size = new Size(417, 26);
            nudCantidad.TabIndex = 0;
            nudCantidad.ThousandsSeparator = true;
            nudCantidad.Value = new decimal(new int[] { 4, 0, 0, 0 });
            // 
            // pnlUnidadMedida
            // 
            pnlUnidadMedida.Controls.Add(lblAyuda);
            pnlUnidadMedida.Dock = DockStyle.Fill;
            pnlUnidadMedida.Location = new Point(195, 91);
            pnlUnidadMedida.Name = "pnlUnidadMedida";
            pnlUnidadMedida.Size = new Size(442, 22);
            pnlUnidadMedida.TabIndex = 4;
            // 
            // lblAyuda
            // 
            lblAyuda.Dock = DockStyle.Fill;
            lblAyuda.ForeColor = Color.DimGray;
            lblAyuda.Location = new Point(0, 0);
            lblAyuda.Name = "lblAyuda";
            lblAyuda.Size = new Size(442, 22);
            lblAyuda.TabIndex = 4;
            lblAyuda.Text = "Unidad de Medida";
            // 
            // lblNotas
            // 
            lblNotas.Dock = DockStyle.Fill;
            lblNotas.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNotas.Location = new Point(40, 0);
            lblNotas.Name = "lblNotas";
            lblNotas.Size = new Size(600, 34);
            lblNotas.TabIndex = 2;
            lblNotas.Text = "Notas:";
            lblNotas.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBox1
            // 
            textBox1.Dock = DockStyle.Fill;
            textBox1.Location = new Point(20, 10);
            textBox1.MaxLength = 250;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Escribe algun dato de relevancia aqui...";
            textBox1.Size = new Size(600, 74);
            textBox1.TabIndex = 6;
            // 
            // pnlInputNotas
            // 
            pnlInputNotas.Controls.Add(textBox1);
            pnlInputNotas.Dock = DockStyle.Fill;
            pnlInputNotas.Location = new Point(0, 34);
            pnlInputNotas.Name = "pnlInputNotas";
            pnlInputNotas.Padding = new Padding(20, 10, 20, 10);
            pnlInputNotas.Size = new Size(640, 94);
            pnlInputNotas.TabIndex = 6;
            // 
            // pnlContainerNotas
            // 
            pnlContainerNotas.Controls.Add(pnlInputNotas);
            pnlContainerNotas.Controls.Add(panel1);
            pnlContainerNotas.Dock = DockStyle.Fill;
            pnlContainerNotas.Location = new Point(0, 197);
            pnlContainerNotas.Name = "pnlContainerNotas";
            pnlContainerNotas.Size = new Size(640, 128);
            pnlContainerNotas.TabIndex = 7;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblNotas);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(40, 0, 0, 0);
            panel1.Size = new Size(640, 34);
            panel1.TabIndex = 7;
            // 
            // pnlPie
            // 
            pnlPie.BackColor = Color.FromArgb(245, 247, 250);
            pnlPie.Controls.Add(pnlButtons);
            pnlPie.Dock = DockStyle.Bottom;
            pnlPie.Location = new Point(0, 325);
            pnlPie.Name = "pnlPie";
            pnlPie.Padding = new Padding(0, 5, 20, 5);
            pnlPie.Size = new Size(640, 55);
            pnlPie.TabIndex = 7;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnAccept);
            pnlButtons.Controls.Add(btnCancel);
            pnlButtons.Dock = DockStyle.Right;
            pnlButtons.Location = new Point(380, 5);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(240, 45);
            pnlButtons.TabIndex = 3;
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
            btnAccept.Size = new Size(115, 45);
            btnAccept.TabIndex = 0;
            btnAccept.Text = "ACEPTAR";
            btnAccept.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.Dock = DockStyle.Left;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(0, 0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(115, 45);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "CANCELAR";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // FrmIngredienteReceta
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(640, 380);
            Controls.Add(pnlContainerNotas);
            Controls.Add(pnlPie);
            Controls.Add(pnlIngredientes);
            Controls.Add(pnlHeader);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmIngredienteReceta";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmIngredienteReceta";
            pnlHeader.ResumeLayout(false);
            pnlIngredientes.ResumeLayout(false);
            tlpIngrediente.ResumeLayout(false);
            pnlLabel.ResumeLayout(false);
            pnlCombo.ResumeLayout(false);
            pnlLabelCantidad.ResumeLayout(false);
            pnlNumeric.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
            pnlUnidadMedida.ResumeLayout(false);
            pnlInputNotas.ResumeLayout(false);
            pnlInputNotas.PerformLayout();
            pnlContainerNotas.ResumeLayout(false);
            panel1.ResumeLayout(false);
            pnlPie.ResumeLayout(false);
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Label lblDescripcion;
        private Panel pnlHeader;
        private Panel pnlIngredientes;
        private TableLayoutPanel tlpIngrediente;
        private Panel pnlLabel;
        private Label lblIngrediente;
        private Panel pnlCombo;
        private ComboBox cmbIngrediente;
        private Panel pnlLabelCantidad;
        private Label lblCantidad;
        private Panel pnlNumeric;
        private NumericUpDown nudCantidad;
        private Panel pnlUnidadMedida;
        private Label lblAyuda;
        private Label lblNotas;
        private TextBox textBox1;
        private Panel pnlInputNotas;
        private Panel pnlContainerNotas;
        private Panel panel1;
        private Panel pnlPie;
        private Panel pnlButtons;
        private Button btnAccept;
        private Button btnCancel;
    }
}