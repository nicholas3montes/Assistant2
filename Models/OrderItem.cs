namespace Assistant2.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
    }
}
