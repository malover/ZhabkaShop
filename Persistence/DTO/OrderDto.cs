namespace Persistence.DTO
{
    public class OrderDto
    {
        public string Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public Dictionary<string, int> OrderedProducts { get; set; }
    }
}
