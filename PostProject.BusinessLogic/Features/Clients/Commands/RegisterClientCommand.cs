using AutoMapper;
using MediatR;
using PostProject.Application.DTOs;
using PostProject.Application.Security.Jwt;
using PostProject.Application.Security.Password;
using PostProject.DataAcces.Entities;
using PostProject.DataAcces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.Application.Features.Clients.Commands
{
    public sealed record RegisterClientCommand(RegisterDto ClientDto) : IRequest<string>;

    public class RegisterClientCommandHandler(IClientRepository clientRepository, 
        IPasswordHasher passwordHasher, IMapper mapper, IJwtHandler jwtHandler)
        : IRequestHandler<RegisterClientCommand, string>
    {
        public async Task<string> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
        {
            //var dto1 = new RegisterDto("Oleh", "Ivanov", DateTime.Now, "1234567890", "oleh@gmail.com", DateTime.UtcNow, "password123");
            //var dto2 = dto1 with { LastName = "Petrov" };

            //Console.WriteLine(dto1); // RegisterDto { FirstName = Oleh, LastName = Ivanov, ... }
            //Console.WriteLine(dto2); // RegisterDto { FirstName = Oleh, LastName = Petrov, ... }

            //copy with changes using record


            Client client = mapper.Map<Client>(request, opt =>
            {
                opt.Items["Password"] = passwordHasher.Hash(request.ClientDto.Password);
            });
            await clientRepository.PostAsync(client);

            var res = jwtHandler.Handle(client);

            return res;
        }
    }
}
