using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Ocean_Desk_dv.View.Catalogs;

partial class FrmIngredienteReceta
{
    private IContainer? components = null;
    private Label lblTitulo = null!;
    private Label lblDescripcion = null!;
    private Label lblIngrediente = null!;
    private ComboBox cmbIngrediente = null!;
    private Label lblCantidad = null!;
    private NumericUpDown nudCantidad = null!;
    private Label lblNotas = null!;
    private TextBox txtNotas = null!;
    private Label lblAyuda = null!;
    private Panel pnlPie = null!;
    private Button btnCancelar = null!;
    private Button btnAceptar = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components is not null)
            components.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        lblTitulo = new Label();
        lblDescripcion = new Label();
        lblIngrediente = new Label();
        cmbIngrediente = new ComboBox();
        lblCantidad = new Label();
        nudCantidad = new NumericUpDown();
        lblNotas = new Label();
        txtNotas = new TextBox();
        lblAyuda = new Label();
        pnlPie = new Panel();
        btnCancelar = new Button();
        btnAceptar = new Button();
        ((ISupportInitialize)nudCantidad).BeginInit();
        pnlPie.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Century Gothic", 15F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(8, 31, 63);
        lblTitulo.Location = new Point(26, 18);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(198, 23);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Agregar ingrediente";
        // 
        // lblDescripcion
        // 
        lblDescripcion.AutoSize = true;
        lblDescripcion.Font = new Font("Century Gothic", 9F, FontStyle.Regular);
        lblDescripcion.ForeColor = Color.FromArgb(95, 105, 115);
        lblDescripcion.Location = new Point(29, 49);
        lblDescripcion.Name = "lblDescripcion";
        lblDescripcion.Size = new Size(343, 17);
        lblDescripcion.TabIndex = 1;
        lblDescripcion.Text = "Selecciona un ingrediente y define la cantidad por porción.";
        // 
        // lblIngrediente
        // 
        lblIngrediente.AutoSize = true;
        lblIngrediente.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
        lblIngrediente.ForeColor = Color.FromArgb(8, 31, 63);
        lblIngrediente.Location = new Point(29, 82);
        lblIngrediente.Name = "lblIngrediente";
        lblIngrediente.Size = new Size(75, 16);
        lblIngrediente.TabIndex = 2;
        lblIngrediente.Text = "Ingrediente";
        // 
        // cmbIngrediente
        // 
        cmbIngrediente.DropDownStyle = ComboBoxStyle.DropDownList;
        cmbIngrediente.Font = new Font("Century Gothic", 10F);
        cmbIngrediente.FormattingEnabled = true;
        cmbIngrediente.Location = new Point(29, 103);
        cmbIngrediente.Name = "cmbIngrediente";
        cmbIngrediente.Size = new Size(580, 25);
        cmbIngrediente.TabIndex = 3;
        // 
        // lblCantidad
        // 
        lblCantidad.AutoSize = true;
        lblCantidad.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
        lblCantidad.ForeColor = Color.FromArgb(8, 31, 63);
        lblCantidad.Location = new Point(29, 148);
        lblCantidad.Name = "lblCantidad";
        lblCantidad.Size = new Size(123, 16);
        lblCantidad.TabIndex = 4;
        lblCantidad.Text = "Cantidad por porción";
        // 
        // nudCantidad
        // 
        nudCantidad.DecimalPlaces = 4;
        nudCantidad.Font = new Font("Century Gothic", 10F);
        nudCantidad.Increment = 0.1M;
        nudCantidad.Location = new Point(29, 170);
        nudCantidad.Maximum = 99999999.9999M;
        nudCantidad.Minimum = 0.0001M;
        nudCantidad.Name = "nudCantidad";
        nudCantidad.Size = new Size(165, 24);
        nudCantidad.TabIndex = 5;
        nudCantidad.ThousandsSeparator = true;
        nudCantidad.Value = 1M;
        // 
        // lblAyuda
        // 
        lblAyuda.AutoSize = false;
        lblAyuda.Font = new Font("Century Gothic", 8.5F);
        lblAyuda.ForeColor = Color.FromArgb(95, 105, 115);
        lblAyuda.Location = new Point(213, 171);
        lblAyuda.Name = "lblAyuda";
        lblAyuda.Size = new Size(396, 32);
        lblAyuda.TabIndex = 6;
        lblAyuda.Text = "La cantidad se expresa en la unidad base del ingrediente.";
        // 
        // lblNotas
        // 
        lblNotas.AutoSize = true;
        lblNotas.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
        lblNotas.ForeColor = Color.FromArgb(8, 31, 63);
        lblNotas.Location = new Point(29, 216);
        lblNotas.Name = "lblNotas";
        lblNotas.Size = new Size(166, 16);
        lblNotas.TabIndex = 7;
        lblNotas.Text = "Notas de preparación (opcional)";
        // 
        // txtNotas
        // 
        txtNotas.Font = new Font("Century Gothic", 9.5F);
        txtNotas.Location = new Point(29, 238);
        txtNotas.MaxLength = 250;
        txtNotas.Multiline = true;
        txtNotas.Name = "txtNotas";
        txtNotas.ScrollBars = ScrollBars.Vertical;
        txtNotas.Size = new Size(580, 57);
        txtNotas.TabIndex = 8;
        // 
        // pnlPie
        // 
        pnlPie.BackColor = Color.White;
        pnlPie.Controls.Add(btnCancelar);
        pnlPie.Controls.Add(btnAceptar);
        pnlPie.Dock = DockStyle.Bottom;
        pnlPie.Location = new Point(0, 315);
        pnlPie.Name = "pnlPie";
        pnlPie.Size = new Size(640, 65);
        pnlPie.TabIndex = 9;
        // 
        // btnCancelar
        // 
        btnCancelar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnCancelar.BackColor = Color.FromArgb(238, 243, 247);
        btnCancelar.DialogResult = DialogResult.Cancel;
        btnCancelar.FlatAppearance.BorderSize = 0;
        btnCancelar.FlatStyle = FlatStyle.Flat;
        btnCancelar.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
        btnCancelar.ForeColor = Color.FromArgb(8, 31, 63);
        btnCancelar.Location = new Point(356, 14);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new Size(112, 36);
        btnCancelar.TabIndex = 0;
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = false;
        // 
        // btnAceptar
        // 
        btnAceptar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnAceptar.BackColor = Color.FromArgb(8, 126, 164);
        btnAceptar.FlatAppearance.BorderSize = 0;
        btnAceptar.FlatStyle = FlatStyle.Flat;
        btnAceptar.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
        btnAceptar.ForeColor = Color.White;
        btnAceptar.Location = new Point(479, 14);
        btnAceptar.Name = "btnAceptar";
        btnAceptar.Size = new Size(130, 36);
        btnAceptar.TabIndex = 1;
        btnAceptar.Text = "Agregar ingrediente";
        btnAceptar.UseVisualStyleBackColor = false;
        // 
        // FrmIngredienteReceta
        // 
        AcceptButton = btnAceptar;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.White;
        CancelButton = btnCancelar;
        ClientSize = new Size(640, 380);
        Controls.Add(txtNotas);
        Controls.Add(lblNotas);
        Controls.Add(lblAyuda);
        Controls.Add(nudCantidad);
        Controls.Add(lblCantidad);
        Controls.Add(cmbIngrediente);
        Controls.Add(lblIngrediente);
        Controls.Add(lblDescripcion);
        Controls.Add(lblTitulo);
        Controls.Add(pnlPie);
        Font = new Font("Century Gothic", 9F);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmIngredienteReceta";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Ingrediente de receta";
        ((ISupportInitialize)nudCantidad).EndInit();
        pnlPie.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }
}
