using Asp.Versioning;
using AutoMapper;
using WebAppTemplateManager.Api.Mapping;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace WebAppTemplateManager.Api.Controllers.v1
{
    // [Route("api/[controller]")]
    // [ApiVersion("2.0")]
    [ApiController]
    // public class DVBaseController<T> : ControllerBase where T : DVBaseController<T>

    public abstract class TheBaseController<T> : ControllerBase where T : TheBaseController<T>
    {
        protected ILogger<T> _logger;
        protected ISender _sender;
    
        public TheBaseController(ILogger<T> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
            //_mapper = new MapperConfiguration(cfg =>
            //{
            //    cfg.AddProfile<MappingProfile>();
            //}).CreateMapper();
        }
    }
}
