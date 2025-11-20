namespace Pharmacy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ManufacturingPlant
    {
        [Key]
        public int PlantId { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Contact { get; set; }
    }
}
