using Microsoft.EntityFrameworkCore;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Common.Interfaces
{
    public interface ISipeDbContext
    {
        DbSet<GmEvolucionesExternasIntermedia> GmEvolucionesExternasIntermedia { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new());
    }
}