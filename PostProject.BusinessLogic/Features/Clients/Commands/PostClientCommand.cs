using MediatR;
using PostProject.Application.Features.DTOs;
using PostProject.DataAcces.Entities;
using PostProject.DataAcces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.Application.Features.Clients.Commands
{
    public sealed record PostClientCommand(ClientDto ClientDto) : IRequest<ClientDto>;

    public class PostClientCommandHandler(IClientRepository clientRepository) : IRequestHandler<PostClientCommand, ClientDto>
    {
        public async Task<ClientDto> Handle(PostClientCommand request, CancellationToken cancellationToken)
        {
            Client client = new Client()
            {
                Id = Guid.NewGuid(),
                FirstName = request.ClientDto.FirstName
            };
            await clientRepository.PostAsync(client);
            return request.ClientDto;
        }
    }
}
