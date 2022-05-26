using Karizma.Sample.Contracts.Utilities.Logger;
using Karizma.Sample.Services.Abstractions;
using Karizma.Sample.Services.Abstractions.Dtos;
using Karizma.Sample.Services.Utilities.Logger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using System.IO;

namespace Karizma.Sample.Services
{
    public static class Startup
    {
        public static IServiceCollection AddServiceManager(this IServiceCollection services)
        {
            return services.AddScoped<IServiceManager,ServiceManager>();
        }
        
        public static IServiceCollection AddAutoMapperService(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(MapperProfile));

        }

        public static IServiceCollection ConfigurePriceCalculatingSetting(this IServiceCollection services,IConfiguration configuration)
        {
            return services.Configure<PriceCalculatingSetting>(configuration.GetSection("PriceCalculatingSetting"));
        }
        
        public static IServiceCollection ConfigureValidTime(this IServiceCollection services,IConfiguration configuration)
        {
            return services.Configure<ValidTime>(configuration.GetSection("ValidTime"));
        }

        public static IServiceCollection AddLogger(this IServiceCollection services)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

            return services.AddSingleton<ILoggerManager, LoggerManager>();
        }
    }
}
