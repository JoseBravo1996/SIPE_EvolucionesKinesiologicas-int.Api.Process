using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DatabaseFacade dbFacade { get; set; }
        DbSet<ComCliente> ComClientes { get; set; }
        DbSet<ComClientesHist> ComClientesHists { get; set; }
        DbSet<ComClientesPfisica> ComClientesPfisicas { get; set; }
        DbSet<ComClientesPfisicasHist> ComClientesPfisicasHists { get; set; }
        DbSet<ComClientesPjuridica> ComClientesPjuridicas { get; set; }
        DbSet<ComClientesPjuridicasHist> ComClientesPjuridicasHists { get; set; }
        DbSet<ComDomiciliosCliente> ComDomiciliosClientes { get; set; }
        DbSet<GenDomicilio> GenDomicilios { get; set; }
        DbSet<GenProvincia> GenProvincias { get; set; }
        DbSet<SyaCambiosEstadoCotizacion> SyaCambiosEstadoCotizacions { get; set; }
        DbSet<SyaCotizacion> SyaCotizaciones { get; set; }
        DbSet<SyaCotizacionesHist> SyaCotizacionesHists { get; set; }
        DbSet<SyaDatosComplementariosCotizacionDomestica> SyaDatosComplementariosCotizacionDomesticas { get; set; }
        DbSet<ComUnidadesComerciale> ComUnidadesComerciales { get; set; }
        DbSet<SyaCotizacionUnidadComercial> SyaCotizacionUnidadComercials { get; set; }
        DbSet<SyaSolicitudesCostosCompartido> SyaSolicitudesCostosCompartidos { get; set; }
        DbSet<SyaSolicitudesCostosCompartidosHist> SyaSolicitudesCostosCompartidosHists { get; set; }
        DbSet<GmEvolucionesExternasHist> EvolucionesExternasHist { get; set; }
        DbSet<GmEvolucionesExternas> GmEvolucionesExternas { get; set; }
        DbSet<PRTPrestador> Prestadores { get; set; }
        DbSet<GmEvolucionesExternasInnominado> GmEvolucionesExternasInnominado { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
    }
}