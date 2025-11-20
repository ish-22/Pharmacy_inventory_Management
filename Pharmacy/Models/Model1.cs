namespace Pharmacy.Models
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

        public virtual DbSet<Drug> Drugs { get; set; }
        public virtual DbSet<ManufacturingPlant> ManufacturingPlants { get; set; }
        public virtual DbSet<OrdersDetailss> OrdersDetailsses { get; set; }
        public virtual DbSet<pharmacy> pharmacies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
