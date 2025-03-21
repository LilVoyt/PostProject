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
                    opt.MapFrom(src => src.DepartmentSenderId))
                .ForMember(dest => dest.DepartmentReceiverId, opt =>
                    opt.MapFrom(src => src.DepartmentReceiverId))
                .ForMember(dest => dest.ClientSenderId, opt =>
                    opt.MapFrom(src => src.ClientSenderId))
                .ForMember(dest => dest.ClientReceiverId, opt =>
                    opt.MapFrom(src => src.ClientReceiverId))
                .ForMember(dest => dest.TrackId, opt =>
                    opt.MapFrom((src, dest, destMember, context) => context.Items["TrackId"]))
                .ForMember(dest => dest.Description, opt =>
                    opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ClientReceiverId, opt =>
                    opt.MapFrom(src => src.ClientReceiverId))
                .ForMember(dest => dest.Price, opt =>
                    opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.DepartureDate, opt =>
                    opt.MapFrom(src => src.DepartureDate));

        }
    }
}
