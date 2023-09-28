using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MySqlX.XDevAPI.Common;
using System.Net;

namespace DocumentVersionManager.Api.Filters
{
    public class ErrorHandlingFilterAttribute: ExceptionFilterAttribute 
    {
        //public override void OnException(ExceptionContext context)
        //{
        // if (context.Exception is DocumentVersionManagerException)
        //    {
        //        context.Result = new BadRequestObjectResult(new { error = context.Exception.Message });
        //    }
        //    else
        //    {
        //        context.Result = new BadRequestObjectResult(new { error = "An error occured" + context.Exception.Message });
        //    }
        //    context.ExceptionHandled = true;
        //}   


        //var code = HttpStatusCode.InternalServerError; // 500 if unexpected
        //var result = JsonSerializer.Serialize(new { error = "An error occured" + context.Exception.Message });
        //context.Response.ContentType = "application/json";
        //    context.Response.StatusCode = (int) code;
        //context.Result = new JsonResult(result);

        public override void OnException(ExceptionContext context)
        {
            //if (context.Exception is null)
            //{
            //    context.Result = new BadRequestObjectResult(new { error = context.Exception.Message });
            //}
                 var exception = context.Exception;
            var problemDetails = new ProblemDetails { 
                Detail = exception.Message,
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = "An error occured",
                Status = (int)HttpStatusCode.InternalServerError,
                Instance = context.HttpContext.Request.Path,

            };
            
               // context.Result = new BadRequestObjectResult(new { error = "An error occured" + context.Exception.Message });
            context.Result = new ObjectResult(problemDetails);

            context.ExceptionHandled = true;
        }
    }
}
