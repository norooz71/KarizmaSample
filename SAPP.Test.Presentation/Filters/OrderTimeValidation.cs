using Karizma.Sample.Domain.Exeptions;
using Karizma.Sample.Presentation.Responses;
using Karizma.Sample.Services.Abstractions.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace Karizma.Sample.Presentation.Filters
{
    public class OrderTimeValidation : IActionFilter
    {

        private readonly ValidTime _validTime;

        public OrderTimeValidation(IOptions<ValidTime> validTime)
        {
            _validTime = validTime.Value;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var orderTimeHour = DateTime.Now.Hour;

            if (orderTimeHour < _validTime.Min || orderTimeHour > _validTime.Max)
            {
                context.Result = new BadRequestObjectResult(new BaseResponse<object>(false, 400, orderTimeHour, new List<string> { ExceptionMessages.InvalidTime }));

                return;
            }

        }
    }
}
