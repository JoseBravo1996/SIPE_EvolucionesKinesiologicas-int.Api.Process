namespace SIPE_Evolucion.Application.Spd.DTO
{
    public class ClientePoliza
    {
        public ClientePoliza()
        {
            PersonaFisica = new PersonaFisicaPoliza();
            PersonaJuridica = new PersonaJuridicaPoliza();
            Domicilio = new DomicilioPoliza();
        }

        public int IntIdCliente { get; set; }
        public string? ChrTipoPersona { get; set; }
        public string? ChrCUITCUILCDI { get; set; }
        public string? ChrNivelRiesgo { get; set; }
        public int SmiEstablecimientos { get; set; }
        public bool BitCuentaEspecial { get; set; }
        public DomicilioPoliza Domicilio { get; set; }
        public PersonaFisicaPoliza PersonaFisica { get; set; }
        public PersonaJuridicaPoliza PersonaJuridica { get; set; }
    }

    public class PersonaFisicaPoliza
    {
        public int IntIdCliente { get; set; }
        public string? VarNombre { get; set; }
        public string? VarApellido { get; set; }
        public string? ChrTipoDocumento { get; set; }
        public string? ChrNroDocumento { get; set; }

    }

    public class PersonaJuridicaPoliza
    {
        public int IntIdCliente { get; set; }
        public string? VarRazonSocial { get; set; }
    }

    public class DomicilioPoliza
    {
        public int IntIdDomicilio { get; set; }
        public string? VarCPDesnormalizado { get; set; }
        public int IntIdProvDesnormalizada { get; set; }
        public int IntIdUsuarioAlta { get; set; }
        public DateTime DatFechaAlta { get; set; }
        public int IntIdUsuarioModif { get; set; }
        public DateTime DatFechaModif { get; set; }
        public int IntIdPais { get; set; }
    }
}
