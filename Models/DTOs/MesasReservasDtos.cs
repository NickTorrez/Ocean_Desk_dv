namespace Ocean_Desk_dv.Models.DTOs;

public sealed class MesaDto
{
    public int TableId { get; init; }
    public int TableNumber { get; init; }
    public int Capacity { get; init; }
    public string Status { get; init; } = string.Empty;
    public bool IsActive { get; init; }
}

public sealed class ReservaDto
{
    public int ReservaId { get; init; }
    public string Cliente { get; init; } = string.Empty;
    public DateTime Fecha { get; init; }
    public TimeSpan Hora { get; init; }
    public int Personas { get; init; }
    public int? Mesa { get; init; }
    public string Estado { get; init; } = string.Empty;
}

/// <summary>Datos de una reserva para validar y cambiar su estado sin exponer la entidad EF a la Vista.</summary>
public sealed class ReservaOperacionDto
{
    public int ReservationId { get; init; }
    public int CustomerId { get; init; }
    public int? TableId { get; init; }
    public DateOnly ReservationDate { get; init; }
    public TimeOnly ReservationTime { get; init; }
    public int GuestCount { get; init; }
    public string Status { get; init; } = string.Empty;
    public string CustomerName { get; init; } = string.Empty;
    public int? TableNumber { get; init; }
}

public sealed class ReservaGuardarDto
{
    public int? ReservaId { get; init; }
    public string ClienteNombreCompleto { get; init; } = string.Empty;
    public int? NumeroMesa { get; init; }
    public DateOnly Fecha { get; init; }
    public TimeOnly Hora { get; init; }
    public int Personas { get; init; }
}
