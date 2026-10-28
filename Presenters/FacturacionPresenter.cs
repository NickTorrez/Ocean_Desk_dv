using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Services.Interfaces_Services;
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
    public class FacturacionPresenter : IDisposable
    {
        private readonly IFacturacionView _view;
        private readonly IFacturacionRepository _repository;
        private bool _disposed;

        public FacturacionPresenter(
            IFacturacionView view,
            IFacturacionRepository repository)
        {
            _view = view ??
                throw new ArgumentNullException(nameof(view));

            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));

            _view.VerDetalleClicked += OnVerDetalleClicked;
            _view.AnularFacturaClicked += OnAnularFacturaClicked;
        }

        /// <summary>
        /// Carga las facturas desde el repositorio.
        /// La generación automática de facturas pendientes
        /// se conserva en ObtenerFacturas().
        /// </summary>
        public void Inicializar()
        {
            CargarFacturas();
        }

        /// <summary>
        /// Consulta y muestra las facturas registradas.
        /// </summary>
        public void CargarFacturas()
        {
            try
            {
                List<FacturaPrueba> facturas = _repository
                    .ObtenerFacturas()
                    .Select(MapearFactura)
                    .ToList();

                _view.MostrarFacturas(facturas);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    "No fue posible cargar las facturas.\n\n" +
                    $"Detalle: {ex.Message}",
                    "Error de facturación",
                    MessageType.Error);
            }
        }

        /// <summary>
        /// Consulta el detalle de la factura seleccionada.
        /// </summary>
        private void OnVerDetalleClicked(
            object? sender,
            EventArgs e)
        {
            string numeroFactura =
                _view.NumeroFacturaSeleccionada;

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
                FacturaDto? factura =
                    _repository.ObtenerFactura(numeroFactura);

                if (factura is null)
                {
                    _view.MostrarMensaje(
                        "No se encontró la factura seleccionada en la base de datos.",
                        "Factura no encontrada",
                        MessageType.Warning);
                    return;
                }

                _view.MostrarDetalleFactura(
                    MapearFactura(factura));
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    "No fue posible consultar el detalle de la factura.\n\n" +
                    $"Detalle: {ex.Message}",
                    "Error de facturación",
                    MessageType.Error);
            }
        }

        /// <summary>
        /// Anula la factura seleccionada mediante el repositorio.
        /// </summary>
        private void OnAnularFacturaClicked(
            object? sender,
            EventArgs e)
        {
            string numeroFactura =
                _view.NumeroFacturaSeleccionada;

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
                ResultadoOperacionDto resultado =
                    _repository.AnularFactura(
                        numeroFactura,
                        _view.UsuarioId,
                        DateTime.Now);

                if (!resultado.Exito)
                {
                    _view.MostrarMensaje(
                        resultado.Mensaje,
                        "No se pudo anular la factura",
                        MessageType.Warning);
                    return;
                }

                _view.MostrarMensaje(
                    resultado.Mensaje,
                    "Anulación realizada",
                    MessageType.Information);

                _view.RefrescarFacturas();
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    "No fue posible anular la factura en la base de datos.\n\n" +
                    (ex.InnerException?.Message ?? ex.Message),
                    "Error de base de datos",
                    MessageType.Error);
            }
            catch (Exception ex)
            {
                _view.MostrarMensaje(
                    "Ocurrió un error inesperado al anular la factura.\n\n" +
                    $"Detalle: {ex.Message}",
                    "Error de facturación",
                    MessageType.Error);
            }
        }

        /// <summary>
        /// Adapta el DTO del repositorio al modelo utilizado por la vista.
        /// </summary>
        private static FacturaPrueba MapearFactura(
            FacturaDto factura)
        {
            return new FacturaPrueba
            {
                NumeroFactura = factura.NumeroFactura,
                Fecha = factura.Fecha,
                Cliente = factura.Cliente,
                TipoOrden = factura.TipoOrden,
                Mesa = factura.Mesa,
                Subtotal = factura.Subtotal,
                Descuento = factura.Descuento,
                Total = factura.Total,
                MetodoPago = factura.MetodoPago,
                Estado = factura.Estado,

                Detalles = factura.Detalles
                    .Select(detalle => new DetalleFacturaPrueba
                    {
                        Producto = detalle.Producto,
                        Cantidad = detalle.Cantidad,
                        Precio = detalle.Precio
                    })
                    .ToList()
            };
        }

        /// <summary>
        /// Libera las suscripciones y el repositorio al cerrar el módulo.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
                return;

            _view.VerDetalleClicked -= OnVerDetalleClicked;
            _view.AnularFacturaClicked -= OnAnularFacturaClicked;

            _repository.Dispose();

            _disposed = true;
        }
    }
}
