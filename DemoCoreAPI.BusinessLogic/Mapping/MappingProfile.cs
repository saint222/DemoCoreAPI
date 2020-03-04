using AutoMapper;
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
            CreateMap<UserDb, LoginAPIModel>().ReverseMap();
            CreateMap<UserDb, RegisterAPIModel>().ReverseMap();
            CreateMap<UserDb, RegisterBindingModel>().ReverseMap();
        }
    }
}
