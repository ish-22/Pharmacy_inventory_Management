using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Project.Models;
using SPC.Data;
using SPC.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Project.Controllers
{
    // localhost:xxxx/api/suppliers
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public TenderController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllTenders()
        {
            var allTenders = dbContext.Tenders.ToList();
            return Ok(allTenders);
        }

        [HttpGet]
        [Route("{Id:int}")]

        public IActionResult GetTenderById(int Id)
        {
            var tender = dbContext.Tenders.Find(Id);

            if (tender is null)
            {
                return NotFound();
            }
            return Ok(tender);
        }


        [HttpPost]
        public IActionResult AddTender(AddTenderDTO addTenderDto)
        {
            var tenderEntity = new Tender()
            {
                Id = addTenderDto.Id,
                DrugName = addTenderDto.DrugName,
                Quantity = addTenderDto.Quantity,
                Description = addTenderDto.Description,
                publishedDate = addTenderDto.publishedDate,
                closingDate = addTenderDto.closingDate,
                Status = addTenderDto.Status,


            };
            dbContext.Tenders.Add(tenderEntity);
            dbContext.SaveChanges();

            return Ok(tenderEntity);
        }

        [HttpPut]
        public IActionResult UpdateTender(int Id, updateTenderDTO updatetenderDto)
        {
            var tender = dbContext.Tenders.Find(Id);
            if (tender is null)
            {
                return NotFound();
            }

            tender.DrugName = updatetenderDto.DrugName;
            tender.Quantity = updatetenderDto.Quantity;
            tender.Description = updatetenderDto.Description;
            tender.publishedDate = updatetenderDto.publishedDate;
            tender.closingDate = updatetenderDto.closingDate;
            tender.Status = updatetenderDto.Status;

            dbContext.SaveChanges();

            return Ok(tender);
        }
        [HttpDelete]
        [Route("{Id:int}")]
        public IActionResult DeleteSupplier(int Id)
        {
            var tender = dbContext.Tenders.Find(Id);
            if (tender is null)
            {
                return NotFound();
            }
            dbContext.Tenders.Remove(tender);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
