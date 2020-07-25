﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoCoreAPI.DomainModels.Models
{
    [NotMapped]
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
        [MaxLength(50), MinLength(1)]
        public string Patronymic { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [MaxLength(50), MinLength(1)]
        public string Password { get; set; }
        public int Role { get; set; }            // enum
        public string Discriminator { get; set; }
    }
}
