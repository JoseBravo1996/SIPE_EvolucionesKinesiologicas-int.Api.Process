using FluentValidation;
using SIPE_Evolucion.Application.Common.Interfaces;

namespace SIPE_Evolucion.Application.Evoluciones.Commands.IntegrarEvoluconMedica
{
    public class IntegrarEvolucionMedicaRequestValidator : AbstractValidator<IntegrarEvolucionMedicaRequest>
    {
        public IntegrarEvolucionMedicaRequestValidator(IApplicationDbContext _context)
        {
            RuleFor(x => x.Evolucion).NotNull().WithMessage("La evolución es requerida.");
            RuleFor(x => x.DatoEvolucionExterna).NotNull().WithMessage("Los datos de evolución externa son requeridos.");
            RuleFor(x => x.Cuil).NotEmpty().WithMessage("El campo 'Cuil' es requerido.");
            RuleFor(x => x.Evolucion.ManoHabil).NotEmpty().WithMessage("El campo 'Mano Habil' es requerido.");
            RuleFor(x => x.Evolucion.AtencionTipoId).NotEmpty().WithMessage("El campo 'AtencionTipoId' es requerido.");
            RuleFor(x => x.Evolucion.NecesitaTraslado).NotEmpty().WithMessage("El campo 'NecesitaTraslado' es requerido.");
            RuleFor(x => x.Evolucion.MedicoId).NotEmpty().WithMessage("El campo 'MedicoId' es requerido.");
            RuleFor(x => x.Evolucion.FechaEvolucion).NotEmpty().WithMessage("El campo 'FechaEvolucion' es requerido.");
            RuleFor(x => x.Evolucion.Diagnostico).NotEmpty().WithMessage("El campo 'Diagnostico' es requerido.");
            RuleFor(x => x.Evolucion.SiniestroTipoId).NotEmpty().WithMessage("El campo 'SiniestroTipoId' es requerido.");
            RuleFor(x => x.Evolucion.ZonaAfectadaId).NotEmpty().WithMessage("El campo 'ZonaAfectadaId' es requerido.");
            RuleFor(x => x.Evolucion.AgenteMaterialId).NotEmpty().WithMessage("El campo 'AgenteMaterialId' es requerido.");
            RuleFor(x => x.Evolucion.NaturalezaLesionId).NotEmpty().WithMessage("El campo 'NaturalezaLesionId' es requerido.");
            RuleFor(x => x.Evolucion.SiniestroDescripcion).NotEmpty().WithMessage("El campo 'SiniestroDescripcion' es requerido.");
            RuleFor(x => x.Evolucion.EsNominado).NotEmpty().WithMessage("El campo 'EsNominado' es requerido.");
            RuleFor(x => x.Evolucion.EvolucionEstadoId).NotEmpty().WithMessage("El campo 'EvolucionEstadoId' es requerido.");
            RuleFor(x => x.Evolucion.UsuarioId).NotEmpty().WithMessage("El campo 'UsuarioId' es requerido.");
            RuleFor(x => x.Evolucion.NecesitaTraslado).NotEmpty().WithMessage("El campo 'NecesitaTraslado' es requerido.");
            RuleFor(x => x.Evolucion.NecesitaTraslado).NotEmpty().WithMessage("El campo 'NecesitaTraslado' es requerido.");
            RuleFor(x => x.DatoEvolucionExterna.EvolucionMedicaId).NotEmpty().WithMessage("El campo 'EvolucionMedicaId' es requerido.");
            RuleFor(x => x.DatoEvolucionExterna.NroDenuncia).NotEmpty().WithMessage("El campo 'NroDenuncia' es requerido.");
            RuleFor(x => x.DatoEvolucionExterna.NroSiniestro).NotEmpty().WithMessage("El campo 'NroSiniestro' es requerido.");
            RuleFor(x => x.DatoEvolucionExterna.DelegacionOrigen).NotEmpty().WithMessage("El campo 'DelegacionOrigen' es requerido.");
            RuleFor(x => x.DatoEvolucionExterna.Cuit).NotEmpty().WithMessage("El campo 'Cuit' es requerido.");
            RuleFor(x => x.DatoEvolucionExterna.Cuil).NotEmpty().WithMessage("El campo 'Cuil' es requerido.");
        }
    }
}
