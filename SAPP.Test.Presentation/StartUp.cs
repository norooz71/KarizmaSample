using Karizma.Sample.Presentation.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace Karizma.Sample.Presentation
{
    public static class StartUp
    {
        public static IServiceCollection AddOrderTimeValidation(this IServiceCollection services)
        {
            return services.AddScoped<OrderTimeValidation>();
        }

        public static IServiceCollection AddOrderPriceValidation(this IServiceCollection services)
        {
            
            return  services.AddScoped<OrderPriceValidation>();

        }
    }
}
