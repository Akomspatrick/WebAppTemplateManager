using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.ModelVersion.Commands;
using DocumentVersionManager.Application.CQRS.ModelVersion.Queries;
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
    public  class ModelVersionsController  : DVBaseController<ModelVersionsController>
    {
        public ModelVersionsController(ILogger<ModelVersionsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.ModelVersion.Create, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.Create)]
        public async Task<IActionResult> Create(ModelVersionCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelVersionCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateModelVersion(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ModelVersion.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateModelVersion(ApplicationModelVersionCreateDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateModelVersionCommand(createType), cancellationToken);
        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.ModelVersion.Delete, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            return (await _sender.Send(new DeleteModelVersionCommand(new ApplicationModelVersionDeleteDTO(guid)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.ModelVersion.Update, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.Update)]
        public async Task<IActionResult> Update(ModelVersionUpdateDTO request,, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelVersionUpdateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelType(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new OkObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ModelVersion.Create}/{dto.}", dto)));
        }
         }

        private async Task<Either<GeneralFailure, int>> UpdateModelVersion(ApplicationModelVersionUpdateDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateModelVersionCommand(updateType), cancellationToken);
        [ProducesResponseType(typeof(IEnumerable<ModelVersionResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelVersion.Get, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
            return (await _sender.Send(new GetAllModelVersionQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(GetModelVersionResponseResult(result)));
        }

        private IEnumerable<ModelVersionResponseDTO> GetModelVersionResponseResult(IEnumerable<ApplicationModelVersionResponseDTO> result)
        { throw new NotImplementedException("Please implement like below");// return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)));
        }
        [ProducesResponseType(typeof(IEnumerable<ModelVersionResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelVersion.GetById, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");var result = Guid.TryParse(NameOrGuid, out Guid guid); if (result){return (await _sender.Send(new GetModelTypeByGuidQuery(new ApplicationModelTypeRequestByGuidDTO(guid)), cancellationToken)).Match<IActionResult>(Left: errors => new OkObjectResult(errors),Right: result => new OkObjectResult(new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelTypeResponse(result.Models)
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelVersion.Get, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.Get)]
        public async Task<IActionResult> Get(ModelVersionCreateDTO request, CancellationToken cancellationToken)
        {
    }
}