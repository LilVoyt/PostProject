using AutoMapper;
using MediatR;
using PostProject.Application.DTOs;
using PostProject.DataAcces.Entities;
using PostProject.DataAcces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.Application.Features.Shipments.Queries
{
    public sealed record GetShipmentsByClientId(Guid ClientId) : IRequest<List<Shipment>>;

    public class GetShipmentByClientIdHandler(IShipmentRepository shipmentRepository, IMapper mapper) : IRequestHandler<GetShipmentsByClientId, List<Shipment>>
    {
        public async Task<List<Shipment>> Handle(GetShipmentsByClientId request, CancellationToken cancellationToken)
        {
            List<Shipment> shipments = await shipmentRepository.GetShipmentsByClientId(request.ClientId);

            List<ShipmentDto> shipmentsDto = new List<ShipmentDto>();

            foreach(Shipment shipment in shipments)
            {
                shipmentsDto.Add(mapper.Map<ShipmentDto>(shipment));
            }

            return shipments;
        }
    }
}
