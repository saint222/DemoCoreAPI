using System;
using System.ComponentModel.DataAnnotations;

namespace DemoCoreAPI.DomainModels.Models
{
    public class Address
    {
        public long Id { get; set; }
        public int Region { get; set; }      // enum
        public string District { get; set; }
        public string Locality { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; } // Must be string. Dont forget about "72a"
    }
}
