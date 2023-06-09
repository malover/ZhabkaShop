namespace Domain.Models
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsFulfilled { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
