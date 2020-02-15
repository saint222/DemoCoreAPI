using DemoCoreAPI.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        RegisterResultViewModel Register(RegisterViewModel model);
        LoginResultViewModel Login(LoginViewModel model);
    }
}
