namespace SIPE_Evolucion.Domain.Entities
{
    public partial class ComCliente
    {
        public ComCliente()
        {
            ComClientesHists = new HashSet<ComClientesHist>();
            ComDomiciliosClientes = new HashSet<ComDomiciliosCliente>();
        }

        public int IntIdCliente { get; set; }
        public string ChrTipoPersona { get; set; } = null!;
        public string ChrCuitcuilcdi { get; set; } = null!;
        public int? IntIdSituacionIva { get; set; }
        public string? ChrNivelRiesgo { get; set; }
        public string? VarActividad { get; set; }
        public short? SmiEstablecimientos { get; set; }
        public DateTime? DatFechaInicioActividad { get; set; }
        public string? VarIdClienteCrm { get; set; }
        public bool BitCuentaEspecial { get; set; }
        public string? VarActOtras { get; set; }

        public virtual ComClientesPfisica ComClientesPfisica { get; set; } = null!;
        public virtual ComClientesPjuridica ComClientesPjuridica { get; set; } = null!;
        public virtual ICollection<ComClientesHist> ComClientesHists { get; set; }
        public virtual ICollection<ComDomiciliosCliente> ComDomiciliosClientes { get; set; }
    }
}
