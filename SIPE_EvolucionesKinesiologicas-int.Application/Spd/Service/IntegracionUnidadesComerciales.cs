using SIPE_Evolucion.Application.Common.Interfaces;
using SIPE_Evolucion.Domain.Entities;
using SIPE_Evolucion.Domain.Enum;

namespace SIPE_Evolucion.Application.Spd.Service;

public  class IntegracionUnidadesComerciales : IIntegracionUnidadesComerciales
{
    public async Task<List<SyaCotizacionUnidadComercial>> GetDatosUnidadesComerciales(SyaCotizacion cotizacion)
    {
        return await Task.Run(() =>
        {
            var result = new List<SyaCotizacionUnidadComercial>();
            foreach (var solicitud in cotizacion.SolicitudesCostosCompartidosNav)
            {
                if(solicitud.IntIdEstado == (int)CostoCompartidoEstados.Compartido)
                {
                    result.Add(new SyaCotizacionUnidadComercial()
                    {
                        IntIdUnidadComercial = solicitud.IntIdUnidadComercial,
                        DatFechaIncorporacion = solicitud.DatFecha,
                        SyaCotizacionNav = cotizacion
                    });
                }
            }
            return result;
        });
    }
}