using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.DomainModels.Models
{
    public class PupilDb: UserDb
    {
        public ClassDb Class { get; set; }
        public SchoolDb School { get; set; }
        public List<TeacherDb> Teachers { get; set; }
    }
}
