using Microsoft.EntityFrameworkCore;
using SIPE_Evolucion.Application.Common.Interfaces;
using SIPE_Evolucion.Domain.Entities;
using System.Reflection;

namespace SIPE_Evolucion.Infrastructure.Persistence
{
    public partial class SipeDbContext : DbContext, ISipeDbContext
    {
        public SipeDbContext()
        {
        }

        public SipeDbContext(DbContextOptions<SipeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GmEvolucionesExternasIntermedia> GmEvolucionesExternasIntermedia { get; set; }

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
