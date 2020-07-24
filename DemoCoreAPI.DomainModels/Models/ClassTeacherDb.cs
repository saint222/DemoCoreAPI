using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoCoreAPI.DomainModels.Models
{
    public class ClassTeacherDb
    {
        public long TeacherDbId { get; set; }
        public long ClassDbId { get; set; }
        public TeacherDb Teacher { get; set; }
        public ClassDb Class { get; set; }
    }
}
