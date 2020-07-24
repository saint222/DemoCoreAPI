using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.DomainModels.Models
{
    public class ParentPupilDb
    {
        public long ParentDbId { get; set; }
        public ParentDb Parent { get; set; }
        public long PupilDbId { get; set; }
        public PupilDb Pupil { get; set; }
    }
}
