using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure.GlobalExceptionHandler
{

    public class GlobalExceptionHandler : IExceptionHandler
    {
      //  private readonly IExceptionHandlerFeature _exceptionHandlerFeature;
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, $"Exception occured {exception.Message} {exception.Source}");

            var exceptionHandlerFeature =httpContext.Features.Get<IExceptionHandlerFeature>();
          
            (int statusCode, string title) = exception switch
            {   InvalidCastException invalidCastException => (400, invalidCastException.Message),
                AggregateException aggregateException => (400, aggregateException.Message),
                ArgumentNullException argumentNullException => (400, argumentNullException.Message),
                ArgumentException argumentException => (400, argumentException.Message),
               // ValidationException validationException => (400, validationException.Message),
                KeyNotFoundException keyNotFoundException => (404, keyNotFoundException.Message),
                FormatException formatException => (400, formatException.Message),
                MySqlException mySqlException => (400, mySqlException.Message),
                //ForbidException => (403, "Forbidden"),
                BadHttpRequestException => (400, "Bad request"),
               // NotFoundException notfnotfound => (404, "Directory not found"),
                _ => (500, "An error occured @" + exception.Message)
            };

           

            var problemDetails = new ProblemDetails
            {
                //  Detail = exception.Message, //details are not passes to the client but are logged
                Detail = exception.InnerException?.Message,
                Type = nameof(exception),
                Title = title,//"An error occured from " + exception.Source,
                Status = statusCode,// (int)HttpStatusCode.InternalServerError,
                Instance = exceptionHandlerFeature?.Endpoint?.ToString() ??    httpContext.Request.Path,
            };

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = statusCode; 
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;

        }


    }
}
