using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Services;
using Ocean_Desk_dv.Services.Interfaces_Services;
using Ocean_Desk_dv.UI;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.View.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private bool _procesandoLogin;

        #region Constructor
        public FrmLogin()
        {
            InitializeComponent();
        }
        #endregion

        #region Botones y eventos
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
            if (_procesandoLogin)
                return;

            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username))
            {
                FrmMessageBox.Show(
                    "Ingrese su nombre de usuario.",
                    "Campo requerido",
                    MessageType.Warning);

                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                FrmMessageBox.Show(
                    "Ingrese su contraseña.",
                    "Campo requerido",
                    MessageType.Warning);

                txtPassword.Focus();
                return;
            }

            _procesandoLogin = true;
            btnLogin.Enabled = false;

            try
            {
                UsuarioAutenticadoDto usuarioAutenticado;

                using (IAuthenticationService servicio =
                    OceanDeskRepositoryFactory.CrearAuthenticationService())
                {
                    // 1. Verificar las credenciales en SQL Server.
                    ResultadoAutenticacionDto resultado =
                        servicio.Autenticar(username, password);

                    if (!resultado.Exito || resultado.Usuario is null)
                    {
                        string titulo = resultado.CuentaBloqueada
                            ? "Cuenta bloqueada"
                            : "Acceso denegado";

                        FrmMessageBox.Show(
                            resultado.Mensaje,
                            titulo,
                            MessageType.Warning);

                        txtPassword.Clear();
                        txtPassword.Focus();
                        return;
                    }

                    usuarioAutenticado = resultado.Usuario;

                    // 2. Exigir cambio de contraseña cuando corresponda.
                    if (usuarioAutenticado.MustChangePassword)
                    {
                        using FrmCambioContrasenaInicial ventanaCambio =
                            new FrmCambioContrasenaInicial(
                                usuarioAutenticado.NombreCompleto);

                        if (ventanaCambio.ShowDialog(this) != DialogResult.OK)
                        {
                            // No se permite acceder al menú sin completar
                            // el cambio obligatorio.
                            return;
                        }

                        ResultadoOperacionDto cambio =
                            servicio.CambiarContrasenaInicial(
                                usuarioAutenticado.UserId,
                                ventanaCambio.NuevaContrasena,
                                ventanaCambio.ConfirmacionContrasena);

                        if (!cambio.Exito)
                        {
                            FrmMessageBox.Show(
                                cambio.Mensaje,
                                "No se pudo actualizar la contraseña",
                                MessageType.Warning);

                            return;
                        }

                        // 3. Volver a autenticar para obtener la sesión
                        // actualizada, sin la obligación de cambio.
                        ResultadoAutenticacionDto nuevoResultado =
                            servicio.Autenticar(
                                username,
                                ventanaCambio.NuevaContrasena);

                        if (!nuevoResultado.Exito ||
                            nuevoResultado.Usuario is null)
                        {
                            FrmMessageBox.Show(
                                "La contraseña fue actualizada, pero no fue posible " +
                                "establecer la sesión. Inicie sesión nuevamente.",
                                "Autenticación",
                                MessageType.Error);

                            txtPassword.Clear();
                            return;
                        }

                        usuarioAutenticado = nuevoResultado.Usuario;
                    }
                }

                // 4. Entregar la identidad autenticada al formulario de carga.
                FrmLoading loading = new FrmLoading(
                    this,
                    usuarioAutenticado);

                loading.Show();
                Hide();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"Error durante la autenticación: {ex}");

                FrmMessageBox.Show(
                    "No fue posible completar el inicio de sesión. " +
                    "Compruebe la conexión con la base de datos e inténtelo nuevamente.",
                    "Error de autenticación",
                    MessageType.Error);
            }
            finally
            {
                _procesandoLogin = false;

                if (!IsDisposed)
                    btnLogin.Enabled = true;
            }
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
        #endregion
    }
}
