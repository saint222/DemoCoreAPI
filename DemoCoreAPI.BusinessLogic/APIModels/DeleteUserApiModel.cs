using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.APIModels
{
    public class DeleteUserApiModel
    {
        public string Message { get; set; } = "User has been deleted";
        public bool Success { get; set; } = true;
    }
}
