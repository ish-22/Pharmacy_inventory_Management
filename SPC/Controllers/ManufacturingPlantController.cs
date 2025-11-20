using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC.Data;
using SPC.Models;
using SPC.Models.Entities;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturingPlantController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ManufacturingPlantController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllManufacturingPlants()
        {
            var allManufacturingPlants = dbContext.ManufacturingPlants.ToList();
            return Ok(allManufacturingPlants);
        }

        [HttpGet]
        [Route("{PlantId:int}")]

        public IActionResult GetDrugById(int PlantId)
        {
            var ManufacturingPlant = dbContext.ManufacturingPlants.Find(PlantId);

            if (ManufacturingPlant is null)
            {
                return NotFound();
            }
            return Ok(ManufacturingPlant);
        }


        [HttpPost]
        public IActionResult AddManufacturingPlant(AddManufacturingPlantsDTO addManufacturingPlantDto)
        {
            var manufacturingPlantEntity = new ManufacturingPlant()
            {
                PlantId = addManufacturingPlantDto.PlantId,
                Location = addManufacturingPlantDto.Location,
                Contact = addManufacturingPlantDto.Contact,


            };
            dbContext.ManufacturingPlants.Add(manufacturingPlantEntity);
            dbContext.SaveChanges();

            return Ok(manufacturingPlantEntity);
        }

        [HttpPut]
        public IActionResult UpdateManufacturingPlant(int PlantId, updateManufacturingPlantsDTO updatedrugDto)
        {
            var manufacturingPlant = dbContext.ManufacturingPlants.Find(PlantId);
            if (manufacturingPlant is null)
            {
                return NotFound();
            }

            manufacturingPlant.PlantId = updatedrugDto.PlantId;
            manufacturingPlant.Location = updatedrugDto.Location;
            manufacturingPlant.Contact = updatedrugDto.Contact;



            dbContext.SaveChanges();

            return Ok(manufacturingPlant);
        }
        [HttpDelete]
        [Route("{PlantId:int}")]
        public IActionResult DeleteManufacturingPlant(int PlantId)
        {
            var manufacturingPlant = dbContext.ManufacturingPlants.Find(PlantId);
            if (manufacturingPlant is null)
            {
                return NotFound();
            }
            dbContext.ManufacturingPlants.Remove(manufacturingPlant);
            dbContext.SaveChanges();

            return Ok();
        }

    }
}

