using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.DomainModels.Models
{
    public class Class
    {
        public long Id { get; set; }
        public int Grade { get; set; }          // enum
        public int Letter { get; set; }         // enum
        public ICollection<Pupil> Pupils { get; set; }
        public School School { get; set; }
        public ICollection<ClassTeacher> ClassTeachers { get; set; }
    }
}
