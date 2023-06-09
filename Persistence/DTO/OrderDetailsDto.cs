namespace Persistence.DTO
{
    public class OrderDetailsDto
    {
        public int OrderDetailsId { get; set; }
        public string Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public string ProductName { get; set; }

    }
}
