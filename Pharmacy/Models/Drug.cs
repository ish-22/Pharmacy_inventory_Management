namespace Pharmacy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Drug
    {
        public int DrugId { get; set; }

        [Required]
        public string Name { get; set; }

        public int WarehouseID { get; set; }

        public int StockQuantity { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ExpiryDate { get; set; }

        [Required]
        public string Type { get; set; }
    }
}
