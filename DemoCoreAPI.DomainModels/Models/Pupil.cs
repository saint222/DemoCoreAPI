﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoCoreAPI.DomainModels.Models

{
    public class Pupil
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
        public int Role { get; set; } = 1;       // enum
        public Address Address { get; set; }
        public Class Class { get; set; }
        public School School { get; set; }      
        public ICollection<Mark> Marks { get; set; }
        public ICollection<ParentPupil> ParentPupils { get; set; }
    }
}
