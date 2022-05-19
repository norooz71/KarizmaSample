using Karizma.Sample.Presentation.Filters;
using Karizma.Sample.Presentation.Responses;
using Karizma.Sample.Services.Abstractions;
using Karizma.Sample.Services.Abstractions.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Karizma.Sample.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController:ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public OrderController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;   
        }

        [HttpPost]
        [ServiceFilter(typeof(OrderPriceValidation), Order = 1)]
        [ServiceFilter(typeof(OrderTimeValidation), Order = 2)]
        public async Task<IActionResult> Add()
        {
             await _serviceManager.OrderService.Add(1);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result=await _serviceManager.OrderService.GetAll();

            return Ok(new BaseResponse<IEnumerable<OrderDto>>(true, 200, result, null));
        }

    }
}
