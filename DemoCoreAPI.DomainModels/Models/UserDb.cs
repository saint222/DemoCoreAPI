using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.DomainModels.Models
{
    public class UserDb
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
