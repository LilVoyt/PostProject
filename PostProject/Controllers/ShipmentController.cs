using MediatR;
using Microsoft.AspNetCore.Mvc;
using PostProject.Application.Features.Shipments.Commands;
using PostProject.Application.Features.Shipments.Queries;

namespace PostProject.Presentation.Controllers
{
    [Route("api/shipment")]
    [ApiController]
    public class ShipmentController(IMediator mediator) : ControllerBase
    {
        [HttpPost("create-shipment")]
        public async Task<IActionResult> CreateShipment(AddShipmentCommand addShipmentCommand)
        {
            string trackId = await mediator.Send(addShipmentCommand);

            return Ok(trackId);
        }

        [HttpGet("get-shipments")]
        public async Task<IActionResult> GetShipments(Guid Id)
        {
            GetShipmentsByClientId getShipmentsByClientId = new GetShipmentsByClientId(Id);

            var res = await mediator.Send(getShipmentsByClientId);
            return Ok(res);
        }
    }
}
