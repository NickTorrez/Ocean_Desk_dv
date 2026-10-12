namespace Ocean_Desk_dv.Models.DTOs;

public sealed class ResultadoOperacionDto
{
    public bool Exito { get; init; }
    public string Mensaje { get; init; } = string.Empty;
    public static ResultadoOperacionDto Correcto(string mensaje = "Operación realizada correctamente.") => new() { Exito = true, Mensaje = mensaje };
    public static ResultadoOperacionDto Fallido(string mensaje) => new() { Exito = false, Mensaje = mensaje };
}
