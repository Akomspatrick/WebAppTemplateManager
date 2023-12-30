using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.CQRS.TestFlowType.Commands;
using DocumentVersionManager.Application.CQRS.TestFlowType.Queries;
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
    public  class TestFlowTypesController  : TheBaseController<TestFlowTypesController>
    {

        public TestFlowTypesController(ILogger<TestFlowTypesController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<TestFlowTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestFlowType.Get, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllTestFlowTypeQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(TestFlowTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestFlowType.GetById, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                (_sender.Send(new GetTestFlowTypeByGuidQuery(new TestFlowTypeGetRequestByGuidDTO(guid)), cancellationToken)).ToActionResult404()
                :
                (_sender.Send(new GetTestFlowTypeByIdQuery(new TestFlowTypeGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToActionResult404();
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestFlowType.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] TestFlowTypeGetRequestDTO request, CancellationToken cancellationToken)
                => ( _sender.Send(new GetTestFlowTypeQuery(request), cancellationToken)) .ToActionResult404();

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.TestFlowType.Create, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.Create)]
        public Task<IActionResult> Create(TestFlowTypeCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateTestFlowTypeCommand(request), cancellationToken)).ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.TestFlowType.Create}", request);

        [HttpPut(template: DocumentVersionManagerAPIEndPoints.TestFlowType.Update, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.Update)]
        public Task<IActionResult> Update(TestFlowTypeUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateTestFlowTypeCommand(request), cancellationToken)) .ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.TestFlowType.Create}", request);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.TestFlowType.Delete, Name = DocumentVersionManagerAPIEndPoints.TestFlowType.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            =>_sender.Send(new DeleteTestFlowTypeCommand(new TestFlowTypeDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}