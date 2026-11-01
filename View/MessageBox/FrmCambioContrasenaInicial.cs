using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocean_Desk_dv.View.MessageBox
{
    public partial class FrmCambioContrasenaInicial : Form
    {
        private readonly TextBox txtNuevaContrasena;
        private readonly TextBox txtConfirmacionContrasena;

        public string NuevaContrasena => txtNuevaContrasena.Text;

        public string ConfirmacionContrasena =>
            txtConfirmacionContrasena.Text;

        public FrmCambioContrasenaInicial(string nombreCompleto)
        {
            Text = "Cambio obligatorio de contraseña";
            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowIcon = false;
            ShowInTaskbar = false;
            BackColor = Color.White;
            ClientSize = new Size(510, 340);
            Font = new Font("Century Gothic", 9.5F);

            Label lblTitulo = new()
            {
                Text = "Proteja su cuenta",
                Font = new Font("Century Gothic", 17F, FontStyle.Bold),
                ForeColor = Color.FromArgb(18, 48, 71),
                AutoSize = false,
                Location = new Point(35, 25),
                Size = new Size(440, 35)
            };

            Label lblUsuario = new()
            {
                Text = $"Bienvenido/a, {nombreCompleto}. Debe establecer una contraseña personal.",
                ForeColor = Color.DimGray,
                AutoSize = false,
                Location = new Point(37, 67),
                Size = new Size(440, 40)
            };

            Label lblNueva = new()
            {
                Text = "Nueva contraseña",
                Location = new Point(38, 120),
                AutoSize = true
            };

            txtNuevaContrasena = new TextBox
            {
                Location = new Point(38, 145),
                Size = new Size(430, 30),
                UseSystemPasswordChar = true,
                MaxLength = 128,
                Font = new Font("Century Gothic", 11F)
            };

            Label lblConfirmacion = new()
            {
                Text = "Confirmar nueva contraseña",
                Location = new Point(38, 185),
                AutoSize = true
            };

            txtConfirmacionContrasena = new TextBox
            {
                Location = new Point(38, 210),
                Size = new Size(430, 30),
                UseSystemPasswordChar = true,
                MaxLength = 128,
                Font = new Font("Century Gothic", 11F)
            };

            Label lblReglas = new()
            {
                Text = "Mínimo 12 caracteres: mayúsculas, minúsculas, números y símbolos.",
                Location = new Point(38, 248),
                Size = new Size(435, 32),
                ForeColor = Color.DimGray
            };

            Button btnGuardar = new()
            {
                Text = "Guardar contraseña",
                Location = new Point(260, 290),
                Size = new Size(208, 35),
                BackColor = Color.DarkBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.None
            };

            Button btnCancelar = new()
            {
                Text = "Cancelar",
                Location = new Point(150, 290),
                Size = new Size(100, 35),
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.Cancel
            };

            btnGuardar.Click += BtnGuardar_Click;

            Controls.AddRange(
            [
                lblTitulo,
            lblUsuario,
            lblNueva,
            txtNuevaContrasena,
            lblConfirmacion,
            txtConfirmacionContrasena,
            lblReglas,
            btnCancelar,
            btnGuardar
            ]);

            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NuevaContrasena) ||
                string.IsNullOrWhiteSpace(ConfirmacionContrasena))
            {
                MessageBox.Show(
                    "Complete ambos campos.",
                    "Datos requeridos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (!string.Equals(
                NuevaContrasena,
                ConfirmacionContrasena,
                StringComparison.Ordinal))
            {
                MessageBox.Show(
                    "Las contraseñas no coinciden.",
                    "Verificación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtConfirmacionContrasena.Clear();
                txtConfirmacionContrasena.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
