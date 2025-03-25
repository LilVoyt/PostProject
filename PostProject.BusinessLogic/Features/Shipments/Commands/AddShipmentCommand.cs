using AutoMapper;
using MediatR;
using PostProject.Application.DTOs;
using PostProject.Application.Helpers;
using PostProject.Application.Security.Password;
using PostProject.DataAcces.Entities;
using PostProject.DataAcces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.Application.Features.Shipments.Commands
{
    public sealed record AddShipmentCommand(AddShipmentDto AddShipmentDto) : IRequest<string>;

    public class AddShipmentCommandHandler(IShipmentRepository shipmentRepository, IMapper mapper, 
        ITrackIdService trackIdService, IBoxRepository boxRepository, ITrackLogRepository trackLogRepository) 
        : IRequestHandler<AddShipmentCommand, string>
    {
        public async Task<string> Handle(AddShipmentCommand request, CancellationToken cancellationToken)
        {
            Shipment shipment = mapper.Map<Shipment>(request, opt =>
            {
                opt.Items["TrackId"] = trackIdService.GenerateNumericTrackId();
            });

            List<Box> boxes = new List<Box>();

            foreach(BoxDto boxDto in request.AddShipmentDto.BoxDtos)
            {
                boxes.Add(mapper.Map<Box>(boxDto, opt =>
                {
                    opt.Items["ShipmentId"] = shipment.Id;
                }));
            }

            await shipmentRepository.PostShipment(shipment);

            await boxRepository.PostBoxesAsync(boxes);

            await trackLogRepository.LogShipment(shipment.Id, "Shipment created!");

            return shipment.TrackId;
        }
    }
}
