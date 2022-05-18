using Karizma.Sample.Domain.Exeptions;
using Karizma.Sample.Presentation.Responses;
using Karizma.Sample.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Karizma.Sample.Presentation.Filters
{
    public class OrderPriceValidation : IAsyncActionFilter
    {
        private readonly int PriceValidaion;

        private readonly IServiceManager _servicemanager;

        public OrderPriceValidation(IConfiguration configuration, IServiceManager serviceManager)
        {
            PriceValidaion = int.Parse(configuration["PriceValidation"]);

            _servicemanager = serviceManager;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var price = await _servicemanager.OrderService.CalculatePice(1);

            if (price < PriceValidaion)
            {
                context.Result = new BadRequestObjectResult(new BaseResponse<object>(false, 400, price, new List<string> { ExceptionMessages.InvalidOrderPrice }));

                return;
            }


            var result = await next();
        }
    }
}
