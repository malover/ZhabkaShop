using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
    }
}
