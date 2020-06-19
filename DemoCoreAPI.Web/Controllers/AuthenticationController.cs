using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Threading.Tasks;
using DemoCoreAPI.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text;
using DemoCoreAPI.BusinessLogic.Errors;
using DemoCoreAPI.DomainModels.Enums;
using MediatR;
using DemoCoreAPI.BusinessLogic.Commands;

namespace DemoCoreAPI.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/Authentication/login
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginCommand model)
        {
            var user = await _mediator.Send(model);
            var loginResult = CreateToken(user);
            return Ok(loginResult);
        }

        // POST: api/Authentication/register
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterCommand model)
        {
            var registerResult = await _mediator.Send(model);
            return Ok(registerResult);
        }

        private dynamic CreateToken(LoginAPIModel model)
        {
            var claims = new List<Claim> //using System.Security.Claims;
            {
                new Claim(JwtRegisteredClaimNames.Sub, model.Id.ToString()),
                new Claim(ClaimTypes.Role, Enum.GetName(typeof(Roles), model.Role)), // ROLES !!!
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()), //using System.IdentityModel.Tokens.Jwt;
                new Claim(JwtRegisteredClaimNames.Exp, new DateTimeOffset(DateTime.Now.AddDays(1)).ToUnixTimeSeconds().ToString())
            };

            var token = new JwtSecurityToken(
                    new JwtHeader(
                        new SigningCredentials(
                            new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes("NobodyWillGuessMeLOL")), SecurityAlgorithms.HmacSha256)),
                        new JwtPayload(claims));
            var output = new
            {
                id = model.Id,
                role = Enum.GetName(typeof(Roles), model.Role),
                token = new JwtSecurityTokenHandler().WriteToken(token) // Core will return props in camelCase
            };
            return output;
        }
    }
}
