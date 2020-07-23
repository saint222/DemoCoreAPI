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
        public SchoolAddressDb SchoolAddress { get; set; }
        public List<TeacherDb> Teachers { get; set; }
        public List<ClassDb> Classes { get; set; }
        public List<PupilDb> Pupils { get; set; }
        public List<SchoolPhoneNumberDb> SchoolPhoneNumbers { get; set; }
    }
}
