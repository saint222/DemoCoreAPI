using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DemoCoreAPI.BusinessLogic.Interfaces;
using DemoCoreAPI.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text;
using DemoCoreAPI.BusinessLogic.Errors;
using System.Net;
using DocumentFormat.OpenXml.Office2013.Drawing.Chart;

namespace DemoCoreAPI.Web.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        public readonly IAuthService _authService;
        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/Authentication/login
        [HttpPost]
        [Route("login")]
        public IActionResult Login(LoginBindingModel model)
        {
            try
            {
                var user = _authService.Login(model);
                if (user == null)
                    return NotFound();
                var loginResult = CreateToken(user);
                return Ok(loginResult);
            }
            catch (ArgumentNullException ex)
            {
                Log.Error(ex, $"Model {model} is null");
                return BadRequest(ex);
            }
            catch (ArgumentException ex)
            {
                Log.Error(ex, $"The fields of the model {model} are null");
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception occured while logging.");
                return ServerError(ex);
            }
        }

        // POST: api/Authentication/register
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterBindingModel model)
        {
            try
            {
                var registerResult = _authService.Register(model);
                return Ok(registerResult);
            }
            catch (ArgumentNullException ex)
            {
                Log.Error(ex, $"Model {model} is null");
                return BadRequest(ex);
            }
            catch (ArgumentException ex)
            {
                Log.Error(ex, $"The fields of the model {model} are null");
                return BadRequest(ex);
            }
            catch (EmailDuplicateException ex) 
            {
                Log.Error(ex, "User with such email already exists.");
                return BadRequest(ex); ;
            }
            catch (PasswordMismatchException ex)
            {
                Log.Error(ex, "Passwords mismatch.");
                return UnprocessableEntity(ex);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception occured while rigistration.");
                return ServerError(ex);
            }
        }

        private IActionResult ServerError(Exception ex)
        {
            Response.StatusCode = 500;
            return Json(new { Message = "Server error" }, ex);
        }

        private dynamic CreateToken(LoginAPIModel model)
        {
            var claims = new List<Claim> //using System.Security.Claims;
            {
                new Claim(JwtRegisteredClaimNames.Sub, model.Id.ToString()),
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
                access_Token = new JwtSecurityTokenHandler().WriteToken(token), // Core will return props in camelCase
                id = model.Id,                
                firstName = model.FirstName,
                lastName = model.LastName,
                email = model.Email,
                age = model.Age,
                isAdmin = model.IsAdmin
            };
            return output;
        }
    }
}
