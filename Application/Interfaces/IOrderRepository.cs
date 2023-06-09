using Application.DTO;

namespace Application.Interfaces
{
    public interface IOrderRepository
    {
        public Task<List<OrderDto>> GetAllAsync();
        public Task FulfillOrderAsync(int id);
        public Task AddOrderAsync(OrderDto order);
    }
}
