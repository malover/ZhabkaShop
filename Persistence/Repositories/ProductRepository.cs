using Application.DTO;
using Application.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceContext _context;

        public ProductRepository(ECommerceContext context)
        {
            _context = context;
        }

        public Task<List<Product>> GetAllAsync()
        {
            return _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is not null) return product;
            return null;
        }

        public async Task AddProductAsync(ProductDto prod)
        {
            var product = new Product
            {
                Name = prod.Name,
                Quantity = prod.Quantity,
                Price = prod.Price
            };
            await _context.AddAsync(product);
        }

        public async Task UpdateProductAsync(ProductDto prod)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Name == prod.Name);
            if (product is not null)
            {
                product.Name = prod.Name;
                product.Quantity = prod.Quantity;
                product.Price = prod.Price;
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product is not null) _context.Remove(product);
        }
    }
}
