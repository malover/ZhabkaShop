using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories;

namespace Persistence
{
    public class UnityOfWork : IUnitOfWork
    {
        private IProductRepository? _productRepository;
        private IOrderRepository? _orderRepository;

        private readonly ECommerceContext _context;
        private bool _disposed;

        public IProductRepository ProductRepository
        {
            get
            {
                this._productRepository ??= new ProductRepository(_context);
                return this._productRepository;
            }
        }
        public IOrderRepository OrderRepository
        {
            get
            {
                this._orderRepository ??= new OrderRepository(_context);
                return this._orderRepository;
            }
        }

        public UnityOfWork(ECommerceContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this._disposed = true;
        }
    }
}
