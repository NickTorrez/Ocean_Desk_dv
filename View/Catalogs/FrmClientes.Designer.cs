namespace Ocean_Desk_dv.View.Catalogs
{
    partial class FrmClientes
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
            pnlLista = new Panel();
            pnlDetalles = new Panel();
            pnlAcciones = new Panel();
            pnlResumen = new Panel();
            pnlBusqueda = new Panel();
            txtBuscar = new TextBox();
            chkSoloActivos = new CheckBox();
            btnBuscar = new Button();
            tlpResumen = new TableLayoutPanel();
            pnlCardTotal = new Panel();
            pnlCardActivos = new Panel();
            pnlCardFrecuentes = new Panel();
            lblValorTotal = new Label();
            lblTituloTotal = new Label();
            lblValorActivos = new Label();
            lblTituloActivos = new Label();
            lblValorFrecuentes = new Label();
            lblTituloFrecuentes = new Label();
            pnlLista.SuspendLayout();
            pnlResumen.SuspendLayout();
            pnlBusqueda.SuspendLayout();
            tlpResumen.SuspendLayout();
            pnlCardTotal.SuspendLayout();
            pnlCardActivos.SuspendLayout();
            pnlCardFrecuentes.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLista
            // 
            pnlLista.BackColor = Color.Transparent;
            pnlLista.Controls.Add(pnlResumen);
            pnlLista.Controls.Add(pnlBusqueda);
            pnlLista.Controls.Add(pnlAcciones);
            pnlLista.Controls.Add(pnlDetalles);
            pnlLista.Dock = DockStyle.Fill;
            pnlLista.Location = new Point(0, 0);
            pnlLista.Name = "pnlLista";
            pnlLista.Padding = new Padding(3, 10, 10, 10);
            pnlLista.Size = new Size(922, 783);
            pnlLista.TabIndex = 0;
            // 
            // pnlDetalles
            // 
            pnlDetalles.BackColor = Color.White;
            pnlDetalles.Dock = DockStyle.Right;
            pnlDetalles.Location = new Point(582, 10);
            pnlDetalles.Name = "pnlDetalles";
            pnlDetalles.Padding = new Padding(15, 12, 15, 12);
            pnlDetalles.Size = new Size(330, 763);
            pnlDetalles.TabIndex = 0;
            // 
            // pnlAcciones
            // 
            pnlAcciones.BackColor = Color.White;
            pnlAcciones.Dock = DockStyle.Bottom;
            pnlAcciones.Location = new Point(3, 708);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Padding = new Padding(15, 6, 15, 8);
            pnlAcciones.Size = new Size(579, 65);
            pnlAcciones.TabIndex = 1;
            // 
            // pnlResumen
            // 
            pnlResumen.BackColor = Color.White;
            pnlResumen.Controls.Add(tlpResumen);
            pnlResumen.Dock = DockStyle.Top;
            pnlResumen.Location = new Point(3, 135);
            pnlResumen.Name = "pnlResumen";
            pnlResumen.Padding = new Padding(15, 10, 15, 10);
            pnlResumen.Size = new Size(579, 90);
            pnlResumen.TabIndex = 0;
            // 
            // pnlBusqueda
            // 
            pnlBusqueda.Controls.Add(btnBuscar);
            pnlBusqueda.Controls.Add(chkSoloActivos);
            pnlBusqueda.Controls.Add(txtBuscar);
            pnlBusqueda.Dock = DockStyle.Top;
            pnlBusqueda.Location = new Point(3, 10);
            pnlBusqueda.Name = "pnlBusqueda";
            pnlBusqueda.Size = new Size(579, 125);
            pnlBusqueda.TabIndex = 2;
            // 
            // txtBuscar
            // 
            txtBuscar.BorderStyle = BorderStyle.FixedSingle;
            txtBuscar.ForeColor = Color.FromArgb(8, 31, 63);
            txtBuscar.Location = new Point(15, 22);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "Buscar por nombre, teléfono o correo";
            txtBuscar.Size = new Size(420, 26);
            txtBuscar.TabIndex = 0;
            // 
            // chkSoloActivos
            // 
            chkSoloActivos.AutoSize = true;
            chkSoloActivos.Checked = true;
            chkSoloActivos.CheckState = CheckState.Checked;
            chkSoloActivos.Cursor = Cursors.Hand;
            chkSoloActivos.Location = new Point(455, 23);
            chkSoloActivos.Name = "chkSoloActivos";
            chkSoloActivos.Size = new Size(119, 24);
            chkSoloActivos.TabIndex = 1;
            chkSoloActivos.Text = "Solo activos";
            chkSoloActivos.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.BackColor = Color.FromArgb(8, 126, 164);
            btnBuscar.Cursor = Cursors.Hand;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Location = new Point(795, 15);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(130, 40);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "BUSCAR";
            btnBuscar.UseVisualStyleBackColor = false;
            // 
            // tlpResumen
            // 
            tlpResumen.ColumnCount = 2;
            tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpResumen.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpResumen.Controls.Add(pnlCardTotal, 0, 0);
            tlpResumen.Controls.Add(pnlCardActivos, 1, 0);
            tlpResumen.Controls.Add(pnlCardFrecuentes, 2, 0);
            tlpResumen.Dock = DockStyle.Left;
            tlpResumen.Location = new Point(15, 10);
            tlpResumen.Margin = new Padding(3, 0, 0, 0);
            tlpResumen.Name = "tlpResumen";
            tlpResumen.RowCount = 1;
            tlpResumen.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpResumen.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpResumen.Size = new Size(250, 70);
            tlpResumen.TabIndex = 0;
            // 
            // pnlCardTotal
            // 
            pnlCardTotal.Controls.Add(lblTituloTotal);
            pnlCardTotal.Controls.Add(lblValorTotal);
            pnlCardTotal.Dock = DockStyle.Fill;
            pnlCardTotal.Location = new Point(0, 10);
            pnlCardTotal.Margin = new Padding(0, 10, 10, 3);
            pnlCardTotal.Name = "pnlCardTotal";
            pnlCardTotal.Padding = new Padding(15, 8, 15, 8);
            pnlCardTotal.Size = new Size(115, 37);
            pnlCardTotal.TabIndex = 0;
            // 
            // pnlCardActivos
            // 
            pnlCardActivos.Controls.Add(lblTituloActivos);
            pnlCardActivos.Controls.Add(lblValorActivos);
            pnlCardActivos.Location = new Point(125, 10);
            pnlCardActivos.Margin = new Padding(0, 10, 10, 0);
            pnlCardActivos.Name = "pnlCardActivos";
            pnlCardActivos.Size = new Size(115, 40);
            pnlCardActivos.TabIndex = 1;
            // 
            // pnlCardFrecuentes
            // 
            pnlCardFrecuentes.Controls.Add(lblTituloFrecuentes);
            pnlCardFrecuentes.Controls.Add(lblValorFrecuentes);
            pnlCardFrecuentes.Location = new Point(3, 53);
            pnlCardFrecuentes.Name = "pnlCardFrecuentes";
            pnlCardFrecuentes.Size = new Size(119, 14);
            pnlCardFrecuentes.TabIndex = 2;
            // 
            // lblValorTotal
            // 
            lblValorTotal.AutoSize = true;
            lblValorTotal.Dock = DockStyle.Fill;
            lblValorTotal.Font = new Font("Century Gothic", 12F);
            lblValorTotal.Location = new Point(15, 8);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(21, 23);
            lblValorTotal.TabIndex = 0;
            lblValorTotal.Text = "0";
            lblValorTotal.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTituloTotal
            // 
            lblTituloTotal.Dock = DockStyle.Top;
            lblTituloTotal.ForeColor = Color.FromArgb(111, 119, 128);
            lblTituloTotal.Location = new Point(15, 8);
            lblTituloTotal.Name = "lblTituloTotal";
            lblTituloTotal.Size = new Size(85, 24);
            lblTituloTotal.TabIndex = 1;
            lblTituloTotal.Text = "Clientes registrados";
            // 
            // lblValorActivos
            // 
            lblValorActivos.AutoSize = true;
            lblValorActivos.Location = new Point(0, 0);
            lblValorActivos.Name = "lblValorActivos";
            lblValorActivos.Size = new Size(53, 20);
            lblValorActivos.TabIndex = 0;
            lblValorActivos.Text = "label1";
            // 
            // lblTituloActivos
            // 
            lblTituloActivos.Dock = DockStyle.Top;
            lblTituloActivos.ForeColor = Color.FromArgb(111, 119, 128);
            lblTituloActivos.Location = new Point(0, 0);
            lblTituloActivos.Name = "lblTituloActivos";
            lblTituloActivos.Size = new Size(115, 24);
            lblTituloActivos.TabIndex = 1;
            lblTituloActivos.Text = "Clientes activos";
            // 
            // lblValorFrecuentes
            // 
            lblValorFrecuentes.AutoSize = true;
            lblValorFrecuentes.Location = new Point(0, 0);
            lblValorFrecuentes.Name = "lblValorFrecuentes";
            lblValorFrecuentes.Size = new Size(53, 20);
            lblValorFrecuentes.TabIndex = 0;
            lblValorFrecuentes.Text = "label1";
            // 
            // lblTituloFrecuentes
            // 
            lblTituloFrecuentes.AutoSize = true;
            lblTituloFrecuentes.ForeColor = Color.FromArgb(111, 119, 128);
            lblTituloFrecuentes.Location = new Point(0, 0);
            lblTituloFrecuentes.Name = "lblTituloFrecuentes";
            lblTituloFrecuentes.Size = new Size(150, 20);
            lblTituloFrecuentes.TabIndex = 1;
            lblTituloFrecuentes.Text = "Clientes frecuentes";
            // 
            // FrmClientes
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(922, 783);
            Controls.Add(pnlLista);
            Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(8, 31, 63);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmClientes";
            Text = "FrmClientes";
            pnlLista.ResumeLayout(false);
            pnlResumen.ResumeLayout(false);
            pnlBusqueda.ResumeLayout(false);
            pnlBusqueda.PerformLayout();
            tlpResumen.ResumeLayout(false);
            pnlCardTotal.ResumeLayout(false);
            pnlCardTotal.PerformLayout();
            pnlCardActivos.ResumeLayout(false);
            pnlCardActivos.PerformLayout();
            pnlCardFrecuentes.ResumeLayout(false);
            pnlCardFrecuentes.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLista;
        private Panel pnlAcciones;
        private Panel pnlDetalles;
        private Panel pnlResumen;
        private Panel pnlBusqueda;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private CheckBox chkSoloActivos;
        private TableLayoutPanel tlpResumen;
        private Panel pnlCardTotal;
        private Panel pnlCardActivos;
        private Label lblValorTotal;
        private Panel pnlCardFrecuentes;
        private Label lblTituloTotal;
        private Label lblTituloActivos;
        private Label lblValorActivos;
        private Label lblTituloFrecuentes;
        private Label lblValorFrecuentes;
    }
}