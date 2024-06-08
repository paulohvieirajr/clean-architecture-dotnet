using CleanArchMVC.Domain.Interfaces;
using CleanArchMVC.Infra.Data.Context;
using CleanArchMVC.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchMVC.Infra.Ioc
{
    public static class DependenceInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,  
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
