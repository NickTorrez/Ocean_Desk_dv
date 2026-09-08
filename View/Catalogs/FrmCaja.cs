using Microsoft.VisualBasic;
using Ocean_Desk_dv.Presenters;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.UI.Models;
using Ocean_Desk_dv.View.Interfaces;
using Ocean_Desk_dv.View.MessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocean_Desk_dv.UI.Catalogs
{
    /// <summary>
    /// Vista principal del módulo de Caja.
    /// Implementa ICajaView y delega la lógica de negocio al CajaPresenter.
    /// </summary>
    public partial class FrmCaja : Form, ICajaView
    {
        private readonly int _usuarioId;
        private CajaPresenter? _presenter;

        #region Constructor
        /// <summary>
        /// Constructor utilizado mientras el sistema de autenticación no entrega el usuario real.
        /// </summary>
        public FrmCaja() : this(1)
        {
        }

        /// <summary>
        /// Inicializa el formulario de Caja para el usuario indicado.
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public FrmCaja(int usuarioId)
        {
            if (usuarioId <= 0)
                throw new ArgumentOutOfRangeException(nameof(usuarioId));

            _usuarioId = usuarioId;

            InitializeComponent();

            dgvMovimientosCaja.AutoGenerateColumns = false;

            _presenter = new CajaPresenter(this);
            _presenter.Inicializar();

            FormClosed += FrmCaja_FormClosed;
        }
        #endregion

        #region Implementación de ICajaView
        public int UsuarioId => _usuarioId;

        public event EventHandler AbrirCajaClicked = delegate { };
        public event EventHandler CerrarCajaClicked = delegate { };
        public event EventHandler RegistrarIngresoClicked = delegate { };
        public event EventHandler RegistrarEgresoClicked = delegate { };

        /// <summary>
        /// Muestra en pantalla el estado actual de la caja.
        /// </summary>
        public void MostrarEstadoCaja(bool abierta, DateTime? fechaApertura)
        {
            lblEstadoCaja.Text = abierta ? "ABIERTA" : "CERRADA";

            lblDetalleCaja.Text = abierta && fechaApertura.HasValue
                ? $"Apertura: {fechaApertura.Value:dd/MM/yyyy HH:mm}"
                : "No existe una caja abierta actualmente.";

            btnAbrirCaja.Enabled = !abierta;
            btnRegistrarIngreso.Enabled = abierta;
            btnRegistrarEgreso.Enabled = abierta;
            btnCerrarCaja.Enabled = abierta;

            if (abierta)
            {
                lblEstadoCaja.BackColor = Color.FromArgb(232, 244, 238);
                lblEstadoCaja.ForeColor = Color.FromArgb(42, 122, 82);
            }
            else
            {
                lblEstadoCaja.BackColor = Color.FromArgb(240, 242, 244);
                lblEstadoCaja.ForeColor = Color.FromArgb(111, 119, 128);
            }

            ActualizarEstadoVisualBotones();
        }

        /// <summary>
        /// Actualiza las tarjetas de resumen de la caja.
        /// </summary>
        public void MostrarResumen(
            decimal apertura,
            decimal ingresos,
            decimal egresos,
            decimal efectivoEsperado)
        {
            lblValorApertura.Text = FormatearMoneda(apertura);
            lblValorIngresos.Text = FormatearMoneda(ingresos);
            lblValorEgresos.Text = FormatearMoneda(egresos);
            lblValorEsperado.Text = FormatearMoneda(efectivoEsperado);
        }

        /// <summary>
        /// Muestra la información correspondiente al último cierre registrado.
        /// </summary>
        public void MostrarUltimoCierre(
            DateTime? fechaCierre,
            decimal? efectivoEsperado,
            decimal? efectivoReal,
            decimal? diferencia,
            string usuario)
        {
            lblUltimoCierreFecha.Text =
                fechaCierre.HasValue
                    ? $"Fecha: {fechaCierre.Value:dd/MM/yyyy HH:mm}"
                    : "Fecha: -";

            lblUltimoCierreEsperado.Text =
                efectivoEsperado.HasValue
                    ? $"Esperado: {FormatearMoneda(efectivoEsperado.Value)}"
                    : "Esperado: -";

            lblUltimoCierreContado.Text =
                efectivoReal.HasValue
                    ? $"Contado: {FormatearMoneda(efectivoReal.Value)}"
                    : "Contado: -";

            lblUltimoCierreDiferencia.Text =
                diferencia.HasValue
                    ? $"Diferencia: {FormatearMoneda(diferencia.Value)}"
                    : "Diferencia: -";

            lblUltimoCierreUsuario.Text =
                string.IsNullOrWhiteSpace(usuario)
                    ? "Usuario: -"
                    : $"Usuario: {usuario}";
        }

        /// <summary>
        /// Carga los movimientos reales en el DataGridView.
        /// </summary>
        public void MostrarMovimientos(List<MovimientoCajaPrueba> movimientos)
        {
            dgvMovimientosCaja.DataSource = null;
            dgvMovimientosCaja.DataSource = movimientos;
            dgvMovimientosCaja.ClearSelection();
        }

        /// <summary>
        /// Muestra un mensaje utilizando el MessageBox personalizado del proyecto.
        /// </summary>
        public void MostrarMensaje(string mensaje, MessageType tipo)
        {
            FrmMessageBox.Show(mensaje, "Caja", tipo);
        }

        /// <summary>
        /// Muestra una confirmación y ejecuta la acción solo cuando el usuario confirma.
        /// </summary>
        public void MostrarConfirmacion(string mensaje, string titulo, Action accionConfirmada)
        {
            DialogResult resultado = FrmMessageBox.Show(
                mensaje,
                titulo,
                MessageType.Confirmation);

            if (resultado == DialogResult.Yes)
                accionConfirmada();
        }

        /// <summary>
        /// Solicita al usuario un monto monetario.
        /// </summary>
        public decimal? SolicitarMonto(string mensaje, string titulo)
        {
            return FrmInputBox.SolicitarMonto(this,titulo,mensaje);
        }

        /// <summary>
        /// Solicita al usuario un texto simple.
        /// </summary>
        public string? SolicitarTexto(string mensaje, string titulo)
        {
            return FrmTextInput.SolicitarTexto(this,titulo,mensaje);
        }
        #endregion

        #region Evento de Botones
        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            AbrirCajaClicked.Invoke(this, EventArgs.Empty);
        }

        private void btnRegistrarIngreso_Click(object sender, EventArgs e)
        {
            RegistrarIngresoClicked.Invoke(this, EventArgs.Empty);
        }

        private void btnRegistrarEgreso_Click(object sender, EventArgs e)
        {
            RegistrarEgresoClicked.Invoke(this, EventArgs.Empty);
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            CerrarCajaClicked.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Estado Visual
        private void ActualizarEstadoVisualBotones()
        {
            AplicarEstadoBoton(
                btnAbrirCaja,
                btnAbrirCaja.Enabled,
                Color.FromArgb(135, 206, 250),
                Color.FromArgb(8, 31, 63));

            AplicarEstadoBoton(
                btnRegistrarIngreso,
                btnRegistrarIngreso.Enabled,
                Color.FromArgb(238, 243, 247),
                Color.FromArgb(8, 31, 63));

            AplicarEstadoBoton(
                btnRegistrarEgreso,
                btnRegistrarEgreso.Enabled,
                Color.FromArgb(238, 243, 247),
                Color.FromArgb(8, 31, 63));

            AplicarEstadoBoton(
                btnCerrarCaja,
                btnCerrarCaja.Enabled,
                Color.FromArgb(8, 126, 164),
                Color.White);
        }

        private void AplicarEstadoBoton(
           Button boton,
           bool habilitado,
           Color colorNormal,
           Color colorTexto)
        {
            boton.Enabled = habilitado;

            if (habilitado)
            {
                boton.BackColor = colorNormal;
                boton.ForeColor = colorTexto;
            }
            else
            {
                boton.BackColor = Color.FromArgb(232, 236, 239);

                boton.ForeColor = Color.FromArgb(155, 163, 170);
            }
        }
        #endregion

        #region Utilidades
        private static string FormatearMoneda(decimal monto)
        {
            return "C$ " + monto.ToString(
                "N2",
                CultureInfo.GetCultureInfo("es-NI"));
        }

        #endregion

        #region Liberación de recursos
        private void FrmCaja_FormClosed(object? sender, FormClosedEventArgs e)
        {
            _presenter?.Dispose();
            _presenter = null;
        }
        #endregion

        #region Monto de dgvMovimientos
        private void dgvMovimientosCaja_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvMovimientosCaja.Columns[e.ColumnIndex].Name != "colMonto")
                return;

            if (e.Value == null || e.Value == DBNull.Value)
                return;

            if (decimal.TryParse(e.Value.ToString(), out decimal monto))
            {
                e.Value = FormatearMoneda(monto);
                e.FormattingApplied = true;
            }
        }
        #endregion

    }
}
