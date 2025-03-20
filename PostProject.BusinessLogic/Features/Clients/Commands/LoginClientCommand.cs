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
    public sealed record LoginClientCommand(LoginDto LoginDto) : IRequest<Guid>;

    public class LoginClientCommandHandler(IClientRepository clientRepository, IPasswordHasher passwordHasher) : IRequestHandler<LoginClientCommand, Guid>
    {
        public async Task<Guid> Handle(LoginClientCommand request, CancellationToken cancellationToken)
        {
            Client client = await clientRepository.FindByPhoneNumberAsync(request.LoginDto.PhoneNumber);
            bool isPasswordValid = passwordHasher.Verify(request.LoginDto.Password, client.Password);
            if (!isPasswordValid)
            {
                throw new KeyNotFoundException("Password is not valid");
            }
            return client.Id;
        }
    }
}
