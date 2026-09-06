using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.UI.MessageBox;
using Ocean_Desk_dv.UI.Models;
using Ocean_Desk_dv.View.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocean_Desk_dv.Presenters
{
    /// <summary>
    /// Contiene la lógica de negocio del módulo de Facturación.
    /// Se encarga de consultar ventas/facturas, generar las facturas pendientes
    /// y procesar anulaciones mediante Entity Framework Core.
    /// </summary>
    public class FacturacionPresenter
    {
        private readonly IFacturacionView _view;

        public FacturacionPresenter(IFacturacionView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));

            _view.VerDetalleClicked += OnVerDetalleClicked;
            _view.AnularFacturaClicked += OnAnularFacturaClicked;

            CargarFacturas();
        }

        /// <summary>
        /// Consulta las facturas existentes y genera automáticamente las facturas
        /// para las ventas completadas que todavía no poseen una factura.
        /// </summary>
        public void CargarFacturas()
        {
            try
            {
                GenerarFacturasPendientes();

                using OceanDeskDbContext db = new OceanDeskDbContext();

                List<Invoice> invoices = db.Invoices
                    .AsNoTracking()
                    .Include(i => i.Sale)
                        .ThenInclude(s => s.Customer)
                    .Include(i => i.Sale)
                        .ThenInclude(s => s.Table)
                    .Include(i => i.Sale)
                        .ThenInclude(s => s.SalePayments)
                    .Include(i => i.Sale)
                        .ThenInclude(s => s.SaleDetails)
                            .ThenInclude(d => d.Product)
                    .OrderByDescending(i => i.IssueDateTime)
                    .ToList();

                List<FacturaPrueba> facturas = invoices
                    .Select(MapInvoice)
                    .ToList();

                _view.MostrarFacturas(facturas);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    $"No fue posible cargar las facturas.\n\nDetalle: {ex.Message}",
                    "Error de facturación",
                    MessageType.Error);
            }
        }

        /// <summary>
        /// Genera una factura para cada venta completada que todavía no tenga factura.
        /// Esta operación se mantiene dentro del Presenter porque la vista actual
        /// no cuenta con un botón independiente para "Generar factura".
        /// </summary>
        private void GenerarFacturasPendientes()
        {
            using OceanDeskDbContext db = new OceanDeskDbContext();

            List<Sale> ventasPendientes = db.Sales
                .Where(s =>
                    s.Status == "Completed" &&
                    !db.Invoices.Any(i => i.SaleId == s.SaleId))
                .OrderBy(s => s.SaleId)
                .ToList();

            if (ventasPendientes.Count == 0)
                return;

            int siguienteNumero = ObtenerSiguienteNumeroFactura(db);

            foreach (Sale venta in ventasPendientes)
            {
                Invoice factura = new Invoice
                {
                    SaleId = venta.SaleId,
                    InvoiceNumber = GenerarNumeroFactura(siguienteNumero++),
                    IssueDateTime = DateTime.Now,
                    CustomerId = venta.CustomerId,
                    Subtotal = venta.Subtotal,
                    Discount = venta.Discount,
                    Total = venta.Total,
                    Status = "Issued"
                };

                db.Invoices.Add(factura);
            }

            db.SaveChanges();
        }

        /// <summary>
        /// Obtiene el siguiente consecutivo numérico utilizado para InvoiceNumber.
        /// </summary>
        private int ObtenerSiguienteNumeroFactura(OceanDeskDbContext db)
        {
            List<string> numeros = db.Invoices
                .AsNoTracking()
                .Select(i => i.InvoiceNumber)
                .ToList();

            int maximo = 0;

            foreach (string numero in numeros)
            {
                if (string.IsNullOrWhiteSpace(numero))
                    continue;

                string parteNumerica = new string(
                    numero.Reverse()
                        .TakeWhile(char.IsDigit)
                        .Reverse()
                        .ToArray());

                if (int.TryParse(parteNumerica, out int valor) && valor > maximo)
                {
                    maximo = valor;
                }
            }

            return maximo + 1;
        }

        private static string GenerarNumeroFactura(int numero)
        {
            return $"F001-{numero:0000}";
        }

        /// <summary>
        /// Consulta y muestra el detalle completo de la factura seleccionada.
        /// </summary>
        private void OnVerDetalleClicked(object? sender, EventArgs e)
        {
            string numeroFactura = _view.NumeroFacturaSeleccionada;

            if (string.IsNullOrWhiteSpace(numeroFactura))
            {
                _view.MostrarMensaje(
                    "Seleccione una factura para consultar su detalle.",
                    "Factura no seleccionada",
                    MessageType.Warning);
                return;
            }

            try
            {
                using OceanDeskDbContext db = new OceanDeskDbContext();

                Invoice? invoice = db.Invoices
                    .AsNoTracking()
                    .Include(i => i.Sale)
                        .ThenInclude(s => s.Customer)
                    .Include(i => i.Sale)
                        .ThenInclude(s => s.Table)
                    .Include(i => i.Sale)
                        .ThenInclude(s => s.SalePayments)
                    .Include(i => i.Sale)
                        .ThenInclude(s => s.SaleDetails)
                            .ThenInclude(d => d.Product)
                    .FirstOrDefault(i => i.InvoiceNumber == numeroFactura);

                if (invoice == null)
                {
                    _view.MostrarMensaje(
                        "No se encontró la factura seleccionada en la base de datos.",
                        "Factura no encontrada",
                        MessageType.Warning);
                    return;
                }

                _view.MostrarDetalleFactura(MapInvoice(invoice));
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    $"No fue posible consultar el detalle.\n\nDetalle: {ex.Message}",
                    "Error de facturación",
                    MessageType.Error);
            }
        }

        /// <summary>
        /// Anula la factura seleccionada estableciendo el estado Voided
        /// y registrando los datos de anulación.
        /// </summary>
        private void OnAnularFacturaClicked(object? sender, EventArgs e)
        {
            string numeroFactura = _view.NumeroFacturaSeleccionada;

            if (string.IsNullOrWhiteSpace(numeroFactura))
            {
                _view.MostrarMensaje(
                    "Seleccione una factura para realizar la anulación.",
                    "Factura no seleccionada",
                    MessageType.Warning);
                return;
            }

            try
            {
                using OceanDeskDbContext db = new OceanDeskDbContext();

                Invoice? invoice = db.Invoices
                    .FirstOrDefault(i => i.InvoiceNumber == numeroFactura);

                if (invoice == null)
                {
                    _view.MostrarMensaje(
                        "No se encontró la factura seleccionada en la base de datos.",
                        "Factura no encontrada",
                        MessageType.Warning);
                    return;
                }

                if (invoice.Status == "Voided")
                {
                    _view.MostrarMensaje(
                        "La factura seleccionada ya se encuentra anulada.",
                        "Factura anulada",
                        MessageType.Warning);
                    return;
                }

                invoice.Status = "Voided";
                invoice.CancellationDateTime = DateTime.Now;
                invoice.CancellationReason = "Anulación realizada desde el módulo de Facturación.";
                invoice.CancellationUserId = _view.UsuarioId;

                db.SaveChanges();

                _view.MostrarMensaje(
                    $"La factura {invoice.InvoiceNumber} ha sido anulada correctamente.",
                    "Anulación realizada",
                    MessageType.Information);

                _view.RefrescarFacturas();
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    $"No fue posible anular la factura.\n\nDetalle: {ex.InnerException?.Message ?? ex.Message}",
                    "Error de base de datos",
                    MessageType.Error);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    $"Ocurrió un error inesperado.\n\nDetalle: {ex.Message}",
                    "Error de facturación",
                    MessageType.Error);
            }
        }

        private static FacturaPrueba MapInvoice(Invoice invoice)
        {
            Sale sale = invoice.Sale;

            string cliente = sale.Customer == null
                ? "Consumidor Final"
                : $"{sale.Customer.FirstName} {sale.Customer.LastName}".Trim();

            string metodoPago = sale.SalePayments
                .OrderByDescending(p => p.PaymentDateTime)
                .Select(p => TraducirMetodoPago(p.PaymentMethod))
                .FirstOrDefault()
                ?? "No registrado";

            string estado = invoice.Status switch
            {
                "Voided" => "Anulada",
                _ => "Pagada"
            };

            return new FacturaPrueba
            {
                NumeroFactura = invoice.InvoiceNumber,
                Fecha = invoice.IssueDateTime,
                Cliente = cliente,
                TipoOrden = TraducirTipoOrden(sale.OrderType),
                Mesa = sale.Table?.TableNumber,
                Subtotal = invoice.Subtotal,
                Descuento = invoice.Discount,
                Total = invoice.Total,
                MetodoPago = metodoPago,
                Estado = estado,
                Detalles = sale.SaleDetails
                    .OrderBy(d => d.SaleDetailId)
                    .Select(d => new DetalleFacturaPrueba
                    {
                        Producto = d.Product?.ProductName ?? "Producto no disponible",
                        Cantidad = ConvertirCantidad(d.Quantity),
                        Precio = d.UnitPrice
                    })
                    .ToList()
            };
        }

        private static int ConvertirCantidad(decimal cantidad)
        {
            if (cantidad <= 0)
                return 0;

            return decimal.ToInt32(decimal.Round(cantidad, 0, MidpointRounding.AwayFromZero));
        }

        private static string TraducirMetodoPago(string metodoPago)
        {
            return metodoPago switch
            {
                "Cash" => "Efectivo",
                "Card" => "Tarjeta",
                "Transfer" => "Transferencia",
                _ => metodoPago
            };
        }

        private static string TraducirTipoOrden(string tipoOrden)
        {
            return tipoOrden switch
            {
                "Local" => "Local",
                "Delivery" => "Delivery",
                _ => tipoOrden
            };
        }
    }
}
