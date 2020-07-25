using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.DomainModels.Models
{
    public class ClassDb
    {
        public long Id { get; set; }
        public int Grade { get; set; }          // enum
        public int Letter { get; set; }         // enum
        public List<PupilDb> Pupils { get; set; }
        public SchoolDb School { get; set; }
        public ICollection<ClassTeacherDb> ClassTeachers { get; set; }
    }
}
