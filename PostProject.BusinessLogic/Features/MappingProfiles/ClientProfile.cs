using AutoMapper;
using PostProject.Application.Features.Clients.Commands;
using PostProject.DataAcces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostProject.Application.Features.MappingProfiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<RegisterClientCommand, Client>()
                .ForMember(dest => dest.Id, opt =>
                opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.FirstName, opt =>
                    opt.MapFrom(src => src.ClientDto.FirstName))
                .ForMember(dest => dest.LastName, opt =>
                    opt.MapFrom(src => src.ClientDto.LastName))
                .ForMember(dest => dest.BirthDay, opt =>
                    opt.MapFrom(src => src.ClientDto.BirthDay))
                .ForMember(dest => dest.PhoneNumber, opt =>
                    opt.MapFrom(src => src.ClientDto.PhoneNumber))
                .ForMember(dest => dest.Email, opt =>
                    opt.MapFrom(src => src.ClientDto.Email))
                .ForMember(dest => dest.DateJoined, opt =>
                    opt.MapFrom(src => src.ClientDto.DateJoined))
                .ForMember(dest => dest.Password, opt =>
                    opt.MapFrom((src, dest, destMember, context) => context.Items["Password"]));




        }
    }
}
