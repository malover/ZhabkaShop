using Application.DTO;
using Domain.Models;

namespace Application.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAllAsync();
        public Task<Product?> GetProductByIdAsync(int id);
        public Task AddProductAsync(ProductDto product);
        public Task UpdateProductAsync(ProductDto product);
        public Task DeleteProductAsync(int id);
    }
}
