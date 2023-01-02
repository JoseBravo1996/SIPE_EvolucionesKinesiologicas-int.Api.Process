using SIPE_Evolucion.Application.Common.Helpers;
using SIPE_Evolucion.Application.Common.Interfaces;
using SIPE_Evolucion.Application.Spd.DTO;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Spd.Service;

public  class IntegracionDomicilioService : IIntegracionDomicilioService
{
    public void AgregarNuevoDomocilio(DomicilioPoliza domicilioPoliza, ComCliente cliente, int idProvincia)
    {
        var nuevoGenDomicilio = IntegracionClienteSpdHelper.MapNuevoDomicilio(domicilioPoliza, idProvincia);
        var domicilioTipoUno = IntegracionClienteSpdHelper.MapNuevoDomicilioCliente(cliente, nuevoGenDomicilio, 1);
        var domicilioTipoDos = IntegracionClienteSpdHelper.MapNuevoDomicilioCliente(cliente, nuevoGenDomicilio, 2);

        cliente.ComDomiciliosClientes.Add(domicilioTipoUno);
        cliente.ComDomiciliosClientes.Add(domicilioTipoDos);
    }
}
