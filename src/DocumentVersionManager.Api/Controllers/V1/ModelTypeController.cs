﻿using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using DocumentVersionManager.Application.CQRS.ModelType.Queries;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DocumentVersionManager.Api.Controllers.V1
{
    [ApiController]
    // [Route("api")]
    public class ModelTypeController : ControllerBase
    {
        private readonly ILogger<ModelTypeController> _logger;
        //private readonly IMediator _mediator;
        private readonly ISender _mediator;

        public ModelTypeController(ILogger<ModelTypeController> logger, ISender mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet(template: DocumentVersionAPIEndPoints.ModelType.GetAll, Name = DocumentVersionAPIEndPoints.ModelType.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            return (await _mediator.Send(new GetAllModelTypeQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                                Right: result => new OkObjectResult(result));
        }

        [HttpPost(template: DocumentVersionAPIEndPoints.ModelType.Create, Name = DocumentVersionAPIEndPoints.ModelType.Create)]
        public async Task<IActionResult> Create(ModelTypeCreateDTO request, CancellationToken cancellationToken)
        {
            var modelType = new ApplicationModelTypeCreateDTO(request.ModelTypeId, request.ModelTypeName);

            return modelType.EnsureInputIsNotEmpty("Input Cannot be Empty")//.EnsureInputIsNotEmpty("Input Cannot be empty")
                .Bind<Either<GeneralFailures, int>>(modelType => CreateModelType(modelType, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                      Right: result => result.Match<IActionResult>(
                      Left: errors2 => new OkObjectResult(ModelFailuresExtensions.GetEnumDescription(errors2)),
                      Right: result2 => Created($"/{DocumentVersionAPIEndPoints.ModelType.Create}/{modelType.ModelTypeId}", modelType)));
        }

        [HttpGet(template: DocumentVersionAPIEndPoints.ModelType.Get, Name = DocumentVersionAPIEndPoints.ModelType.Get)]
        public async Task<IActionResult> Get([FromBody] ModelTypeRequestDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _mediator.Send(new GetModelTypeQuery(new ApplicationModelTypeRequestDTO(request.ModelTypeId)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(ModelFailuresExtensions.GetEnumDescription(errors)),
                                Right: result => new OkObjectResult(result));
        }


        [HttpDelete(template: DocumentVersionAPIEndPoints.ModelType.Delete, Name = DocumentVersionAPIEndPoints.ModelType.Delete)]
        public async Task<IActionResult> Get([FromBody] ModelTypeDeleteDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _mediator.Send(new DeleteModelTypeCommand(new ApplicationModelTypeDeleteDTO(request.ModelTypeId)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(ModelFailuresExtensions.GetEnumDescription(errors)),
                                Right: result => new OkObjectResult(result));
        }

        [HttpPut(template: DocumentVersionAPIEndPoints.ModelType.Update, Name = DocumentVersionAPIEndPoints.ModelType.Update)]
        public async Task<IActionResult> Update(ModelTypeUpdateDTO request, CancellationToken cancellationToken)
        {
            var modelType = new ApplicationModelTypeUpdateDTO(request.ModelTypeId, request.ModelTypeName);

            return modelType.EnsureInputIsNotEmpty("Input Cannot be Empty")//.EnsureInputIsNotEmpty("Input Cannot be empty")
                .Bind<Either<GeneralFailures, int>>(modelType => UpdateModelType(modelType, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                      Right: result => result.Match<IActionResult>(
                      Left: errors2 => new OkObjectResult(ModelFailuresExtensions.GetEnumDescription(errors2)),
                      Right: result2 => Created($"/{DocumentVersionAPIEndPoints.ModelType.Create}/{modelType.ModelTypeId}", modelType)));
        }






        private async Task<Either<GeneralFailures, int>> CreateModelType(ApplicationModelTypeCreateDTO modelType, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new CreateModelTypeCommand(modelType), cancellationToken);

        }

        private async Task<Either<GeneralFailures, int>> UpdateModelType(ApplicationModelTypeUpdateDTO modelType, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new UpdateModelTypeCommand(modelType), cancellationToken);

        }

    }
}
