using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence.ServiceExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDbProvider(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommerceContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString(ECommerceContext.DbConnectionName));
            });
            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IUnitOfWork, UnityOfWork>();

            return services;
        }

    }
}
