using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.CQRS.TestPoint.Commands;
using DocumentVersionManager.Application.CQRS.TestPoint.Queries;
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
    public  class TestPointsController  : TheBaseController<TestPointsController>
    {

        public TestPointsController(ILogger<TestPointsController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<TestPointResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestPoint.Get, Name = DocumentVersionManagerAPIEndPoints.TestPoint.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllTestPointQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(TestPointResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestPoint.GetById, Name = DocumentVersionManagerAPIEndPoints.TestPoint.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                (_sender.Send(new GetTestPointByGuidQuery(new TestPointGetRequestByGuidDTO(guid)), cancellationToken)).ToActionResult404()
                :
                (_sender.Send(new GetTestPointByIdQuery(new TestPointGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToActionResult404();
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.TestPoint.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.TestPoint.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] TestPointGetRequestDTO request, CancellationToken cancellationToken)
                => ( _sender.Send(new GetTestPointQuery(request), cancellationToken)) .ToActionResult404();

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.TestPoint.Create, Name = DocumentVersionManagerAPIEndPoints.TestPoint.Create)]
        public Task<IActionResult> Create(TestPointCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateTestPointCommand(request), cancellationToken)).ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.TestPoint.Create}", request);

        [HttpPut(template: DocumentVersionManagerAPIEndPoints.TestPoint.Update, Name = DocumentVersionManagerAPIEndPoints.TestPoint.Update)]
        public Task<IActionResult> Update(TestPointUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateTestPointCommand(request), cancellationToken)) .ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.TestPoint.Create}", request);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.TestPoint.Delete, Name = DocumentVersionManagerAPIEndPoints.TestPoint.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            =>_sender.Send(new DeleteTestPointCommand(new TestPointDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}