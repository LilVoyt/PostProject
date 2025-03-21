using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PostProject.Application.DTOs;
using PostProject.Application.Features.Clients.Commands;
using PostProject.Application.Features.Clients.Queries;

namespace PostProject.Presentation.Controllers
{
    [Route("api/client")]
    [ApiController]
    public class ClientController(IMediator mediator) : ControllerBase
    {
        [HttpGet("get")]
        [Authorize]
        public async Task<RegisterDto> GetClients()
        {
            return await mediator.Send(new GetClientsQuery());
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterClient(RegisterDto registerDto)
        {
            RegisterClientCommand registerClientCommand = new RegisterClientCommand(registerDto);
            var res = await mediator.Send(registerClientCommand);
            return Ok(res);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginClient(LoginDto loginDto)
        {
            LoginClientCommand editClientCommand = new LoginClientCommand(loginDto);
            var res = await mediator.Send(editClientCommand);
            return Ok(res);
        }
    }
}
