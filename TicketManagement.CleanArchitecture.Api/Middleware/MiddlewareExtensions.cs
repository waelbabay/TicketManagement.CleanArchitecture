namespace TicketManagement.CleanArchitecture.Api.Middleware
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder useCustomExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
