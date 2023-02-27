using GeonAPI.Application.Repositories;
using GeonAPI.Persistence.Contexts;
using GeonAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GeonAPI.Persistence
{
    public static class ServiceRegistiration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<GeonAPIDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString));
            serviceCollection.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            serviceCollection.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>(); 
        }
    }
}