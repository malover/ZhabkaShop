namespace Application.DTO
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetailsDto> OrderDetails { get; set; }
    }
}
