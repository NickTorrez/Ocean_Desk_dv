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
    public class MesasReservasPresenter
    {
        private readonly IMesasReservasView _view;

        public MesasReservasPresenter(IMesasReservasView view)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));

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
            CargarMesas();
            CargarReservas();
        }

        private void OnNuevaReservaClicked(object? sender, EventArgs e)
        {
            try
            {
                _view.MostrarMesasParaReserva(ObtenerMesasDisponibles(), null);
                _view.LimpiarFormularioNuevaReserva();
                _view.AbrirPanelNuevaReserva(false);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void OnGuardarReservaClicked(object? sender, EventArgs e)
        {
            try
            {
                if (_view.ReservaIdSeleccionada.HasValue)
                    ActualizarReserva(_view.ReservaIdSeleccionada.Value);
                else
                    CrearReserva();
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    $"No fue posible guardar la reserva en la base de datos.\n\n{ex.InnerException?.Message ?? ex.Message}",
                    MessageType.Error);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void OnEditarReservaClicked(object? sender, EventArgs e)
        {
            if (!ValidarReservaSeleccionada())
                return;

            try
            {
                using var db = new OceanDeskDbContext();

                Reservation? reserva = db.Reservations
                    .AsNoTracking()
                    .FirstOrDefault(r => r.ReservationId == _view.ReservaIdSeleccionada.Value);

                if (reserva == null)
                {
                    _view.MostrarMensaje(
                        "La reserva seleccionada ya no existe en la base de datos.",
                        MessageType.Warning);
                    CargarReservas();
                    return;
                }

                string cliente = ObtenerNombreCliente(db, reserva.CustomerId);
                string? nombreMesa = ObtenerNumeroMesa(db, reserva.TableId);

                var reservaVista = new ReservaPrueba
                {
                    ReservaId = reserva.ReservationId,
                    Cliente = cliente,
                    Fecha = reserva.ReservationDate.ToDateTime(TimeOnly.MinValue),
                    Hora = reserva.ReservationTime.ToTimeSpan(),
                    Personas = reserva.GuestCount,
                    Mesa = int.TryParse(nombreMesa, out int numeroMesa) ? numeroMesa : null,
                    Estado = TraducirEstado(reserva.Status)
                };

                _view.MostrarMesasParaReserva(ObtenerMesasDisponibles(reservaVista.Mesa), reservaVista.Mesa);
                _view.CargarDatosReserva(reservaVista);
                _view.AbrirPanelNuevaReserva(true);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void OnCancelarReservaClicked(object? sender, EventArgs e)
        {
                if (!ValidarReservaSeleccionada())
            return;

            try
            {
                using var db = new OceanDeskDbContext();

                Reservation? reserva = db.Reservations
                    .FirstOrDefault(r => r.ReservationId == _view.ReservaIdSeleccionada.Value);

                if (reserva == null)
                {
                    _view.MostrarMensaje(
                        "La reserva seleccionada ya no existe.",
                        MessageType.Warning);
                    CargarReservas();
                    return;
                }

                if (reserva.Status == "Cancelled")
                {
                    _view.MostrarMensaje(
                        "La reserva seleccionada ya se encuentra cancelada.",
                        MessageType.Warning);
                    return;
                }

                if (reserva.Status == "Attended")
                {
                    _view.MostrarMensaje(
                        "No se puede cancelar una reserva que ya fue atendida.",
                        MessageType.Warning);
                    return;
                }

                // Cancelar la reserva.
                reserva.Status = "Cancelled";

                // Liberar la mesa asociada.
                if (reserva.TableId.HasValue)
                {
                    TableRestaurant? mesa = db.TableRestaurants
                        .FirstOrDefault(t => t.TableId == reserva.TableId.Value);

                    if (mesa != null && mesa.Status != "Maintenance")
                    {
                        mesa.Status = "Available";
                    }
                }

                db.SaveChanges();

                CargarMesas();
                CargarReservas();

                _view.MostrarMensaje(
                    "La reserva fue cancelada correctamente y la mesa quedó disponible.",
                    MessageType.Information);
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    $"No fue posible cancelar la reserva.\n\n{ex.InnerException?.Message ?? ex.Message}",
                    MessageType.Error);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void OnAsignarMesaClicked(object? sender, EventArgs e)
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
                using var db = new OceanDeskDbContext();

                Reservation? reserva = db.Reservations
                    .FirstOrDefault(r => r.ReservationId == _view.ReservaIdSeleccionada.Value);

                if (reserva == null)
                {
                    _view.MostrarMensaje(
                        "La reserva seleccionada ya no existe.",
                        MessageType.Warning);
                    CargarReservas();
                    return;
                }

                if (reserva.Status == "Cancelled" || reserva.Status == "Attended")
                {
                    _view.MostrarMensaje(
                        "La reserva seleccionada no permite asignar una mesa en su estado actual.",
                        MessageType.Warning);
                    return;
                }

                if (reserva.TableId.HasValue)
                {
                    _view.MostrarMensaje(
                        "La reserva ya tiene una mesa asignada.",
                        MessageType.Information);
                    return;
                }

                TableRestaurant? mesa = db.TableRestaurants
                    .FirstOrDefault(t =>
                        t.TableNumber == _view.NumeroMesaSeleccionadaParaAsignar.Value &&
                        t.IsActive);

                if (mesa == null)
                {
                    _view.MostrarMensaje(
                        "La mesa seleccionada no existe o no está activa.",
                        MessageType.Warning);
                    return;
                }

                if (mesa.Status != "Available")
                {
                    _view.MostrarMensaje(
                        "La mesa seleccionada ya no se encuentra disponible.",
                        MessageType.Warning);
                    CargarMesas();
                    return;
                }

                if (reserva.GuestCount > mesa.Capacity)
                {
                    _view.MostrarMensaje(
                        $"La mesa seleccionada tiene una capacidad máxima de {mesa.Capacity} personas.",
                        MessageType.Warning);
                    return;
                }

                // Verificar que no exista otra reserva para esa mesa
                // en la misma fecha y hora.
                if (ExisteReservaConMesaEnFechaHora(
                    db,
                    mesa.TableId,
                    reserva.ReservationDate,
                    reserva.ReservationTime,
                    reserva.ReservationId))
                {
                    _view.MostrarMensaje(
                        "Ya existe otra reserva activa para esa mesa en la fecha y hora seleccionadas.",
                        MessageType.Warning);
                    return;
                }

                reserva.TableId = mesa.TableId;

                // La mesa queda apartada para la reserva.
                mesa.Status = "Reserved";

                db.SaveChanges();

                CargarMesas();
                CargarReservas();

                _view.MostrarMensaje(
                    $"La Mesa {mesa.TableNumber:00} fue asignada correctamente y quedó reservada.",
                    MessageType.Information);
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    $"No fue posible asignar la mesa.\n\n{ex.InnerException?.Message ?? ex.Message}",
                    MessageType.Error);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void OnCambiarEstadoReservaClicked(object? sender, EventArgs e)
        {
            if (!ValidarReservaSeleccionada())
                return;

            try
            {
                using var db = new OceanDeskDbContext();

                Reservation? reserva = db.Reservations
                    .FirstOrDefault(r => r.ReservationId == _view.ReservaIdSeleccionada.Value);

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

                        // Verificar si ya pasó el tiempo permitido
                        // para que el cliente se presente.
                        DateTime fechaHoraReserva =
                            reserva.ReservationDate.ToDateTime(reserva.ReservationTime);

                        DateTime fechaHoraLimite =
                            fechaHoraReserva.AddMinutes(30);

                        if (DateTime.Now > fechaHoraLimite)
                        {
                            DialogResult resultado = FrmMessageBox.Show(
                                $"La reserva estaba programada para las " +
                                $"{reserva.ReservationTime:hh\\:mm}.\n\n" +
                                "Han pasado más de 30 minutos desde la hora de reserva.\n\n" +
                                "¿Desea marcar esta reserva como 'No Show'?",
                                "Reserva no atendida",
                                MessageType.Confirmation);

                            if (resultado == DialogResult.Yes)
                            {
                                nuevoEstado = "NoShow";
                            }
                            else
                            {
                                return;
                            }
                        }
                        else
                        {
                            // Si todavía está dentro del margen de 30 minutos,
                            // se puede marcar como atendida.
                            if (!reserva.TableId.HasValue)
                            {
                                _view.MostrarMensaje(
                                    "No se puede marcar como atendida una reserva que no tiene una mesa asignada.",
                                    MessageType.Warning);
                                return;
                            }

                            nuevoEstado = "Attended";
                        }

                        break;

                    case "Attended":
                        _view.MostrarMensaje(
                            "Una reserva atendida no puede cambiar nuevamente de estado.",
                            MessageType.Warning);
                        return;

                    case "Cancelled":
                        _view.MostrarMensaje(
                            "Una reserva cancelada no puede cambiar de estado.",
                            MessageType.Warning);
                        return;

                    case "NoShow":
                        _view.MostrarMensaje(
                            "Una reserva marcada como 'No Show' no puede cambiar nuevamente de estado.",
                            MessageType.Warning);
                        return;

                    default:
                        _view.MostrarMensaje(
                            "El estado actual de la reserva no es válido.",
                            MessageType.Error);
                        return;
                }

                TableRestaurant? mesa = null;

                if (reserva.TableId.HasValue)
                {
                    mesa = db.TableRestaurants
                        .FirstOrDefault(t => t.TableId == reserva.TableId.Value);
                }

                // Actualizar estado de la reserva.
                reserva.Status = nuevoEstado;

                // Sincronizar el estado de la mesa.
                if (mesa != null)
                {
                    if (nuevoEstado == "Confirmed")
                    {
                        mesa.Status = "Reserved";
                    }
                    else if (nuevoEstado == "Attended")
                    {
                        mesa.Status = "Occupied";
                    }
                    else if (nuevoEstado == "NoShow")
                    {
                        mesa.Status = "Available";
                    }
                }

                db.SaveChanges();

                CargarMesas();
                CargarReservas();

                _view.MostrarMensaje(
                    $"La reserva ahora se encuentra en estado '{TraducirEstado(nuevoEstado)}'.",
                    MessageType.Information);
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    $"No fue posible cambiar el estado de la reserva.\n\n{ex.InnerException?.Message ?? ex.Message}",
                    MessageType.Error);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void OnLiberarMesaClicked(object? sender, EventArgs e)
        {
            if (_view.NumeroMesaOcupadaSeleccionada == null)
            {
                _view.MostrarMensaje(
                    "Debe seleccionar una mesa ocupada.",
                    MessageType.Warning);
                return;
            }

            try
            {
                using var db = new OceanDeskDbContext();

                TableRestaurant? mesa = db.TableRestaurants
                .FirstOrDefault(t =>
                    t.TableNumber == _view.NumeroMesaOcupadaSeleccionada.Value &&
                    t.IsActive);

                if (mesa == null)
                {
                    _view.MostrarMensaje(
                        "La mesa seleccionada no existe o no está activa.",
                        MessageType.Warning);
                    CargarMesas();
                    return;
                }

                if (mesa.Status != "Occupied")
                {
                    _view.MostrarMensaje(
                        "Solo se pueden liberar mesas que actualmente se encuentran ocupadas.",
                        MessageType.Warning);
                    return;
                }

                mesa.Status = "Available";

                db.SaveChanges();

                CargarMesas();

                _view.MostrarMensaje(
                    $"La Mesa {mesa.TableNumber:00} fue liberada correctamente y ahora está disponible.",
                    MessageType.Information);
            }
            catch (DbUpdateException ex)
            {
                _view.MostrarMensaje(
                    $"No fue posible liberar la mesa.\n\n{ex.InnerException?.Message ?? ex.Message}",
                    MessageType.Error);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void CrearReserva()
        {
            string clienteNombre = _view.ClienteReserva.Trim();

            if (string.IsNullOrWhiteSpace(clienteNombre))
            {
                _view.MostrarMensaje(
                    "Ingrese el nombre del cliente.",
                    MessageType.Warning);
                return;
            }

            if (_view.FechaReserva.Date < DateTime.Today)
            {
                _view.MostrarMensaje(
                    "La fecha de la reserva no puede ser anterior a la fecha actual.",
                    MessageType.Warning);
                return;
            }

            if (_view.PersonasReserva <= 0)
            {
                _view.MostrarMensaje(
                    "La cantidad de personas debe ser mayor que cero.",
                    MessageType.Warning);
                return;
            }

            using var db = new OceanDeskDbContext();

            Customer? cliente = BuscarCliente(db, clienteNombre);

            if (cliente == null)
            {
                _view.MostrarMensaje(
                    "No se encontró un cliente con ese nombre. Registre primero al cliente desde Punto de Venta.",
                    MessageType.Warning);
                return;
            }

            TableRestaurant? mesa = ResolverMesa(db, _view.NumeroMesaSeleccionada);

            if (mesa != null)
            {
                if (mesa.Status != "Available")
                {
                    _view.MostrarMensaje(
                        "La mesa seleccionada ya no se encuentra disponible.",
                        MessageType.Warning);
                    CargarMesas();
                    return;
                }

                if (_view.PersonasReserva > mesa.Capacity)
                {
                    _view.MostrarMensaje(
                        $"La Mesa {mesa.TableNumber:00} tiene una capacidad máxima de {mesa.Capacity} personas.",
                        MessageType.Warning);
                    return;
                }

                if (ExisteReservaConMesaEnFechaHora(
                    db,
                    mesa.TableId,
                    DateOnly.FromDateTime(_view.FechaReserva.Date),
                    TimeOnly.FromTimeSpan(_view.HoraReserva),
                    null))
                {
                    _view.MostrarMensaje(
                        "Ya existe una reserva activa para esa mesa en la fecha y hora seleccionadas.",
                        MessageType.Warning);
                    return;
                }
            }

            DateOnly fecha = DateOnly.FromDateTime(_view.FechaReserva.Date);
            TimeOnly hora = TimeOnly.FromTimeSpan(_view.HoraReserva);

            if (ExisteReservaClienteEnFechaHora(
                db,
                cliente.CustomerId,
                fecha,
                hora,
                null))
            {
                _view.MostrarMensaje(
                    "El cliente ya tiene una reserva activa para la fecha y hora seleccionadas.",
                    MessageType.Warning);
                return;
            }

            var nuevaReserva = new Reservation
            {
                CustomerId = cliente.CustomerId,
                TableId = mesa?.TableId,
                ReservationDate = fecha,
                ReservationTime = hora,
                GuestCount = (byte)_view.PersonasReserva,
                Status = "Pending",
                RegistrationDateTime = DateTime.Now
            };

            db.Reservations.Add(nuevaReserva);

            // Si la reserva nace con una mesa asignada,
            // la mesa queda apartada para esa reserva.
            if (mesa != null)
            {
                mesa.Status = "Reserved";
            }

            db.SaveChanges();

            CargarMesas();
            CargarReservas();

            _view.CerrarPanelNuevaReserva();

            _view.MostrarMensaje(
                "La reserva fue registrada correctamente.",
                MessageType.Information);
        }

        private void ActualizarReserva(int reservaId)
        {
            string clienteNombre = _view.ClienteReserva.Trim();

            if (string.IsNullOrWhiteSpace(clienteNombre))
            {
                _view.MostrarMensaje(
                    "Ingrese el nombre del cliente.",
                    MessageType.Warning);
                return;
            }

            if (_view.FechaReserva.Date < DateTime.Today)
            {
                _view.MostrarMensaje(
                    "La fecha de la reserva no puede ser anterior a la fecha actual.",
                    MessageType.Warning);
                return;
            }

            if (_view.PersonasReserva <= 0)
            {
                _view.MostrarMensaje(
                    "La cantidad de personas debe ser mayor que cero.",
                    MessageType.Warning);
                return;
            }

            using var db = new OceanDeskDbContext();

            Reservation? reserva = db.Reservations
                .FirstOrDefault(r => r.ReservationId == reservaId);

            if (reserva == null)
            {
                _view.MostrarMensaje(
                    "La reserva que intenta modificar ya no existe.",
                    MessageType.Warning);
                CargarReservas();
                return;
            }

            if (reserva.Status == "Cancelled" || reserva.Status == "Attended")
            {
                _view.MostrarMensaje(
                    "La reserva seleccionada no puede modificarse en su estado actual.",
                    MessageType.Warning);
                return;
            }

            Customer? cliente = BuscarCliente(db, clienteNombre);

            if (cliente == null)
            {
                _view.MostrarMensaje(
                    "No se encontró un cliente con ese nombre. Registre primero al cliente desde Punto de Venta.",
                    MessageType.Warning);
                return;
            }

            // Guardamos la mesa anterior antes de modificarla.
            int? mesaAnteriorId = reserva.TableId;

            TableRestaurant? mesaNueva = ResolverMesa(
                db,
                _view.NumeroMesaSeleccionada);

            if (mesaNueva != null)
            {
                // Si es una mesa diferente a la actual,
                // debe estar disponible.
                if (mesaNueva.Status != "Available" &&
                    mesaNueva.TableId != reserva.TableId)
                {
                    _view.MostrarMensaje(
                        "La mesa seleccionada ya no se encuentra disponible.",
                        MessageType.Warning);
                    CargarMesas();
                    return;
                }

                if (_view.PersonasReserva > mesaNueva.Capacity)
                {
                    _view.MostrarMensaje(
                        $"La Mesa {mesaNueva.TableNumber:00} tiene una capacidad máxima de {mesaNueva.Capacity} personas.",
                        MessageType.Warning);
                    return;
                }
            }

            DateOnly fecha = DateOnly.FromDateTime(_view.FechaReserva.Date);
            TimeOnly hora = TimeOnly.FromTimeSpan(_view.HoraReserva);

            if (ExisteReservaConMesaEnFechaHora(
                db,
                mesaNueva?.TableId,
                fecha,
                hora,
                reserva.ReservationId))
            {
                _view.MostrarMensaje(
                    "Ya existe otra reserva activa para esa mesa en la fecha y hora seleccionadas.",
                    MessageType.Warning);
                return;
            }

            if (ExisteReservaClienteEnFechaHora(
                db,
                cliente.CustomerId,
                fecha,
                hora,
                reserva.ReservationId))
            {
                _view.MostrarMensaje(
                    "El cliente ya tiene otra reserva activa para la fecha y hora seleccionadas.",
                    MessageType.Warning);
                return;
            }

            // Actualizar datos de la reserva.
            reserva.CustomerId = cliente.CustomerId;
            reserva.TableId = mesaNueva?.TableId;
            reserva.ReservationDate = fecha;
            reserva.ReservationTime = hora;
            reserva.GuestCount = (byte)_view.PersonasReserva;

            // Si cambió de mesa, liberar la anterior.
            if (mesaAnteriorId.HasValue &&
                mesaAnteriorId.Value != mesaNueva?.TableId)
            {
                TableRestaurant? mesaAnterior = db.TableRestaurants
                    .FirstOrDefault(t => t.TableId == mesaAnteriorId.Value);

                if (mesaAnterior != null &&
                    mesaAnterior.Status != "Maintenance")
                {
                    mesaAnterior.Status = "Available";
                }
            }

            // La nueva mesa queda reservada.
            if (mesaNueva != null &&
                mesaNueva.Status != "Maintenance")
            {
                mesaNueva.Status = "Reserved";
            }

            db.SaveChanges();

            CargarMesas();
            CargarReservas();

            _view.CerrarPanelNuevaReserva();

            _view.MostrarMensaje(
                "La reserva fue actualizada correctamente.",
                MessageType.Information);
        }

        private void CargarMesas()
        {
            using var db = new OceanDeskDbContext();

            List<TableRestaurant> mesas = db.TableRestaurants
                .AsNoTracking()
                .Where(t => t.IsActive)
                .OrderBy(t => t.TableNumber)
                .ToList();

            _view.MostrarMesas(mesas);
        }

        private List<TableRestaurant> ObtenerMesasDisponibles(int? mesaActualNumero = null)
        {
            using var db = new OceanDeskDbContext();

            return db.TableRestaurants
                .AsNoTracking()
                .Where(t =>
                    t.IsActive &&
                    (t.Status == "Available" ||
                     (mesaActualNumero.HasValue && t.TableNumber == mesaActualNumero.Value)))
                .OrderBy(t => t.TableNumber)
                .ToList();
        }

        private void CargarReservas()
        {
            using var db = new OceanDeskDbContext();

            var reservasDb = (
                from r in db.Reservations.AsNoTracking()
                join c in db.Customers.AsNoTracking()
                    on r.CustomerId equals c.CustomerId
                join t in db.TableRestaurants.AsNoTracking()
                    on r.TableId equals t.TableId into mesas
                from t in mesas.DefaultIfEmpty()
                orderby r.ReservationDate, r.ReservationTime, r.ReservationId
                select new
                {
                    r.ReservationId,
                    Cliente = (c.FirstName + " " + c.LastName),
                    r.ReservationDate,
                    r.ReservationTime,
                    r.GuestCount,
                    TableNumber = t != null ? (int?)t.TableNumber : null,
                    r.Status
                }
            ).ToList();

            var reservas = reservasDb
                .Select(r => new ReservaPrueba
                {
                    ReservaId = r.ReservationId,
                    Cliente = r.Cliente.Trim(),
                    Fecha = r.ReservationDate.ToDateTime(TimeOnly.MinValue),
                    Hora = r.ReservationTime.ToTimeSpan(),
                    Personas = r.GuestCount,
                    Mesa = r.TableNumber,
                    Estado = TraducirEstado(r.Status)
                })
                .ToList();

            _view.MostrarReservas(reservas);
        }

        private static Customer? BuscarCliente(OceanDeskDbContext db, string nombreCompleto)
        {
            string nombreBuscado = NormalizarTexto(nombreCompleto);

            return db.Customers
                .Where(c => c.IsActive)
                .AsEnumerable()
                .FirstOrDefault(c =>
                    NormalizarTexto($"{c.FirstName} {c.LastName}")
                        .Equals(nombreBuscado, StringComparison.OrdinalIgnoreCase));
        }

        private static string NormalizarTexto(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return string.Empty;

            string normalizado = texto.Trim().Normalize(
                System.Text.NormalizationForm.FormD);

            StringBuilder resultado = new StringBuilder();

            foreach (char caracter in normalizado)
            {
                if (System.Globalization.CharUnicodeInfo.GetUnicodeCategory(caracter)
                    != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    resultado.Append(caracter);
                }
            }

            return resultado
                .ToString()
                .Normalize(System.Text.NormalizationForm.FormC);
        }

        private static string ObtenerNombreCliente(OceanDeskDbContext db, int customerId)
        {
            Customer? cliente = db.Customers
                .AsNoTracking()
                .FirstOrDefault(c => c.CustomerId == customerId);

            return cliente == null
                ? "Cliente no encontrado"
                : $"{cliente.FirstName} {cliente.LastName}".Trim();
        }

        private static string? ObtenerNumeroMesa(OceanDeskDbContext db, int? tableId)
        {
            if (!tableId.HasValue)
                return null;

            return db.TableRestaurants
                .AsNoTracking()
                .Where(t => t.TableId == tableId.Value)
                .Select(t => t.TableNumber.ToString())
                .FirstOrDefault();
        }

        private static TableRestaurant? ResolverMesa(
            OceanDeskDbContext db,
            int? numeroMesa)
        {
            if (!numeroMesa.HasValue)
                return null;

            return db.TableRestaurants
                .FirstOrDefault(t =>
                    t.TableNumber == numeroMesa.Value &&
                    t.IsActive);
        }

        private static bool ExisteReservaConMesaEnFechaHora(
            OceanDeskDbContext db,
            int? tableId,
            DateOnly fecha,
            TimeOnly hora,
            int? reservaExcluirId)
        {
            if (!tableId.HasValue)
                return false;

            return db.Reservations.Any(r =>
                r.TableId == tableId.Value &&
                r.ReservationDate == fecha &&
                r.ReservationTime == hora &&
                r.Status != "Cancelled" &&
                r.ReservationId != reservaExcluirId);
        }

        private static bool ExisteReservaClienteEnFechaHora(
            OceanDeskDbContext db,
            int customerId,
            DateOnly fecha,
            TimeOnly hora,
            int? reservaExcluirId)
        {
            return db.Reservations.Any(r =>
                r.CustomerId == customerId &&
                r.ReservationDate == fecha &&
                r.ReservationTime == hora &&
                r.Status != "Cancelled" &&
                r.ReservationId != reservaExcluirId);
        }

        private bool ValidarReservaSeleccionada()
        {
            if (!_view.ReservaIdSeleccionada.HasValue)
            {
                _view.MostrarMensaje(
                    "Seleccione una reserva.",
                    MessageType.Warning);
                return false;
            }

            return true;
        }

        private void MostrarError(Exception ex)
        {
            _view.MostrarMensaje(
                $"Ocurrió un error inesperado.\n\n{ex.Message}",
                MessageType.Error);
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
    }
}
