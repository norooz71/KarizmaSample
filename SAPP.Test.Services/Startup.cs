using Karizma.Sample.Services.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karizma.Sample.Services
{
    public static class Startup
    {
        public static IServiceCollection AddServiceManager(this IServiceCollection services)
        {
            return services.AddScoped<IServiceManager,ServiceManager>();
        } 
    }
}
