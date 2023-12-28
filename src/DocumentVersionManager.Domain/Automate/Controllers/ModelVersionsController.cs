using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.ModelVersion.Commands;
using DocumentVersionManager.Application.CQRS.ModelVersion.Queries;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
namespace DocumentVersionManager.Api.Controllers.v1
{
    public  class ModelVersionsController  : TheBaseController<ModelVersionsController>
    {

        public ModelVersionsController(ILogger<ModelVersionsController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<ModelVersionResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelVersion.Get, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
             return (await _sender.Send<Either<GeneralFailure, IEnumerable<ApplicationModelVersionResponseDTO>>>(new GetAllModelVersionQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(GetModelVersionResponseResult(result)));
        }

        private IEnumerable<ModelVersionResponseDTO> GetModelVersionResponseResult(IEnumerable<ApplicationModelVersionResponseDTO> result)
        
        => throw new NotImplementedException("Please implement like below");
        //=> result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertModelVersionResponse(x.Models)));
        

        private ICollection<ModelResponseDTO> CovertModelTypeResponse(ICollection<ApplicationModelResponseDTO> models)
        => throw new NotImplementedException("Please implement like below");
        //=> models.Select(x => new ModelResponseDTO(x.ModelId, x.ModelName, x.ModelTypesName)).ToList();

        [ProducesResponseType(typeof(ModelVersionResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelVersion.GetById, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");
            var result = Guid.TryParse(NameOrGuid, out Guid guid);
            if (result)
            {
                var ModelVersionRequestByIdDTO = new ModelVersionGetRequestByGuidDTO(guid);
                return (await _sender.Send(new GetModelVersionByGuidQuery(new ApplicationModelVersionGetRequestByGuidDTO(ModelVersionRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationModelVersionResponseDTO_To_ModelVersionResponseDTO(result)));
            }
            else
            {
                var ModelVersionRequestByIdDTO = new ModelVersionGetRequestByIdDTO(NameOrGuid);
                return (await _sender.Send<Either<GeneralFailure, ApplicationModelVersionResponseDTO>>(new GetModelVersionByIdQuery(new ApplicationModelVersionGetRequestByIdDTO(ModelVersionRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationModelVersionResponseDTO_To_ModelVersionResponseDTO(result)));
            }
        }

        private ModelVersionResponseDTO MapApplicationModelVersionResponseDTO_To_ModelVersionResponseDTO(ApplicationModelVersionResponseDTO result)
        => throw new NotImplementedException("Please implement like below");
        // => new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelResponse(result.Models));

         private ICollection<ModelResponseDTO> CovertToModelResponse(ICollection<ApplicationModelResponseDTO> models)
        => throw new NotImplementedException("Please implement like below");
        // => models.Select(x => new ModelResponseDTO(x.ModelId, x.ModelName, x.ModelTypesName)).ToList();

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelVersion.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.GetByJSONBody)]
        public async Task<IActionResult> GetByJSONBody([FromBody] ModelVersionGetRequestDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _sender.Send(new GetModelVersionQuery(new ApplicationModelVersionGetRequestDTO(request)), cancellationToken))
            .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                Right: result => new OkObjectResult(MapApplicationModelVersionResponseDTO_To_ModelVersionResponseDTO(result)));
        }

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.ModelVersion.Create, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.Create)]
        public async Task<IActionResult> Create(ModelVersionCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelVersionCreateRequestDTO(request);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, Guid>>(_ => (  CreateModelVersion(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new BadRequestObjectResult(errors2),
                    Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ModelVersion.Create}/{result2}", dto)));
        }

        private async Task<Either<GeneralFailure, Guid>> CreateModelVersion(ApplicationModelVersionCreateRequestDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateModelVersionCommand(createType), cancellationToken);


        [HttpPut(template: DocumentVersionManagerAPIEndPoints.ModelVersion.Update, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.Update)]
        public async Task<IActionResult> Update(ModelVersionUpdateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelVersionUpdateRequestDTO(request);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelVersion(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new     BadRequestObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ModelVersion.Create}/{dto}", dto)));

         }

        private async Task<Either<GeneralFailure, int>> UpdateModelVersion(ApplicationModelVersionUpdateRequestDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateModelVersionCommand(updateType), cancellationToken);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.ModelVersion.Delete, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
        {
        var result = new ModelVersionDeleteRequestDTO(request);
        var guid = new ApplicationModelVersionDeleteRequestDTO(result);
        return guid.EnsureInputIsNotEmpty("Input Cannot be null")
            .Bind<Either<GeneralFailure, int>>(guid => DeleteModelVersion(guid, cancellationToken).Result)
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }

        private async Task<Either<GeneralFailure, int>> DeleteModelVersion(ApplicationModelVersionDeleteRequestDTO dto, CancellationToken cancellationToken)
        =>  await _sender.Send(new DeleteModelVersionCommand(dto), cancellationToken);

    }
}