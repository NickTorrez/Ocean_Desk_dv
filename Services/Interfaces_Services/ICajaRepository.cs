using Ocean_Desk_dv.Models.DTOs;

namespace Ocean_Desk_dv.Services.Interfaces_Services;

public interface ICajaRepository : IDisposable
{
    CashRegisterDto? ObtenerCajaAbiertaMasReciente();
    CashRegisterDto? ObtenerUltimoCierre();
    bool ExisteCajaAbierta();
    bool TieneCajaAbiertaParaUsuario(int usuarioId);
    CashRegisterDto? AbrirCaja(int usuarioId, decimal montoApertura, DateTime fechaApertura);
    void RegistrarMovimiento(int cajaId, int usuarioId, string tipo, string metodoPago, string concepto, decimal monto);
    void CerrarCaja(int cajaId, int usuarioId, decimal efectivoEsperado, decimal efectivoReal, decimal diferencia, DateTime fechaCierre);
    void SincronizarVentasCompletadas(int cajaId, DateTime fechaApertura);
    ResumenCajaDto ObtenerResumen(int cajaId, decimal montoApertura);
}
