using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SIPE_Evolucion.Application.Common.Interfaces;
using SIPE_Evolucion.Infrastructure.Persistence;

namespace SIPE_Evolucion.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("PISCYSEFCoreDatabase"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddDbContext<SipeDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("EFCoreDatabase"),
                    b => b.MigrationsAssembly(typeof(SipeDbContext).Assembly.FullName)));

            services.AddScoped<ISipeDbContext>(provider => provider.GetRequiredService<SipeDbContext>());

            return services;
        }
    }
}