using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TicketManagement.CleanArchitecture.Application.Contracts.Persistence;
using TicketManagement.CleanArchitecture.Persistence.Repositories;

namespace TicketManagement.CleanArchitecture.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection RegisterPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TicketManagementDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TicketManagementConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            return services;
        }
    }
}
