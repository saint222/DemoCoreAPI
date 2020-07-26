using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoCoreAPI.DomainModels.Models
{
    public class SchoolPhoneNumberDb
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Number { get; set; }
        public School School { get; set; }
    }
}
