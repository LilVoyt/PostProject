using MediatR;
using Microsoft.AspNetCore.Mvc;
using PostProject.Application.Features.Shipments.Commands;

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

    }
}
