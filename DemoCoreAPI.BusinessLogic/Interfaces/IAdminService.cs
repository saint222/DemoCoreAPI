using DemoCoreAPI.BusinessLogic.APIModels;
using DemoCoreAPI.BusinessLogic.BindingModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.Interfaces
{
    public interface IAdminService
    {
        UserApiModel GetUserById(long id);
        ICollection<UserApiModel> GetAllUsers();
        NewUserApiModel CreateNewUser(NewUserBindingModel model);
        UpdatedUserApiModel UpdateUser(UpdateUserBindingModel model);
        DeleteUserApiModel RemoveUser(long id);
    }
}
