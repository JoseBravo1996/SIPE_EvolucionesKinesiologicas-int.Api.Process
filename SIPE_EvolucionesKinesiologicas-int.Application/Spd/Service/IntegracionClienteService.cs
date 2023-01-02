using SIPE_Evolucion.Application.Common.Helpers;
using SIPE_Evolucion.Application.Common.Interfaces;
using SIPE_Evolucion.Application.Spd.DTO;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Spd.Service;

public  class IntegracionClienteService : IIntegracionClienteService
{
    private readonly IIntegracionDomicilioService _domicilioSpdService;
    public IntegracionClienteService(IIntegracionDomicilioService domicilioSpdService)
    {
        _domicilioSpdService = domicilioSpdService;
    }

    public void UpdateCliente(ClientePoliza clientePoliza, bool personaFisica, ComCliente cliente,
        int idProvincia)
    {
        cliente = IntegracionClienteSpdHelper.MapActualizacionCliente(cliente, clientePoliza);
        InsertarClienteHist(clientePoliza, cliente);

        if (personaFisica)
            InsetarActualizarPersonaFisica(clientePoliza, cliente);
        else
            InsertarActualizarPersonaJuridica(clientePoliza, cliente);

        _domicilioSpdService.AgregarNuevoDomocilio(clientePoliza.Domicilio, cliente, idProvincia);
    }

    private static void InsertarClienteHist(ClientePoliza clientePoliza, ComCliente cliente)
    {
        if (cliente.ComClientesHists is null)
            cliente.ComClientesHists = new List<ComClientesHist>();
        if (!cliente.ComClientesHists.Any())
        {
            var nuevoClienteHist = IntegracionClienteSpdHelper.MapNuevoClienteHist(clientePoliza);
            cliente.ComClientesHists.Add(nuevoClienteHist);
        }
    }

    public ComCliente GetNuevoCliente(ClientePoliza clientePoliza, bool personaFisica, int idProvincia)
    {
        var nuevoCliente = IntegracionClienteSpdHelper.MapNuevoCliente(clientePoliza);
        var nuevoClienteHist = IntegracionClienteSpdHelper.MapNuevoClienteHist(clientePoliza);
        nuevoCliente.ComClientesHists.Add(nuevoClienteHist);

        if (personaFisica)
            AgregarNuevaPersonaFisica(clientePoliza, nuevoCliente);
        else
            AgregarNuevaPersonaJuridica(clientePoliza, nuevoCliente);

        _domicilioSpdService.AgregarNuevoDomocilio(clientePoliza.Domicilio, nuevoCliente, idProvincia);

        return nuevoCliente;
    }

    private void InsertarActualizarPersonaJuridica(ClientePoliza clientePoliza, ComCliente cliente)
    {
        if (cliente.ComClientesPjuridica is not null)
        {
            cliente.ComClientesPjuridica = IntegracionClienteSpdHelper.MapActualizacionPersonaJuridica(
                    cliente.ComClientesPjuridica, clientePoliza.PersonaJuridica);

            var personaJuridicaHist = cliente.ComClientesPjuridica.ComClientesPjuridicasHists;
            if (!personaJuridicaHist.Any())
            {
                var nuevaPersonaJuridicaHist = IntegracionClienteSpdHelper.MapNuevaPersonaJuridicaHist(clientePoliza.PersonaJuridica);
                nuevaPersonaJuridicaHist.IntIdClienteHistNavigation = cliente.ComClientesHists.First();
                personaJuridicaHist.Add(nuevaPersonaJuridicaHist);
            }
        }
        else
            AgregarNuevaPersonaJuridica(clientePoliza, cliente);
    }

    private void InsetarActualizarPersonaFisica(ClientePoliza clientePoliza, ComCliente cliente)
    {
        if (cliente.ComClientesPfisica is not null) 
        {
            cliente.ComClientesPfisica = IntegracionClienteSpdHelper.MapActualizacionPersonaFisica(
                cliente.ComClientesPfisica, clientePoliza.PersonaFisica);

            var personaFisicaHist = cliente.ComClientesPfisica.ComClientesPfisicasHists;
            if (!personaFisicaHist.Any())
            {
                var nuevaPersonaFisicaHist = IntegracionClienteSpdHelper.MapNuevaPersonaFisicaHist(clientePoliza.PersonaFisica);
                nuevaPersonaFisicaHist.IntIdClienteHistNavigation = cliente.ComClientesHists.First();
                personaFisicaHist.Add(nuevaPersonaFisicaHist);
            }
        }
        else
            AgregarNuevaPersonaFisica(clientePoliza, cliente);
    }

    private void AgregarNuevaPersonaJuridica(ClientePoliza clientePoliza, ComCliente nuevoCliente)
    {
        var nuevaPersonaJuridica = IntegracionClienteSpdHelper.MapNuevaPersonaJuridica(clientePoliza.PersonaJuridica);
        var nuevaPersonaJuridicaHist = IntegracionClienteSpdHelper.MapNuevaPersonaJuridicaHist(clientePoliza.PersonaJuridica);
        nuevaPersonaJuridicaHist.IntIdClienteHistNavigation = nuevoCliente.ComClientesHists.First();
        nuevaPersonaJuridica.ComClientesPjuridicasHists.Add(nuevaPersonaJuridicaHist);
        nuevoCliente.ComClientesPjuridica = nuevaPersonaJuridica;
    }

    private void AgregarNuevaPersonaFisica(ClientePoliza clientePoliza, ComCliente nuevoCliente)
    {
        var nuevaPersonaFisica = IntegracionClienteSpdHelper.MapNuevaPersonaFisica(clientePoliza.PersonaFisica);
        var nuevaPersonaFisicaHist = IntegracionClienteSpdHelper.MapNuevaPersonaFisicaHist(clientePoliza.PersonaFisica);
        nuevaPersonaFisicaHist.IntIdClienteHistNavigation = nuevoCliente.ComClientesHists.First();
        nuevaPersonaFisica.ComClientesPfisicasHists.Add(nuevaPersonaFisicaHist);
        nuevoCliente.ComClientesPfisica = nuevaPersonaFisica;
    }

}