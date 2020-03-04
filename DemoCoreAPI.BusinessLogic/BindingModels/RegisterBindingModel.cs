using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.ViewModels
{
    public class RegisterBindingModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
