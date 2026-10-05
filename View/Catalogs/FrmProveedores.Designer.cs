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
            pnlBarraProveedores = new Panel();
            pnlContenido = new Panel();
            SuspendLayout();
            // 
            // pnlBarraProveedores
            // 
            pnlBarraProveedores.Dock = DockStyle.Top;
            pnlBarraProveedores.Location = new Point(0, 0);
            pnlBarraProveedores.Name = "pnlBarraProveedores";
            pnlBarraProveedores.Padding = new Padding(12, 8, 12, 8);
            pnlBarraProveedores.Size = new Size(922, 98);
            pnlBarraProveedores.TabIndex = 0;
            // 
            // pnlContenido
            // 
            pnlContenido.Dock = DockStyle.Fill;
            pnlContenido.Location = new Point(0, 98);
            pnlContenido.Name = "pnlContenido";
            pnlContenido.Padding = new Padding(3, 12, 3, 10);
            pnlContenido.Size = new Size(922, 685);
            pnlContenido.TabIndex = 1;
            // 
            // FrmProveedores
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(922, 783);
            Controls.Add(pnlContenido);
            Controls.Add(pnlBarraProveedores);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmProveedores";
            Text = "FrmProveedores";
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBarraProveedores;
        private Panel pnlContenido;
    }
}