using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using DocumentVersionManager.Application.CQRS.ModelType.Queries;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using  MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
namespace DocumentVersionManager.Api.Controllers.v1
{
    public  class ModelTypesController  : TheBaseController<ModelTypesController>
    {
        public ModelTypesController(ILogger<ModelTypesController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.ModelType.Create, Name = DocumentVersionManagerAPIEndPoints.ModelType.Create)]
        public async Task<IActionResult> Create(ModelTypeCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelTypeCreateRequestDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateModelType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new BadRequestObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ModelType.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateModelType(ApplicationModelTypeCreateRequestDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateModelTypeCommand(createType), cancellationToken);

        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.ModelType.Delete, Name = DocumentVersionManagerAPIEndPoints.ModelType.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
        var result = new ModelTypeDeleteRequestDTO(request);
        var guid = new ApplicationModelTypeDeleteRequestDTO(result);
        return guid.EnsureInputIsNotEmpty("Input Cannot be null")
            .Bind<Either<GeneralFailure, int>>(guid => DeleteModelType(guid, cancellationToken).Result)
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }

        private async Task<Either<GeneralFailure, int>> DeleteModelType(ApplicationModelTypeDeleteRequestDTO dto, CancellationToken cancellationToken)
        =>  await _sender.Send(new DeleteModelTypeCommand(dto), cancellationToken);
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.ModelType.Update, Name = DocumentVersionManagerAPIEndPoints.ModelType.Update)]
        public async Task<IActionResult> Update(ModelTypeUpdateRequestDTO request,, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelTypeUpdateRequestDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelType(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new     BadRequestObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ModelType.Create}/{dto.}", dto)));

         }

        private async Task<Either<GeneralFailure, int>> UpdateModelType(ApplicationModelTypeUpdateRequestDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateModelTypeCommand(updateType), cancellationToken);
        [ProducesResponseType(typeof(IEnumerable<ModelTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelType.Get, Name = DocumentVersionManagerAPIEndPoints.ModelType.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
             return (await _sender.Send<Either<GeneralFailure, IEnumerable<ApplicationModelTypeResponseDTO>>>(new GetAllModelTypeQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(GetModelTypeResponseResult(result)));
        }

        private IEnumerable<ModelTypeResponseDTO> GetModelTypeResponseResult(IEnumerable<ApplicationModelTypeResponseDTO> result)
        { throw new NotImplementedException("Please implement like below");// return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)));
        }
        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelType.GetById, Name = DocumentVersionManagerAPIEndPoints.ModelType.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");
            var result = Guid.TryParse(NameOrGuid, out Guid guid);
            if (result)
            {
                var ModelTypeRequestByIdDTO = new ModelTypeGetRequestByGuidDTO(guid);
                return (await _sender.Send(new GetModelTypeByGuidQuery(new ApplicationModelTypeGetRequestByGuidDTO(ModelTypeRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationModelTypeResponseDTO_To_ModelTypeResponseDTO(result)));
            }
            else
            {
                var ModelTypeRequestByIdDTO = new ModelTypeGetRequestByIdDTO(NameOrGuid);
                return (await _sender.Send<Either<GeneralFailure, ApplicationModelTypeResponseDTO>>(new GetModelTypeByIdQuery(new ApplicationModelTypeGetRequestByIdDTO(ModelTypeRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationModelTypeResponseDTO_To_ModelTypeResponseDTO(result)));
            }
        }
        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelType.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.ModelType.GetByJSONBody)]
        public async Task<IActionResult> GetByJSONBody([FromBody] ModelTypeGetRequestDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _sender.Send(new GetModelTypeQuery(new ApplicationModelTypeGetRequestDTO(request)), cancellationToken))
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(MapApplicationModelTypeResponseDTO_To_ModelTypeResponseDTO(result)));
         }
    }
}