using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC.Data;
using SPC.Models.Entities;
using SPC.Data;
using SPC.Models.Entities;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAuthController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public AdminAuthController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("register")]
        public IActionResult Register(AdminDto adminDto)
        {
            if (dbContext.Admins.Any(a => a.Email == adminDto.Email))
            {
                return BadRequest("Email already exists.");
            }

            var Admins = new Admin
            {
                Email = adminDto.Email,
                Password = adminDto.Password // Ideally, hash the password before saving.
            };

            dbContext.Admins.Add(Admins);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("login")]
        public IActionResult Login(AdminDto adminDto)
        {
            var admin = dbContext.Admins.FirstOrDefault(a => a.Email == adminDto.Email && a.Password == adminDto.Password);

            if (admin == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok("Login successful.");
        }
    }
}

