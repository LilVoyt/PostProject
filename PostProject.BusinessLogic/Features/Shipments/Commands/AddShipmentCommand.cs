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
    public sealed record AddShipmentCommand(Guid DepartmentSenderId, Guid DepartmentReceiverId, Guid ClientSenderId,
        Guid ClientReceiverId, string Description, decimal? Price, DateTime DepartureDate, List<BoxDto> BoxDtos) : IRequest<string>;

    public class AddShipmentCommandHandler(IShipmentRepository shipmentRepository, IMapper mapper, 
        ITrackIdService trackIdService, IBoxRepository boxRepository) 
        : IRequestHandler<AddShipmentCommand, string>
    {
        public async Task<string> Handle(AddShipmentCommand request, CancellationToken cancellationToken)
        {
            Shipment shipment = mapper.Map<Shipment>(request, opt =>
            {
                opt.Items["TrackId"] = trackIdService.GenerateNumericTrackId();
            });

            await shipmentRepository.PostShipment(shipment);

            List<Box> boxes = new List<Box>();

            foreach(BoxDto boxDto in request.BoxDtos)
            {
                boxes.Add(mapper.Map<Box>(boxDto, opt =>
                {
                    opt.Items["ShipmentId"] = shipment.Id;
                }));
            }

            await boxRepository.PostBoxesAsync(boxes);

            return shipment.TrackId;
        }
    }
}
