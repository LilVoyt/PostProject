using MediatR;
using PostProject.Application.Features.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.Application.Features.Clients.Queries
{
    public sealed record GetClientsQuery() : IRequest<RegisterDto>;

    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, RegisterDto>
    {
        public Task<RegisterDto> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
