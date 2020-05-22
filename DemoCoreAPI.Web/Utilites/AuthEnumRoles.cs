using DemoCoreAPI.DomainModels.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DemoCoreAPI.Web.Utilites
{
    public class AuthEnumRoles : AuthorizeAttribute
    {
        public AuthEnumRoles(params Roles[] roles) : base()
        {
            var allowedRoles = roles.Select(x => Enum.GetName(typeof(Roles), x));
            Roles = string.Join(",", allowedRoles);
        }
    }
}
