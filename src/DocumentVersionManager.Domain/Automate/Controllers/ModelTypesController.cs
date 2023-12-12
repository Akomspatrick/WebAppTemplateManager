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
    public  class ModelTypesController  : DVBaseController<ModelTypesController>
    {
        public ModelTypesController(ILogger<ModelTypesController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.ModelType.Create, Name = DocumentVersionManagerAPIEndPoints.ModelType.Create)]
        public async Task<IActionResult> Create(ModelTypeCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelTypeCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateModelType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ModelType.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateModelType(ApplicationModelTypeCreateDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateModelTypeCommand(createType), cancellationToken);
        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.ModelType.Delete, Name = DocumentVersionManagerAPIEndPoints.ModelType.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            return (await _sender.Send(new DeleteModelTypeCommand(new ApplicationModelTypeDeleteDTO(guid)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.ModelType.Update, Name = DocumentVersionManagerAPIEndPoints.ModelType.Update)]
        public async Task<IActionResult> Update(ModelTypeUpdateDTO request,, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelTypeUpdateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelType(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new OkObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ModelType.Create}/{dto.}", dto)));
        }
         }

        private async Task<Either<GeneralFailure, int>> UpdateModelType(ApplicationModelTypeUpdateDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateModelTypeCommand(updateType), cancellationToken);
        [ProducesResponseType(typeof(IEnumerable<ModelTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelType.Get, Name = DocumentVersionManagerAPIEndPoints.ModelType.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
            return (await _sender.Send(new GetAllModelTypeQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(GetModelTypeResponseResult(result)));
        }

        private IEnumerable<ModelTypeResponseDTO> GetModelTypeResponseResult(IEnumerable<ApplicationModelTypeResponseDTO> result)
        { throw new NotImplementedException("Please implement like below");// return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)));
        }
        [ProducesResponseType(typeof(IEnumerable<ModelTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelType.GetById, Name = DocumentVersionManagerAPIEndPoints.ModelType.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");var result = Guid.TryParse(NameOrGuid, out Guid guid); if (result){return (await _sender.Send(new GetModelTypeByGuidQuery(new ApplicationModelTypeRequestByGuidDTO(guid)), cancellationToken)).Match<IActionResult>(Left: errors => new OkObjectResult(errors),Right: result => new OkObjectResult(new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelTypeResponse(result.Models)
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelType.Get, Name = DocumentVersionManagerAPIEndPoints.ModelType.Get)]
        public async Task<IActionResult> Get(ModelTypeCreateDTO request, CancellationToken cancellationToken)
        {
    }
}