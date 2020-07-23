using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.DomainModels.Models
{
    public class TeacherDb: UserDb
    {
        public SchoolDb School { get; set; }
        public PupilDb Pupil { get; set; }
    }
}
