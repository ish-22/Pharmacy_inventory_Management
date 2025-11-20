using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SPC.Data;
using SPC.Models.Entities;
using SPC.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public OrderDetailsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllOrderDetails()
        {
            var allOrderDetails = dbContext.OrdersDetailss.ToList();
            return Ok(allOrderDetails);
        }

        [HttpGet]
        [Route("{OrderId:int}")]

        public IActionResult GetOrderDetailsById(int OrderId)
        {
            var orderDetails = dbContext.OrdersDetailss.Find(OrderId);

            if (orderDetails is null)
            {
                return NotFound();
            }
            return Ok(orderDetails);
        }


        [HttpPost]
        public IActionResult AddOrderDetails(AddOrderDetailsDTO addOrderDetailsDto)
        {
            var orderDetailsEntity = new OrderDetails()
            {
                OrderId = addOrderDetailsDto.OrderId,
                Pharmacyname = addOrderDetailsDto.Pharmacyname,
                Drugname = addOrderDetailsDto.Drugname,
                Quantity = addOrderDetailsDto.Quantity,
                price = addOrderDetailsDto.price,
                TotalCost = addOrderDetailsDto.TotalCost,
                QuantityOrdered = addOrderDetailsDto.QuantityOrdered,
                orderDate = addOrderDetailsDto.orderDate,
                Status = addOrderDetailsDto.Status,


            };
            dbContext.OrdersDetailss.Add(orderDetailsEntity);
            dbContext.SaveChanges();

            return Ok(orderDetailsEntity);
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
