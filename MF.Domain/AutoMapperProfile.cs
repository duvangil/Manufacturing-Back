using AutoMapper;
using MF.Domain.Dtos;
using MF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, LoginUserDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Username))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash))
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<ElaborationType,ElaborationTypeDto>().ReverseMap();
            //CreateMap<Product, ProductDto>()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            //    //.ForMember(dest => dest.ElaborationTypeName, opt => opt.MapFrom(src => src.ElaborationType.Name))
            //    .ForMember(dest => dest.ElaborationTypeId, opt => opt.MapFrom(src => src.ElaborationTypeId))
            //    .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State));
        }
    }
}
