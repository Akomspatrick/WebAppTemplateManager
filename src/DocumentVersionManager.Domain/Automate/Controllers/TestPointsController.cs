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
    public  class TestPointsController  : TheBaseController<TestPointsController>
    {
        public TestPointsController(ILogger<TestPointsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.TestPoint.Create, Name = DocumentVersionManagerAPIEndPoints.TestPoint.Create)]
        public async Task<IActionResult> Create(TestPointCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationTestPointCreateRequestDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateTestPoint(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new BadRequestObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.TestPoint.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateTestPoint(ApplicationTestPointCreateRequestDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateTestPointCommand(createType), cancellationToken);

        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.TestPoint.Delete, Name = DocumentVersionManagerAPIEndPoints.TestPoint.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
        var result = new TestPointDeleteRequestDTO(request);
        var guid = new ApplicationTestPointDeleteRequestDTO(result);
        return guid.EnsureInputIsNotEmpty("Input Cannot be null")
            .Bind<Either<GeneralFailure, int>>(guid => DeleteTestPoint(guid, cancellationToken).Result)
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }

        private async Task<Either<GeneralFailure, int>> DeleteTestPoint(ApplicationTestPointDeleteRequestDTO dto, CancellationToken cancellationToken)
        =>  await _sender.Send(new DeleteTestPointCommand(dto), cancellationToken);
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.TestPoint.Update, Name = DocumentVersionManagerAPIEndPoints.TestPoint.Update)]
        public async Task<IActionResult> Update(TestPointUpdateRequestDTO request,, CancellationToken cancellationToken)
        {
            var dto = new ApplicationTestPointUpdateRequestDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateTestPoint(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new     BadRequestObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.TestPoint.Create}/{dto.}", dto)));

         }

        private async Task<Either<GeneralFailure, int>> UpdateTestPoint(ApplicationTestPointUpdateRequestDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateTestPointCommand(updateType), cancellationToken);
        [ProducesResponseType(typeof(IEnumerable<TestPointResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestPoint.Get, Name = DocumentVersionManagerAPIEndPoints.TestPoint.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
             return (await _sender.Send<Either<GeneralFailure, IEnumerable<ApplicationTestPointResponseDTO>>>(new GetAllTestPointQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(GetTestPointResponseResult(result)));
        }

        private IEnumerable<TestPointResponseDTO> GetTestPointResponseResult(IEnumerable<ApplicationTestPointResponseDTO> result)
        { throw new NotImplementedException("Please implement like below");// return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)));
        }
        [ProducesResponseType(typeof(TestPointResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestPoint.GetById, Name = DocumentVersionManagerAPIEndPoints.TestPoint.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");
            var result = Guid.TryParse(NameOrGuid, out Guid guid);
            if (result)
            {
                var TestPointRequestByIdDTO = new TestPointGetRequestByGuidDTO(guid);
                return (await _sender.Send(new GetTestPointByGuidQuery(new ApplicationTestPointGetRequestByGuidDTO(TestPointRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationTestPointResponseDTO_To_TestPointResponseDTO(result)));
            }
            else
            {
                var TestPointRequestByIdDTO = new TestPointGetRequestByIdDTO(NameOrGuid);
                return (await _sender.Send<Either<GeneralFailure, ApplicationTestPointResponseDTO>>(new GetTestPointByIdQuery(new ApplicationTestPointGetRequestByIdDTO(TestPointRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationTestPointResponseDTO_To_TestPointResponseDTO(result)));
            }
        }
        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestPoint.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.TestPoint.GetByJSONBody)]
        public async Task<IActionResult> GetByJSONBody([FromBody] TestPointGetRequestDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _sender.Send(new GetTestPointQuery(new ApplicationTestPointGetRequestDTO(request)), cancellationToken))
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(MapApplicationTestPointResponseDTO_To_TestPointResponseDTO(result)));
         }
    }
}