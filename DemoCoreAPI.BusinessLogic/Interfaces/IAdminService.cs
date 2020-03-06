using DemoCoreAPI.BusinessLogic.APIModels;
using DemoCoreAPI.BusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.Interfaces
{
    public interface IAdminService
    {
        UserAPIModel GetUserById(long id);
        ICollection<UserAPIModel> GetAllUsers();
        NewUserAPIModel CreateNewUser(NewUserBindingModel model);
        UpdatedUserAPIModel UpdateUser(UpdateUserBindingModel model);
    }
}
