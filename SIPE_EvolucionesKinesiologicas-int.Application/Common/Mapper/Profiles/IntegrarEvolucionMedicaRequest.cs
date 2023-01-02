

using AutoMapper;
using SIPE_Evolucion.Application.Evoluciones.DTO;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Common.Mapper.Profiles
{
    public class EvolucionProfile : Profile
    {
        public EvolucionProfile()
        {
            CreateMap<EvolucionMedicaDto, GmEvolucionesExternas >();
            CreateMap<TrabajadorDto, GmEvolucionesExternasInnominado >();
        }
    }
}
