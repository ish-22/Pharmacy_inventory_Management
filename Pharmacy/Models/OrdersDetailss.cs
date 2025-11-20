namespace Pharmacy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrdersDetailss")]
    public partial class OrdersDetailss
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public string Pharmacyname { get; set; }

        [Required]
        public string Drugname { get; set; }

        public int Quantity { get; set; }

        [Required]
        public string price { get; set; }

        [Required]
        public string TotalCost { get; set; }

        public int QuantityOrdered { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime orderDate { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
