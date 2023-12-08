using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentVersionManager.Api.Controllers.v1
{

    [Route("Error")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [HttpPost(Name = "Error")]

        public IActionResult Error()
        {
            //Exception exception = HttpContext.Features.Get<Exception>();
            Exception exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            return Problem(
                                 detail: exception?.StackTrace,
                                 title: exception?.Message,
                                 statusCode: StatusCodes.Status500InternalServerError,
                                 instance: HttpContext.Request.Path,
                                 type: "https://tools.ietf.org/html/rfc7231#section-6.6.1"
                                                                                                      );
        }

    }

}

