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
    public class MesasReservasPresenter : IDisposable
    {
        private readonly IMesasReservasView _view;
        private readonly IMesasReservasRepository _repository;
        private bool _disposed;

        public MesasReservasPresenter(
            IMesasReservasView view,
            IMesasReservasRepository repository)
        {
            _view = view ??
                throw new ArgumentNullException(nameof(view));

            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));

            _view.NuevaReservaClicked += OnNuevaReservaClicked;
            _view.GuardarReservaClicked += OnGuardarReservaClicked;
            _view.EditarReservaClicked += OnEditarReservaClicked;
            _view.CancelarReservaClicked += OnCancelarReservaClicked;
            _view.AsignarMesaClicked += OnAsignarMesaClicked;
            _view.CambiarEstadoReservaClicked += OnCambiarEstadoReservaClicked;
            _view.LiberarMesaClicked += OnLiberarMesaClicked;
        }

        public void Inicializar()
        {
            try
            {
                CargarMesas();
                CargarReservas();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        #region Carga de información

        private void CargarMesas()
        {
            List<TableRestaurant> mesas =
                MapearMesas(_repository.ObtenerMesasActivas());

            _view.MostrarMesas(mesas);
        }

        private List<TableRestaurant> ObtenerMesasDisponibles(
            int? mesaActualNumero = null)
        {
            return MapearMesas(
                _repository.ObtenerMesasDisponibles(mesaActualNumero));
        }

        private void CargarReservas()
        {
            List<ReservaPrueba> reservas =
                _repository.ObtenerReservas()
                    .Select(r => new ReservaPrueba
                    {
                        ReservaId = r.ReservaId,
                        Cliente = r.Cliente,
                        Fecha = r.Fecha,
                        Hora = r.Hora,
                        Personas = r.Personas,
                        Mesa = r.Mesa,
                        Estado = r.Estado
                    })
                    .ToList();

            _view.MostrarReservas(reservas);
        }

        private static List<TableRestaurant> MapearMesas(
            IEnumerable<MesaDto> mesas)
        {
            return mesas.Select(m => new TableRestaurant
            {
                TableId = m.TableId,
                TableNumber = m.TableNumber,
                Capacity = checked((byte)m.Capacity),
                Status = m.Status,
                IsActive = m.IsActive
            }).ToList();
        }

        #endregion

        #region Crear y editar reservas

        private void OnNuevaReservaClicked(
            object? sender,
            EventArgs e)
        {
            try
            {
                _view.MostrarMesasParaReserva(
                    ObtenerMesasDisponibles(),
                    null);

                _view.LimpiarFormularioNuevaReserva();
                _view.AbrirPanelNuevaReserva(false);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void OnGuardarReservaClicked(
            object? sender,
            EventArgs e)
        {
            try
            {
                if (!ValidarDatosFormulario(out string clienteNombre))
                    return;

                ResultadoOperacionDto resultado;

                if (_view.ReservaIdSeleccionada.HasValue)
                {
                    resultado = _repository.ActualizarReserva(
                        CrearSolicitud(
                            clienteNombre,
                            _view.ReservaIdSeleccionada.Value));
                }
                else
                {
                    resultado = _repository.CrearReserva(
                        CrearSolicitud(clienteNombre, null));
                }

                if (!resultado.Exito)
                {
                    _view.MostrarMensaje(
                        resultado.Mensaje,
                        MessageType.Warning);

                    return;
                }

                CargarMesas();
                CargarReservas();
                _view.CerrarPanelNuevaReserva();

                _view.MostrarMensaje(
                    resultado.Mensaje,
                    MessageType.Information);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void OnEditarReservaClicked(
            object? sender,
            EventArgs e)
        {
            if (!ValidarReservaSeleccionada())
                return;

            try
            {
                int reservaId = _view.ReservaIdSeleccionada!.Value;

                ReservaOperacionDto? reserva =
                    _repository.ObtenerReserva(reservaId);

                if (reserva == null)
                {
                    _view.MostrarMensaje(
                        "La reserva seleccionada ya no existe.",
                        MessageType.Warning);

                    CargarReservas();
                    return;
                }

                if (reserva.Status is "Cancelled" or "Attended" or "NoShow")
                {
                    _view.MostrarMensaje(
                        "La reserva seleccionada no puede modificarse " +
                        "en su estado actual.",
                        MessageType.Warning);

                    return;
                }

                var reservaVista = new ReservaPrueba
                {
                    ReservaId = reserva.ReservationId,
                    Cliente = reserva.CustomerName,
                    Fecha = reserva.ReservationDate.ToDateTime(
                        TimeOnly.MinValue),
                    Hora = reserva.ReservationTime.ToTimeSpan(),
                    Personas = reserva.GuestCount,
                    Mesa = reserva.TableNumber,
                    Estado = TraducirEstado(reserva.Status)
                };

                _view.MostrarMesasParaReserva(
                    ObtenerMesasDisponibles(reserva.TableNumber),
                    reserva.TableNumber);

                _view.CargarDatosReserva(reservaVista);
                _view.AbrirPanelNuevaReserva(true);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private bool ValidarDatosFormulario(out string clienteNombre)
        {
            clienteNombre = _view.ClienteReserva.Trim();

            if (string.IsNullOrWhiteSpace(clienteNombre))
            {
                _view.MostrarMensaje(
                    "Ingrese el nombre del cliente.",
                    MessageType.Warning);

                return false;
            }

            if (_view.FechaReserva.Date < DateTime.Today)
            {
                _view.MostrarMensaje(
                    "La fecha de la reserva no puede ser anterior " +
                    "a la fecha actual.",
                    MessageType.Warning);

                return false;
            }

            if (_view.PersonasReserva <= 0 ||
                _view.PersonasReserva > byte.MaxValue)
            {
                _view.MostrarMensaje(
                    "La cantidad de personas debe ser mayor que cero " +
                    "y estar dentro del límite permitido.",
                    MessageType.Warning);

                return false;
            }

            return true;
        }

        private ReservaGuardarDto CrearSolicitud(
            string clienteNombre,
            int? reservaId)
        {
            return new ReservaGuardarDto
            {
                ReservaId = reservaId,
                ClienteNombreCompleto = clienteNombre,
                NumeroMesa = _view.NumeroMesaSeleccionada,
                Fecha = DateOnly.FromDateTime(
                    _view.FechaReserva.Date),
                Hora = TimeOnly.FromTimeSpan(
                    _view.HoraReserva),
                Personas = _view.PersonasReserva
            };
        }

        #endregion

        #region Cancelar reserva

        private void OnCancelarReservaClicked(
            object? sender,
            EventArgs e)
        {
            if (!ValidarReservaSeleccionada())
                return;

            try
            {
                ResultadoOperacionDto resultado =
                    _repository.CancelarReserva(
                        _view.ReservaIdSeleccionada!.Value);

                if (resultado.Exito)
                {
                    CargarMesas();
                    CargarReservas();
                }

                _view.MostrarMensaje(
                    resultado.Mensaje,
                    resultado.Exito
                        ? MessageType.Information
                        : MessageType.Warning);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        #endregion

        #region Asignar mesa

        private void OnAsignarMesaClicked(
            object? sender,
            EventArgs e)
        {
            if (!ValidarReservaSeleccionada())
                return;

            if (!_view.NumeroMesaSeleccionadaParaAsignar.HasValue)
            {
                _view.MostrarMensaje(
                    "Seleccione una mesa disponible en las tarjetas.",
                    MessageType.Warning);

                return;
            }

            try
            {
                ResultadoOperacionDto resultado =
                    _repository.AsignarMesa(
                        _view.ReservaIdSeleccionada!.Value,
                        _view.NumeroMesaSeleccionadaParaAsignar.Value);

                if (resultado.Exito)
                {
                    CargarMesas();
                    CargarReservas();
                }

                _view.MostrarMensaje(
                    resultado.Mensaje,
                    resultado.Exito
                        ? MessageType.Information
                        : MessageType.Warning);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        #endregion

        #region Cambiar estado de reserva

        private void OnCambiarEstadoReservaClicked(
            object? sender,
            EventArgs e)
        {
            if (!ValidarReservaSeleccionada())
                return;

            try
            {
                int reservaId = _view.ReservaIdSeleccionada!.Value;

                ReservaOperacionDto? reserva =
                    _repository.ObtenerReserva(reservaId);

                if (reserva == null)
                {
                    _view.MostrarMensaje(
                        "La reserva seleccionada ya no existe.",
                        MessageType.Warning);

                    CargarReservas();
                    return;
                }

                string nuevoEstado;

                switch (reserva.Status)
                {
                    case "Pending":
                        nuevoEstado = "Confirmed";
                        break;

                    case "Confirmed":
                        {
                            DateTime fechaHoraReserva =
                                reserva.ReservationDate.ToDateTime(
                                    reserva.ReservationTime);

                            DateTime fechaHoraLimite =
                                fechaHoraReserva.AddMinutes(30);

                            if (DateTime.Now > fechaHoraLimite)
                            {
                                DialogResult resultado =
                                    FrmMessageBox.Show(
                                        $"La reserva estaba programada para las " +
                                        $"{reserva.ReservationTime:hh\\:mm}.\n\n" +
                                        "Han pasado más de 30 minutos desde " +
                                        "la hora de reserva.\n\n" +
                                        "¿Desea marcar esta reserva como 'No Show'?",
                                        "Reserva no atendida",
                                        MessageType.Confirmation);

                                if (resultado != DialogResult.Yes)
                                    return;

                                nuevoEstado = "NoShow";
                            }
                            else
                            {
                                if (!reserva.TableId.HasValue)
                                {
                                    _view.MostrarMensaje(
                                        "No se puede marcar como atendida una " +
                                        "reserva que no tiene una mesa asignada.",
                                        MessageType.Warning);

                                    return;
                                }

                                nuevoEstado = "Attended";
                            }

                            break;
                        }

                    case "Attended":
                        _view.MostrarMensaje(
                            "Una reserva atendida no puede cambiar " +
                            "nuevamente de estado.",
                            MessageType.Warning);

                        return;

                    case "Cancelled":
                        _view.MostrarMensaje(
                            "Una reserva cancelada no puede cambiar " +
                            "de estado.",
                            MessageType.Warning);

                        return;

                    case "NoShow":
                        _view.MostrarMensaje(
                            "Una reserva marcada como 'No Show' no " +
                            "puede cambiar nuevamente de estado.",
                            MessageType.Warning);

                        return;

                    default:
                        _view.MostrarMensaje(
                            "El estado actual de la reserva no es válido.",
                            MessageType.Error);

                        return;
                }

                ResultadoOperacionDto cambio =
                    _repository.CambiarEstadoReserva(
                        reservaId,
                        nuevoEstado);

                if (cambio.Exito)
                {
                    CargarMesas();
                    CargarReservas();
                }

                _view.MostrarMensaje(
                    cambio.Mensaje,
                    cambio.Exito
                        ? MessageType.Information
                        : MessageType.Warning);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        #endregion

        #region Liberar mesa

        private void OnLiberarMesaClicked(
            object? sender,
            EventArgs e)
        {
            if (!_view.NumeroMesaOcupadaSeleccionada.HasValue)
            {
                _view.MostrarMensaje(
                    "Debe seleccionar una mesa ocupada.",
                    MessageType.Warning);

                return;
            }

            try
            {
                ResultadoOperacionDto resultado =
                    _repository.LiberarMesa(
                        _view.NumeroMesaOcupadaSeleccionada.Value);

                if (resultado.Exito)
                    CargarMesas();

                _view.MostrarMensaje(
                    resultado.Mensaje,
                    resultado.Exito
                        ? MessageType.Information
                        : MessageType.Warning);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        #endregion

        #region Validaciones y utilidades

        private bool ValidarReservaSeleccionada()
        {
            if (_view.ReservaIdSeleccionada.HasValue)
                return true;

            _view.MostrarMensaje(
                "Seleccione una reserva.",
                MessageType.Warning);

            return false;
        }

        private static string TraducirEstado(string estado)
        {
            return estado switch
            {
                "Pending" => "Pendiente",
                "Confirmed" => "Confirmada",
                "Attended" => "Atendida",
                "Cancelled" => "Cancelada",
                "NoShow" => "No Show",
                _ => estado
            };
        }

        private void MostrarError(Exception ex)
        {
            string detalle =
                ex.InnerException?.Message ?? ex.Message;

            _view.MostrarMensaje(
                $"Ocurrió un error al procesar la operación.\n\n{detalle}",
                MessageType.Error);
        }

        #endregion

        #region Liberación de recursos

        public void Dispose()
        {
            if (_disposed)
                return;

            _view.NuevaReservaClicked -= OnNuevaReservaClicked;
            _view.GuardarReservaClicked -= OnGuardarReservaClicked;
            _view.EditarReservaClicked -= OnEditarReservaClicked;
            _view.CancelarReservaClicked -= OnCancelarReservaClicked;
            _view.AsignarMesaClicked -= OnAsignarMesaClicked;
            _view.CambiarEstadoReservaClicked -= OnCambiarEstadoReservaClicked;
            _view.LiberarMesaClicked -= OnLiberarMesaClicked;

            _repository.Dispose();

            _disposed = true;
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
