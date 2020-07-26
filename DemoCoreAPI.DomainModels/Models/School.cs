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
        public long AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<SchoolPhoneNumberDb> SchoolPhoneNumbers { get; set; }
        public PrincipalDb Principal { get; set; }
        public ICollection<VicePrincipalDb> VicePrincipals { get; set; }
        public ICollection<TeacherDb> Teachers { get; set; }
        public ICollection<ClassDb> Classes { get; set; }
        public ICollection<PupilDb> Pupils { get; set; }
    }
}
