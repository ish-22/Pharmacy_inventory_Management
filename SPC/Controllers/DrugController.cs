using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC.Data;
using SPC.Models;
using SPC.Models.Entities;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public DrugController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllDrugs()
        {
            var allDrugs = dbContext.Drugs.ToList();
            return Ok(allDrugs);
        }

        [HttpGet]
        [Route("{DrugId:int}")]

        public IActionResult GetDrugById(int DrugId)
        {
            var drug = dbContext.Admins.Find(DrugId);

            if (drug is null)
            {
                return NotFound();
            }
            return Ok(drug);
        }


        [HttpPost]
        public IActionResult AddDrug(AddDrugsDTO addDrugDto)
        {
            var drugEntity = new Drug()
            {
                DrugId = addDrugDto.DrugId,
                Name = addDrugDto.Name,
                WarehouseID = addDrugDto.WarehouseID,
                StockQuantity = addDrugDto.StockQuantity,
                ExpiryDate = addDrugDto.ExpiryDate,
                Type = addDrugDto.Type,


            };
            dbContext.Drugs.Add(drugEntity);
            dbContext.SaveChanges();

            return Ok(drugEntity);
        }

        [HttpPut]
        public IActionResult UpdateDrug(int DrugId, UpdateDrugsDTO updatedrugDto)
        {
            var drug = dbContext.Drugs.Find(DrugId);
            if (drug is null)
            {
                return NotFound();
            }

            drug.Name = updatedrugDto.Name;
            drug.StockQuantity = updatedrugDto.StockQuantity;
            drug.Type = updatedrugDto.Type;
            drug.ExpiryDate = updatedrugDto.ExpiryDate;
            drug.WarehouseID = updatedrugDto.WarehouseID;


            dbContext.SaveChanges();

            return Ok(drug);
        }
        [HttpDelete]
        [Route("{DrugId:int}")]
        public IActionResult DeleteDrug(int DrugId)
        {
            var drug = dbContext.Drugs.Find(DrugId);
            if (drug is null)
            {
                return NotFound();
            }
            dbContext.Drugs.Remove(drug);
            dbContext.SaveChanges();

            return Ok();
        }

    }
}

