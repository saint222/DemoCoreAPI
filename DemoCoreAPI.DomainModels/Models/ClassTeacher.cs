using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoCoreAPI.DomainModels.Models
{
    public class ClassTeacher
    {
        public long TeacherId { get; set; }
        public long ClassId { get; set; }
        public Teacher Teacher { get; set; }
        public Class Class { get; set; }
    }
}
