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
    public class BoxProfile : Profile
    {
        public BoxProfile()
        {
            CreateMap<BoxDto, Box>()
                .ForMember(dest => dest.ShipmentId, opt =>
                   opt.MapFrom((src, dest, destMember, context) => context.Items["ShipmentId"]))
               .ForMember(dest => dest.Weight, opt =>
                   opt.MapFrom(src => src.Weight))
               .ForMember(dest => dest.Height, opt =>
                   opt.MapFrom(src => src.Height))
               .ForMember(dest => dest.Width, opt =>
                   opt.MapFrom(src => src.Width))
               .ForMember(dest => dest.Price, opt =>
                   opt.MapFrom(src => src.Price));
        }
    }
}
