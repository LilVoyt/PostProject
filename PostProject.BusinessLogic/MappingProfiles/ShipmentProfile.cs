using AutoMapper;
using PostProject.Application.DTOs;
using PostProject.Application.Features.Shipments.Commands;
using PostProject.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.Application.MappingProfiles
{
    public class ShipmentProfile : Profile
    {
        public ShipmentProfile()
        {
            CreateMap<AddShipmentCommand, Shipment>()
                .ForMember(dest => dest.DepartmentSenderId, opt =>
                    opt.MapFrom(src => src.AddShipmentDto.DepartmentSenderId))
                .ForMember(dest => dest.DepartmentReceiverId, opt =>
                    opt.MapFrom(src => src.AddShipmentDto.DepartmentReceiverId))
                .ForMember(dest => dest.ClientSenderId, opt =>
                    opt.MapFrom(src => src.AddShipmentDto.ClientSenderId))
                .ForMember(dest => dest.ClientReceiverId, opt =>
                    opt.MapFrom(src => src.AddShipmentDto.ClientReceiverId))
                .ForMember(dest => dest.TrackId, opt =>
                    opt.MapFrom((src, dest, destMember, context) => context.Items["TrackId"]))
                .ForMember(dest => dest.Description, opt =>
                    opt.MapFrom(src => src.AddShipmentDto.Description))
                .ForMember(dest => dest.ClientReceiverId, opt =>
                    opt.MapFrom(src => src.AddShipmentDto.ClientReceiverId))
                .ForMember(dest => dest.Price, opt =>
                    opt.MapFrom(src => src.AddShipmentDto.Price))
                .ForMember(dest => dest.DepartureDate, opt =>
                    opt.MapFrom(src => src.AddShipmentDto.DepartureDate));

            CreateMap<Shipment, ShipmentDto>()
                .ForMember(dest => dest.Id, opt =>
                    opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.TrackId, opt =>
                    opt.MapFrom(src => src.TrackId))
                .ForMember(dest => dest.Description, opt =>
                    opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt =>
                    opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.DepartureDate, opt =>
                    opt.MapFrom(src => src.DepartureDate))
                .ForMember(dest => dest.DepartmentReceiver, opt =>
                    opt.MapFrom(src => src.DepartmentReceiver))
                .ForMember(dest => dest.DepartmentSender, opt =>
                    opt.MapFrom(src => src.DepartmentSender))
                .ForMember(dest => dest.ClientSender, opt =>
                    opt.MapFrom(src => src.ClientSender))
                .ForMember(dest => dest.TrackLogs, opt =>
                    opt.MapFrom(src => src.TrackLogs))
                .ForMember(dest => dest.Boxes, opt =>
                    opt.MapFrom(src => src.Boxes));
        }
    }
}
