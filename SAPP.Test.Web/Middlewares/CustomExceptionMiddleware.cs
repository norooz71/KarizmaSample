﻿using Microsoft.AspNetCore.Http;
using Karizma.Sample.Contracts.Utilities.Logger;
using Karizma.Sample.Domain.Entities.Test;
using Karizma.Sample.Domain.Exeptions;
using Karizma.Sample.Presentation.Responses;

namespace Karizma.Sample.Web.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        private readonly ILoggerManager _logger;

        public CustomExceptionMiddleware(RequestDelegate next,ILoggerManager logger)
        {
            _next = next;

            _logger = logger;   
        }

        public async Task InvokeAsync(HttpContext _context)
        {
            try
            {
                await _next(_context);
            }
            catch (GlobalException ex)
            {
                _logger.Error(ex.Message);

                _context.Response.ContentType = "application/json";
                _context.Response.StatusCode = _context.Response.StatusCode;


                var errorMessages = new List<string>();

                int statusCode = 0;

                switch (ex.Type)
                {
                    case ExceptionType.NotFound:
                        errorMessages.Add(ex.Message);
                        statusCode = 404;
                        break;

                    case ExceptionType.InvalidArgument:
                        errorMessages.Add(ex.Message);
                        statusCode = 400;
                        break;

                    default:
                        errorMessages.Add(ExceptionMessages.InternalError);
                        statusCode = 500;
                        break;
                }

                await _context.Response.WriteAsync(new BaseResponse<object>(true, statusCode, null, errorMessages).ToString());
            }

        }
    }

}
