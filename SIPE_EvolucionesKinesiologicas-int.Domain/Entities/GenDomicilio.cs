namespace SIPE_Evolucion.Domain.Entities
{
    public partial class GenDomicilio
    {
        public GenDomicilio()
        {
            ComDomiciliosClientes = new HashSet<ComDomiciliosCliente>();
        }

        public int IntIdDomicilio { get; set; }
        public int? IntIdLocalidad { get; set; }
        public int? IntIdCalle { get; set; }
        public string? VarNumero { get; set; }
        public string? ChrPiso { get; set; }
        public string? ChrDpto { get; set; }
        public string? VarBarrio { get; set; }
        public string? VarEntreCalle1 { get; set; }
        public string? VarEntreCalle2 { get; set; }
        public string? ChrCpa { get; set; }
        public string? ChrCodigoPostal { get; set; }
        public string? VarLocDesnormalizada { get; set; }
        public string? VarCalleDesnormalizada { get; set; }
        public string? VarCpdesnormalizado { get; set; }
        public int? IntIdProvDesnormalizada { get; set; }
        public int IntIdUsuarioAlta { get; set; }
        public DateTime DatFechaAlta { get; set; }
        public int IntIdUsuarioModif { get; set; }
        public DateTime DatFechaModif { get; set; }
        public int? IntIdUsuarioBaja { get; set; }
        public DateTime? DatFechaBaja { get; set; }
        public string? VarIdDomicilioCrm { get; set; }
        public string? VarPaisDesnormalizado { get; set; }
        public int IntIdPais { get; set; }
        public string? VarProvinciaExtranjera { get; set; }
        public string? VarPartidoDepartamento { get; set; }
        public DateTime? DatFecha { get; set; }
        public string? ChrNormal { get; set; }

        public virtual ICollection<ComDomiciliosCliente> ComDomiciliosClientes { get; set; }
    }
}
