using DemoCoreAPI.DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoCoreAPI.DomainModels.Models
{
    public class SchoolDb
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(999), MinLength(1)]
        public int Number { get; set; }
        public SchoolAddressDb SchoolAddress { get; set; }
        public ICollection<SchoolPhoneNumberDb> SchoolPhoneNumbers { get; set; }
        public PrincipalDb Principal { get; set; }
        public ICollection<VicePrincipalDb> VicePrincipals { get; set; }
        public ICollection<TeacherDb> Teachers { get; set; }
        public ICollection<ClassDb> Classes { get; set; }
        public ICollection<PupilDb> Pupils { get; set; }
    }
}
