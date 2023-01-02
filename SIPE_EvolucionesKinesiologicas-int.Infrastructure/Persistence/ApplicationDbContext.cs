using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SIPE_Evolucion.Application.Common.Interfaces;
using SIPE_Evolucion.Domain.Entities;
using System.Reflection;

namespace SIPE_Evolucion.Infrastructure.Persistence
{
    public partial class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext()
        {
            dbFacade = Database;
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            dbFacade = Database;
        }
        public DatabaseFacade dbFacade { get; set; }
        public virtual DbSet<ComCliente> ComClientes { get; set; } = null!;
        public virtual DbSet<ComClientesHist> ComClientesHists { get; set; } = null!;
        public virtual DbSet<ComClientesPfisica> ComClientesPfisicas { get; set; } = null!;
        public virtual DbSet<ComClientesPfisicasHist> ComClientesPfisicasHists { get; set; } = null!;
        public virtual DbSet<ComClientesPjuridica> ComClientesPjuridicas { get; set; } = null!;
        public virtual DbSet<ComClientesPjuridicasHist> ComClientesPjuridicasHists { get; set; } = null!;
        public virtual DbSet<ComDomiciliosCliente> ComDomiciliosClientes { get; set; } = null!;
        public virtual DbSet<GenDomicilio> GenDomicilios { get; set; } = null!;
        public virtual DbSet<GenProvincia> GenProvincias { get; set; } = null!;
        public virtual DbSet<GmEvolucionesExternasHist> EvolucionesExternasHist { get; set; } = null!;
        public virtual DbSet<GmEvolucionesExternas> GmEvolucionesExternas { get; set; } = null!;
        public virtual DbSet<SyaCambiosEstadoCotizacion> SyaCambiosEstadoCotizacions { get; set; } = null!;
        public virtual DbSet<SyaCotizacion> SyaCotizaciones { get; set; } = null!;
        public virtual DbSet<SyaCotizacionesHist> SyaCotizacionesHists { get; set; } = null!;
        public virtual DbSet<SyaDatosComplementariosCotizacionDomestica> SyaDatosComplementariosCotizacionDomesticas { get; set; } = null!;
        public virtual DbSet<ComUnidadesComerciale> ComUnidadesComerciales { get; set; } = null!;
        public virtual DbSet<SyaCotizacionUnidadComercial> SyaCotizacionUnidadComercials { get; set; } = null!;
        public virtual DbSet<SyaSolicitudesCostosCompartido> SyaSolicitudesCostosCompartidos { get; set; } = null!;
        public virtual DbSet<SyaSolicitudesCostosCompartidosHist> SyaSolicitudesCostosCompartidosHists { get; set; } = null!;
        public virtual DbSet<PRTPrestador> Prestadores { get; set; }
        public virtual DbSet<GmEvolucionesExternasInnominado> GmEvolucionesExternasInnominado { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
