

using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SIPE_Evolucion.Application.Common.Mapper.Profiles;

namespace SIPE_Evolucion.Application.Common.Mapper
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMapperServices(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new EvolucionProfile());
                mc.AllowNullCollections = true;
            });
            var mapper = mappingConfig.CreateMapper();
            mapper.ConfigurationProvider.CompileMappings();

            services.AddSingleton(mapper);

            return services;
        }
    }
}
