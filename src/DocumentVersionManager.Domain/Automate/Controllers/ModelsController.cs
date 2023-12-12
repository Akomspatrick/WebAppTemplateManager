using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using DocumentVersionManager.Application.CQRS.Model.Queries;
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
    public  class ModelsController  : DVBaseController<ModelsController>
    {
        public ModelsController(ILogger<ModelsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.Model.Create, Name = DocumentVersionManagerAPIEndPoints.Model.Create)]
        public async Task<IActionResult> Create(ModelCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateModel(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Model.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateModel(ApplicationModelCreateDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateModelCommand(createType), cancellationToken);
        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.Model.Delete, Name = DocumentVersionManagerAPIEndPoints.Model.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            return (await _sender.Send(new DeleteModelCommand(new ApplicationModelDeleteDTO(guid)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.Model.Update, Name = DocumentVersionManagerAPIEndPoints.Model.Update)]
        public async Task<IActionResult> Update(ModelUpdateDTO request,, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelUpdateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelType(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new OkObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Model.Create}/{dto.}", dto)));
        }
         }

        private async Task<Either<GeneralFailure, int>> UpdateModel(ApplicationModelUpdateDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateModelCommand(updateType), cancellationToken);
        [ProducesResponseType(typeof(IEnumerable<ModelResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Model.Get, Name = DocumentVersionManagerAPIEndPoints.Model.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
            return (await _sender.Send(new GetAllModelQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(GetModelResponseResult(result)));
        }

        private IEnumerable<ModelResponseDTO> GetModelResponseResult(IEnumerable<ApplicationModelResponseDTO> result)
        { throw new NotImplementedException("Please implement like below");// return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)));
        }
        [ProducesResponseType(typeof(IEnumerable<ModelResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Model.GetById, Name = DocumentVersionManagerAPIEndPoints.Model.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");var result = Guid.TryParse(NameOrGuid, out Guid guid); if (result){return (await _sender.Send(new GetModelTypeByGuidQuery(new ApplicationModelTypeRequestByGuidDTO(guid)), cancellationToken)).Match<IActionResult>(Left: errors => new OkObjectResult(errors),Right: result => new OkObjectResult(new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelTypeResponse(result.Models)
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Model.Get, Name = DocumentVersionManagerAPIEndPoints.Model.Get)]
        public async Task<IActionResult> Get(ModelCreateDTO request, CancellationToken cancellationToken)
        {
    }
}