using Booking.Application.DataBase;
using Booking.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Booking.Persistence
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var con = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DataBaseService>(options => options.UseSqlServer(con));
            services.AddScoped<IDataBaseService, DataBaseService>();

            return services;
        }
    }
}
