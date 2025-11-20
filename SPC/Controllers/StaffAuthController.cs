using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPC.Data;
using SPC.Models.Entities;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffAuthController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public StaffAuthController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("register")]
        public IActionResult Register(StaffDto Dto)
        {
            if (dbContext.Staffs.Any(a => a.Email == Dto.Email))
            {
                return BadRequest("Email already exists.");
            }

            var staff = new Staff
            {
                Email = Dto.Email,
                Password = Dto.Password // Ideally, hash the password before saving.
            };

            dbContext.Staffs.Add(staff);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(StaffDto Dto)
        {
            // Hash the password before comparing
            

            var staff = await dbContext.Staffs
                .FirstOrDefaultAsync(a => a.Email == Dto.Email && a.Password == Dto.Password);

            if (staff == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok("Login successful.");
        }

        
    }
}

