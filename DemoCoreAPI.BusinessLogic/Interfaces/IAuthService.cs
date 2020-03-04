using DemoCoreAPI.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.Interfaces
{
    public interface IAuthService
    {
        RegisterAPIModel Register(RegisterBindingModel model);
        LoginAPIModel Login(LoginBindingModel model);
    }
}
