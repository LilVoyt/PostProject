using AutoMapper;
using MediatR;
using PostProject.Application.Features.DTOs;
using PostProject.Application.Features.Security.Password;
using PostProject.DataAcces.Entities;
using PostProject.DataAcces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.Application.Features.Clients.Commands
{
    public sealed record RegisterClientCommand(RegisterDto ClientDto) : IRequest<Guid>;

    public class RegisterClientCommandHandler(IClientRepository clientRepository, IPasswordHasher passwordHasher, IMapper mapper)
        : IRequestHandler<RegisterClientCommand, Guid>
    {
        public async Task<Guid> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
        {
            Client client = mapper.Map<Client>(request, opt =>
            {
                opt.Items["Password"] = passwordHasher.Hash(request.ClientDto.Password);
            });
            await clientRepository.PostAsync(client);
            return client.Id;
        }
    }
}
