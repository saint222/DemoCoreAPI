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
            CreateMap<UserDb, LoginBindingModel>().ReverseMap();
            CreateMap<UserDb, LoginApiModel>().ReverseMap();
            CreateMap<UserDb, RegisterApiModel>().ReverseMap();
            CreateMap<UserDb, RegisterBindingModel>().ReverseMap();
            CreateMap<UserDb, NewUserBindingModel>().ReverseMap();
            CreateMap<UserDb, UpdateUserBindingModel>().ReverseMap();
            CreateMap<UserDb, NewUserApiModel>().ReverseMap();
            CreateMap<UserDb, UpdatedUserApiModel>().ReverseMap();
            CreateMap<UserDb, UserApiModel>().ReverseMap();
            CreateMap<UserDb, DeleteUserApiModel>().ReverseMap();
            CreateMap<UserDb, RegisterCommand>().ReverseMap();
            CreateMap<UserDb, LoginCommand>().ReverseMap();

            CreateMap<AddSchoolCommand, SchoolDb>()
                .ForMember(dest => dest.SchoolAddress, 
                e => e.MapFrom(src => src.Address)).ReverseMap();
            CreateMap<SchoolAddress, SchoolAddressDb>().ReverseMap();
            CreateMap<SchoolDb, AddSchoolApiModel>().ReverseMap();
        }
    }
}
