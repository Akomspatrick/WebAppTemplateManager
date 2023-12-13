using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.TestFlowType.Commands;
using DocumentVersionManager.Application.CQRS.TestFlowType.Queries;
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
    public  class TestFlowTypesController  : TheBaseController<TestFlowTypesController>
    {
        public TestFlowTypesController(ILogger<TestFlowTypesController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.TestFlowType.Create, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.Create)]
        public async Task<IActionResult> Create(TestFlowTypeCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationTestFlowTypeCreateRequestDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateTestFlowType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new BadRequestObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.TestFlowType.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateTestFlowType(ApplicationTestFlowTypeCreateRequestDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateTestFlowTypeCommand(createType), cancellationToken);

        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.TestFlowType.Delete, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
        var result = new TestFlowTypeDeleteRequestDTO(request);
        var guid = new ApplicationTestFlowTypeDeleteRequestDTO(result);
        return guid.EnsureInputIsNotEmpty("Input Cannot be null")
            .Bind<Either<GeneralFailure, int>>(guid => DeleteTestFlowType(guid, cancellationToken).Result)
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }

        private async Task<Either<GeneralFailure, int>> DeleteTestFlowType(ApplicationTestFlowTypeDeleteRequestDTO dto, CancellationToken cancellationToken)
        =>  await _sender.Send(new DeleteTestFlowTypeCommand(dto), cancellationToken);
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.TestFlowType.Update, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.Update)]
        public async Task<IActionResult> Update(TestFlowTypeUpdateRequestDTO request,, CancellationToken cancellationToken)
        {
            var dto = new ApplicationTestFlowTypeUpdateRequestDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateTestFlowType(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new     BadRequestObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.TestFlowType.Create}/{dto.}", dto)));

         }

        private async Task<Either<GeneralFailure, int>> UpdateTestFlowType(ApplicationTestFlowTypeUpdateRequestDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateTestFlowTypeCommand(updateType), cancellationToken);
        [ProducesResponseType(typeof(IEnumerable<TestFlowTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestFlowType.Get, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
             return (await _sender.Send<Either<GeneralFailure, IEnumerable<ApplicationTestFlowTypeResponseDTO>>>(new GetAllTestFlowTypeQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(GetTestFlowTypeResponseResult(result)));
        }

        private IEnumerable<TestFlowTypeResponseDTO> GetTestFlowTypeResponseResult(IEnumerable<ApplicationTestFlowTypeResponseDTO> result)
        { throw new NotImplementedException("Please implement like below");// return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)));
        }
        [ProducesResponseType(typeof(TestFlowTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestFlowType.GetById, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");
            var result = Guid.TryParse(NameOrGuid, out Guid guid);
            if (result)
            {
                var TestFlowTypeRequestByIdDTO = new TestFlowTypeGetRequestByGuidDTO(guid);
                return (await _sender.Send(new GetTestFlowTypeByGuidQuery(new ApplicationTestFlowTypeGetRequestByGuidDTO(TestFlowTypeRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationTestFlowTypeResponseDTO_To_TestFlowTypeResponseDTO(result)));
            }
            else
            {
                var TestFlowTypeRequestByIdDTO = new TestFlowTypeGetRequestByIdDTO(NameOrGuid);
                return (await _sender.Send<Either<GeneralFailure, ApplicationTestFlowTypeResponseDTO>>(new GetTestFlowTypeByIdQuery(new ApplicationTestFlowTypeGetRequestByIdDTO(TestFlowTypeRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationTestFlowTypeResponseDTO_To_TestFlowTypeResponseDTO(result)));
            }
        }
        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestFlowType.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.GetByJSONBody)]
        public async Task<IActionResult> GetByJSONBody([FromBody] TestFlowTypeGetRequestDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _sender.Send(new GetTestFlowTypeQuery(new ApplicationTestFlowTypeGetRequestDTO(request)), cancellationToken))
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(MapApplicationTestFlowTypeResponseDTO_To_TestFlowTypeResponseDTO(result)));
         }
    }
}