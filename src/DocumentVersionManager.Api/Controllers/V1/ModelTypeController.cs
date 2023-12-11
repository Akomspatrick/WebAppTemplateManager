using DocumentVersionManager.Api.Extentions;
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

    public class ModelTypeController : DVBaseController<ModelTypeController>
    {
        public ModelTypeController(ILogger<ModelTypeController> logger, ISender sender) : base(logger, sender)
        {
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]

        [HttpGet(template: DocumentVersionAPIEndPoints.ModelType.GetByModelTypeObj, Name = DocumentVersionAPIEndPoints.ModelType.GetByModelTypeObj)]
        public async Task<IActionResult> GetByModelTypeObj([FromBody] ModelTypeRequestDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _sender.Send(new GetModelTypeQuery(new ApplicationModelTypeRequestDTO(request.ModelTypesName)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                                Right: result => new OkObjectResult(new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelTypeResponse(result.Models)
              )));
        }


        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(DocumentVersionAPIEndPoints.ModelType.GetById, Name = DocumentVersionAPIEndPoints.ModelType.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string ModelTypeNameOrGuid, CancellationToken cancellationToken)
        {
            var x = ModelTypeNameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");
            var result = Guid.TryParse(ModelTypeNameOrGuid, out Guid guid);
            if (result)
            {

                return (await _sender.Send(new GetModelTypeByGuidQuery(new ApplicationModelTypeRequestByGuidDTO(guid)), cancellationToken))
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                                    Right: result => new OkObjectResult(new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelTypeResponse(result.Models)
                                    )));
            }
            else
            {
                return (await _sender.Send(new GetModelTypeByIdQuery(new ApplicationModelTypeRequestByIdDTO(ModelTypeNameOrGuid)), cancellationToken))
              .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                      Right: result => new OkObjectResult(new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelTypeResponse(result.Models)
                      )));
            }

            //return (await _sender.Send(new GetModelTypeQuery(new ApplicationModelTypeRequestDTO(request.ModelTypesName)), cancellationToken))
            //.Match<IActionResult>(Left: errors => new OkObjectResult(errors),
            //                    Right: result => new OkObjectResult(new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelTypeResponse(result.Models)
            //                    )));

        }

        [ProducesResponseType(typeof(IEnumerable<ModelTypeResponseDTO>), StatusCodes.Status200OK)]

        [HttpGet(template: DocumentVersionAPIEndPoints.ModelType.Get, Name = DocumentVersionAPIEndPoints.ModelType.Get)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return (await _sender.Send(new GetAllModelTypeQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                                Right: result => new OkObjectResult(result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)))));
            // Right: result => new OkObjectResult(getresult(result)));
        }

        private ICollection<ModelResponseDTO> CovertToModelTypeResponse(ICollection<ApplicationModelResponseDTO> models)
        {
            return models.Select(x => new ModelResponseDTO(x.ModelId, x.ModelName, x.ModelTypesName)).ToList();
        }



        [HttpPost(template: DocumentVersionAPIEndPoints.ModelType.Create, Name = DocumentVersionAPIEndPoints.ModelType.Create)]
        public async Task<IActionResult> Create(ModelTypeCreateDTO request, CancellationToken cancellationToken)
        {
            var modelType = new ApplicationModelTypeCreateDTO(request.ModelTypesName);

            return modelType.EnsureInputIsNotEmpty("Input Cannot be Empty")//.EnsureInputIsNotEmpty("Input Cannot be empty")
                .Bind<Either<GeneralFailure, int>>(modelType => CreateModelType(modelType, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                      Right: result => result.Match<IActionResult>(
                      Left: errors2 => new OkObjectResult(errors2),
                      Right: result2 => Created($"/{DocumentVersionAPIEndPoints.ModelType.Create}/{modelType.ModelTypesName}", modelType)));
        }



        [HttpDelete(template: DocumentVersionAPIEndPoints.ModelType.Delete, Name = DocumentVersionAPIEndPoints.ModelType.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid ModelTypeGuid, CancellationToken cancellationToken)
        {
            // var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _sender.Send(new DeleteModelTypeCommand(new ApplicationModelTypeDeleteDTO(ModelTypeGuid)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                                Right: result => new OkObjectResult(result));
        }

        [HttpPut(template: DocumentVersionAPIEndPoints.ModelType.Update, Name = DocumentVersionAPIEndPoints.ModelType.Update)]
        public IActionResult Update(ModelTypeUpdateDTO request, CancellationToken cancellationToken)
        {
            var modelType = new ApplicationModelTypeUpdateDTO(request.ModelTypesId, request.ModelTypesName);

            return modelType.EnsureInputIsNotEmpty("Input Cannot be Empty")//.EnsureInputIsNotEmpty("Input Cannot be empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelType(modelType, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                      Right: result => result.Match<IActionResult>(
                      Left: errors2 => new OkObjectResult(errors2),
                      Right: result2 => Created($"/{DocumentVersionAPIEndPoints.ModelType.Create}/{modelType.ModelTypesId}", modelType)));
        }

        private async Task<Either<GeneralFailure, int>> CreateModelType(ApplicationModelTypeCreateDTO modelType, CancellationToken cancellationToken)
         => await _sender.Send(new CreateModelTypeCommand(modelType), cancellationToken);

        private async Task<Either<GeneralFailure, int>> UpdateModelType(ApplicationModelTypeUpdateDTO modelType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateModelTypeCommand(modelType), cancellationToken);



    }
}
