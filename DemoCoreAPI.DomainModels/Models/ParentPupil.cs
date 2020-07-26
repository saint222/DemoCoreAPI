using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DemoCoreAPI.DomainModels.Models
{
    public class ParentPupil
    {
        public long ParentId { get; set; }
        public Parent Parent { get; set; }
        public long PupilId { get; set; }
        public Pupil Pupil { get; set; }
    }
}
