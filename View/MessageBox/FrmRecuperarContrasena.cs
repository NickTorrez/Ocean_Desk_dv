using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Services;
using Ocean_Desk_dv.Services.Interfaces_Services;
using Ocean_Desk_dv.UI.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocean_Desk_dv.View.MessageBox
{
    public partial class FrmRecuperarContrasena : Form
    {
        private const int LongitudCodigo = 8;
        private const int SegundosEntreEnvios = 60;

        private readonly System.Windows.Forms.Timer _temporizadorReenvio =
            new System.Windows.Forms.Timer
            {
                Interval = 1000
            };

        private IPasswordRecoveryService? _servicioRecuperacion;

        private string _correoActual = string.Empty;

        private int _anchoFormulario;
        private int _alturaPanelVerificacion;

        private DateTime _reenvioDisponibleUtc;

        private bool _etapaVerificacion;
        private bool _procesando;

        public FrmRecuperarContrasena()
        {
            InitializeComponent();

            // Capturar las dimensiones originales antes de reducir
            // la ventana a la primera etapa.
            _anchoFormulario = ClientSize.Width;

            pnlContenido.PerformLayout();

            _alturaPanelVerificacion = pnlVerificarCodigo.Height;

            if (_alturaPanelVerificacion <= 0)
            {
                throw new InvalidOperationException(
                    "No fue posible obtener la altura del panel de verificación.");
            }

            ConfigurarControles();
            ConfigurarEventos();
            ConfigurarTemporizador();

            ConfigurarEtapaInicial();

            FormClosed += FrmRecuperarContrasena_FormClosed;
        }

        #region Configuración inicial

        private void ConfigurarControles()
        {
            txtCorreo.MaxLength = 150;
            txtCodigo.MaxLength = LongitudCodigo;

            txtCodigo.TextAlign = HorizontalAlignment.Center;

            btnReenviarCodigo.Enabled = false;

            AcceptButton = btnEnviarCodigo;
            CancelButton = btnClose;
        }

        private void ConfigurarEventos()
        {
            btnClose.Click += btnClose_Click;

            btnEnviarCodigo.Click += btnEnviarCodigo_Click;
            btnVerificarCodigo.Click += btnVerificarCodigo_Click;
            btnReenviarCodigo.Click += btnReenviarCodigo_Click;
            btnVolverCorreo.Click += btnVolverCorreo_Click;

            txtCodigo.TextChanged += txtCodigo_TextChanged;
        }

        private void ConfigurarTemporizador()
        {
            _temporizadorReenvio.Tick +=
                TemporizadorReenvio_Tick;
        }

        private void ConfigurarEtapaInicial()
        {
            _etapaVerificacion = false;

            pnlSolicitarCodigo.Visible = true;
            pnlVerificarCodigo.Visible = false;

            txtCorreo.Enabled = true;
            txtCodigo.Clear();

            btnEnviarCodigo.Enabled = true;
            btnReenviarCodigo.Enabled = false;

            lblMensajeCodigo.Text = "Vigencia limitada";

            AcceptButton = btnEnviarCodigo;

            pnlContenido.PerformLayout();

            // La ventana comienza ajustada únicamente al primer panel.
            AjustarTamanoVentana(incluirPanelVerificacion: false);
        }

        #endregion

        #region Redimensionamiento del formulario

        /// <summary>
        /// Ajusta la altura de la ventana según los paneles visibles.
        /// Conserva el ancho original y mantiene centrada la ventana.
        /// </summary>
        private void AjustarTamanoVentana(
            bool incluirPanelVerificacion)
        {
            bool ventanaVisible = Visible && IsHandleCreated;

            // Guardar el centro actual antes de modificar las dimensiones.
            int centroX = Left + Width / 2;
            int centroY = Top + Height / 2;

            // Altura del contenido:
            // Padding + panel superior.
            int alturaContenido =
                pnlContenido.Padding.Vertical +
                pnlSolicitarCodigo.Height;

            // Si la segunda etapa está activa, sumar su altura
            // de diseño. El panel se encuentra configurado como Dock Fill.
            if (incluirPanelVerificacion)
            {
                alturaContenido += _alturaPanelVerificacion;
            }

            // Altura total = encabezado + contenido.
            int nuevaAltura =
                pnlHeader.Height + alturaContenido;

            ClientSize = new System.Drawing.Size(
                _anchoFormulario,
                nuevaAltura);

            PerformLayout();

            if (!ventanaVisible)
                return;

            // Mantener el centro de la ventana después del redimensionamiento.
            System.Drawing.Point centro = new(
                centroX,
                centroY);

            System.Drawing.Rectangle areaTrabajo =
                Screen.FromPoint(centro).WorkingArea;

            int nuevaX = Math.Clamp(
                centroX - Width / 2,
                areaTrabajo.Left,
                Math.Max(areaTrabajo.Left, areaTrabajo.Right - Width));

            int nuevaY = Math.Clamp(
                centroY - Height / 2,
                areaTrabajo.Top,
                Math.Max(areaTrabajo.Top, areaTrabajo.Bottom - Height));

            Location = new System.Drawing.Point(nuevaX, nuevaY);
        }

        /// <summary>
        /// Muestra los dos paneles y adapta la altura de la ventana.
        /// </summary>
        private void MostrarEtapaVerificacion()
        {
            _etapaVerificacion = true;

            pnlSolicitarCodigo.Visible = true;
            pnlVerificarCodigo.Visible = true;

            txtCorreo.Enabled = false;
            btnEnviarCodigo.Enabled = false;

            txtCodigo.Clear();

            pnlContenido.PerformLayout();

            // El panel de verificación ocupa el espacio restante
            // mediante DockStyle.Fill.
            AjustarTamanoVentana(incluirPanelVerificacion: true);

            AcceptButton = btnVerificarCodigo;

            txtCodigo.Focus();
        }

        /// <summary>
        /// Regresa a la solicitud del correo y reduce la ventana.
        /// </summary>
        private void MostrarEtapaSolicitud()
        {
            _etapaVerificacion = false;

            _temporizadorReenvio.Stop();

            _reenvioDisponibleUtc = DateTime.MinValue;

            pnlVerificarCodigo.Visible = false;
            pnlSolicitarCodigo.Visible = true;

            txtCorreo.Enabled = true;
            txtCodigo.Clear();

            btnEnviarCodigo.Enabled = true;
            btnReenviarCodigo.Enabled = false;

            lblMensajeCodigo.Text = "Vigencia limitada";

            pnlContenido.PerformLayout();

            AjustarTamanoVentana(incluirPanelVerificacion: false);

            AcceptButton = btnEnviarCodigo;

            txtCorreo.Focus();
        }

        #endregion

        #region Solicitud y reenvío del código

        private async void btnEnviarCodigo_Click(
            object? sender,
            EventArgs e)
        {
            if (_procesando)
                return;

            string correo = txtCorreo.Text.Trim();

            if (string.IsNullOrWhiteSpace(correo))
            {
                FrmMessageBox.Show(
                    "Introduce tu dirección de correo electrónico.",
                    "Campo requerido",
                    MessageType.Warning,
                    this);

                txtCorreo.Focus();
                return;
            }

            if (!MailAddress.TryCreate(correo, out _))
            {
                FrmMessageBox.Show(
                    "Introduce una dirección de correo electrónico válida.",
                    "Correo electrónico",
                    MessageType.Warning,
                    this);

                txtCorreo.Focus();
                return;
            }

            _correoActual = correo;

            await SolicitarCodigoAsync(esReenvio: false);
        }

        private async void btnReenviarCodigo_Click(
            object? sender,
            EventArgs e)
        {
            if (_procesando || string.IsNullOrWhiteSpace(_correoActual))
                return;

            if (DateTime.UtcNow < _reenvioDisponibleUtc)
                return;

            await SolicitarCodigoAsync(esReenvio: true);
        }

        private async Task SolicitarCodigoAsync(bool esReenvio)
        {
            if (_procesando)
                return;

            _procesando = true;

            btnEnviarCodigo.Enabled = false;
            btnReenviarCodigo.Enabled = false;
            btnVolverCorreo.Enabled = false;
            btnClose.Enabled = false;

            try
            {
                // Crear el servicio únicamente cuando se necesita.
                _servicioRecuperacion ??=
                    OceanDeskRepositoryFactory.CrearPasswordRecoveryService();

                ResultadoOperacionDto resultado =
                    await _servicioRecuperacion.SolicitarCodigoAsync(
                        _correoActual);

                if (!resultado.Exito)
                {
                    FrmMessageBox.Show(
                        resultado.Mensaje,
                        "Solicitud de recuperación",
                        MessageType.Warning,
                        this);

                    return;
                }

                // La respuesta es genérica por seguridad:
                // no revela si el correo pertenece a una cuenta.
                FrmMessageBox.Show(
                    resultado.Mensaje,
                    esReenvio
                        ? "Reenvío de código"
                        : "Solicitud de recuperación",
                    MessageType.Information,
                    this);

                // Si se reenvió, el código anterior ya puede haber sido
                // sustituido por uno nuevo.
                if (esReenvio)
                {
                    txtCodigo.Clear();
                }

                IniciarTemporizadorReenvio();

                // La primera solicitud abre la segunda etapa.
                // Los reenvíos permanecen en la misma etapa.
                if (!esReenvio)
                {
                    MostrarEtapaVerificacion();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"Error al solicitar código de recuperación: {ex}");

                FrmMessageBox.Show(
                    "No fue posible iniciar el proceso de recuperación. " +
                    "Comprueba la conexión con SQL Server y la configuración " +
                    "del servicio de correo electrónico.",
                    "Error de recuperación",
                    MessageType.Error,
                    this);
            }
            finally
            {
                _procesando = false;

                if (!IsDisposed)
                {
                    btnClose.Enabled = true;
                    btnVolverCorreo.Enabled = true;

                    btnEnviarCodigo.Enabled = !_etapaVerificacion;

                    btnReenviarCodigo.Enabled =
                        _etapaVerificacion &&
                        DateTime.UtcNow >= _reenvioDisponibleUtc;
                }
            }
        }

        #endregion

        #region Temporizador de reenvío

        private void IniciarTemporizadorReenvio()
        {
            _reenvioDisponibleUtc =
                DateTime.UtcNow.AddSeconds(SegundosEntreEnvios);

            btnReenviarCodigo.Enabled = false;

            ActualizarEstadoReenvio();

            _temporizadorReenvio.Start();
        }

        private void TemporizadorReenvio_Tick(
            object? sender,
            EventArgs e)
        {
            ActualizarEstadoReenvio();

            if (DateTime.UtcNow >= _reenvioDisponibleUtc)
            {
                _temporizadorReenvio.Stop();

                btnReenviarCodigo.Enabled = true;

                lblMensajeCodigo.Text = "Vigencia limitada";
            }
        }

        private void ActualizarEstadoReenvio()
        {
            int segundosRestantes = Math.Max(
                0,
                (int)Math.Ceiling(
                    (_reenvioDisponibleUtc - DateTime.UtcNow).TotalSeconds));

            if (segundosRestantes > 0)
            {
                lblMensajeCodigo.Text =
                    $"Reenviar en {segundosRestantes}s";
            }
        }

        #endregion

        #region Verificación del código

        private void btnVerificarCodigo_Click(
            object? sender,
            EventArgs e)
        {
            if (_procesando)
                return;

            string codigo = txtCodigo.Text.Trim();

            if (codigo.Length != LongitudCodigo ||
                codigo.Any(c => c < '0' || c > '9'))
            {
                FrmMessageBox.Show(
                    "Introduce el código completo de ocho dígitos.",
                    "Código de recuperación",
                    MessageType.Warning,
                    this);

                txtCodigo.Focus();
                return;
            }

            _procesando = true;
            btnVerificarCodigo.Enabled = false;

            try
            {
                if (_servicioRecuperacion is null)
                {
                    throw new InvalidOperationException(
                        "El servicio de recuperación no está inicializado.");
                }

                ResultadoOperacionDto resultado =
                    _servicioRecuperacion.VerificarCodigo(
                        _correoActual,
                        codigo);

                if (!resultado.Exito)
                {
                    FrmMessageBox.Show(
                        resultado.Mensaje,
                        "Verificación de identidad",
                        MessageType.Warning,
                        this);

                    txtCodigo.Focus();
                    return;
                }

                // El código fue verificado.
                // Ahora se reutiliza el formulario de cambio de contraseña
                // en su modo de recuperación.
                using FrmCambioContrasenaInicial formularioCambio =
                    new FrmCambioContrasenaInicial();

                formularioCambio.ConfigurarRecuperacion(
                    _correoActual,
                    codigo,
                    _servicioRecuperacion);

                DialogResult resultadoCambio =
                    formularioCambio.ShowDialog(this);

                if (resultadoCambio == DialogResult.OK)
                {
                    // El servicio ya restableció la contraseña y consumió
                    // el código. Regresamos al inicio de sesión.
                    DialogResult = DialogResult.OK;

                    Close();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(
                    $"Error al verificar el código: {ex}");

                FrmMessageBox.Show(
                    "No fue posible completar la verificación. " +
                    "Comprueba la conexión e inténtalo nuevamente.",
                    "Error de verificación",
                    MessageType.Error,
                    this);
            }
            finally
            {
                _procesando = false;

                if (!IsDisposed)
                    btnVerificarCodigo.Enabled = true;
            }
        }

        /// <summary>
        /// Elimina caracteres que no sean dígitos, incluso cuando
        /// el usuario pega contenido desde el portapapeles.
        /// </summary>
        private void txtCodigo_TextChanged(
            object? sender,
            EventArgs e)
        {
            string codigoLimpio = new string(
                txtCodigo.Text
                    .Where(c => c >= '0' && c <= '9')
                    .Take(LongitudCodigo)
                    .ToArray());

            if (txtCodigo.Text != codigoLimpio)
            {
                int posicion = txtCodigo.SelectionStart;

                txtCodigo.Text = codigoLimpio;

                txtCodigo.SelectionStart = Math.Min(
                    posicion,
                    codigoLimpio.Length);
            }
        }

        #endregion

        #region Navegación y cierre

        private void btnVolverCorreo_Click(
            object? sender,
            EventArgs e)
        {
            if (_procesando)
                return;

            MostrarEtapaSolicitud();
        }

        private void btnClose_Click(
            object? sender,
            EventArgs e)
        {
            if (_procesando)
                return;

            DialogResult = DialogResult.Cancel;

            Close();
        }

        private void FrmRecuperarContrasena_FormClosed(
            object? sender,
            FormClosedEventArgs e)
        {
            _temporizadorReenvio.Stop();
            _temporizadorReenvio.Dispose();

            _servicioRecuperacion?.Dispose();
            _servicioRecuperacion = null;
        }

        #endregion
    }
}
