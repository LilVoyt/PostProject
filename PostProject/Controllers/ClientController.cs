using MediatR;
using Microsoft.AspNetCore.Mvc;
using PostProject.Application.Features.Clients.Queries;
using PostProject.Application.Features.DTOs;

namespace PostProject.Presentation.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController(IMediator mediator) : ControllerBase
    {
        [HttpGet("get")]
        public async Task<ClientDto> GetClients()
        {
            return await mediator.Send(new GetClientsQuery());
        }
    }
}
