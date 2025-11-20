using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC.Data;
using SPC.Models.Entities;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyAuthController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public PharmacyAuthController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("register")]
        public IActionResult Register(PharmacyDto Dto)
        {
            if (dbContext.pharmacies.Any(a => a.Email == Dto.Email))
            {
                return BadRequest("Email already exists.");
            }

            var Pharmacies = new Pharmacy
            {
                Email = Dto.Email,
                Password = Dto.Password // Ideally, hash the password before saving.
            };

            dbContext.pharmacies.Add(Pharmacies);
            dbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("login")]
        public IActionResult Login(PharmacyDto Dto)
        {
            var Pharmacy = dbContext.pharmacies.FirstOrDefault(a => a.Email == Dto.Email && a.Password == Dto.Password);

            if (Pharmacy == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            return Ok("Login successful.");
        }
    }
}


