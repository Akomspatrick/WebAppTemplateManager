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
    public  class TestFlowTypesController  : DVBaseController<TestFlowTypesController>
    {
        public TestFlowTypesController(ILogger<TestFlowTypesController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.TestFlowType.Create, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.Create)]
        public async Task<IActionResult> Create(TestFlowTypeCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationTestFlowTypeCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateTestFlowType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.TestFlowType.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateTestFlowType(ApplicationTestFlowTypeCreateDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateTestFlowTypeCommand(createType), cancellationToken);
        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.TestFlowType.Delete, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            return (await _sender.Send(new DeleteTestFlowTypeCommand(new ApplicationTestFlowTypeDeleteDTO(guid)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.TestFlowType.Update, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.Update)]
        public async Task<IActionResult> Update(TestFlowTypeUpdateDTO request,, CancellationToken cancellationToken)
        {
            var dto = new ApplicationTestFlowTypeUpdateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelType(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new OkObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.TestFlowType.Create}/{dto.}", dto)));
        }
         }

        private async Task<Either<GeneralFailure, int>> UpdateTestFlowType(ApplicationTestFlowTypeUpdateDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateTestFlowTypeCommand(updateType), cancellationToken);
        [ProducesResponseType(typeof(IEnumerable<TestFlowTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestFlowType.Get, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
            return (await _sender.Send(new GetAllTestFlowTypeQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(GetTestFlowTypeResponseResult(result)));
        }

        private IEnumerable<TestFlowTypeResponseDTO> GetTestFlowTypeResponseResult(IEnumerable<ApplicationTestFlowTypeResponseDTO> result)
        { throw new NotImplementedException("Please implement like below");// return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)));
        }
        [ProducesResponseType(typeof(IEnumerable<TestFlowTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestFlowType.GetById, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");var result = Guid.TryParse(NameOrGuid, out Guid guid); if (result){return (await _sender.Send(new GetModelTypeByGuidQuery(new ApplicationModelTypeRequestByGuidDTO(guid)), cancellationToken)).Match<IActionResult>(Left: errors => new OkObjectResult(errors),Right: result => new OkObjectResult(new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelTypeResponse(result.Models)
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestFlowType.Get, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.Get)]
        public async Task<IActionResult> Get(TestFlowTypeCreateDTO request, CancellationToken cancellationToken)
        {
    }
}