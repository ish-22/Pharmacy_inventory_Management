using Microsoft.EntityFrameworkCore;
using SPC.Models.Entities;
using System.Collections.Generic;

namespace SPC.Data
{
    public class ApplicationDbContext : DbContext
    {
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options)
        //{

        //}
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<OrderDetails> OrdersDetailss { get; set; }
        public DbSet<Tender> Tenders { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<ManufacturingPlant> ManufacturingPlants { get; set; }
        public DbSet<Pharmacy> pharmacies { get; set; }
        public DbSet<Staff> Staffs { get; set; }


    }
}

