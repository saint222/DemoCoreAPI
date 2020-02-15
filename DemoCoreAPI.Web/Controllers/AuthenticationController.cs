using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCoreAPI.BusinessLogic.Interfaces;
using DemoCoreAPI.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
        public IActionResult Login(LoginViewModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "LoginViewModel can not be null.");
            try
            {
                var loginResult = _authService.Login(model);
                return Ok(loginResult);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception occured while logging.");
                return BadRequest(ex);
            }
        }

        // POST: api/Authentication/register
        [HttpPost]
        [Route("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "RegisterViewModel can not be null.");
            try
            {
                var registerResult = _authService.Register(model);
                return Ok(registerResult);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception occured while rigistration.");
                return BadRequest(ex);
            }
        }
    }
}
