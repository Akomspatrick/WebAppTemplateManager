using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly IExceptionHandlerFeature _exceptionHandlerFeature;
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger
            //,IExceptionHandlerFeature exceptionHandlerFeature
            )
        {
            // _exceptionHandlerFeature = exceptionHandlerFeature;
            _logger = logger;
        }
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            _logger.LogError(exception, $"Exception occured {exception.Message}");
            // var x = _exceptionHandlerFeature.Error;
            var problemDetails = new ProblemDetails
            {
                //  Detail = exception.Message, //details are not passes to the client but are logged
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = "An error occured",
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = httpContext.Request.Path,

            };

            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError; ;
            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);
            return true;

        }


    }
}
