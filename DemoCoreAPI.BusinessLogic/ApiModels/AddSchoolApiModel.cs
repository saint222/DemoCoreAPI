using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.APIModels
{
    public class AddSchoolApiModel
    {
        public string Message { get; set; } = "New school has been created";
        public bool Success { get; set; } = true;
    }
}
