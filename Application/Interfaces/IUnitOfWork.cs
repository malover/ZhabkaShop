namespace Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductRepository ProductRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public Task SaveAsync();
    }
}
