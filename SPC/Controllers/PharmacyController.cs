using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using SPC.Data;
using SPC.Models;
using SPC.Models.Entities;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public PharmacyController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllPharmacies()
        {
            var allPharmacies = dbContext.pharmacies.ToList();
            return Ok(allPharmacies);
        }

        [HttpGet]
        [Route("{Id:int}")]

        public IActionResult GetPharmacyById(int Id)
        {
            var Pharmacy = dbContext.pharmacies.Find(Id);

            if (Pharmacy is null)
            {
                return NotFound();
            }
            return Ok(Pharmacy);
        }


        [HttpPost]
        public IActionResult AddPharmacy(AddPharmacyDTO addPharmacyDto)
        {
            var pharmacyEntity = new Pharmacy()
            {
                Id = addPharmacyDto.Id,
                Email = addPharmacyDto.Email,
                Password = addPharmacyDto.Password,



            };
            dbContext.pharmacies.Add(pharmacyEntity);
            dbContext.SaveChanges();

            return Ok(pharmacyEntity);
        }

        [HttpPut]
        public IActionResult UpdatePharmacy(int Id, UpdatePharmacyDTO updatepharmacyDto)
        {
            var Pharmacy = dbContext.pharmacies.Find(Id);
            if (Pharmacy is null)
            {
                return NotFound();
            }

            Pharmacy.Id = updatepharmacyDto.Id;
            Pharmacy.Email = updatepharmacyDto.Email;
            Pharmacy.Password = updatepharmacyDto.Password;



            dbContext.SaveChanges();

            return Ok(Pharmacy);
        }
        [HttpDelete]
        [Route("{Id:int}")]
        public IActionResult DeletePharmacy(int Id)
        {
            var Pharmacy = dbContext.pharmacies.Find(Id);
            if (Pharmacy is null)
            {
                return NotFound();
            }
            dbContext.pharmacies.Remove(Pharmacy);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
