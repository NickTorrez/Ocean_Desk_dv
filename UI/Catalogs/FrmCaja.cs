using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace Ocean_Desk_dv.UI.Catalogs
{
    public partial class FrmCaja : Form
    {
        private readonly List<MovimientoCajaPrueba> _movimientos = new List<MovimientoCajaPrueba>();

        private readonly List<CierreCajaPrueba> _historialCierres = new List<CierreCajaPrueba>();

        private bool _cajaAbierta = true;

        public FrmCaja()
        {
            InitializeComponent();

            CargarMovimientosPrueba();
            MostrarMovimientos();
            ActualizarResumenCaja();
            ActualizarEstadoCaja();

        }

        #region Carga de Datos en dgv y tarjetas de movimientos
        private void CargarMovimientosPrueba() //Metodo para cargar datos en el dgv
        {
            _movimientos.Clear();

            _movimientos.Add(new MovimientoCajaPrueba
            {
                Fecha = DateTime.Today.AddHours(8),
                Tipo = "Venta",
                Concepto = "Venta #0001",
                MetodoPago = "Efectivo",
                Monto = 450.00m,
                Usuario = "Administrador"
            });

            _movimientos.Add(new MovimientoCajaPrueba
            {
                Fecha = DateTime.Today.AddHours(9),
                Tipo = "Venta",
                Concepto = "Venta #0002",
                MetodoPago = "Tarjeta",
                Monto = 320.50m,
                Usuario = "Cajero"
            });

            _movimientos.Add(new MovimientoCajaPrueba
            {
                Fecha = DateTime.Today.AddHours(10),
                Tipo = "Ingreso",
                Concepto = "Fondo adicional",
                MetodoPago = "Efectivo",
                Monto = 500.00m,
                Usuario = "Administrador"
            });

            _movimientos.Add(new MovimientoCajaPrueba
            {
                Fecha = DateTime.Today.AddHours(11),
                Tipo = "Egreso",
                Concepto = "Compra urgente",
                MetodoPago = "Efectivo",
                Monto = 120.00m,
                Usuario = "Administrador"
            });

        }

        private void MostrarMovimientos() //carga una nueva lista de movimientos y asegura que no haya filas seleccionadas al finalizar
        {
            dgvMovimientosCaja.DataSource = null;
            dgvMovimientosCaja.DataSource = _movimientos;

            dgvMovimientosCaja.ClearSelection();
        }

        private void ActualizarResumenCaja() //Cargar Datos a las tarjetas de resumenes
        {
            decimal apertura = 1000.00m;

            decimal ingresos =
                _movimientos
                    .Where(m =>
                        m.Tipo == "Venta" ||
                        m.Tipo == "Ingreso")
                    .Sum(m => m.Monto);

            decimal egresos =
                _movimientos
                    .Where(m =>
                        m.Tipo == "Egreso")
                    .Sum(m => m.Monto);

            decimal efectivoEsperado = ObtenerEfectivoEsperado();

            lblValorApertura.Text =
                apertura.ToString(
                    "C",
                    System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            lblValorIngresos.Text =
                ingresos.ToString(
                    "C",
                    System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            lblValorEgresos.Text =
                egresos.ToString(
                    "C",
                    System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            lblValorEsperado.Text =
                efectivoEsperado.ToString(
                    "C",
                    System.Globalization.CultureInfo.GetCultureInfo("es-NI"));
        }
        #endregion

        #region Crear datos de historial de prueba
        private void CargarHistorialCierresPrueba()
        {
            _historialCierres.Clear();

            _historialCierres.Add(
                new CierreCajaPrueba
                {
                    FechaCierre = DateTime.Today.AddDays(-1)
                        .AddHours(20)
                        .AddMinutes(15),

                    EfectivoEsperado = 5250.00m,
                    EfectivoReal = 5250.00m,
                    Diferencia = 0,
                    Usuario = "Administrador"
                });

            _historialCierres.Add(
                new CierreCajaPrueba
                {
                    FechaCierre = DateTime.Today.AddDays(-2)
                        .AddHours(20)
                        .AddMinutes(30),

                    EfectivoEsperado = 4800.00m,
                    EfectivoReal = 4775.00m,
                    Diferencia = -25.00m,
                    Usuario = "Cajero"
                });

            _historialCierres.Add(
                new CierreCajaPrueba
                {
                    FechaCierre = DateTime.Today.AddDays(-3)
                        .AddHours(21),

                    EfectivoEsperado = 6100.00m,
                    EfectivoReal = 6170.00m,
                    Diferencia = 70.00m,
                    Usuario = "Administrador"
                });
        }
        #endregion

        #region Color y Comportamiento en el panel de estado de caja y botones de acciones
        private void ActualizarEstadoCaja()
        {
            lblEstadoCaja.Text =
                _cajaAbierta
                    ? "ABIERTA"
                    : "CERRADA";

            if (_cajaAbierta)
            {
                btnAbrirCaja.Enabled = false;
                btnRegistrarIngreso.Enabled = true;
                btnRegistrarEgreso.Enabled = true;
                btnCerrarCaja.Enabled = true;

                lblEstadoCaja.BackColor =
                    Color.FromArgb(232, 244, 238);

                lblEstadoCaja.ForeColor =
                    Color.FromArgb(42, 122, 82);
            }
            else
            {
                btnAbrirCaja.Enabled = true;
                btnRegistrarIngreso.Enabled = false;
                btnRegistrarEgreso.Enabled = false;
                btnCerrarCaja.Enabled = false;

                lblEstadoCaja.BackColor =
                    Color.FromArgb(240, 242, 244);

                lblEstadoCaja.ForeColor =
                    Color.FromArgb(111, 119, 128);
            }

            ActualizarEstadoVisualBotones();
        }

        private void ActualizarEstadoVisualBotones()
        {
            AplicarEstadoBoton(
                btnAbrirCaja,
                btnAbrirCaja.Enabled,
                Color.FromArgb(238, 243, 247),
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
                boton.BackColor =
                    Color.FromArgb(232, 236, 239);

                boton.ForeColor =
                    Color.FromArgb(155, 163, 170);
            }
        }
        #endregion

        #region Eventos y Funciones de los Botones
        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            DialogResult resultado =
            FrmMessageBox.Show(
           "¿Desea abrir la caja?",
           "Apertura de caja",
           MessageType.Confirmation);

            if (resultado != DialogResult.Yes)
                return;

            _cajaAbierta = true;

            ActualizarEstadoCaja();

            FrmMessageBox.Show(
                "La caja ha sido abierta correctamente.",
                "Caja abierta",
                MessageType.Information);
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (!_cajaAbierta)
                return;

            decimal efectivoEsperado = ObtenerEfectivoEsperado();

            string esperadoFormateado = efectivoEsperado.ToString(
                    "C",
                    System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            string efectivoTexto =
                Interaction.InputBox(
                    $"Efectivo esperado: {esperadoFormateado}\n\n" +
                    "Ingrese el efectivo contado físicamente:",
                    "Conteo de efectivo");

            if (string.IsNullOrWhiteSpace(efectivoTexto))
                return;

            if (!decimal.TryParse(
                efectivoTexto,
                out decimal efectivoReal))
            {
                FrmMessageBox.Show(
                    "Ingrese un monto válido.",
                    "Monto inválido",
                    MessageType.Warning);

                return;
            }

            if (efectivoReal < 0)
            {
                FrmMessageBox.Show(
                    "El efectivo contado no puede ser negativo.",
                    "Monto inválido",
                    MessageType.Warning);

                return;
            }

            decimal diferencia = efectivoReal - efectivoEsperado;

            MostrarResumenCierre(efectivoEsperado,efectivoReal,diferencia);
        }

        private void MostrarResumenCierre(decimal efectivoEsperado,decimal efectivoReal,decimal diferencia)
        {
            string esperado = efectivoEsperado.ToString(
                    "C",
                    System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            string real = efectivoReal.ToString(
                    "C",
                    System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            string diferenciaTexto = diferencia.ToString(
                    "C",
                    System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            string mensaje =
                $"Efectivo esperado: {esperado}\n" +
                $"Efectivo contado: {real}\n" +
                $"Diferencia: {diferenciaTexto}\n\n" +
                "¿Desea confirmar el cierre de caja?";

            DialogResult resultado = FrmMessageBox.Show(
                    mensaje,
                    "Resumen de cierre",
                    MessageType.Confirmation);

            if (resultado != DialogResult.Yes)
                return;

            FinalizarCierreCaja(efectivoEsperado,efectivoReal,diferencia);
        }

        private void FinalizarCierreCaja(decimal efectivoEsperado,decimal efectivoReal,decimal diferencia)
        {
            _cajaAbierta = false;

            lblValorEsperado.Text = efectivoEsperado.ToString(
                    "C",
                    System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            ActualizarEstadoCaja();

            ActualizarResumenCaja();

            FrmMessageBox.Show(
                "La caja ha sido cerrada correctamente.",
                "Caja cerrada",
                MessageType.Information);

            _historialCierres.Add(new CierreCajaPrueba
            {
                FechaCierre = DateTime.Now,
                EfectivoEsperado = efectivoEsperado,
                EfectivoReal = efectivoReal,
                Diferencia = diferencia,
                Usuario = "Administrador"
            });
        }

        private decimal ObtenerEfectivoEsperado()
        {
            decimal apertura = 1000.00m;

            decimal ingresosEfectivo =
                _movimientos
                    .Where(m =>
                        (m.Tipo == "Venta" ||
                         m.Tipo == "Ingreso")
                        &&
                        m.MetodoPago == "Efectivo")
                    .Sum(m => m.Monto);

            decimal egresosEfectivo =
                _movimientos
                    .Where(m =>
                        m.Tipo == "Egreso" &&
                        m.MetodoPago == "Efectivo")
                    .Sum(m => m.Monto);

            return apertura
                + ingresosEfectivo
                - egresosEfectivo;
        }

        private void btnRegistrarIngreso_Click(object sender, EventArgs e)
        {
            if (!_cajaAbierta)
            {
                FrmMessageBox.Show(
                  "La caja se encuentra cerrada.\n\n" +
                  "Abra la caja antes de registrar movimientos.",
                  "Caja cerrada",
                  MessageType.Warning);

                return;
            }

            string concepto =
                Interaction.InputBox(
                    "Ingrese el concepto del ingreso:",
                    "Registrar ingreso");

            if (string.IsNullOrWhiteSpace(concepto))
                return;

            string montoTexto =
                Interaction.InputBox(
                    "Ingrese el monto del ingreso:",
                    "Registrar ingreso");

            if (!decimal.TryParse(
                montoTexto,
                out decimal monto))
            {
                FrmMessageBox.Show(
                    "Ingrese un monto válido.",
                    "Monto inválido",
                    MessageType.Warning);

                return;
            }

            if (monto <= 0)
            {
                FrmMessageBox.Show(
                    "El monto debe ser mayor que cero.",
                    "Monto inválido",
                    MessageType.Warning);

                return;
            }

            _movimientos.Add(
                new MovimientoCajaPrueba
                {
                    Fecha = DateTime.Now,
                    Tipo = "Ingreso",
                    Concepto = concepto,
                    MetodoPago = "Efectivo",
                    Monto = monto,
                    Usuario = "Administrador"
                });

            MostrarMovimientos();

            ActualizarResumenCaja();

            FrmMessageBox.Show(
                "El ingreso ha sido registrado correctamente.",
                "Ingreso registrado",
                MessageType.Information);
        }

        private void btnRegistrarEgreso_Click(object sender, EventArgs e)
        {
            if (!_cajaAbierta)
            {
                FrmMessageBox.Show(
                  "La caja se encuentra cerrada.\n\n" +
                  "Abra la caja antes de registrar movimientos.",
                  "Caja cerrada",
                  MessageType.Warning);

                return;
            }

            string concepto =
                Interaction.InputBox(
                    "Ingrese el concepto del egreso:",
                    "Registrar egreso");

            if (string.IsNullOrWhiteSpace(concepto))
                return;

            string montoTexto =
                Interaction.InputBox(
                    "Ingrese el monto del egreso:",
                    "Registrar egreso");

            if (!decimal.TryParse(
                montoTexto,
                out decimal monto))
            {
                FrmMessageBox.Show(
                    "Ingrese un monto válido.",
                    "Monto inválido",
                    MessageType.Warning);

                return;
            }

            if (monto <= 0)
            {
                FrmMessageBox.Show(
                    "El monto debe ser mayor que cero.",
                    "Monto inválido",
                    MessageType.Warning);

                return;
            }

            decimal efectivoEsperado = ObtenerEfectivoEsperado();

            if (monto > efectivoEsperado)
            {
                FrmMessageBox.Show(
                    "El monto del egreso supera el efectivo disponible esperado en caja.",
                    "Efectivo insuficiente",
                    MessageType.Warning);

                return;
            }

            _movimientos.Add(
                new MovimientoCajaPrueba
                {
                    Fecha = DateTime.Now,
                    Tipo = "Egreso",
                    Concepto = concepto,
                    MetodoPago = "Efectivo",
                    Monto = monto,
                    Usuario = "Administrador"
                });

            MostrarMovimientos();

            ActualizarResumenCaja();

            FrmMessageBox.Show(
                "El egreso ha sido registrado correctamente.",
                "Egreso registrado",
                MessageType.Information);
        }
        #endregion
    }
}
