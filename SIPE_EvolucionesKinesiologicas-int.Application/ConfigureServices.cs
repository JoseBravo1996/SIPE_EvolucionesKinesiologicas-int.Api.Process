using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SIPE_Evolucion.Application.Common.Interfaces;
using SIPE_Evolucion.Application.Evoluciones.Service;
using SIPE_Evolucion.Application.Spd.Service;
using System.Reflection;

namespace SIPE_Evolucion.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IIntegracionClienteService), typeof(IntegracionClienteService));
        services.AddTransient(typeof(IIntegracionDomicilioService), typeof(IntegracionDomicilioService));
        services.AddTransient(typeof(IIntegracionCotizacionService), typeof(IntegracionCotizacionService));
        services.AddTransient(typeof(IIntegracionCotizacionHistService), typeof(IntegracionCotizacionHistService));
        services.AddTransient(typeof(IIntegracionDatosDomesticaService), typeof(IntegracionDatosDomesticaService));
        services.AddTransient(typeof(IIntegracionCambiosEstadoCotizacionService), typeof(IntegracionCambiosEstadoCotizacionService));
        services.AddTransient(typeof(IIntegracionUnidadesComerciales), typeof(IntegracionUnidadesComerciales));
        services.AddTransient(typeof(IIntegracionCostosCompartidosService), typeof(IntegracionCostosCompartidosService));
        services.AddTransient(typeof(IIntegracionCostosCompartidosHistService), typeof(IntegracionCostosCompartidosHistService));
        services.AddTransient(typeof(IIntegracionEvolucionExternaService), typeof(IntegracionEvolucionExternaService));

        return services;
    }
}