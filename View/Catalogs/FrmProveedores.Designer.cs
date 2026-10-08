namespace Ocean_Desk_dv.View.Catalogs
{
    partial class FrmProveedores
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
            PnlProveedores = new Panel();
            btnNuevaCompra = new Button();
            btnEditarProveedor = new Button();
            btnNuevoProveedor = new Button();
            txtBuscarProveedor = new TextBox();
            pnlContenido = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            PnlDatos = new Panel();
            tabControl1 = new TabControl();
            TpProveedores = new TabPage();
            djvCompras = new DataGridView();
            tabPage2 = new TabPage();
            PnlProveedores.SuspendLayout();
            pnlContenido.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            TpProveedores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)djvCompras).BeginInit();
            SuspendLayout();
            // 
            // PnlProveedores
            // 
            PnlProveedores.BackColor = Color.FromArgb(245, 247, 250);
            PnlProveedores.Controls.Add(btnNuevaCompra);
            PnlProveedores.Controls.Add(btnEditarProveedor);
            PnlProveedores.Controls.Add(btnNuevoProveedor);
            PnlProveedores.Controls.Add(txtBuscarProveedor);
            PnlProveedores.Dock = DockStyle.Top;
            PnlProveedores.Location = new Point(0, 0);
            PnlProveedores.Name = "PnlProveedores";
            PnlProveedores.Padding = new Padding(12, 8, 12, 8);
            PnlProveedores.Size = new Size(922, 78);
            PnlProveedores.TabIndex = 0;
            // 
            // btnNuevaCompra
            // 
            btnNuevaCompra.BackColor = Color.FromArgb(8, 231, 164);
            btnNuevaCompra.FlatAppearance.BorderSize = 0;
            btnNuevaCompra.FlatStyle = FlatStyle.Flat;
            btnNuevaCompra.ForeColor = Color.White;
            btnNuevaCompra.Location = new Point(496, 41);
            btnNuevaCompra.Name = "btnNuevaCompra";
            btnNuevaCompra.Size = new Size(121, 29);
            btnNuevaCompra.TabIndex = 3;
            btnNuevaCompra.Text = "Nueva Compra";
            btnNuevaCompra.UseVisualStyleBackColor = false;
            // 
            // btnEditarProveedor
            // 
            btnEditarProveedor.BackColor = Color.FromArgb(238, 247, 243);
            btnEditarProveedor.FlatStyle = FlatStyle.Flat;
            btnEditarProveedor.ForeColor = Color.FromArgb(8, 31, 63);
            btnEditarProveedor.Location = new Point(308, 42);
            btnEditarProveedor.Name = "btnEditarProveedor";
            btnEditarProveedor.Size = new Size(137, 29);
            btnEditarProveedor.TabIndex = 2;
            btnEditarProveedor.Text = "Editar Proveedor";
            btnEditarProveedor.UseVisualStyleBackColor = false;
            // 
            // btnNuevoProveedor
            // 
            btnNuevoProveedor.BackColor = Color.FromArgb(8, 126, 164);
            btnNuevoProveedor.FlatAppearance.BorderSize = 0;
            btnNuevoProveedor.FlatStyle = FlatStyle.Flat;
            btnNuevoProveedor.ForeColor = Color.White;
            btnNuevoProveedor.Location = new Point(125, 42);
            btnNuevoProveedor.Name = "btnNuevoProveedor";
            btnNuevoProveedor.Size = new Size(137, 29);
            btnNuevoProveedor.TabIndex = 1;
            btnNuevoProveedor.Text = "Nuevo Proveedor";
            btnNuevoProveedor.UseVisualStyleBackColor = false;
            // 
            // txtBuscarProveedor
            // 
            txtBuscarProveedor.BorderStyle = BorderStyle.None;
            txtBuscarProveedor.Dock = DockStyle.Fill;
            txtBuscarProveedor.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscarProveedor.Location = new Point(12, 8);
            txtBuscarProveedor.MaxLength = 150;
            txtBuscarProveedor.Name = "txtBuscarProveedor";
            txtBuscarProveedor.Size = new Size(898, 21);
            txtBuscarProveedor.TabIndex = 0;
            txtBuscarProveedor.Text = "Buscar Proveedor";
            // 
            // pnlContenido
            // 
            pnlContenido.Controls.Add(tableLayoutPanel1);
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(0, 78);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Padding = new Padding(3, 12, 3, 10);
            pnlContenido.Size = new Size(922, 705);
            pnlContenido.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64F));
            tableLayoutPanel1.Controls.Add(PnlDatos, 1, 0);
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(916, 683);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // PnlDatos
            // 
            PnlDatos.Dock = DockStyle.Top;
            PnlDatos.Location = new Point(332, 3);
            PnlDatos.Name = "PnlDatos";
            PnlDatos.Padding = new Padding(18, 0, 0, 0);
            PnlDatos.Size = new Size(581, 125);
            PnlDatos.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(TpProveedores);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(323, 677);
            tabControl1.TabIndex = 1;
            // 
            // TpProveedores
            // 
            TpProveedores.AccessibleDescription = "";
            TpProveedores.AccessibleName = "";
            TpProveedores.BackColor = Color.Transparent;
            TpProveedores.Controls.Add(djvCompras);
            TpProveedores.Location = new Point(4, 29);
            TpProveedores.Name = "TpProveedores";
            TpProveedores.Padding = new Padding(3);
            TpProveedores.Size = new Size(315, 644);
            TpProveedores.TabIndex = 0;
            TpProveedores.Text = "TpProveedores";
            // 
            // djvCompras
            // 
            djvCompras.AllowUserToAddRows = false;
            djvCompras.AllowUserToDeleteRows = false;
            djvCompras.AllowUserToResizeColumns = false;
            djvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            djvCompras.BorderStyle = BorderStyle.None;
            djvCompras.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            djvCompras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 15, 255, 255);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            djvCompras.DefaultCellStyle = dataGridViewCellStyle1;
            djvCompras.Dock = DockStyle.Fill;
            djvCompras.EnableHeadersVisualStyles = false;
            djvCompras.GridColor = Color.FromArgb(230, 234, 238);
            djvCompras.Location = new Point(3, 3);
            djvCompras.MultiSelect = false;
            djvCompras.Name = "djvCompras";
            djvCompras.RowHeadersVisible = false;
            djvCompras.RowHeadersWidth = 51;
            djvCompras.RowTemplate.Height = 38;
            djvCompras.ScrollBars = ScrollBars.None;
            djvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            djvCompras.Size = new Size(309, 638);
            djvCompras.TabIndex = 0;
            djvCompras.CellContentClick += djvCompras_CellContentClick;
            // 
            // tabPage2
            // 
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(315, 644);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "TpComprasAsociadas";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // FrmProveedores
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(922, 783);
            Controls.Add(pnlContenido);
            Controls.Add(PnlProveedores);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmProveedores";
            Text = "FrmProveedores";
            PnlProveedores.ResumeLayout(false);
            PnlProveedores.PerformLayout();
            pnlContenido.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            TpProveedores.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)djvCompras).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PnlProveedores;
        private Panel pnlContenido;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel PnlDatos;
        private TabControl tabControl1;
        private TabPage TpProveedores;
        private TabPage tabPage2;
        private Button btnNuevaCompra;
        private Button btnEditarProveedor;
        private Button btnNuevoProveedor;
        private TextBox txt;
        private TextBox txtBuscarProveedor;
        private DataGridView djvCompras;
    }
}