using AutoMapper;
using DemoCoreAPI.BusinessLogic.APIModels;
using DemoCoreAPI.BusinessLogic.BindingModels;
using DemoCoreAPI.BusinessLogic.Commands;
using DemoCoreAPI.BusinessLogic.ViewModels;
using DemoCoreAPI.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginBindingModel>().ReverseMap();
            CreateMap<User, LoginApiModel>().ReverseMap();
            CreateMap<User, RegisterApiModel>().ReverseMap();
            CreateMap<User, RegisterBindingModel>().ReverseMap();
            CreateMap<User, NewUserBindingModel>().ReverseMap();
            CreateMap<User, UpdateUserBindingModel>().ReverseMap();
            CreateMap<User, NewUserApiModel>().ReverseMap();
            CreateMap<User, UpdatedUserApiModel>().ReverseMap();
            CreateMap<User, UserApiModel>().ReverseMap();
            CreateMap<User, DeleteUserApiModel>().ReverseMap();
            CreateMap<User, RegisterCommand>().ReverseMap();
            CreateMap<User, LoginCommand>().ReverseMap();

            CreateMap<AddSchoolCommand, School>()
                .ForMember(dest => dest.Address, 
                e => e.MapFrom(src => src.Address)).ReverseMap();
            CreateMap<AddressBindingModel, Address>().ReverseMap();
            CreateMap<School, AddSchoolApiModel>().ReverseMap();
        }
    }
}
