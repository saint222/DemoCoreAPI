using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DemoCoreAPI.BusinessLogic.APIModels;
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