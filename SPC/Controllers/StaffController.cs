using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC.Data;
using SPC.Models;
using SPC.Models.Entities;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public StaffController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllStaff()
        {
            var allStaff = dbContext.Staffs.ToList();
            return Ok(allStaff);
        }

        [HttpGet]
        [Route("{Id:int}")]

        public IActionResult GetStaffById(int Id)
        {
            var staff = dbContext.Staffs.Find(Id);

            if (staff is null)
            {
                return NotFound();
            }
            return Ok(staff);
        }


        [HttpPost]
        public IActionResult AddStaff(AddStaffDTO addStaffDto)
        {
            var staffEntity = new Staff()
            {
                Id = addStaffDto.Id,
                Email=addStaffDto.Email,
                Password=addStaffDto.Password,
              
                
            };
            dbContext.Staffs.Add(staffEntity);
            dbContext.SaveChanges();

            return Ok(staffEntity);
        }

        [HttpPut]
        public IActionResult UpdateStaff(int Id, UpdateStaffDTO updatestaffDto)
        {
            var staff = dbContext.Staffs.Find(Id);
            if (staff is null)
            {
                return NotFound();
            }

            staff.Id = updatestaffDto.Id;
            staff.Email = updatestaffDto.Email;
            staff.Password = updatestaffDto.Password;
            



            dbContext.SaveChanges();

            return Ok(staff);
        }
        [HttpDelete]
        [Route("{Id:int}")]
        public IActionResult DeleteStaff(int Id)
        {
            var staff = dbContext.Staffs.Find(Id);
            if (staff is null)
            {
                return NotFound();
            }
            dbContext.Staffs.Remove(staff);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
