using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using DocumentVersionManager.Application.CQRS.ModelType.Queries;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentVersionManager.Api.Controllers.V1
{
   // [Route("api/[controller]")]
    [ApiController]
    public class ModelController : ControllerBase
    {
        private readonly ILogger<ModelController> _logger;
        //private readonly IMediator _mediator;
        private readonly ISender _mediator;

        public ModelController(ILogger<ModelController> logger, ISender mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(template: DocumentVersionAPIEndPoints.Model.Get, Name = DocumentVersionAPIEndPoints.Model.Get)]
        public async Task<IActionResult> Get([FromBody] ModelRequestDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _mediator.Send(new GetModelsQuery(new ApplicationModelRequestDTO(request.ModelId)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(ModelFailuresExtensions.GetEnumDescription(errors)),
                                Right: result => new OkObjectResult(result));
        }

        [HttpGet(template: DocumentVersionAPIEndPoints.Model.GetAll, Name = DocumentVersionAPIEndPoints.Model.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return (await _mediator.Send(new GetAllModelsQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                                Right: result => new OkObjectResult(result));
        }

        [HttpPost(template: DocumentVersionAPIEndPoints.Model.Create, Name = DocumentVersionAPIEndPoints.Model.Create)]
        public async Task<IActionResult> Create(ModelCreateDTO request, CancellationToken cancellationToken)
        {
            var modelType = new ApplicationModelCreateDTO(request.ModelId,request.ModelTypeId, request.ModelName);

            return modelType.EnsureInputIsNotEmpty("Input Cannot be Empty")//.EnsureInputIsNotEmpty("Input Cannot be empty")
                .Bind<Either<GeneralFailures, int>>(modelType => CreateModel(modelType, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                      Right: result => result.Match<IActionResult>(
                      Left: errors2 => new OkObjectResult(ModelFailuresExtensions.GetEnumDescription(errors2)),
                      Right: result2 => Created($"/{DocumentVersionAPIEndPoints.ModelType.Create}/{modelType.ModelTypeId}", modelType)));
        }



        [HttpDelete(template: DocumentVersionAPIEndPoints.Model.Delete, Name = DocumentVersionAPIEndPoints.Model.Delete)]
        public async Task<IActionResult> Get([FromBody] ModelDeleteDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _mediator.Send(new DeleteModelCommand(new ApplicationModelDeleteDTO(request.ModelId)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(ModelFailuresExtensions.GetEnumDescription(errors)),
                                Right: result => new OkObjectResult(result));
        }

        [HttpPut(template: DocumentVersionAPIEndPoints.Model.Update, Name = DocumentVersionAPIEndPoints.Model.Update)]
        public async Task<IActionResult> Update(ModelUpdateDTO request, CancellationToken cancellationToken)
        {
            var modelType = new ApplicationModelUpdateDTO(request.ModelId,  request.ModelTypeId, request.ModelName);

            return modelType.EnsureInputIsNotEmpty("Input Cannot be Empty")//.EnsureInputIsNotEmpty("Input Cannot be empty")
                .Bind<Either<GeneralFailures, int>>(modelType => UpdateModelType(modelType, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                      Right: result => result.Match<IActionResult>(
                      Left: errors2 => new OkObjectResult(ModelFailuresExtensions.GetEnumDescription(errors2)),
                      Right: result2 => Created($"/{DocumentVersionAPIEndPoints.ModelType.Create}/{modelType.ModelTypeId}", modelType)));
        }

        private async Task<Either<GeneralFailures, int>> UpdateModelType(ApplicationModelUpdateDTO modelType, CancellationToken cancellationToken)
       => await _mediator.Send(new UpdateModelCommand(modelType), cancellationToken);










        private async Task<Either<GeneralFailures, int>> CreateModel(ApplicationModelCreateDTO modelType, CancellationToken cancellationToken)
           => await _mediator.Send(new CreateModelCommand(modelType), cancellationToken);

    }
}
