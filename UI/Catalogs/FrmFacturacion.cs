using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.UI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocean_Desk_dv.UI.Catalogs
{
    public partial class FrmFacturacion : Form
    {
        private readonly List<FacturaPrueba> _facturas = new List<FacturaPrueba>(); //Declaramos una lista para las facturas

        private FacturaPrueba _facturaImprimiendo; // Variable para almacenar la factura que se está imprimiendo

        private readonly PrintDocument _documentoImpresion = new PrintDocument(); // Variable para manejar la impresión

        public FrmFacturacion()
        {
            InitializeComponent();

            _documentoImpresion.PrintPage += DocumentoImpresion_PrintPage;

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

            // Factura 1
            _facturas.Add(new FacturaPrueba
            {
                NumeroFactura = "F001-0001",
                Fecha = DateTime.Today,
                Cliente = "Juan Pérez",
                TipoOrden = "Local",
                Mesa = 5,

                Subtotal = 377.00m,
                Descuento = 0.00m,
                Total = 377.00m,

                MetodoPago = "Efectivo",
                Estado = "Pagada",

                Detalles = new List<DetalleFacturaPrueba>
                {
                    new DetalleFacturaPrueba
                    {
                        Producto = "Ceviche Mixto",
                        Cantidad = 2,
                        Precio = 120.00m
                    },

                    new DetalleFacturaPrueba
                    {
                        Producto = "Camarones al Ajillo",
                        Cantidad = 1,
                        Precio = 100.00m
                    },

                    new DetalleFacturaPrueba
                    {
                        Producto = "Coca Cola",
                        Cantidad = 2,
                        Precio = 18.50m
                    }
                }
            });

            // Factura 2
            _facturas.Add(new FacturaPrueba
            {
                NumeroFactura = "F001-0002",
                Fecha = DateTime.Today,
                Cliente = "María López",
                TipoOrden = "Delivery",
                Mesa = null,

                Subtotal = 206.20m,
                Descuento = 10.20m,
                Total = 196.00m,

                MetodoPago = "Tarjeta",
                Estado = "Pagada",

                Detalles = new List<DetalleFacturaPrueba>
                {
                    new DetalleFacturaPrueba
                    {
                        Producto = "Pargo Frito Especial de la Casa con Salsa de Mariscos",
                        Cantidad = 1,
                        Precio = 150.00m
                    },

                    new DetalleFacturaPrueba
                    {
                        Producto = "Limonada",
                        Cantidad = 2,
                        Precio = 28.10m
                    }
                }
            });

            // Factura 3
            _facturas.Add(new FacturaPrueba
            {
                NumeroFactura = "F001-0003",
                Fecha = DateTime.Today.AddDays(-1),
                Cliente = "Carlos Rodríguez",
                TipoOrden = "Local",
                Mesa = 3,

                Subtotal = 138.50m,
                Descuento = 0.00m,
                Total = 138.50m,

                MetodoPago = "Efectivo",
                Estado = "Anulada",

                Detalles = new List<DetalleFacturaPrueba>
                {
                    new DetalleFacturaPrueba
                    {
                        Producto = "Ceviche Mixto",
                        Cantidad = 1,
                        Precio = 120.00m
                    },

                    new DetalleFacturaPrueba
                    {
                        Producto = "Coca Cola",
                        Cantidad = 1,
                        Precio = 18.50m
                    }
                }
            });

            // Factura 4
            _facturas.Add(new FacturaPrueba
            {
                NumeroFactura = "F001-0004",
                Fecha = DateTime.Today.AddDays(-2),
                Cliente = "Consumidor Final",
                TipoOrden = "Local",
                Mesa = 1,

                Subtotal = 280.00m,
                Descuento = 4.25m,
                Total = 275.75m,

                MetodoPago = "Efectivo",
                Estado = "Pagada",

                Detalles = new List<DetalleFacturaPrueba>
                {
                    new DetalleFacturaPrueba
                    {
                        Producto = "Camarones al Ajillo",
                        Cantidad = 2,
                        Precio = 100.00m
                    },

                    new DetalleFacturaPrueba
                    {
                        Producto = "Tostones",
                        Cantidad = 1,
                        Precio = 80.00m
                    }
                }
            });

            // Factura 5
            _facturas.Add(new FacturaPrueba
            {
                NumeroFactura = "F001-0005",
                Fecha = DateTime.Today.AddDays(-3),
                Cliente = "Ana Martínez",
                TipoOrden = "Delivery",
                Mesa = null,

                Subtotal = 489.60m,
                Descuento = 0.00m,
                Total = 489.60m,

                MetodoPago = "Transferencia",
                Estado = "Pagada",

                Detalles = new List<DetalleFacturaPrueba>
                {
                    new DetalleFacturaPrueba
                    {
                        Producto = "Ceviche Mixto",
                        Cantidad = 3,
                        Precio = 120.50m
                    },

                    new DetalleFacturaPrueba
                    {
                        Producto = "Camarones al Ajillo",
                        Cantidad = 1,
                        Precio = 100.00m
                    },

                    new DetalleFacturaPrueba
                    {
                        Producto = "Limonada",
                        Cantidad = 1,
                        Precio = 28.10m
                    }
                }
            });

            // Factura 6
            _facturas.Add(new FacturaPrueba
            {
                NumeroFactura = "F001-0006",
                Fecha = DateTime.Today.AddDays(-4),
                Cliente = "Pedro Gómez",
                TipoOrden = "Local",
                Mesa = 6,

                Subtotal = 150.00m,
                Descuento = 0.00m,
                Total = 150.00m,

                MetodoPago = "Tarjeta",
                Estado = "Anulada",

                Detalles = new List<DetalleFacturaPrueba>
                {
                    new DetalleFacturaPrueba
                    {
                        Producto = "Pargo Frito Especial de la Casa con Salsa de Mariscos",
                        Cantidad = 1,
                        Precio = 150.00m
                    }
                }
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

        #region MesaggeBoxes para los Botones
        /// <summary>
        /// Muestra el detalle de la factura seleccionada en un panel dentro del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            DataGridViewRow fila =
                dgvFacturas.SelectedRows[0];

            FacturaPrueba factura =
                fila.DataBoundItem as FacturaPrueba;

            if (factura == null)
            {
                FrmMessageBox.Show(
                    "No fue posible obtener la información de la factura seleccionada.",
                    "Error",
                    MessageType.Error);

                return;
            }

            AbrirDetalleFactura(factura);
        }

        /// <summary>
        /// Muestra una vista previa de impresión del comprobante de la factura seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            _facturaImprimiendo = factura;

            using (PrintPreviewDialog vistaPrevia = new PrintPreviewDialog())
            {
                vistaPrevia.Document = _documentoImpresion;
                vistaPrevia.Width = 900;
                vistaPrevia.Height = 700;

                vistaPrevia.ShowDialog();
            }
        }

        /// <summary>
        /// Permite anular la factura seleccionada, cambiando su estado a "Anulada" y mostrando un mensaje de confirmación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        #endregion

        #region Metodos y Funcionamiento para Ver Detalle de Facturas
        /// <summary>
        /// Centra el panel de detalle de factura dentro del contenedor.
        /// </summary>
        private void CentrarDetalleFactura()
        {
            pnlDetalleFactura.Left =
                (pnlDetalleFacturaContainer.Width -
                 pnlDetalleFactura.Width) / 2;

            pnlDetalleFactura.Top =
                (pnlDetalleFacturaContainer.Height -
                 pnlDetalleFactura.Height) / 2;
        }

        /// <summary>
        /// Abre el panel de detalle de factura y muestra la información de la factura seleccionada.
        /// </summary>
        /// <param name="factura"></param>
        private void AbrirDetalleFactura(FacturaPrueba factura)
        {
            lblNumeroFacturaDetalle.Text = factura.NumeroFactura;
            lblFechaDetalle.Text = factura.Fecha.ToString("dd/MM/yyyy");
            lblClienteDetalle.Text = factura.Cliente;
            lblTipoOrdenDetalle.Text = factura.TipoOrden;

            lblTotalFactura.Text =
                factura.Total.ToString(
                    "C",
                    System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            lblEstadoDetalle.Text = factura.Estado;

            pnlDetalleFacturaContainer.Visible = true;
            pnlDetalleFactura.Visible = true;

            pnlDetalleFactura.BringToFront();

            CentrarDetalleFactura();
        }

        /// <summary>
        /// Cierra el panel de detalle de factura y lo oculta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrarDetalle_Click(object sender, EventArgs e)
        {
            pnlDetalleFactura.Visible = false;
            pnlDetalleFacturaContainer.Visible = false;
        }
        #endregion

        #region Metodos y Funcionamiento para Imprimir Facturas
        /// <summary>
        /// Genera el contenido de la página de impresión para la factura seleccionada, incluyendo el título, detalles de la factura y total.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DocumentoImpresion_PrintPage(object sender,PrintPageEventArgs e)
        {
            if (_facturaImprimiendo == null)
                return;

            Graphics g = e.Graphics;

            using Font fuenteTitulo = new Font("Segoe UI", 16, FontStyle.Bold);

            using Font fuenteNormal = new Font("Segoe UI", 10, FontStyle.Regular);

            using Font fuenteNegrita = new Font("Segoe UI", 10, FontStyle.Bold);

            Brush pincel = Brushes.Black;

            float x = 70;
            float y = 60;
            float espacio = 30;

            g.DrawString(
                "OCEAN DESK",
                fuenteTitulo,
                pincel,
                x,
                y);

            y += 45;

            g.DrawString(
                "DETALLE DE FACTURA",
                fuenteNegrita,
                pincel,
                x,
                y);

            y += espacio + 10;

            g.DrawString(
                $"Factura: {_facturaImprimiendo.NumeroFactura}",
                fuenteNormal,
                pincel,
                x,
                y);

            y += espacio;

            g.DrawString(
                $"Fecha: {_facturaImprimiendo.Fecha:dd/MM/yyyy}",
                fuenteNormal,
                pincel,
                x,
                y);

            y += espacio;

            g.DrawString(
                $"Cliente: {_facturaImprimiendo.Cliente}",
                fuenteNormal,
                pincel,
                x,
                y);

            y += espacio;

            g.DrawString(
                $"Tipo de orden: {_facturaImprimiendo.TipoOrden}",
                fuenteNormal,
                pincel,
                x,
                y);

            y += 45;

            g.DrawLine(
                Pens.Black,
                x,
                y,
                650,
                y);

            y += 30;

            g.DrawString(
                "TOTAL",
                fuenteNegrita,
                pincel,
                x,
                y);

            g.DrawString(
                _facturaImprimiendo.Total.ToString(
                    "C",
                    System.Globalization.CultureInfo.GetCultureInfo("es-NI")),
                fuenteNegrita,
                pincel,
                500,
                y);

            y += 45;

            g.DrawString(
                $"Estado: {_facturaImprimiendo.Estado}",
                fuenteNormal,
                pincel,
                x,
                y);

            y += 60;

            g.DrawString(
                "Gracias por su preferencia.",
                fuenteNormal,
                pincel,
                x,
                y);
        }

        #endregion
    }
}
