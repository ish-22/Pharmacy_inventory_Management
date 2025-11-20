using System.ComponentModel.DataAnnotations;

namespace SPC.Models.Entities
{
    public class OrderDetails
    {
        [Key]
        public int OrderId { get; set; }
        public string Pharmacyname { get; set; }
        public string Drugname { get; set; }
        public int Quantity { get; set; }
        public string price { get; set; }
        public string TotalCost { get; set; }
        public int QuantityOrdered { get; set; }
        public DateTime orderDate { get; set; }
        public string Status { get; set; }
    }
}
