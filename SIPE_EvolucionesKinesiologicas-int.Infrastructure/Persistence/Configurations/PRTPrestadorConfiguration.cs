using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Infrastructure.Persistence.Configurations
{
    public class PRTPrestadorConfiguration : IEntityTypeConfiguration<PRTPrestador>
    {
        public void Configure(EntityTypeBuilder<PRTPrestador> builder)
        {
            builder.ToTable("PRT_Prestadores").HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("intIdPrestador");
            builder.Property(p => p.Cuil).HasColumnName("chrCuit");
            builder.Property(p => p.NroSucursal).HasColumnName("intNroSucursal");
        }
    }
}
