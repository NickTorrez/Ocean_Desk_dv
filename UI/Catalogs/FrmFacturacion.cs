using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ocean_Desk_dv.UI.Models;
using Ocean_Desk_dv.UI.MessageBox;

namespace Ocean_Desk_dv.UI.Catalogs
{
    public partial class FrmFacturacion : Form
    {
        private readonly List<FacturaPrueba> _facturas = new List<FacturaPrueba>(); //Declaramos una lista para las facturas

        public FrmFacturacion()
        {
            InitializeComponent();

            CargarFacturasPrueba(); //Cargamos las Facturas
            MostrarFacturas(); //Se mjuestran las facturas en el dgv
            ActualizarEstadoBotones(); //Comportamiento entre botones y dgv
            ConfigurarFiltroEstado();
            ConfigurarFiltroFechas();
        }

        #region Metodos para Cargar y Mostrar Facturas de Prueba
        private void MostrarFacturas()
        {
            dgvFacturas.DataSource = null;
            dgvFacturas.DataSource = _facturas;

            dgvFacturas.CurrentCell = null;

            dgvFacturas.ClearSelection();

            ActualizarEstadoBotones();
        }

        private void CargarFacturasPrueba()
        {
            _facturas.Clear();

            _facturas.Add(new FacturaPrueba
            {
                NumeroFactura = "F001-0001",
                Fecha = DateTime.Today,
                Cliente = "Juan Pérez",
                TipoOrden = "Local",
                Total = 450.00m,
                Estado = "Pagada"
            });

            _facturas.Add(new FacturaPrueba
            {
                NumeroFactura = "F001-0002",
                Fecha = DateTime.Today,
                Cliente = "María López",
                TipoOrden = "Delivery",
                Total = 320.50m,
                Estado = "Pagada"
            });

            _facturas.Add(new FacturaPrueba
            {
                NumeroFactura = "F001-0003",
                Fecha = DateTime.Today.AddDays(-1),
                Cliente = "Carlos Rodríguez",
                TipoOrden = "Local",
                Total = 180.00m,
                Estado = "Anulada"
            });

            _facturas.Add(new FacturaPrueba
            {
                NumeroFactura = "F001-0004",
                Fecha = DateTime.Today.AddDays(-2),
                Cliente = "Consumidor Final",
                TipoOrden = "Local",
                Total = 275.75m,
                Estado = "Pagada"
            });

            _facturas.Add(new FacturaPrueba
            {
                NumeroFactura = "F001-0005",
                Fecha = DateTime.Today.AddDays(-3),
                Cliente = "Ana Martínez",
                TipoOrden = "Delivery",
                Total = 525.00m,
                Estado = "Pagada"
            });

            _facturas.Add(new FacturaPrueba
            {
                NumeroFactura = "F001-0006",
                Fecha = DateTime.Today.AddDays(-4),
                Cliente = "Pedro Gómez",
                TipoOrden = "Local",
                Total = 150.00m,
                Estado = "Anulada"
            });
        }
        #endregion

        #region Metodos de Comportamiento entre los Buttons y el Dgv
        private void ActualizarEstadoBotones()//Reacción de los botones al tipo de factura
        {
            bool haySeleccion = dgvFacturas.SelectedRows.Count > 0;

            // No hay factura seleccionada
            if (!haySeleccion)
            {
                ConfigurarEstadoBoton(
                    btnVerDetalle,
                    false,
                    _colorBotonNormal,
                    _colorBotonTexto);

                ConfigurarEstadoBoton(
                    btnImprimir,
                    false,
                    _colorBotonNormal,
                    _colorBotonTexto);

                ConfigurarEstadoBoton(
                    btnAnular,
                    false,
                    _colorAnularNormal,
                    _colorAnularTexto);

                return;
            }

            // Obtener la factura seleccionada directamente
            DataGridViewRow fila = dgvFacturas.SelectedRows[0];

            FacturaPrueba factura = fila.DataBoundItem as FacturaPrueba;

            if (factura == null)
            {
                ConfigurarEstadoBoton(
                    btnVerDetalle,
                    false,
                    _colorBotonNormal,
                    _colorBotonTexto);

                ConfigurarEstadoBoton(
                    btnImprimir,
                    false,
                    _colorBotonNormal,
                    _colorBotonTexto);

                ConfigurarEstadoBoton(
                    btnAnular,
                    false,
                    _colorAnularNormal,
                    _colorAnularTexto);

                return;
            }

            // Hay una factura seleccionada
            ConfigurarEstadoBoton(
                btnVerDetalle,
                true,
                _colorBotonNormal,
                _colorBotonTexto);

            ConfigurarEstadoBoton(
                btnImprimir,
                true,
                _colorBotonNormal,
                _colorBotonTexto);

            // Una factura anulada no puede volver a anularse
            bool puedeAnular =
                !string.Equals(
                    factura.Estado,
                    "Anulada",
                    StringComparison.OrdinalIgnoreCase);

            ConfigurarEstadoBoton(
                btnAnular,
                puedeAnular,
                _colorAnularNormal,
                _colorAnularTexto);
        }

        private void dgvFacturas_SelectionChanged(object sender, EventArgs e) //Reaccion del dgv a los botones
        {
            ActualizarEstadoBotones();
        }
        #endregion

        #region Colores y Metodos para Botones, y DGV
        private readonly Color _colorBotonNormal = Color.FromArgb(238, 243, 247);

        private readonly Color _colorBotonTexto = Color.FromArgb(8, 31, 63);

        private readonly Color _colorBotonDisabled = Color.FromArgb(232, 236, 239);

        private readonly Color _colorTextoDisabled = Color.FromArgb(155, 163, 170);

        private readonly Color _colorAnularNormal = Color.FromArgb(248, 234, 234);

        private readonly Color _colorAnularTexto = Color.FromArgb(163, 61, 61);

        private void ConfigurarEstadoBoton(Button boton, bool habilitado, Color colorNormal, Color colorTexto)
        {
            boton.Enabled = habilitado;

            if (habilitado)
            {
                boton.BackColor = colorNormal;
                boton.ForeColor = colorTexto;
            }
            else
            {
                boton.BackColor = _colorBotonDisabled;
                boton.ForeColor = _colorTextoDisabled;
            }
        }

        private void dgvFacturas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex != 5)
                return;

            if (e.Value == null)
                return;

            string estado = e.Value.ToString();

            if (estado == "Pagada")
            {
                e.CellStyle.ForeColor =
                    Color.FromArgb(42, 122, 82);

                e.CellStyle.Font =
                    new Font(
                        dgvFacturas.Font,
                        FontStyle.Bold);
            }
            else if (estado == "Anulada")
            {
                e.CellStyle.ForeColor =
                    Color.FromArgb(163, 61, 61);

                e.CellStyle.Font =
                    new Font(
                        dgvFacturas.Font,
                        FontStyle.Bold);
            }
        }

        private void FiltrarFacturas()
        {
            string texto =
                txtBuscar.Text.Trim();

            DateTime fechaDesde =
                dtpFechaDesde.Value.Date;

            DateTime fechaHasta =
                dtpFechaHasta.Value.Date;

            string estadoSeleccionado =
                cmbEstado.SelectedItem?.ToString() ?? "Todos";

            List<FacturaPrueba> facturasFiltradas =
                _facturas
                .Where(factura =>
                    (
                        string.IsNullOrWhiteSpace(texto)
                        ||
                        factura.NumeroFactura.Contains(
                            texto,
                            StringComparison.OrdinalIgnoreCase)
                        ||
                        factura.Cliente.Contains(
                            texto,
                            StringComparison.OrdinalIgnoreCase)
                    )
                    &&
                    factura.Fecha.Date >= fechaDesde
                    &&
                    factura.Fecha.Date <= fechaHasta
                    &&
                    (
                        estadoSeleccionado == "Todos"
                        ||
                        factura.Estado.Equals(
                            estadoSeleccionado,
                            StringComparison.OrdinalIgnoreCase)
                    )
                )
                .ToList();

            dgvFacturas.DataSource = null;
            dgvFacturas.DataSource = facturasFiltradas;

            ActualizarEstadoBotones();
        }

        private void ConfigurarFiltroEstado()
        {
            cmbEstado.Items.Clear();

            cmbEstado.Items.Add("Todos");
            cmbEstado.Items.Add("Pagada");
            cmbEstado.Items.Add("Anulada");

            cmbEstado.SelectedIndex = 0;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarFacturas();
        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarFacturas();
        }

        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            FiltrarFacturas();
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            FiltrarFacturas();
        }

        private void ConfigurarFiltroFechas()
        {
            dtpFechaDesde.Value = DateTime.Today.AddDays(-30);

            dtpFechaHasta.Value = DateTime.Today;
        }
        #endregion

        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count == 0)
            {
                FrmMessageBox.Show(
                    "Seleccione una factura para consultar su detalle.",
                    "Factura no seleccionada",
                    MessageType.Warning);

                return;
            }

            // Aquí posteriormente mostraremos el detalle.
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count == 0)
            {
                FrmMessageBox.Show(
                    "Seleccione una factura para imprimir el comprobante.",
                    "Factura no seleccionada",
                    MessageType.Warning);

                return;
            }

            // La impresión real se implementara posteriormente.
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (dgvFacturas.SelectedRows.Count == 0)
            {
                FrmMessageBox.Show(
                    "Seleccione una factura para realizar la anulación.",
                    "Factura no seleccionada",
                    MessageType.Warning);

                return;
            }

            DataGridViewRow fila = dgvFacturas.SelectedRows[0];

            FacturaPrueba factura = fila.DataBoundItem as FacturaPrueba;

            if (factura == null)
            {
                FrmMessageBox.Show(
                    "No fue posible obtener la información de la factura seleccionada.",
                    "Error",
                    MessageType.Error);

                return;
            }

            if (factura.Estado == "Anulada")
            {
                FrmMessageBox.Show(
                    "La factura seleccionada ya se encuentra anulada.",
                    "Factura anulada",
                    MessageType.Warning);

                return;
            }

            DialogResult resultado =
                FrmMessageBox.Show(
                    $"¿Desea anular la factura {factura.NumeroFactura}?",
                    "Confirmar anulación",
                    MessageType.Confirmation);

            if (resultado != DialogResult.Yes)
                return;

            factura.Estado = "Anulada";

            MostrarFacturas();

            FrmMessageBox.Show(
                $"La factura {factura.NumeroFactura} ha sido anulada correctamente.",
                "Anulación realizada",
                MessageType.Information);
        }
    }
}
