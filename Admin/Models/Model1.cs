namespace Admin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<C__EFMigrationsHistory> C__EFMigrationsHistory { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Drug> Drugs { get; set; }
        public virtual DbSet<ManufacturingPlant> ManufacturingPlants { get; set; }
        public virtual DbSet<OrdersDetailss> OrdersDetailsses { get; set; }
        public virtual DbSet<pharmacy> pharmacies { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Tender> Tenders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
