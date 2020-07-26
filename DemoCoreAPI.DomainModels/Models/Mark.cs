using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoCoreAPI.DomainModels.Models
{
    public class Mark
    {
        [Key]
        public long Id { get; set; }
        public string Value { get; set; }
        public DateTime DateOfMark { get; set; } = DateTime.Now; 
        public Pupil Pupil { get; set; }
        public SchoolSubject SchoolSubject { get; set; }
        public bool IsTermMark { get; set; }
        public bool IsYearMark { get; set; }
    }
}
