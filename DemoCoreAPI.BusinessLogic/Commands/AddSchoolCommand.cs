using DemoCoreAPI.BusinessLogic.APIModels;
using DemoCoreAPI.BusinessLogic.BindingModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoCoreAPI.BusinessLogic.Commands
{
    public class AddSchoolCommand: IRequest<AddSchoolApiModel>
    {
        public int SchoolNumber { get; set; }
        public SchoolAddress Address { get; set; }
    }
}
