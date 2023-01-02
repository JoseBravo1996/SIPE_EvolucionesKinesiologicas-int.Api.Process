namespace SIPE_Evolucion.Domain.Entities
{
    public partial class ComClientesHist
    {
        public ComClientesHist()
        {
            ComClientesPfisicasHists = new HashSet<ComClientesPfisicasHist>();
            ComClientesPjuridicasHists = new HashSet<ComClientesPjuridicasHist>();
        }

        public int IntIdClienteHist { get; set; }
        public int IntIdCliente { get; set; }
        public string ChrTipoPersona { get; set; } = null!;
        public string ChrCuitcuilcdi { get; set; } = null!;
        public int? IntIdSituacionIva { get; set; }
        public string? ChrNivelRiesgo { get; set; }
        public string? VarActividad { get; set; }
        public short? SmiEstablecimientos { get; set; }
        public DateTime? DatFechaInicioActividad { get; set; }
        public string? VarIdClienteCrm { get; set; }
        public string? VarActOtras { get; set; }

        public virtual ComCliente IntIdClienteNavigation { get; set; } = null!;
        public virtual ICollection<ComClientesPfisicasHist> ComClientesPfisicasHists { get; set; }
        public virtual ICollection<ComClientesPjuridicasHist> ComClientesPjuridicasHists { get; set; }
    }
}
