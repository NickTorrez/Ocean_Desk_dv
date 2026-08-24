using Ocean_Desk_dv.UI;
using Ocean_Desk_dv.UI.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocean_Desk_dv
{
    public partial class FrmLogin : Form
    {
        private bool passwordVisible = false; // Variable para controlar la visibilidad de la contraseña

        #region Constructor
        public FrmLogin()
        {
            InitializeComponent();
        }
        #endregion

        /// <summary>
        /// Maneja el evento Click del botón de cerrar, cerrando la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        /// <summary>
        /// Maneja el evento Click del botón de cancelar, minimizando la aplicación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Maneja el evento Click del botón de mostrar/ocultar contraseña, alternando la visibilidad de la contraseña y cambiando el texto del botón.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            passwordVisible = !passwordVisible;

            txtPassword.UseSystemPasswordChar = !passwordVisible;


            if (passwordVisible)
            {
                btnShowPassword.Text = "🔒";
            }
            else
            {
                btnShowPassword.Text = "👁";
            }
        }

        /// <summary>
        /// Maneja el evento Click del botón de login, validando los campos de usuario y contraseña, mostrando mensajes de advertencia si están vacíos, y abriendo el formulario principal si ambos campos están completos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                FrmMessageBox.Show(
                "Ingrese su nombre de usuario.",
                "Campo requerido",
                MessageType.Warning);

                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                FrmMessageBox.Show(
                "Ingrese su contraseña.",
                "Campo requerido",
                MessageType.Warning);

                txtPassword.Focus();
                return;
            }

            FrmLoading loading = new FrmLoading(this); // Crear una instancia del formulario de carga
            loading.Show();

            this.Hide();
        }

        /// <summary>
        /// Limpia los campos de usuario y contraseña, y establece el foco en el campo de usuario.
        /// </summary>
        public void LimpiarCampos() // Método público para limpiar los campos de usuario y contraseña
        {
            txtUsername.Clear();
            txtPassword.Clear();
            txtUsername.Focus();
        }
    }
}
