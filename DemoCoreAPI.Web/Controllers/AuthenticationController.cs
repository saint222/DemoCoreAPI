using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCoreAPI.BusinessLogic.Interfaces;
using DemoCoreAPI.BusinessLogic.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoCoreAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        public readonly IAuthService _authService;
        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }
        
        // POST: api/Authentication
        [HttpPost]
        [Route("/login")]
        public IActionResult Login(LoginViewModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            var loginResult = _authService.Login(model);
            return Json(loginResult);
        }

        // POST: api/Authentication
        [HttpPost]
        [Route("/register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            var loginResult = _authService.Register(model);
            return Json(loginResult);
        }
    }
}
