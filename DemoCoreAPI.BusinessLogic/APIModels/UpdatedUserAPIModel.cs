using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.APIModels
{
    public class UpdatedUserAPIModel
    {
        public string Message { get; set; } = "User has been updated";
        public bool Success { get; set; } = true;
    }
}
