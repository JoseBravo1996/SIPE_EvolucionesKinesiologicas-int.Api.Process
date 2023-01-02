using SIPE_Evolucion.Application.Spd.DTO;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Common.Helpers;

public class IntegracionClienteSpdHelper
{
    public static ComCliente MapActualizacionCliente(ComCliente clienteLocal, ClientePoliza datosNuevoCliente)
    {
        clienteLocal.ChrTipoPersona = datosNuevoCliente.ChrTipoPersona;
        clienteLocal.ChrCuitcuilcdi = datosNuevoCliente.ChrCUITCUILCDI;
        clienteLocal.ChrNivelRiesgo = datosNuevoCliente.ChrNivelRiesgo;
        clienteLocal.BitCuentaEspecial = datosNuevoCliente.BitCuentaEspecial;
        clienteLocal.SmiEstablecimientos = (short)datosNuevoCliente.SmiEstablecimientos;
        clienteLocal.IntIdSituacionIva = null;
        clienteLocal.VarActividad = null;
        clienteLocal.DatFechaInicioActividad = null;
        clienteLocal.VarIdClienteCrm = null;
        clienteLocal.VarActOtras = null;

        return clienteLocal;
    }

    public static GenDomicilio MapActualizacionGenDomicilio(GenDomicilio domicilio, DomicilioPoliza domicilioExt, int idProvincia)
    {
        domicilio.VarCpdesnormalizado = domicilioExt.VarCPDesnormalizado ?? null;
        domicilio.IntIdProvDesnormalizada = idProvincia;
        domicilio.IntIdUsuarioModif = domicilioExt.IntIdUsuarioModif;
        domicilio.DatFechaModif = DateTime.Now;
        domicilio.IntIdPais = domicilioExt.IntIdPais;
        domicilio.IntIdUsuarioBaja = null;
        domicilio.IntIdLocalidad = null;
        domicilio.IntIdCalle = null;
        domicilio.VarNumero = null;
        domicilio.ChrPiso = null;
        domicilio.ChrDpto = null;
        domicilio.VarBarrio = null;
        domicilio.VarEntreCalle1 = null;
        domicilio.VarEntreCalle2 = null;
        domicilio.ChrCpa = null;
        domicilio.ChrCodigoPostal = null;
        domicilio.VarLocDesnormalizada = null;
        domicilio.VarCalleDesnormalizada = null;
        domicilio.DatFechaBaja = null;
        domicilio.VarIdDomicilioCrm = null;
        domicilio.VarPaisDesnormalizado = null;
        domicilio.VarProvinciaExtranjera = null;
        domicilio.VarPartidoDepartamento = null;
        domicilio.DatFecha = null;
        domicilio.ChrNormal = null;

        return domicilio;
    }

    public static ComClientesPfisica MapActualizacionPersonaFisica(ComClientesPfisica personaPiscys, PersonaFisicaPoliza personaNueva)
    {
        personaPiscys.VarNombre = personaNueva.VarNombre;
        personaPiscys.VarApellido = personaNueva.VarApellido;
        personaPiscys.ChrTipoDocumento = personaNueva.ChrTipoDocumento;
        personaPiscys.ChrNroDocumento = personaNueva.ChrNroDocumento;
        personaPiscys.ChrSexo = null;
        personaPiscys.DatFechaNacimiento = null;
        personaPiscys.VarLugarNacimiento = null;
        personaPiscys.ChrCiuo = null;
        personaPiscys.IntIdEstadoCivil = null;
        personaPiscys.IntIdNacionalidad = null;
        personaPiscys.VarOcupacion = null;

        return personaPiscys;
    }

    public static ComClientesPjuridica MapActualizacionPersonaJuridica(ComClientesPjuridica personaPiscys, PersonaJuridicaPoliza personaNueva)
    {
        personaPiscys.VarRazonSocial = personaNueva.VarRazonSocial;
        personaPiscys.DatFechaConstitucion = null;
        personaPiscys.VarProtocoloNotarial = null;
        personaPiscys.VarNumeroInscripcion = null;
        personaPiscys.IntIdRegistro = null;
        personaPiscys.VarIibb = null;

        return personaPiscys;
    }

    public static ComCliente MapNuevoCliente(ClientePoliza cliente)
    {
        var nuevoCliente = new ComCliente()
        {
            ChrTipoPersona = cliente.ChrTipoPersona,
            ChrCuitcuilcdi = cliente.ChrCUITCUILCDI,
            ChrNivelRiesgo = cliente.ChrNivelRiesgo,
            SmiEstablecimientos = (short?)cliente.SmiEstablecimientos,
            BitCuentaEspecial = cliente.BitCuentaEspecial,
        };

        return nuevoCliente;
    }

    public static ComClientesHist MapNuevoClienteHist(ClientePoliza cliente)
    {
        var nuevoClienteHist = new ComClientesHist()
        {
            ChrCuitcuilcdi = cliente.ChrCUITCUILCDI,
            ChrTipoPersona = cliente.ChrTipoPersona,
            ChrNivelRiesgo = cliente.ChrNivelRiesgo,
            SmiEstablecimientos = (short?)cliente.SmiEstablecimientos
        };

        return nuevoClienteHist;
    }

    public static ComClientesPfisica MapNuevaPersonaFisica(PersonaFisicaPoliza persona)
    {
        var clientesPfisica = new ComClientesPfisica()
        {
            VarNombre = persona.VarNombre,
            VarApellido = persona.VarApellido,
            ChrTipoDocumento = persona.ChrTipoDocumento,
            ChrNroDocumento = persona.ChrNroDocumento,
        };

        return clientesPfisica;
    }

    public static ComClientesPfisicasHist MapNuevaPersonaFisicaHist(PersonaFisicaPoliza persona)
    {
        var clientesPfisicaHist = new ComClientesPfisicasHist()
        {
            VarNombre = persona.VarNombre,
            VarApellido = persona.VarApellido,
            ChrTipoDocumento = persona.ChrTipoDocumento,
            ChrNroDocumento = persona.ChrNroDocumento,
        };

        return clientesPfisicaHist;
    }

    public static ComClientesPjuridica MapNuevaPersonaJuridica(PersonaJuridicaPoliza persona)
    {
        var clientesPJuridica = new ComClientesPjuridica()
        {
            VarRazonSocial = persona.VarRazonSocial
        };

        return clientesPJuridica;
    }

    public static ComClientesPjuridicasHist MapNuevaPersonaJuridicaHist(PersonaJuridicaPoliza persona)
    {
        var clientesPJuridicaHist = new ComClientesPjuridicasHist()
        {
            VarRazonSocial = persona.VarRazonSocial
        };

        return clientesPJuridicaHist;
    }

    public static GenDomicilio MapNuevoDomicilio(DomicilioPoliza domicilio, int idProvincia)
    {
        var clientesPJuridicaHist = new GenDomicilio()
        {
            VarCpdesnormalizado = domicilio.VarCPDesnormalizado,
            IntIdProvDesnormalizada = idProvincia,
            IntIdUsuarioAlta = domicilio.IntIdUsuarioAlta,
            DatFechaAlta = domicilio.DatFechaAlta,
            IntIdUsuarioModif = domicilio.IntIdUsuarioModif,
            DatFechaModif = domicilio.DatFechaModif,
            IntIdPais = domicilio.IntIdPais
        };

        return clientesPJuridicaHist;
    }

    public static ComDomiciliosCliente MapNuevoDomicilioCliente(ComCliente cliente, GenDomicilio domicilio, int tipoDomicilio)
    {
        var domicilioCliente = new ComDomiciliosCliente()
        {
            IntIdClienteNavigation = cliente,
            IntIdDomicilioNavigation = domicilio,
            IntIdTipoDomicilio = tipoDomicilio
        };

        return domicilioCliente;
    }
}
