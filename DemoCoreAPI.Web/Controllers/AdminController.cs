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
using DemoCoreAPI.DomainModels.Enums;
using DemoCoreAPI.Web.Utilites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DemoCoreAPI.Web.Controllers
{
    [AuthEnumRoles(Roles.Admin)]
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
            var users = _adminService.GetAllUsers();
            if (users.Count() == 0)
                return NotFound();
            return Ok(users);
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
            var user = _adminService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost]
        [Route("Add")]
        public IActionResult AddNewUser(NewUserBindingModel model)
        {
            var newUser = _adminService.CreateNewUser(model);
            return Ok(newUser);
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult UpdateUser(UpdateUserBindingModel model)
        {
            var updateUser = _adminService.UpdateUser(model);
            return Ok(updateUser);
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult DeleteUser(long id)
        {
            var result = _adminService.RemoveUser(id);
            return Ok(result);
        }

        private XLWorkbook GenerateXLDoc(ICollection<UserApiModel> users)
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