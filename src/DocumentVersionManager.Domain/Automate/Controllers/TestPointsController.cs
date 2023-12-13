using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.TestPoint.Commands;
using DocumentVersionManager.Application.CQRS.TestPoint.Queries;
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
    public  class TestPointsController  : DVBaseController<TestPointsController>
    {
        public TestPointsController(ILogger<TestPointsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.TestPoint.Create, Name = DocumentVersionManagerAPIEndPoints.TestPoint.Create)]
        public async Task<IActionResult> Create(TestPointCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationTestPointCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateTestPoint(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.TestPoint.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateTestPoint(ApplicationTestPointCreateDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateTestPointCommand(createType), cancellationToken);
        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.TestPoint.Delete, Name = DocumentVersionManagerAPIEndPoints.TestPoint.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            return (await _sender.Send(new DeleteTestPointCommand(new ApplicationTestPointDeleteDTO(guid)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.TestPoint.Update, Name = DocumentVersionManagerAPIEndPoints.TestPoint.Update)]
        public async Task<IActionResult> Update(TestPointUpdateDTO request,, CancellationToken cancellationToken)
        {
            var dto = new ApplicationTestPointUpdateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelType(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new OkObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.TestPoint.Create}/{dto.}", dto)));
        }
         }

        private async Task<Either<GeneralFailure, int>> UpdateTestPoint(ApplicationTestPointUpdateDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateTestPointCommand(updateType), cancellationToken);
        [ProducesResponseType(typeof(IEnumerable<TestPointResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestPoint.Get, Name = DocumentVersionManagerAPIEndPoints.TestPoint.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
            return (await _sender.Send(new GetAllTestPointQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(GetTestPointResponseResult(result)));
        }

        private IEnumerable<TestPointResponseDTO> GetTestPointResponseResult(IEnumerable<ApplicationTestPointResponseDTO> result)
        { throw new NotImplementedException("Please implement like below");// return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)));
        }
        [ProducesResponseType(typeof(IEnumerable<TestPointResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestPoint.GetById, Name = DocumentVersionManagerAPIEndPoints.TestPoint.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");var result = Guid.TryParse(NameOrGuid, out Guid guid); if (result){return (await _sender.Send(new GetModelTypeByGuidQuery(new ApplicationModelTypeRequestByGuidDTO(guid)), cancellationToken)).Match<IActionResult>(Left: errors => new OkObjectResult(errors),Right: result => new OkObjectResult(new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelTypeResponse(result.Models)
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestPoint.Get, Name = DocumentVersionManagerAPIEndPoints.TestPoint.Get)]
        public async Task<IActionResult> Get(TestPointCreateDTO request, CancellationToken cancellationToken)
        {
    }
}