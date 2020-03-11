using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoCoreAPI.BusinessLogic.BindingModels;
using DemoCoreAPI.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DemoCoreAPI.Web.Controllers
{
    //[Authorize()]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        [HttpGet]
        [Route("Users")]
        public IActionResult GetUsers()
        {
            try
            {
                var users = _adminService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception occured while retrieving users");
                return NotFound(ex);
            }
        }

        [HttpGet]
        [Route("User/{id}")]
        public IActionResult GetUserById(long id)
        {
            try
            {
                var user = _adminService.GetUserById(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception occured while retrieving a user");
                return NotFound(ex);
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddNewUser(NewUserBindingModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "NewUserModel can not be null.");
            try
            {
                var newUser = _adminService.CreateNewUser(model);
                return Ok(newUser);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception occured while a new user adding.");
                return BadRequest(ex);
            }            
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateUser(UpdateUserBindingModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model), "UpdateUserModel can not be null.");
            try
            {
                var updateUser = _adminService.UpdateUser(model);
                return Ok(updateUser);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception occured while updating the user");
                return BadRequest(ex);
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteUser(long id)
        {            
            try
            {
                if (id <= 0)
                    throw new ArgumentNullException(nameof(id), "Id can not be 0 or negative.");
                var result = _adminService.RemoveUser(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception occured while deleting the user");
                return BadRequest(ex);
            }
        }
    }
}