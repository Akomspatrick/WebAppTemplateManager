
using System.Net;
using System.Text.Json;

namespace DocumentVersionManager.Api.Middleware
{
public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next; 
        private readonly ILogger<ErrorHandlingMiddleware> _logger;  
        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next; 
            _logger = logger; 
        }   

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception has occurred while executing the request.");
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
           var code = HttpStatusCode.InternalServerError; // 500 if unexpected
          //  var result = JsonSerializer.Serialize(new { error = ex.Message });
            var result = JsonSerializer.Serialize(new { error = "An error occured"+ ex.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
