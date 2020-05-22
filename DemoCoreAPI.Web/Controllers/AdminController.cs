using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DemoCoreAPI.BusinessLogic.APIModels;
using DemoCoreAPI.BusinessLogic.BindingModels;
using DemoCoreAPI.BusinessLogic.Errors;
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
                if (users.Count() == 0)
                    return NotFound();
                return Ok(users);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception occured while retrieving data.");
                return ServerError(ex);
            }
        }

        [HttpGet]
        [Route("GenerateExcel")]
        public IActionResult Excel()
        {           
            using (var stream = new MemoryStream())
            {
                var users = _adminService.GetAllUsers();
                var workBook = GenerateXLDoc(users);
                workBook.SaveAs(stream);
                var content = stream.ToArray();

                return File(
                            content, 
                            "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                            "Users.xlsx"
                            );
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
            catch (ArgumentException ex)
            {
                Log.Error(ex, $"Id {id} is invalid.");
                return BadRequest(ex);
            }
            catch (NotFoundException ex)
            {
                Log.Error(ex, $"User with Id {id} doesn't exist.");
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception occured while retrieving data.");
                return ServerError(ex);
            }
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddNewUser(NewUserBindingModel model)
        {
            try
            {
                var newUser = _adminService.CreateNewUser(model);
                return Ok(newUser);
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
            catch (Exception ex)
            {
                Log.Error(ex, "Exception occured while creating a new user.");
                return ServerError(ex);
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateUser(UpdateUserBindingModel model)
        {
            try
            {
                var updateUser = _adminService.UpdateUser(model);
                return Ok(updateUser);
            }
            catch (ArgumentNullException ex)
            {
                Log.Error(ex, $"Model {model} is null");
                return BadRequest(ex);
            }
            catch (NotFoundException ex)
            {
                Log.Error(ex, $"User {model} is not found.");
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception occured while updating user.");
                return ServerError(ex);
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteUser(long id)
        {
            try
            {
                var result = _adminService.RemoveUser(id);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                Log.Error(ex, $"Id {id} is invalid.");
                return BadRequest(ex);
            }
            catch (NotFoundException ex)
            {
                Log.Error(ex, $"User with Id {id} doesn't exist.");
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Exception occured while deleting user.");
                return ServerError(ex);
            }
        }

        private IActionResult ServerError(Exception ex)
        {
            return Json(new { Message = "Internal server error."}, ex);
        }

        private XLWorkbook GenerateXLDoc(ICollection<UserAPIModel> users)
        {
            var workBook = new XLWorkbook();
            var worksheet = workBook.Worksheets.Add("Users");
            var currentRow = 1;
            worksheet.Cell(currentRow, 1).Value = "Id";
            worksheet.Cell(currentRow, 2).Value = "First Name";
            worksheet.Cell(currentRow, 3).Value = "Last Name";
            worksheet.Cell(currentRow, 4).Value = "Age";
            worksheet.Cell(currentRow, 5).Value = "Email";
            worksheet.Cell(currentRow, 6).Value = "Is Admin";
            foreach (var user in users)
            {
                currentRow++;
                worksheet.Cell(currentRow, 1).Value = user.Id;
                worksheet.Cell(currentRow, 2).Value = user.FirstName;
                worksheet.Cell(currentRow, 3).Value = user.LastName;
                worksheet.Cell(currentRow, 4).Value = user.Age;
                worksheet.Cell(currentRow, 5).Value = user.Email;
                worksheet.Cell(currentRow, 6).Value = user.IsAdmin;
            }
            return workBook;
        }
    }
}