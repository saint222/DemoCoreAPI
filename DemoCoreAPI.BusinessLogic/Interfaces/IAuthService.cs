using DemoCoreAPI.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        RegisterApiModel Register(RegisterBindingModel model);
        LoginApiModel Login(LoginBindingModel model);
    }
}
