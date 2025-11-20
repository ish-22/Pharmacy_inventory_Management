using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SPC.Data;
using SPC.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Project.Controllers
{
    // localhost:xxxx/api/suppliers
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public SuppliersController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllSuppliers()
        {
           var allSuppliers = dbContext.Suppliers.ToList();
            return Ok(allSuppliers);
        }

        [HttpGet]
        [Route("{Id:int}")]

        public IActionResult GetSupplierById(int Id) 
        {
            var supplier = dbContext.Suppliers.Find(Id);

            if(supplier is null)
            {
                return NotFound();
            }
            return Ok(supplier);
        }


        [HttpPost]
        public IActionResult AddSupplier(SupplierDto addSupplierDto)
        {
            var supplierEntity = new Supplier()
            {
              
                Email = addSupplierDto.Email,
                Password =addSupplierDto.Password,

            };
            dbContext.Suppliers.Add(supplierEntity);
            dbContext.SaveChanges();

            return Ok(supplierEntity);
        }

        [HttpPut]
        public IActionResult UpdateSuppliers(int Id,SupplierDto updateSupplierDto)
        {
            var supplier = dbContext.Suppliers.Find(Id);
            if(supplier is null)
            {
                return NotFound();
            }

            
            supplier.Email = updateSupplierDto.Email;
           
            supplier.Password = updateSupplierDto.Password;

            dbContext.SaveChanges();

            return Ok(supplier);
        }
        [HttpDelete]
        [Route("{Id:int}")]
        public IActionResult DeleteSupplier(int Id)
        {
            var supplier = dbContext.Suppliers.Find(Id);
            if(supplier is null)
            {
                return NotFound();
            }
            dbContext.Suppliers.Remove(supplier);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
