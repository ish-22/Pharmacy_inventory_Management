namespace Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tender
    {
        public int Id { get; set; }

        [Required]
        public string DrugName { get; set; }

        public int Quantity { get; set; }

        [Required]
        public string Description { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime publishedDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime closingDate { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
