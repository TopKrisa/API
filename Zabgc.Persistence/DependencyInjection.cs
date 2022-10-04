using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Zabgc.Application.Interfaces;

namespace Zabgc.Persistence
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<ZabgcDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });
            services.AddScoped<IZabgcDbContext>(provider => provider.GetService<ZabgcDbContext>());

            return services;
        }
    }
}
