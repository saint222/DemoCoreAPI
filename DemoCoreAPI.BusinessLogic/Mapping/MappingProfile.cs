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
            CreateMap<UserDb, LoginViewModel>().ReverseMap();
            CreateMap<UserDb, LoginResultViewModel>().ReverseMap();
            CreateMap<UserDb, RegisterResultViewModel>().ReverseMap();
            CreateMap<UserDb, RegisterViewModel>().ReverseMap();
        }
    }
}
