namespace SIPE_Evolucion.Domain.Enum
{
    public enum EstadosCotizacion
    {
    	PendienteInformacionAdicional = 1,
        PendienteCotizarSuscripcion = 2,
        PendienteCotizarMedio = 3,
        PendienteEstudioTecnicoPrevio = 4,
        Rechazada = 5,
        Aprobada = 6,
        PendienteAprobarComercialSuperior = 7,
        PendienteAprobarMedio = 8,
        Aceptada = 9,
        AsignadaPropuesta = 10,
        CanceladaSolicitud = 11,
        Cancelada = 12,
        AsignadaContrato = 13,
        SoloRegistro = 14,
        PendienteInformacionComercial = 15,
        PendienteEtpItp = 16,
        PendienteAprobacionSujetaEtpItp = 17,
        AprobadaSujetaEtpItp = 18,
        AceptadasujetaEtpItp = 19
    }
}