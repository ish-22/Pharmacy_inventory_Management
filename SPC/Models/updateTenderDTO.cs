namespace Project.Models
{
    public class updateTenderDTO
    {
        public int Id { get; set; }
        public string DrugName { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public DateTime publishedDate { get; set; }
        public DateTime closingDate { get; set; }
        public string Status { get; set; }
    }
}
