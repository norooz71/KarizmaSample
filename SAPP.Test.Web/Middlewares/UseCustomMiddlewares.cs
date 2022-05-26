namespace Karizma.Sample.Web.Middlewares
{
    public static class UseCustomMiddlewares
    {
        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
