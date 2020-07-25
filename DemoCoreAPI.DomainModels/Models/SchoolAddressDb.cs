using System;
using System.ComponentModel.DataAnnotations;

namespace DemoCoreAPI.DomainModels.Models
{
    public class SchoolAddressDb
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
        public long SchoolDbId { get; set; }
        public SchoolDb School { get; set; }
    }
}
