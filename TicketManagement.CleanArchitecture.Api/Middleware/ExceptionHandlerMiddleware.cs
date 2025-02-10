using System.Net;
using System.Text.Json;
using TicketManagement.CleanArchitecture.Application.Exceptions;
namespace TicketManagement.CleanArchitecture.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";
            string message = string.Empty;

            switch (exception)
            {
                case NotFoundException notFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    message = notFoundException.Message;
                    break;
                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    message = badRequestException.Message;
                    break;
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    message = JsonSerializer.Serialize(validationException.ValidationErrors);
                    break;
                case Exception:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
            }

            context.Response.StatusCode = (int)httpStatusCode;

            if (message == string.Empty)
            {
                message = "An error occurred. Please try again later.";
            }

            await context.Response.WriteAsync(JsonSerializer.Serialize(new { error = message }));
        }
    }
}
