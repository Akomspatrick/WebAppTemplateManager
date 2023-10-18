using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Application.CQRS.ModelType.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentVersionManager.Api.Controllers.V1
{
   // [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly ILogger<ModelsController> _logger;
        //private readonly IMediator _mediator;
        private readonly ISender _mediator;

        public ModelsController(ILogger<ModelsController> logger, ISender mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(template: DocumentVersionAPIEndPoints.Models.GetAll, Name = DocumentVersionAPIEndPoints.Models.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return (await _mediator.Send(new GetAllModelsQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                                Right: result => new OkObjectResult(result));
        }

    }
}
