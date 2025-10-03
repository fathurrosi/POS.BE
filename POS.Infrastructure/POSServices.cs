using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POS.Application.Interfaces.Repositories;
using POS.Application.Interfaces.Services;
using POS.Infrastructure.Repositories;
using POS.Infrastructure.Services;
namespace POS.Infrastructure
{
    public static class POSServices
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<POSContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IMenuRepository, MenuRepository>();
            services.AddTransient<IPrevillageRepository, PrevillageRepository>();
            services.AddTransient<IJwtService, JwtService>();

            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<IUnitRepository,UnitRepository>();
            return services;
        }
    }
}
