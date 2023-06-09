using Application.Interfaces;

namespace Persistence.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ECommerceContext _context;
        public OrderRepository(ECommerceContext context)
        {
            _context = context;
        }

        public Task AddOrderAsync()
        {
            throw new NotImplementedException();
        }

        public Task FulfillOrderAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
