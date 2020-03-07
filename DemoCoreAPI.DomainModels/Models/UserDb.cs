using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoCoreAPI.DomainModels.Models
{
    public class UserDb
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(50), MinLength(1)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50), MinLength(1)]
        public string LastName { get; set; }
        [Required]
        [Range(1, 150)]
        public int Age { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50), MinLength(1)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; } = false;
    }
}
