using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoCoreAPI.DomainModels.Models
{
    public class Address
    {
        [Key]
        public long Id { get; set; }
        public int Region { get; set; }      // enum
        [Required]
        [MaxLength(50), MinLength(1)]
        public string District { get; set; }
        [Required]
        [MaxLength(50), MinLength(1)]
        public string Locality { get; set; }
        [Required]
        [MaxLength(50), MinLength(1)]
        public string Street { get; set; }
        [Required]
        [Range(1, 999)]
        public int HouseNumber { get; set; }
        public ICollection<School> Schools { get; set; }
        public ICollection<Pupil> Pupils { get; set; }
        public ICollection<Parent> Parents { get; set; }
    }
}
