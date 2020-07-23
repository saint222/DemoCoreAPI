using DemoCoreAPI.DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.DomainModels.Models
{
    public class ClassDb
    {
        public long Id { get; set; }
        public ClassGrades Grade { get; set; }
        public ClassLetters Letter { get; set; }
        public List<PupilDb> Pupils { get; set; }
    }
}
