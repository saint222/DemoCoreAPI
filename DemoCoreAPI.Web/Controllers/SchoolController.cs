using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCoreAPI.BusinessLogic.BindingModels;
using DemoCoreAPI.BusinessLogic.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoCoreAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : Controller
    {
        private readonly IMediator _mediator;
        public SchoolController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/School/create
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(AddSchoolCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
