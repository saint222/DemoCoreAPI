using DemoCoreAPI.BusinessLogic.Interfaces;
using DemoCoreAPI.BusinessLogic.ViewModels;
using DemoCoreAPI.Data;
using DemoCoreAPI.DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.Implementation
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<UserDb> _repo;
        public AuthService(IRepository<UserDb> repo)
        {
            _repo = repo;
        }
        public LoginResultViewModel Login(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        public RegisterResultViewModel Register(RegisterViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
