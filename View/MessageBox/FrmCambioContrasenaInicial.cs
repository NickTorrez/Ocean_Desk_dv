using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.Services.Interfaces_Services;
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

namespace Ocean_Desk_dv.View.MessageBox
{
    public partial class FrmCambioContrasenaInicial : Form
    {
        private enum ModoFormulario
        {
            SinConfigurar,
            CambioObligatorio,
            Recuperacion
        }

        private ModoFormulario _modo = ModoFormulario.SinConfigurar;

        private IAuthenticationService? _authenticationService;
        private IPasswordRecoveryService? _passwordRecoveryService;

        private int _userId;
        private string _email = string.Empty;
        private string _codigo = string.Empty;

        private bool _contrasenaVisible;
        private bool _confirmacionVisible;
        private bool _procesando;

        // Permite que FrmLogin vuelva a autenticar al usuario
        // después de completar el cambio obligatorio.
        public string NuevaContrasenaEstablecida { get; private set; }
            = string.Empty;

        public FrmCambioContrasenaInicial()
        {
            InitializeComponent();

            ConfigurarEventos();
            PrepararCampos();
        }

        /// <summary>
        /// Configura el formulario para el cambio obligatorio
        /// de una contraseña temporal.
        /// </summary>
        public void ConfigurarCambioObligatorio(
            int userId,
            string nombreCompleto,
            IAuthenticationService servicio)
        {
            if (userId <= 0)
                throw new ArgumentException("El identificador del usuario no es válido.");

            _authenticationService = servicio
                ?? throw new ArgumentNullException(nameof(servicio));

            _passwordRecoveryService = null;

            _userId = userId;
            _modo = ModoFormulario.CambioObligatorio;

            lblTitulo.Text = "Cambio de contraseña";
            lblSubtitulo.Text = "Ocean Desk · Configuración inicial";
            lblInstruccion.Text = "Establezca su contraseña personal";

            lblNombreUsuario.Text =
                $"Hola, {nombreCompleto}. Para continuar, debes reemplazar tu contraseña temporal.";

            btnGuardar.Text = "GUARDAR CONTRASEÑA";
            btnCancelar.Text = "CANCELAR";

            LimpiarCampos();
        }

        /// <summary>
        /// Configura el formulario para restablecer una contraseña
        /// después de verificar el código enviado al correo.
        /// </summary>
        public void ConfigurarRecuperacion(
            string email,
            string codigo,
            IPasswordRecoveryService servicio)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("El correo electrónico no es válido.");

            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("El código de recuperación no es válido.");

            _passwordRecoveryService = servicio
                ?? throw new ArgumentNullException(nameof(servicio));

            _authenticationService = null;

            _email = email.Trim();
            _codigo = codigo.Trim();

            _modo = ModoFormulario.Recuperacion;

            lblTitulo.Text = "Restablecer contraseña";
            lblSubtitulo.Text = "Ocean Desk · Recuperación de cuenta";
            lblInstruccion.Text = "Establezca una nueva contraseña";

            lblNombreUsuario.Text =
                $"El código enviado a {_email} fue verificado. Ahora puedes establecer una nueva contraseña.";

            btnGuardar.Text = "RESTABLECER CONTRASEÑA";
            btnCancelar.Text = "CANCELAR";

            LimpiarCampos();
        }

        private void ConfigurarEventos()
        {
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnClose.Click += btnClose_Click;

            btnMostrarContrasena.Click += btnMostrarContrasena_Click;
            btnMostrarConfirmacion.Click += btnMostrarConfirmacion_Click;
        }

        private void PrepararCampos()
        {
            txtNuevaContrasena.MaxLength = 128;
            txtConfirmarContrasena.MaxLength = 128;

            txtNuevaContrasena.UseSystemPasswordChar = true;
            txtConfirmarContrasena.UseSystemPasswordChar = true;

            btnMostrarContrasena.Text = "👁";
            btnMostrarConfirmacion.Text = "👁";

            AcceptButton = btnGuardar;
            CancelButton = btnCancelar;
        }

        private void btnGuardar_Click(object? sender, EventArgs e)
        {
            if (_procesando)
                return;

            if (_modo == ModoFormulario.SinConfigurar)
            {
                FrmMessageBox.Show(
                 "El formulario no ha sido configurado correctamente.",
                 "Ocean Desk",
                 MessageType.Warning,
                 this);

                return;
            }

            string nuevaContrasena = txtNuevaContrasena.Text;
            string confirmacion = txtConfirmarContrasena.Text;

            _procesando = true;
            btnGuardar.Enabled = false;

            try
            {
                ResultadoOperacionDto resultado;

                if (_modo == ModoFormulario.CambioObligatorio)
                {
                    resultado = _authenticationService!
                        .CambiarContrasenaInicial(
                            _userId,
                            nuevaContrasena,
                            confirmacion);
                }
                else
                {
                    resultado = _passwordRecoveryService!
                        .RestablecerContrasena(
                            _email,
                            _codigo,
                            nuevaContrasena,
                            confirmacion);
                }

                if (!resultado.Exito)
                {
                    FrmMessageBox.Show(
                        resultado.Mensaje,
                        "No se pudo actualizar la contraseña",
                        MessageType.Warning,
                        this);

                    return;
                }

                NuevaContrasenaEstablecida = nuevaContrasena;

                FrmMessageBox.Show(
                     resultado.Mensaje,
                     "Ocean Desk",
                     MessageType.Information,
                     this);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"Error al cambiar la contraseña: {ex}");

                FrmMessageBox.Show(
                    "Ocurrió un error al actualizar la contraseña. Inténtelo nuevamente.",
                    "Error",
                    MessageType.Error,
                    this);
            }
            finally
            {
                _procesando = false;

                if (!IsDisposed)
                    btnGuardar.Enabled = true;
            }
        }

        private void btnMostrarContrasena_Click(
            object? sender,
            EventArgs e)
        {
            _contrasenaVisible = !_contrasenaVisible;

            txtNuevaContrasena.UseSystemPasswordChar =
                !_contrasenaVisible;

            btnMostrarContrasena.Text =
                _contrasenaVisible ? "🔒" : "👁";
        }

        private void btnMostrarConfirmacion_Click(
            object? sender,
            EventArgs e)
        {
            _confirmacionVisible = !_confirmacionVisible;

            txtConfirmarContrasena.UseSystemPasswordChar =
                !_confirmacionVisible;

            btnMostrarConfirmacion.Text =
                _confirmacionVisible ? "🔒" : "👁";
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnClose_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LimpiarCampos()
        {
            txtNuevaContrasena.Clear();
            txtConfirmarContrasena.Clear();

            _contrasenaVisible = false;
            _confirmacionVisible = false;

            txtNuevaContrasena.UseSystemPasswordChar = true;
            txtConfirmarContrasena.UseSystemPasswordChar = true;

            btnMostrarContrasena.Text = "👁";
            btnMostrarConfirmacion.Text = "👁";

            txtNuevaContrasena.Focus();
        }
    }
}
