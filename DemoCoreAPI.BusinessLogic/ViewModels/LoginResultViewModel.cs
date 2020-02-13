using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.ViewModels
{
    public class LoginResultViewModel
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}
