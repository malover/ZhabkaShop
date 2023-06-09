using Domain.Models;

namespace Application.Interfaces
{
    public interface IOrderRepository
    {
        public Task AddOrderAsync();
        public Task FulfillOrderAsync(int id);
    }
}
