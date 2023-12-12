using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.CapacityTestPoint.Commands;
using DocumentVersionManager.Application.CQRS.CapacityTestPoint.Queries;
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
    public  class CapacityTestPointsController  : DVBaseController<CapacityTestPointsController>
    {
        public CapacityTestPointsController(ILogger<CapacityTestPointsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.CapacityTestPoint.Create, Name = DocumentVersionManagerAPIEndPoints.CapacityTestPoint.Create)]
        public async Task<IActionResult> Create(CapacityTestPointCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationCapacityTestPointCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateCapacityTestPoint(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.CapacityTestPoint.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateCapacityTestPoint(ApplicationCapacityTestPointCreateDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateCapacityTestPointCommand(createType), cancellationToken);
        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.CapacityTestPoint.Delete, Name = DocumentVersionManagerAPIEndPoints.CapacityTestPoint.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            return (await _sender.Send(new DeleteCapacityTestPointCommand(new ApplicationCapacityTestPointDeleteDTO(guid)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.CapacityTestPoint.Update, Name = DocumentVersionManagerAPIEndPoints.CapacityTestPoint.Update)]
        public async Task<IActionResult> Update(CapacityTestPointUpdateDTO request,, CancellationToken cancellationToken)
        {
            var dto = new ApplicationCapacityTestPointUpdateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelType(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new OkObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.CapacityTestPoint.Create}/{dto.}", dto)));
        }
         }

        private async Task<Either<GeneralFailure, int>> UpdateCapacityTestPoint(ApplicationCapacityTestPointUpdateDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateCapacityTestPointCommand(updateType), cancellationToken);
        [ProducesResponseType(typeof(IEnumerable<CapacityTestPointResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.CapacityTestPoint.Get, Name = DocumentVersionManagerAPIEndPoints.CapacityTestPoint.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
            return (await _sender.Send(new GetAllCapacityTestPointQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(GetCapacityTestPointResponseResult(result)));
        }

        private IEnumerable<CapacityTestPointResponseDTO> GetCapacityTestPointResponseResult(IEnumerable<ApplicationCapacityTestPointResponseDTO> result)
        { throw new NotImplementedException("Please implement like below");// return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)));
        }
        [ProducesResponseType(typeof(IEnumerable<CapacityTestPointResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.CapacityTestPoint.GetById, Name = DocumentVersionManagerAPIEndPoints.CapacityTestPoint.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");var result = Guid.TryParse(NameOrGuid, out Guid guid); if (result){return (await _sender.Send(new GetModelTypeByGuidQuery(new ApplicationModelTypeRequestByGuidDTO(guid)), cancellationToken)).Match<IActionResult>(Left: errors => new OkObjectResult(errors),Right: result => new OkObjectResult(new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelTypeResponse(result.Models)
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.CapacityTestPoint.Get, Name = DocumentVersionManagerAPIEndPoints.CapacityTestPoint.Get)]
        public async Task<IActionResult> Get(CapacityTestPointCreateDTO request, CancellationToken cancellationToken)
        {
    }
}