namespace Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public bool IsFulfilled { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
