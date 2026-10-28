using Microsoft.EntityFrameworkCore;
using Ocean_Desk_dv.Data;
using Ocean_Desk_dv.Models.DTOs;
using Ocean_Desk_dv.Models.Entities;
using Ocean_Desk_dv.Services.Interfaces_Services;
using System.Globalization;
using System.Text;

namespace Ocean_Desk_dv.Services.Repository;

public sealed class MesasReservasRepository : IMesasReservasRepository
{
    private readonly OceanDeskDbContext _context;

    public MesasReservasRepository(OceanDeskDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IReadOnlyList<MesaDto> ObtenerMesasActivas()
    {
        var db = _context;
        return db.TableRestaurants.AsNoTracking().Where(t => t.IsActive).OrderBy(t => t.TableNumber).Select(MapearMesa).ToList();
    }

    public IReadOnlyList<MesaDto> ObtenerMesasDisponibles(int? mesaActualNumero = null)
    {
        var db = _context;
        return db.TableRestaurants.AsNoTracking()
            .Where(t => t.IsActive && (t.Status == "Available" || (mesaActualNumero.HasValue && t.TableNumber == mesaActualNumero.Value)))
            .OrderBy(t => t.TableNumber).Select(MapearMesa).ToList();
    }

    /// <summary>
    /// Obtiene los nombres completos de los clientes activos
    /// para utilizarlos en el autocompletado de reservas.
    /// </summary>
    public IReadOnlyList<string> ObtenerNombresClientesActivos()
    {
        return _context.Customers
            .AsNoTracking()
            .Where(c => c.IsActive)
            .Select(c => (c.FirstName + " " + c.LastName).Trim())
            .Distinct()
            .OrderBy(nombre => nombre)
            .ToList();
    }

    public IReadOnlyList<ReservaDto> ObtenerReservas()
    {
        var db = _context;
        return (from r in db.Reservations.AsNoTracking()
                join c in db.Customers.AsNoTracking() on r.CustomerId equals c.CustomerId
                join table in db.TableRestaurants.AsNoTracking() on r.TableId equals table.TableId into tables
                from t in tables.DefaultIfEmpty()
                orderby r.ReservationDate, r.ReservationTime, r.ReservationId
                select new ReservaDto
                {
                    ReservaId = r.ReservationId,
                    Cliente = (c.FirstName + " " + c.LastName).Trim(),
                    Fecha = r.ReservationDate.ToDateTime(TimeOnly.MinValue),
                    Hora = r.ReservationTime.ToTimeSpan(),
                    Personas = r.GuestCount,
                    Mesa = t != null ? (int?)t.TableNumber : null,
                    Estado = TraducirEstado(r.Status)
                }).ToList();
    }

    public ReservaOperacionDto? ObtenerReserva(int reservaId)
    {
        var db = _context;
        return (from r in db.Reservations.AsNoTracking()
                join c in db.Customers.AsNoTracking() on r.CustomerId equals c.CustomerId
                join table in db.TableRestaurants.AsNoTracking() on r.TableId equals table.TableId into tables
                from t in tables.DefaultIfEmpty()
                where r.ReservationId == reservaId
                select new ReservaOperacionDto
                {
                    ReservationId = r.ReservationId,
                    CustomerId = r.CustomerId,
                    TableId = r.TableId,
                    ReservationDate = r.ReservationDate,
                    ReservationTime = r.ReservationTime,
                    GuestCount = r.GuestCount,
                    Status = r.Status,
                    CustomerName = (c.FirstName + " " + c.LastName).Trim(),
                    TableNumber = t != null ? (int?)t.TableNumber : null
                }).FirstOrDefault();
    }

    public ResultadoOperacionDto CrearReserva(ReservaGuardarDto solicitud)
    {
        var db = _context;
        Customer? cliente = BuscarCliente(db, solicitud.ClienteNombreCompleto);
        if (cliente is null) return ResultadoOperacionDto.Fallido("No se encontró un cliente con ese nombre. Registre primero al cliente desde Punto de Venta.");
        TableRestaurant? mesa = ResolverMesa(db, solicitud.NumeroMesa);
        if (solicitud.NumeroMesa.HasValue && mesa is null) return ResultadoOperacionDto.Fallido("La mesa seleccionada no existe o no está activa.");
        if (mesa != null && mesa.Status != "Available") return ResultadoOperacionDto.Fallido("La mesa seleccionada ya no se encuentra disponible.");
        if (mesa != null && solicitud.Personas > mesa.Capacity) return ResultadoOperacionDto.Fallido($"La Mesa {mesa.TableNumber:00} tiene una capacidad máxima de {mesa.Capacity} personas.");
        if (ExisteReservaMesa(db, mesa?.TableId, solicitud.Fecha, solicitud.Hora, null)) return ResultadoOperacionDto.Fallido("Ya existe una reserva activa para esa mesa en la fecha y hora seleccionadas.");
        if (ExisteReservaCliente(db, cliente.CustomerId, solicitud.Fecha, solicitud.Hora, null)) return ResultadoOperacionDto.Fallido("El cliente ya tiene otra reserva activa para la fecha y hora seleccionadas.");

        using var tx = db.Database.BeginTransaction();
        db.Reservations.Add(new Reservation
        {
            CustomerId = cliente.CustomerId,
            TableId = mesa?.TableId,
            ReservationDate = solicitud.Fecha,
            ReservationTime = solicitud.Hora,
            GuestCount = checked((byte)solicitud.Personas),
            Status = "Pending",
            RegistrationDateTime = DateTime.Now
        });
        if (mesa != null) mesa.Status = "Reserved";
        db.SaveChanges();
        tx.Commit();
        return ResultadoOperacionDto.Correcto("La reserva fue registrada correctamente.");
    }

    public ResultadoOperacionDto ActualizarReserva(ReservaGuardarDto solicitud)
    {
        if (!solicitud.ReservaId.HasValue) return ResultadoOperacionDto.Fallido("No se indicó la reserva que debe actualizarse.");
        var db = _context;
        var reserva = db.Reservations.FirstOrDefault(r => r.ReservationId == solicitud.ReservaId.Value);
        if (reserva is null) return ResultadoOperacionDto.Fallido("La reserva que intenta modificar ya no existe.");
        if (reserva.Status is "Cancelled" or "Attended") return ResultadoOperacionDto.Fallido("La reserva seleccionada no puede modificarse en su estado actual.");
        var cliente = BuscarCliente(db, solicitud.ClienteNombreCompleto);
        if (cliente is null) return ResultadoOperacionDto.Fallido("No se encontró un cliente con ese nombre. Registre primero al cliente desde Punto de Venta.");

        int? mesaAnteriorId = reserva.TableId;
        var mesaNueva = ResolverMesa(db, solicitud.NumeroMesa);
        if (solicitud.NumeroMesa.HasValue && mesaNueva is null) return ResultadoOperacionDto.Fallido("La mesa seleccionada no existe o no está activa.");
        if (mesaNueva != null && mesaNueva.Status != "Available" && mesaNueva.TableId != reserva.TableId)
            return ResultadoOperacionDto.Fallido("La mesa seleccionada ya no se encuentra disponible.");
        if (mesaNueva != null && solicitud.Personas > mesaNueva.Capacity)
            return ResultadoOperacionDto.Fallido($"La Mesa {mesaNueva.TableNumber:00} tiene una capacidad máxima de {mesaNueva.Capacity} personas.");
        if (ExisteReservaMesa(db, mesaNueva?.TableId, solicitud.Fecha, solicitud.Hora, reserva.ReservationId))
            return ResultadoOperacionDto.Fallido("Ya existe otra reserva activa para esa mesa en la fecha y hora seleccionadas.");
        if (ExisteReservaCliente(db, cliente.CustomerId, solicitud.Fecha, solicitud.Hora, reserva.ReservationId))
            return ResultadoOperacionDto.Fallido("El cliente ya tiene otra reserva activa para la fecha y hora seleccionadas.");

        using var tx = db.Database.BeginTransaction();
        reserva.CustomerId = cliente.CustomerId;
        reserva.TableId = mesaNueva?.TableId;
        reserva.ReservationDate = solicitud.Fecha;
        reserva.ReservationTime = solicitud.Hora;
        reserva.GuestCount = checked((byte)solicitud.Personas);
        if (mesaAnteriorId.HasValue && mesaAnteriorId.Value != mesaNueva?.TableId)
        {
            var mesaAnterior = db.TableRestaurants.FirstOrDefault(t => t.TableId == mesaAnteriorId.Value);
            if (mesaAnterior != null && mesaAnterior.Status != "Maintenance") mesaAnterior.Status = "Available";
        }
        if (mesaNueva != null && mesaNueva.Status != "Maintenance") mesaNueva.Status = "Reserved";
        db.SaveChanges();
        tx.Commit();
        return ResultadoOperacionDto.Correcto("La reserva fue actualizada correctamente.");
    }

    public ResultadoOperacionDto CancelarReserva(int reservaId)
    {
        var db = _context;
        var reserva = db.Reservations.FirstOrDefault(r => r.ReservationId == reservaId);
        if (reserva is null) return ResultadoOperacionDto.Fallido("La reserva seleccionada ya no existe.");
        if (reserva.Status == "Cancelled") return ResultadoOperacionDto.Fallido("La reserva seleccionada ya se encuentra cancelada.");
        if (reserva.Status == "Attended") return ResultadoOperacionDto.Fallido("No se puede cancelar una reserva que ya fue atendida.");
        using var tx = db.Database.BeginTransaction();
        reserva.Status = "Cancelled";
        if (reserva.TableId.HasValue)
        {
            var mesa = db.TableRestaurants.FirstOrDefault(t => t.TableId == reserva.TableId.Value);
            if (mesa != null && mesa.Status != "Maintenance") mesa.Status = "Available";
        }
        db.SaveChanges();
        tx.Commit();
        return ResultadoOperacionDto.Correcto("La reserva fue cancelada correctamente y la mesa quedó disponible.");
    }

    public ResultadoOperacionDto AsignarMesa(int reservaId, int numeroMesa)
    {
        var db = _context;
        var reserva = db.Reservations.FirstOrDefault(r => r.ReservationId == reservaId);
        if (reserva is null) return ResultadoOperacionDto.Fallido("La reserva seleccionada ya no existe.");
        if (reserva.Status is "Cancelled" or "Attended") return ResultadoOperacionDto.Fallido("La reserva seleccionada no permite asignar una mesa en su estado actual.");
        if (reserva.TableId.HasValue) return ResultadoOperacionDto.Fallido("La reserva ya tiene una mesa asignada.");
        var mesa = db.TableRestaurants.FirstOrDefault(t => t.TableNumber == numeroMesa && t.IsActive);
        if (mesa is null) return ResultadoOperacionDto.Fallido("La mesa seleccionada no existe o no está activa.");
        if (mesa.Status != "Available") return ResultadoOperacionDto.Fallido("La mesa seleccionada ya no se encuentra disponible.");
        if (reserva.GuestCount > mesa.Capacity) return ResultadoOperacionDto.Fallido($"La mesa seleccionada tiene una capacidad máxima de {mesa.Capacity} personas.");
        if (ExisteReservaMesa(db, mesa.TableId, reserva.ReservationDate, reserva.ReservationTime, reserva.ReservationId))
            return ResultadoOperacionDto.Fallido("Ya existe otra reserva activa para esa mesa en la fecha y hora seleccionadas.");
        reserva.TableId = mesa.TableId;
        mesa.Status = "Reserved";
        db.SaveChanges();
        return ResultadoOperacionDto.Correcto($"La Mesa {mesa.TableNumber:00} fue asignada correctamente y quedó reservada.");
    }

    public ResultadoOperacionDto CambiarEstadoReserva(int reservaId, string nuevoEstado)
    {
        var db = _context;
        var reserva = db.Reservations.FirstOrDefault(r => r.ReservationId == reservaId);
        if (reserva is null) return ResultadoOperacionDto.Fallido("La reserva seleccionada ya no existe.");
        if (nuevoEstado == "Attended" && !reserva.TableId.HasValue)
            return ResultadoOperacionDto.Fallido("No se puede marcar como atendida una reserva que no tiene una mesa asignada.");
        if (nuevoEstado is not ("Confirmed" or "Attended" or "NoShow"))
            return ResultadoOperacionDto.Fallido("El nuevo estado de la reserva no es válido.");
        var mesa = reserva.TableId.HasValue ? db.TableRestaurants.FirstOrDefault(t => t.TableId == reserva.TableId.Value) : null;
        reserva.Status = nuevoEstado;
        if (mesa != null)
        {
            if (nuevoEstado == "Confirmed") mesa.Status = "Reserved";
            else if (nuevoEstado == "Attended") mesa.Status = "Occupied";
            else if (nuevoEstado == "NoShow") mesa.Status = "Available";
        }
        db.SaveChanges();
        return ResultadoOperacionDto.Correcto($"La reserva ahora se encuentra en estado '{TraducirEstado(nuevoEstado)}'.");
    }

    public ResultadoOperacionDto LiberarMesa(int numeroMesa)
    {
        var db = _context;
        var mesa = db.TableRestaurants.FirstOrDefault(t => t.TableNumber == numeroMesa && t.IsActive);
        if (mesa is null) return ResultadoOperacionDto.Fallido("La mesa seleccionada no existe o no está activa.");
        if (mesa.Status != "Occupied") return ResultadoOperacionDto.Fallido("Solo se pueden liberar mesas que actualmente se encuentran ocupadas.");
        mesa.Status = "Available";
        db.SaveChanges();
        return ResultadoOperacionDto.Correcto($"La Mesa {mesa.TableNumber:00} fue liberada correctamente y ahora está disponible.");
    }

    private static MesaDto MapearMesa(TableRestaurant mesa) => new()
    {
        TableId = mesa.TableId, TableNumber = mesa.TableNumber, Capacity = mesa.Capacity,
        Status = mesa.Status, IsActive = mesa.IsActive
    };

    private static Customer? BuscarCliente(OceanDeskDbContext db, string nombreCompleto)
    {
        string buscado = NormalizarTexto(nombreCompleto);
        return db.Customers.AsNoTracking().Where(c => c.IsActive).AsEnumerable()
            .FirstOrDefault(c => NormalizarTexto($"{c.FirstName} {c.LastName}").Equals(buscado, StringComparison.OrdinalIgnoreCase));
    }

    private static TableRestaurant? ResolverMesa(OceanDeskDbContext db, int? numeroMesa) =>
        !numeroMesa.HasValue ? null : db.TableRestaurants.FirstOrDefault(t => t.TableNumber == numeroMesa.Value && t.IsActive);

    private static bool ExisteReservaMesa(OceanDeskDbContext db, int? tableId, DateOnly fecha, TimeOnly hora, int? excluirId) =>
        tableId.HasValue && db.Reservations.Any(r => r.TableId == tableId.Value && r.ReservationDate == fecha && r.ReservationTime == hora && r.Status != "Cancelled" && r.ReservationId != excluirId);

    private static bool ExisteReservaCliente(OceanDeskDbContext db, int customerId, DateOnly fecha, TimeOnly hora, int? excluirId) =>
        db.Reservations.Any(r => r.CustomerId == customerId && r.ReservationDate == fecha && r.ReservationTime == hora && r.Status != "Cancelled" && r.ReservationId != excluirId);

    private static string NormalizarTexto(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto)) return string.Empty;
        string descompuesto = texto.Trim().Normalize(NormalizationForm.FormD);
        var resultado = new StringBuilder();
        foreach (char c in descompuesto)
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark) resultado.Append(c);
        return resultado.ToString().Normalize(NormalizationForm.FormC);
    }

    private static string TraducirEstado(string estado) => estado switch
    {
        "Pending" => "Pendiente", "Confirmed" => "Confirmada", "Attended" => "Atendida",
        "Cancelled" => "Cancelada", "NoShow" => "No Show", _ => estado
    };
    public void Dispose() => _context.Dispose();

}
