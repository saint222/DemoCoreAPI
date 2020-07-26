using DemoCoreAPI.DomainModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.BindingModels
{
    public class AddressBindingModel
    {
        public Regions Region { get; set; }      // enum
        public string District { get; set; }
        public string Locality { get; set; }
        public string Street { get; set; }
        public int HouseNumber { get; set; }
    }
}
