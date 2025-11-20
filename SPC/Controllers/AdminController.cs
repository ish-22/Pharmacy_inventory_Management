using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SPC.Data;
using SPC.Models;
using SPC.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Project.Controllers
{
    // localhost:xxxx/api/suppliers
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public AdminController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllAdmins()
        {
            var allAdmins = dbContext.Admins.ToList();
            return Ok(allAdmins);
        }

        [HttpGet]
        [Route("{Id:int}")]

        public IActionResult GetAdminById(int Id)
        {
            var admin = dbContext.Admins.Find(Id);

            if (admin is null)
            {
                return NotFound();
            }
            return Ok(admin);
        }


        [HttpPost]
        public IActionResult AddAdmin(AddAdminDTO addAdminDto)
        {
            var adminEntity = new Admin()
            {
                Id = addAdminDto.Id,
                Email=addAdminDto.Email,
                Password=addAdminDto.Password,


            };
            dbContext.Admins.Add(adminEntity);
            dbContext.SaveChanges();

            return Ok(adminEntity);
        }

        [HttpPut]
        public IActionResult UpdateAdmin(int Id, UpdateAdminDTO updateadminDto)
        {
            var admin = dbContext.Admins.Find(Id);
            if (admin is null)
            {
                return NotFound();
            }

            admin.Email = updateadminDto.Email;
            admin.Password = updateadminDto.Password;
           

            dbContext.SaveChanges();

            return Ok(admin);
        }
        [HttpDelete]
        [Route("{Id:int}")]
        public IActionResult DeleteAdmin(int Id)
        {
            var admin = dbContext.Admins.Find(Id);
            if (admin is null)
            {
                return NotFound();
            }
            dbContext.Admins.Remove(admin);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
