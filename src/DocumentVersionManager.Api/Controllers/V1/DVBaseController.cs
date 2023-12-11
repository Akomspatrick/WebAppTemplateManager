using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace DocumentVersionManager.Api.Controllers.v1
{
    // [Route("api/[controller]")]
    // [ApiVersion("2.0")]
    [ApiController]
    // public class DVBaseController<T> : ControllerBase where T : DVBaseController<T>

    public abstract class DVBaseController<T> : ControllerBase where T : DVBaseController<T>
    {
        protected ILogger<T> _logger;
        protected ISender _sender;
        public DVBaseController(ILogger<T> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }
    }
}
