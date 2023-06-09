namespace Domain.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
