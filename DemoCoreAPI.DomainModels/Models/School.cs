using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DemoCoreAPI.DomainModels.Models
{
    public class School
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(999), MinLength(1)]
        public int SchoolNumber { get; set; }
        public Address Address { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public Principal Principal { get; set; }
        public ICollection<VicePrincipal> VicePrincipals { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Class> Classes { get; set; }
        public ICollection<Pupil> Pupils { get; set; }
    }
}
