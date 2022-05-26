using Karizma.Sample.Domain.Repositories;
using Karizma.Sample.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Karizma.Sample.Persistance
{
    public static class Startup
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            return  services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static IServiceCollection AddDbContext(this IServiceCollection services,IConfiguration configuration)
        {
            return services.AddDbContext<RepositoryDbContext>(dbBuilder =>
            {
                var connectionString = configuration.GetConnectionString("Database");

                dbBuilder.UseSqlServer(connectionString);

            });
        }

    }
}
