using MediatR;
using Microsoft.EntityFrameworkCore;
using SIPE_Evolucion.Application.Common.Interfaces;
using SIPE_Evolucion.Domain.Entities;

namespace SIPE_Evolucion.Application.Spd.Queries.GetComCliente
{
    public class GetComClienteRequest : IRequest<GetComClienteResponse>
    {
        public string CuitCuil { get; private set; }

        public GetComClienteRequest(string cuitCuil)
        {
            CuitCuil = cuitCuil;
        }
    }

    public class GetComClienteRequestHandler : IRequestHandler<GetComClienteRequest, GetComClienteResponse>
    {
        private readonly IApplicationDbContext _context;

        public GetComClienteRequestHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        async Task<GetComClienteResponse> IRequestHandler<GetComClienteRequest, GetComClienteResponse>.Handle(GetComClienteRequest request, CancellationToken cancellationToken)
        {
            var comCliente = await _context.ComClientes.FirstOrDefaultAsync(c => c.ChrCuitcuilcdi == request.CuitCuil, cancellationToken);
            if (comCliente is null)
                return new GetComClienteResponse(new ComCliente());
            return new GetComClienteResponse(comCliente);
        }
    }
}