namespace SPC.Models.Entities
{
    public class Drug
    {
        public int DrugId { get; set; }
        public string Name { get; set; }
        public int WarehouseID { get; set; }
        public int StockQuantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Type { get; set; }
    }
}
