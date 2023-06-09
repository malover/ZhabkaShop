using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ECommerceContext : DbContext
    {
        public static string DbConnectionName = "ZhabkaShopDb";
        public ECommerceContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
