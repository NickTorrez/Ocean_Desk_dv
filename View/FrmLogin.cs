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
        private bool _cargandoPreferencias;

        private const string CarpetaPreferencias = "OceanDesk";
        private const string ArchivoUsuarioRecordado = "remembered-user.txt";


        #region Constructor
        public FrmLogin()
        {
            InitializeComponent();

            ConfigurarEventosAdicionales();
            CargarUsuarioRecordado();
        }

        private void ConfigurarEventosAdicionales()
        {
            // El diseñador ya conecta los eventos de los botones existentes.
            // Aquí conectamos únicamente los que todavía no están asociados.

            chkRemember.CheckedChanged += chkRemember_CheckedChanged;

            AcceptButton = btnLogin;
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

        #endregion

        #region Autenticación y validación
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

            // Validación del nombre de usuario.
            if (string.IsNullOrWhiteSpace(username))
            {
                FrmMessageBox.Show(
                    "Ingrese su nombre de usuario.",
                    "Campo requerido",
                    MessageType.Warning,
                    this);

                txtUsername.Focus();
                return;
            }

            // Validación de contraseña.
            if (string.IsNullOrEmpty(password))
            {
                FrmMessageBox.Show(
                    "Ingrese su contraseña.",
                    "Campo requerido",
                    MessageType.Warning,
                    this);

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
                    // 1. Autenticar las credenciales.
                    ResultadoAutenticacionDto resultado =
                        servicio.Autenticar(username, password);

                    if (!resultado.Exito ||
                        resultado.Usuario is null)
                    {
                        string titulo = resultado.CuentaBloqueada
                            ? "Cuenta bloqueada"
                            : "Acceso denegado";

                        FrmMessageBox.Show(
                            resultado.Mensaje,
                            titulo,
                            MessageType.Warning,
                            this);

                        txtPassword.Clear();
                        txtPassword.Focus();

                        return;
                    }

                    usuarioAutenticado = resultado.Usuario;

                    // 2. Comprobar si existe un cambio obligatorio.
                    if (usuarioAutenticado.MustChangePassword)
                    {
                        using FrmCambioContrasenaInicial ventanaCambio =
                            new FrmCambioContrasenaInicial();

                        // Configurar el formulario en modo de cambio obligatorio.
                        ventanaCambio.ConfigurarCambioObligatorio(
                            usuarioAutenticado.UserId,
                            usuarioAutenticado.NombreCompleto,
                            servicio);

                        // El usuario debe completar el cambio para continuar.
                        DialogResult resultadoCambio =
                            ventanaCambio.ShowDialog(this);

                        if (resultadoCambio != DialogResult.OK)
                        {
                            // No se permite continuar sin cambiar la contraseña.
                            txtPassword.Clear();
                            txtPassword.Focus();

                            return;
                        }

                        // 3. Autenticar nuevamente con la contraseña personal.
                        // Esto permite obtener la identidad actualizada
                        // y los permisos correspondientes al usuario.
                        ResultadoAutenticacionDto nuevaAutenticacion =
                            servicio.Autenticar(
                                username,
                                ventanaCambio.NuevaContrasenaEstablecida);

                        if (!nuevaAutenticacion.Exito ||
                            nuevaAutenticacion.Usuario is null)
                        {
                            FrmMessageBox.Show(
                                "La contraseña fue actualizada, pero no fue posible " +
                                "establecer la sesión. Inicie sesión nuevamente.",
                                "Error de autenticación",
                                MessageType.Error,
                                this);

                            txtPassword.Clear();
                            txtPassword.Focus();

                            return;
                        }

                        usuarioAutenticado = nuevaAutenticacion.Usuario;
                    }
                }

                // 4. Guardar solamente el nombre de usuario si
                // la opción Recordarme está activada.
                GuardarUsuarioRecordado(username);

                // 5. Entregar la identidad autenticada al formulario de carga.
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
                    MessageType.Error,
                    this);
            }
            finally
            {
                _procesandoLogin = false;

                if (!IsDisposed)
                    btnLogin.Enabled = true;
            }

        }
        #endregion

        #region Recuperación de contraseña
        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_procesandoLogin)
                return;

            using FrmRecuperarContrasena formularioRecuperacion =
                new FrmRecuperarContrasena();

            DialogResult resultado =
                formularioRecuperacion.ShowDialog(this);

            if (resultado == DialogResult.OK)
            {
                // La contraseña fue restablecida correctamente.
                // Se limpia el campo para que el usuario ingrese
                // sus nuevas credenciales.
                txtPassword.Clear();
                txtPassword.Focus();
            }
        }
        #endregion

        #region Recordar usuario
        private static string ObtenerRutaUsuarioRecordado()
        {
            string carpetaLocal = Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData);

            return Path.Combine(
                carpetaLocal,
                CarpetaPreferencias,
                ArchivoUsuarioRecordado);
        }

        /// <summary>
        /// Recupera el último nombre de usuario guardado.
        /// No carga ni almacena contraseñas.
        /// </summary>
        private void CargarUsuarioRecordado()
        {
            _cargandoPreferencias = true;

            try
            {
                string ruta = ObtenerRutaUsuarioRecordado();

                if (!File.Exists(ruta))
                    return;

                string usuarioGuardado =
                    File.ReadAllText(ruta, Encoding.UTF8).Trim();

                if (string.IsNullOrWhiteSpace(usuarioGuardado))
                {
                    File.Delete(ruta);
                    return;
                }

                txtUsername.Text = usuarioGuardado;
                chkRemember.Checked = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"No fue posible cargar el usuario recordado: {ex}");

                txtUsername.Clear();
                chkRemember.Checked = false;
            }
            finally
            {
                _cargandoPreferencias = false;
            }
        }

        /// <summary>
        /// Guarda el usuario después de una autenticación exitosa.
        /// </summary>
        private void GuardarUsuarioRecordado(string username)
        {
            try
            {
                if (!chkRemember.Checked)
                {
                    EliminarUsuarioRecordado();
                    return;
                }

                if (string.IsNullOrWhiteSpace(username))
                    return;

                string ruta = ObtenerRutaUsuarioRecordado();
                string carpeta = Path.GetDirectoryName(ruta)!;

                Directory.CreateDirectory(carpeta);

                File.WriteAllText(
                    ruta,
                    username.Trim(),
                    new UTF8Encoding(false));
            }
            catch (Exception ex)
            {
                // Un fallo al recordar el usuario no debe impedir
                // que la autenticación continúe.
                Debug.WriteLine(
                    $"No fue posible guardar el usuario recordado: {ex}");
            }
        }

        /// <summary>
        /// Elimina el nombre de usuario previamente almacenado.
        /// </summary>
        private void EliminarUsuarioRecordado()
        {
            try
            {
                string ruta = ObtenerRutaUsuarioRecordado();

                if (File.Exists(ruta))
                    File.Delete(ruta);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"No fue posible eliminar el usuario recordado: {ex}");
            }
        }

        private void chkRemember_CheckedChanged(
            object sender,
            EventArgs e)
        {
            if (_cargandoPreferencias)
                return;

            // Al desmarcar la opción se elimina inmediatamente
            // el nombre de usuario previamente recordado.
            if (!chkRemember.Checked)
                EliminarUsuarioRecordado();
        }

        #endregion

        #region Metodos Auxiliares
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
