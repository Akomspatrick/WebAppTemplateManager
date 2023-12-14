﻿using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using DocumentVersionManager.Application.CQRS.ModelType.Queries;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using LanguageExt.ClassInstances;
using LanguageExt.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;

namespace DocumentVersionManager.Api.Controllers.v1
{

    public class ModelTypeController : TheBaseController<ModelTypeController>
    {
        public ModelTypeController(ILogger<ModelTypeController> logger, ISender sender) : base(logger, sender)
        {
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]

        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelType.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.ModelType.GetByJSONBody)]
        public async Task<IActionResult> GetByJSONBody([FromBody] ModelTypeGetRequestDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _sender.Send(new GetModelTypeQuery(new ApplicationModelTypeGetRequestDTO(request)), cancellationToken))
            .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                                Right: result => new OkObjectResult(MapApplicationModelTypeResponseDTO_To_ModelTypeResponseDTO(result)));
        }


        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(DocumentVersionManagerAPIEndPoints.ModelType.GetById, Name = DocumentVersionManagerAPIEndPoints.ModelType.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {

            var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");
            var result = Guid.TryParse(NameOrGuid, out Guid guid);
            if (result)
            {
                var ModelTypeRequestByIdDTO = new ModelTypeGetRequestByGuidDTO(guid);
                return (await _sender.Send(new GetModelTypeByGuidQuery(new ApplicationModelTypeGetRequestByGuidDTO(ModelTypeRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                                    Right: result => new OkObjectResult(MapApplicationModelTypeResponseDTO_To_ModelTypeResponseDTO(result)));
            }
            else
            {
                var ModelTypeRequestByIdDTO = new ModelTypeGetRequestByIdDTO(NameOrGuid);
                return (await _sender.Send<Either<GeneralFailure, ApplicationModelTypeResponseDTO>>(new GetModelTypeByIdQuery(new ApplicationModelTypeGetRequestByIdDTO(ModelTypeRequestByIdDTO)), cancellationToken))
              .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                      Right: result => new OkObjectResult(MapApplicationModelTypeResponseDTO_To_ModelTypeResponseDTO(result)));
            }

        }

        [ProducesResponseType(typeof(IEnumerable<ModelTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelType.Get, Name = DocumentVersionManagerAPIEndPoints.ModelType.Get)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return (await _sender.Send<Either<GeneralFailure, IEnumerable<ApplicationModelTypeResponseDTO>>>(new GetAllModelTypeQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                                Right: result => new OkObjectResult(GetModelTypeResponseResult(result)));

        }

        private IEnumerable<ModelTypeResponseDTO> GetModelTypeResponseResult(IEnumerable<ApplicationModelTypeResponseDTO> result)
        {
            // throw new NotImplementedException("Please implement like below");
            return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelResponse(x.Models)));
        }

        private ICollection<ModelResponseDTO> CovertToModelResponse(ICollection<ApplicationModelResponseDTO> models)
        {
            return models.Select(x => new ModelResponseDTO(x.ModelId, x.ModelName, x.ModelTypesName)).ToList();
        }
        private ModelTypeResponseDTO MapApplicationModelTypeResponseDTO_To_ModelTypeResponseDTO(ApplicationModelTypeResponseDTO result)
        {
            return new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelResponse(result.Models));
        }


        [HttpPost(template: DocumentVersionManagerAPIEndPoints.ModelType.Create, Name = DocumentVersionManagerAPIEndPoints.ModelType.Create)]
        public async Task<IActionResult> Create(ModelTypeCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var modelType = new ApplicationModelTypeCreateRequestDTO(request);

            return modelType.EnsureInputIsNotEmpty("Input Cannot be Empty")//.EnsureInputIsNotEmpty("Input Cannot be empty")
                .Bind<Either<GeneralFailure, int>>(modelType => CreateModelType(modelType, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                      Right: result => result.Match<IActionResult>(
                      Left: errors2 => new BadRequestObjectResult(errors2),
                      Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ModelType.Create}/{modelType}", modelType)));
        }

        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.ModelType.Delete, Name = DocumentVersionManagerAPIEndPoints.ModelType.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
        {
            var result = new ModelTypeDeleteRequestDTO(request);
            var guid = new ApplicationModelTypeDeleteRequestDTO(result);

            return guid.EnsureInputIsNotEmpty("Input Cannot be null")
                .Bind<Either<GeneralFailure, int>>(guid => DeleteModelType(guid, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                 Right: result => new OkObjectResult(result));

        }

        private async Task<Either<GeneralFailure, int>> DeleteModelType(ApplicationModelTypeDeleteRequestDTO dto, CancellationToken cancellationToken)
        {
            return await _sender.Send(new DeleteModelTypeCommand(dto), cancellationToken);

        }

        [HttpPut(template: DocumentVersionManagerAPIEndPoints.ModelType.Update, Name = DocumentVersionManagerAPIEndPoints.ModelType.Update)]
        public IActionResult Update(ModelTypeUpdateRequestDTO request, CancellationToken cancellationToken)
        {
            // we should fist ensure that it is not nulll here before using it 
            var dto = new ApplicationModelTypeUpdateRequestDTO(request);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")//.EnsureInputIsNotEmpty("Input Cannot be empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelType(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                      Right: result => result.Match<IActionResult>(
                      Left: errors2 => new BadRequestObjectResult(errors2),
                      Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ModelType.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateModelType(ApplicationModelTypeCreateRequestDTO modelType, CancellationToken cancellationToken)
         => await _sender.Send(new CreateModelTypeCommand(modelType), cancellationToken);


        private async Task<Either<GeneralFailure, int>> UpdateModelType(ApplicationModelTypeUpdateRequestDTO modelType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateModelTypeCommand(modelType), cancellationToken);

    }
}
