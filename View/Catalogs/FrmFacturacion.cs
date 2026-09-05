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

        private FacturaPrueba _facturaSeleccionada; // Variable para almacenar la factura seleccionada en el DataGridView

        private FacturaPrueba _facturaImprimiendo; // Variable para almacenar la factura que se está imprimiendo

        private readonly PrintDocument _documentoImpresion = new PrintDocument(); // Variable para manejar la impresión

        public FrmFacturacion()
        {
            InitializeComponent();

            dgvFacturas.AutoGenerateColumns = false;

            _documentoImpresion.PrintPage += DocumentoImpresion_PrintPage;

            ConfigurarColumnasFacturas(); // Configuramos las columnas del dgv de facturas

            ConfigurarColumnasDetalleFactura();// Configuramos las columnas del dgv de detalle de factura

            CargarFacturasPrueba(); //Cargamos las Facturas
            MostrarFacturas(); //Se mjuestran las facturas en el dgv
            ActualizarEstadoBotones(); //Comportamiento entre botones y dgv
            ConfigurarFiltroEstado();// Configuramos el filtro de estado
            ConfigurarFiltroFechas();// Configuramos el filtro de fechas
        }

        #region Metodos para Cargar y Mostrar Facturas de Prueba
        /// <summary>
        /// Muestra las facturas en el DataGridView, restableciendo la selección y actualizando el estado de los botones según la factura seleccionada.
        /// </summary>
        private void MostrarFacturas()
        {
            _facturaSeleccionada = null;

            dgvFacturas.DataSource = null;
            dgvFacturas.DataSource = _facturas;

            dgvFacturas.ClearSelection();
            dgvFacturas.CurrentCell = null;

            ActualizarEstadoBotones();
        }

        /// <summary>
        /// Configura las columnas del DataGridView que muestra las facturas, estableciendo las propiedades de enlace de datos y el formato de visualización.
        /// </summary>
        private void ConfigurarColumnasFacturas()
        {
            colFactura.DataPropertyName = "NumeroFactura";
            colFecha.DataPropertyName = "Fecha";
            colCliente.DataPropertyName = "Cliente";
            colTipo.DataPropertyName = "TipoOrden";
            colTotal.DataPropertyName = "Total";
            colEstado.DataPropertyName = "Estado";

            colFecha.DefaultCellStyle.Format = "dd/MM/yyyy";

            colTotal.DefaultCellStyle.Format = "C2";
        }

        /// <summary>
        /// Carga una lista de facturas de prueba con datos ficticios para mostrar en el DataGridView.
        /// </summary>
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
        /// <summary>
        /// Actualiza el estado de los botones (habilitado/deshabilitado) según la selección de facturas en el DataGridView y el estado de la factura seleccionada.
        /// </summary>
        private void ActualizarEstadoBotones()//Reacción de los botones al tipo de factura
        {
            bool hayFactura = _facturaSeleccionada != null;

            bool puedeAnular =
                hayFactura &&
                !string.Equals(
                    _facturaSeleccionada.Estado,
                    "Anulada",
                    StringComparison.OrdinalIgnoreCase);

            ConfigurarEstadoBoton(
                btnVerDetalle,
                hayFactura,
                _colorBotonNormal,
                _colorBotonTexto);

            ConfigurarEstadoBoton(
                btnImprimir,
                hayFactura,
                _colorBotonNormal,
                _colorBotonTexto);

            ConfigurarEstadoBoton(
                btnAnular,
                puedeAnular,
                _colorAnularNormal,
                _colorAnularTexto);
        }

        /// <summary>
        /// Evento que se dispara al hacer clic en una celda del DataGridView de facturas, seleccionando la factura correspondiente y actualizando el estado de los botones según la selección.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila =
                dgvFacturas.Rows[e.RowIndex];

            _facturaSeleccionada =
                fila.DataBoundItem as FacturaPrueba;

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

        /// <summary>
        /// Configura el estado de un botón, habilitándolo o deshabilitándolo y aplicando los colores correspondientes según su estado.
        /// </summary>
        /// <param name="boton"></param>
        /// <param name="habilitado"></param>
        /// <param name="colorNormal"></param>
        /// <param name="colorTexto"></param>

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

        /// <summary>
        /// Evento que se dispara durante el formateo de celdas en el DataGridView de facturas, aplicando estilos de color y fuente según el estado de la factura (Pagada o Anulada).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFacturas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (dgvFacturas.Columns[e.ColumnIndex].Name != "colEstado")
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

        /// <summary>
        /// Filtra las facturas en el DataGridView según el texto de búsqueda, las fechas seleccionadas y el estado seleccionado en los filtros, actualizando la vista con las facturas que cumplen los criterios.
        /// </summary>
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

        #region Funcionamiento para los Botones
        /// <summary>
        /// Muestra el detalle de la factura seleccionada en un panel dentro del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerDetalle_Click(object sender, EventArgs e)
        {
            if (_facturaSeleccionada == null)
            {
                FrmMessageBox.Show(
                    "Seleccione una factura para consultar su detalle.",
                    "Factura no seleccionada",
                    MessageType.Warning);

                return;
            }

            AbrirDetalleFactura(_facturaSeleccionada);
        }

        /// <summary>
        /// Muestra una vista previa de impresión del comprobante de la factura seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            if (_facturaSeleccionada == null)
            {
                FrmMessageBox.Show(
                    "Seleccione una factura para imprimir el comprobante.",
                    "Factura no seleccionada",
                    MessageType.Warning);

                return;
            }

            _facturaImprimiendo =
                _facturaSeleccionada;

            using (PrintPreviewDialog vistaPrevia =
                   new PrintPreviewDialog())
            {
                vistaPrevia.Document =
                    _documentoImpresion;

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
            if (_facturaSeleccionada == null)
            {
                FrmMessageBox.Show(
                    "Seleccione una factura para realizar la anulación.",
                    "Factura no seleccionada",
                    MessageType.Warning);

                return;
            }

            if (_facturaSeleccionada.Estado == "Anulada")
            {
                FrmMessageBox.Show(
                    "La factura seleccionada ya se encuentra anulada.",
                    "Factura anulada",
                    MessageType.Warning);

                return;
            }

            DialogResult resultado =
                FrmMessageBox.Show(
                    $"¿Desea anular la factura " +
                    $"{_facturaSeleccionada.NumeroFactura}?",
                    "Confirmar anulación",
                    MessageType.Confirmation);

            if (resultado != DialogResult.Yes)
                return;

            _facturaSeleccionada.Estado =
                "Anulada";

            MostrarFacturas();

            _facturaSeleccionada = null;

            FrmMessageBox.Show(
                "La factura ha sido anulada correctamente.",
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

            lblMesaDetalle.Text = factura.Mesa.HasValue ? $"Mesa {factura.Mesa.Value:00}" : "No aplica";

            lblEstadoDetalle.Text = factura.Estado;

            lblSubtotalDetalle.Text = factura.Subtotal.ToString(
                    "C",
                    System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            lblDescuentoDetalle.Text = factura.Descuento.ToString(
                    "C",
                    System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            lblTotalDetalle.Text = factura.Total.ToString(
                    "C",
                    System.Globalization.CultureInfo.GetCultureInfo("es-NI"));

            lblMetodoPagoDetalle.Text = factura.MetodoPago;

            dgvDetalleFactura.DataSource = null;
            dgvDetalleFactura.DataSource = factura.Detalles;

            dgvDetalleFactura.ClearSelection();

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

        /// <summary>
        /// Configura las columnas del DataGridView que muestra los detalles de la factura, estableciendo las propiedades de enlace de datos y el formato de visualización.
        /// </summary>
        private void ConfigurarColumnasDetalleFactura()
        {
            dgvDetalleFactura.AutoGenerateColumns = false;

            colDetalleProducto.DataPropertyName = "Producto";
            colDetalleCantidad.DataPropertyName = "Cantidad";
            colDetallePrecio.DataPropertyName = "Precio";
            colDetalleSubtotal.DataPropertyName = "Subtotal";

            colDetalleProducto.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            colDetalleCantidad.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            colDetallePrecio.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            colDetalleSubtotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            colDetallePrecio.DefaultCellStyle.Format = "C2";
            colDetalleSubtotal.DefaultCellStyle.Format = "C2";
        }
        #endregion

        #region Metodos y Funcionamiento para Imprimir Facturas
        /// <summary>
        /// Genera el contenido de la página de impresión para la factura seleccionada, incluyendo el título, detalles de la factura y total.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DocumentoImpresion_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (_facturaImprimiendo == null)
                return;

            Graphics g = e.Graphics;

            using Font fuenteTitulo =
                new Font("Segoe UI", 18, FontStyle.Bold);

            using Font fuenteSubtitulo =
                new Font("Segoe UI", 11, FontStyle.Bold);

            using Font fuenteNormal =
                new Font("Segoe UI", 9, FontStyle.Regular);

            using Font fuenteNegrita =
                new Font("Segoe UI", 9, FontStyle.Bold);

            Brush pincel = Brushes.Black;

            float x = 50;
            float y = 50;

            float ancho = e.PageBounds.Width - 100;

            /* string moneda =
                 System.Globalization.CultureInfo
                     .GetCultureInfo("es-NI")
                     .Name;*/

            // ==========================================
            // ENCABEZADO
            // ==========================================

            g.DrawString(
                "OCEAN DESK",
                fuenteTitulo,
                pincel,
                x,
                y);

            y += 35;

            g.DrawString(
                "FACTURA",
                fuenteSubtitulo,
                pincel,
                x,
                y);

            y += 35;

            g.DrawString(
                $"Factura: {_facturaImprimiendo.NumeroFactura}",
                fuenteNormal,
                pincel,
                x,
                y);

            y += 22;

            g.DrawString(
                $"Fecha: {_facturaImprimiendo.Fecha:dd/MM/yyyy}",
                fuenteNormal,
                pincel,
                x,
                y);

            y += 22;

            g.DrawString(
                $"Cliente: {_facturaImprimiendo.Cliente}",
                fuenteNormal,
                pincel,
                x,
                y);

            y += 22;

            g.DrawString(
                $"Tipo de orden: {_facturaImprimiendo.TipoOrden}",
                fuenteNormal,
                pincel,
                x,
                y);

            y += 22;

            string mesaTexto =
                _facturaImprimiendo.Mesa.HasValue
                    ? $"Mesa {_facturaImprimiendo.Mesa.Value:00}"
                    : "No aplica";

            g.DrawString(
                $"Mesa: {mesaTexto}",
                fuenteNormal,
                pincel,
                x,
                y);

            y += 30;

            // ==========================================
            // PRODUCTOS
            // ==========================================

            g.DrawLine(
                Pens.Black,
                x,
                y,
                x + ancho,
                y);

            y += 12;

            g.DrawString(
                "Producto",
                fuenteNegrita,
                pincel,
                x,
                y);

            g.DrawString(
                "Cant.",
                fuenteNegrita,
                pincel,
                x + 300,
                y);

            g.DrawString(
                "Precio",
                fuenteNegrita,
                pincel,
                x + 365,
                y);

            g.DrawString(
                "Subtotal",
                fuenteNegrita,
                pincel,
                x + 445,
                y);

            y += 25;

            g.DrawLine(
                Pens.Black,
                x,
                y,
                x + ancho,
                y);

            y += 10;

            foreach (DetalleFacturaPrueba detalle
                     in _facturaImprimiendo.Detalles)
            {
                g.DrawString(
                    detalle.Producto,
                    fuenteNormal,
                    pincel,
                    x,
                    y);

                g.DrawString(
                    detalle.Cantidad.ToString(),
                    fuenteNormal,
                    pincel,
                    x + 300,
                    y);

                g.DrawString(
                    detalle.Precio.ToString(
                        "C2",
                        System.Globalization.CultureInfo
                            .GetCultureInfo("es-NI")),
                    fuenteNormal,
                    pincel,
                    x + 360,
                    y);

                g.DrawString(
                    detalle.Subtotal.ToString(
                        "C2",
                        System.Globalization.CultureInfo
                            .GetCultureInfo("es-NI")),
                    fuenteNormal,
                    pincel,
                    x + 445,
                    y);

                y += 25;
            }

            // ==========================================
            // TOTALES
            // ==========================================

            y += 10;

            g.DrawLine(
                Pens.Black,
                x,
                y,
                x + ancho,
                y);

            y += 25;

            g.DrawString(
                "Subtotal:",
                fuenteNegrita,
                pincel,
                x + 300,
                y);

            g.DrawString(
                _facturaImprimiendo.Subtotal.ToString(
                    "C2",
                    System.Globalization.CultureInfo
                        .GetCultureInfo("es-NI")),
                fuenteNormal,
                pincel,
                x + 445,
                y);

            y += 25;

            g.DrawString(
                "Descuento:",
                fuenteNegrita,
                pincel,
                x + 300,
                y);

            g.DrawString(
                _facturaImprimiendo.Descuento.ToString(
                    "C2",
                    System.Globalization.CultureInfo
                        .GetCultureInfo("es-NI")),
                fuenteNormal,
                pincel,
                x + 445,
                y);

            y += 30;

            g.DrawString(
                "TOTAL:",
                fuenteNegrita,
                pincel,
                x + 300,
                y);

            g.DrawString(
                _facturaImprimiendo.Total.ToString(
                    "C2",
                    System.Globalization.CultureInfo
                        .GetCultureInfo("es-NI")),
                fuenteNegrita,
                pincel,
                x + 445,
                y);

            // ==========================================
            // PAGO Y ESTADO
            // ==========================================

            y += 35;

            g.DrawString(
                $"Método de pago: {_facturaImprimiendo.MetodoPago}",
                fuenteNormal,
                pincel,
                x,
                y);

            y += 25;

            g.DrawString(
                $"Estado: {_facturaImprimiendo.Estado}",
                fuenteNegrita,
                pincel,
                x,
                y);

            y += 45;

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
