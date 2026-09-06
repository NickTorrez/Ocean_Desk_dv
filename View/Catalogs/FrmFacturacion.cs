using Ocean_Desk_dv.Presenters;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.UI.Models;
using Ocean_Desk_dv.View.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ocean_Desk_dv.UI.Catalogs
{
    public partial class FrmFacturacion : Form, IFacturacionView
    {
        private readonly List<FacturaPrueba> _facturas = new List<FacturaPrueba>(); //Declaramos una lista para las facturas

        private FacturaPrueba _facturaSeleccionada; // Variable para almacenar la factura seleccionada en el DataGridView

        private FacturaPrueba _facturaImprimiendo; // Variable para almacenar la factura que se está imprimiendo

        private readonly PrintDocument _documentoImpresion = new PrintDocument(); // Variable para manejar la impresión

        private readonly int _usuarioId; // Variable para almacenar el ID del usuario que está operando el módulo

        private FacturacionPresenter? _presenter; // Variable para almacenar la instancia del presentador que maneja la lógica de negocio

        #region Constructor

        public FrmFacturacion() : this(1)
        {
        }

        public FrmFacturacion(int usuarioId)
        {
            InitializeComponent();

            _usuarioId = usuarioId;

            dgvFacturas.AutoGenerateColumns = false;

            _documentoImpresion.PrintPage += DocumentoImpresion_PrintPage;

            ConfigurarColumnasFacturas(); // Configura las columnas del DataGridView de facturas
            ConfigurarColumnasDetalleFactura(); // Configura las columnas del DataGridView de detalle de factura
            ConfigurarFiltroEstado(); // Configura el ComboBox de estado de facturas
            ConfigurarFiltroFechas();// Configura los DateTimePickers de fecha desde y fecha hasta

            dgvDetalleFactura.CellFormatting += dgvDetalleFactura_CellFormatting;

            _presenter = new FacturacionPresenter(this);

            ActualizarEstadoBotones();
        }
        #endregion

        #region Implementacion de IFacturacionView
        public string NumeroFacturaSeleccionada => _facturaSeleccionada?.NumeroFactura ?? string.Empty;

        public int UsuarioId => _usuarioId;

        public event EventHandler? VerDetalleClicked;

        public event EventHandler? AnularFacturaClicked;

        /// <summary>
        /// Recibe las facturas reales consultadas por el Presenter y las carga
        /// en la lista utilizada por el DataGridView.
        /// </summary>
        public void MostrarFacturas(List<FacturaPrueba> facturas)
        {
            _facturas.Clear();
            _facturas.AddRange(facturas);

            _facturaSeleccionada = null;

            FiltrarFacturas();
            ActualizarEstadoBotones();
        }

        /// <summary>
        /// Muestra el detalle proporcionado por el Presenter.
        /// </summary>
        public void MostrarDetalleFactura(FacturaPrueba factura)
        {
            AbrirDetalleFactura(factura);
        }

        /// <summary>
        /// Muestra un mensaje utilizando el MessageBox personalizado de Ocean Desk.
        /// </summary>
        public void MostrarMensaje(
            string mensaje,
            string titulo,
            MessageType tipo)
        {
            FrmMessageBox.Show(
                mensaje,
                titulo,
                tipo);
        }

        /// <summary>
        /// Solicita al Presenter volver a consultar las facturas desde SQL Server.
        /// </summary>
        public void RefrescarFacturas()
        {
            _presenter?.CargarFacturas();
        }

        #endregion

        #region Configuración de la Tabla y Filtros
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
        }

        /// <summary>
        /// Configura el ComboBox de estado de facturas con las opciones "Todos", "Pagada" y "Anulada", estableciendo la opción predeterminada en "Todos".
        /// </summary>
        private void ConfigurarFiltroEstado()
        {
            cmbEstado.Items.Clear();

            cmbEstado.Items.Add("Todos");
            cmbEstado.Items.Add("Pagada");
            cmbEstado.Items.Add("Anulada");

            cmbEstado.SelectedIndex = 0;
        }

        /// <summary>
        /// Configura los DateTimePickers de fecha desde y fecha hasta, estableciendo la fecha desde en 30 días atrás y la fecha hasta en la fecha actual.
        /// </summary>
        private void ConfigurarFiltroFechas()
        {
            dtpFechaDesde.Value = DateTime.Today.AddDays(-30);

            dtpFechaHasta.Value = DateTime.Today;
        }

        /// <summary>
        /// Filtra las facturas en el DataGridView según el texto de búsqueda, las fechas seleccionadas y el estado seleccionado en los filtros, actualizando la vista con las facturas que cumplen los criterios.
        /// </summary>
        private void FiltrarFacturas()
        {
            string texto = txtBuscar.Text.Trim();

            DateTime fechaDesde = dtpFechaDesde.Value.Date;

            DateTime fechaHasta = dtpFechaHasta.Value.Date;

            string estadoSeleccionado = cmbEstado.SelectedItem?.ToString() ?? "Todos";

            List<FacturaPrueba> facturasFiltradas = _facturas
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

            dgvFacturas.ClearSelection();
            dgvFacturas.CurrentCell = null;

            ActualizarEstadoBotones();
        }

        /// <summary>
        /// Evento que se dispara cuando cambia el texto en el TextBox de búsqueda, llamando al método FiltrarFacturas para actualizar la vista según el texto ingresado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBuscar_TextChanged(object? sender, EventArgs e)
        {
            FiltrarFacturas();
        }

        /// <summary>
        /// Evento que se dispara cuando cambia la selección en el ComboBox de estado, llamando al método FiltrarFacturas para actualizar la vista según el estado seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbEstado_SelectedIndexChanged(object? sender, EventArgs e)
        {
            FiltrarFacturas();
        }

        /// <summary>
        /// Evento que se dispara cuando cambia la fecha en el DateTimePicker de fecha desde, llamando al método FiltrarFacturas para actualizar la vista según las fechas seleccionadas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpFechaDesde_ValueChanged(object? sender, EventArgs e)
        {
            FiltrarFacturas();
        }

        /// <summary>
        /// Evento que se dispara cuando cambia la fecha en el DateTimePicker de fecha hasta, llamando al método FiltrarFacturas para actualizar la vista según las fechas seleccionadas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpFechaHasta_ValueChanged(object? sender, EventArgs e)
        {
            FiltrarFacturas();
        }
        #endregion

        #region Seleccion y Estado de Botones
        /// <summary>
        /// Evento que se dispara al hacer clic en una celda del DataGridView de facturas, seleccionando la factura correspondiente y actualizando el estado de los botones según la selección.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFacturas_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvFacturas.Rows[e.RowIndex];

            _facturaSeleccionada = fila.DataBoundItem as FacturaPrueba;

            ActualizarEstadoBotones();
        }

        /// <summary>
        /// Actualiza el estado de los botones (habilitado/deshabilitado) según la selección de facturas en el DataGridView y el estado de la factura seleccionada.
        /// </summary>
        private void ActualizarEstadoBotones()
        {
            bool hayFactura = _facturaSeleccionada != null;

            bool puedeAnular =
                hayFactura &&
                !string.Equals(
                    _facturaSeleccionada?.Estado,
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
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            string nombreColumna = dgvFacturas.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "colTotal" && e.Value is decimal total)
            {
                e.Value = FormatearMoneda(total);
                e.FormattingApplied = true;
                return;
            }

            if (nombreColumna != "colEstado" || e.Value == null)
            {
                return;
            }

            string estado = e.Value.ToString() ?? string.Empty;

            if (estado == "Pagada")
            {
                e.CellStyle.ForeColor = Color.FromArgb(42, 122, 82);

                e.CellStyle.Font =
                    new Font(
                        dgvFacturas.Font,
                        FontStyle.Bold);
            }
            else if (estado == "Anulada")
            {
                e.CellStyle.ForeColor = Color.FromArgb(163, 61, 61);

                e.CellStyle.Font =
                    new Font(
                        dgvFacturas.Font,
                        FontStyle.Bold);
            }
        }
        #endregion

        #region Funcionamiento para los Botones
        /// <summary>
        /// Muestra el detalle de la factura seleccionada en un panel dentro del formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerDetalle_Click(object? sender, EventArgs e)
        {
            if (_facturaSeleccionada == null)
            {
                MostrarMensaje(
                    "Seleccione una factura para consultar su detalle.",
                    "Factura no seleccionada",
                    MessageType.Warning);

                return;
            }

            VerDetalleClicked?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Muestra una vista previa de impresión del comprobante de la factura seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImprimir_Click(object? sender, EventArgs e)
        {
            if (_facturaSeleccionada == null)
            {
                MostrarMensaje(
                    "Seleccione una factura para imprimir el comprobante.",
                    "Factura no seleccionada",
                    MessageType.Warning);

                return;
            }

            _facturaImprimiendo = _facturaSeleccionada;

            using PrintPreviewDialog vistaPrevia = new PrintPreviewDialog
            {
                Document = _documentoImpresion,
                Width = 900,
                Height = 700
            };

            vistaPrevia.ShowDialog();
        }

        /// <summary>
        /// Permite anular la factura seleccionada, cambiando su estado a "Anulada" y mostrando un mensaje de confirmación.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnular_Click(object? sender, EventArgs e)
        {
            if (_facturaSeleccionada == null)
            {
                MostrarMensaje(
                    "Seleccione una factura para realizar la anulación.",
                    "Factura no seleccionada",
                    MessageType.Warning);

                return;
            }

            if (_facturaSeleccionada.Estado == "Anulada")
            {
                MostrarMensaje(
                    "La factura seleccionada ya se encuentra anulada.",
                    "Factura anulada",
                    MessageType.Warning);

                return;
            }

            DialogResult resultado =
                FrmMessageBox.Show(
                    $"¿Desea anular la factura {_facturaSeleccionada.NumeroFactura}?",
                    "Confirmar anulación",
                    MessageType.Confirmation);

            if (resultado != DialogResult.Yes)
                return;

            AnularFacturaClicked?.Invoke(
                this,
                EventArgs.Empty);
        }
        #endregion

        #region Ver Detalle de Facturas
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

            lblSubtotalDetalle.Text = FormatearMoneda(factura.Subtotal);

            lblDescuentoDetalle.Text = FormatearMoneda(factura.Descuento);

            lblTotalDetalle.Text = FormatearMoneda(factura.Total);

            lblMetodoPagoDetalle.Text = factura.MetodoPago;

            dgvDetalleFactura.DataSource = null;
            dgvDetalleFactura.DataSource = factura.Detalles;

            dgvDetalleFactura.ClearSelection();

            pnlDetalleFacturaContainer.Visible = true;
            pnlDetalleFactura.Visible = true;

            pnlDetalleFactura.BringToFront();

            CentrarDetalleFactura();
            CentrarDetalleFactura();
        }

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
        /// Cierra el panel de detalle de factura y lo oculta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrarDetalle_Click(object? sender, EventArgs e)
        {
            pnlDetalleFactura.Visible = false;
            pnlDetalleFacturaContainer.Visible = false;
        }

        /// <summary>
        /// Evento que se dispara durante el formateo de celdas en el DataGridView de detalle de factura, aplicando formato de moneda a las columnas de precio y subtotal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDetalleFactura_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 ||
               e.ColumnIndex < 0)
            {
                return;
            }

            string nombreColumna =
                dgvDetalleFactura.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "colDetallePrecio" &&
                e.Value is decimal precio)
            {
                e.Value = FormatearMoneda(precio);
                e.FormattingApplied = true;
            }
            else if (nombreColumna == "colDetalleSubtotal" &&
                     e.Value is decimal subtotal)
            {
                e.Value = FormatearMoneda(subtotal);
                e.FormattingApplied = true;
            }
        }
        #endregion

        #region Imprimir Facturas
        /// <summary>
        /// Formatea un monto decimal como moneda en formato nicaragüense, agregando el símbolo "C$" y dos decimales.
        /// </summary>
        /// <param name="monto"></param>
        /// <returns></returns>
        private static string FormatearMoneda(decimal monto)
        {
            CultureInfo cultura =
                CultureInfo.GetCultureInfo("es-NI");

            return $"C$ {monto.ToString("N2", cultura)}";
        }

        /// <summary>
        /// Evento que se dispara al imprimir una página del documento, generando el contenido de la factura en la página de impresión utilizando gráficos y fuentes para mostrar los detalles de la factura.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DocumentoImpresion_PrintPage(object? sender, PrintPageEventArgs e)
        {
            if (_facturaImprimiendo == null)
                return;

            Graphics g = e.Graphics;

            using Font fuenteTitulo =
                new Font(
                    "Segoe UI",
                    18,
                    FontStyle.Bold);

            using Font fuenteSubtitulo =
                new Font(
                    "Segoe UI",
                    11,
                    FontStyle.Bold);

            using Font fuenteNormal =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Regular);

            using Font fuenteNegrita =
                new Font(
                    "Segoe UI",
                    9,
                    FontStyle.Bold);

            Brush pincel = Brushes.Black;

            float x = 50;
            float y = 50;

            float ancho =
                e.PageBounds.Width - 100;

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
                    FormatearMoneda(detalle.Precio),
                    fuenteNormal,
                    pincel,
                    x + 360,
                    y);

                g.DrawString(
                    FormatearMoneda(detalle.Subtotal),
                    fuenteNormal,
                    pincel,
                    x + 445,
                    y);

                y += 25;
            }

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
                FormatearMoneda(
                    _facturaImprimiendo.Subtotal),
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
                FormatearMoneda(
                    _facturaImprimiendo.Descuento),
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
                FormatearMoneda(
                    _facturaImprimiendo.Total),
                fuenteNegrita,
                pincel,
                x + 445,
                y);

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

        #region Colores de Botones y Estado de Fcaturas
        private readonly Color _colorBotonNormal = Color.FromArgb(238, 243, 247);

        private readonly Color _colorBotonTexto = Color.FromArgb(8, 31, 63);

        private readonly Color _colorBotonDisabled = Color.FromArgb(232, 236, 239);

        private readonly Color _colorTextoDisabled = Color.FromArgb(155, 163, 170);

        private readonly Color _colorAnularNormal = Color.FromArgb(248, 234, 234);

        private readonly Color _colorAnularTexto = Color.FromArgb(163, 61, 61);
        #endregion

        
    }
}
