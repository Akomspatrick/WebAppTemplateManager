using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.CQRS.DocumentBasePath.Commands;
using DocumentVersionManager.Application.CQRS.DocumentBasePath.Queries;
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
    public  class DocumentBasePathsController  : TheBaseController<DocumentBasePathsController>
    {

        public DocumentBasePathsController(ILogger<DocumentBasePathsController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<DocumentBasePathResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.Get, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllDocumentBasePathQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(DocumentBasePathResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.GetById, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                (_sender.Send(new GetDocumentBasePathByGuidQuery(new DocumentBasePathGetRequestByGuidDTO(guid)), cancellationToken)).ToActionResult404()
                :
                (_sender.Send(new GetDocumentBasePathByIdQuery(new DocumentBasePathGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToActionResult404();
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] DocumentBasePathGetRequestDTO request, CancellationToken cancellationToken)
                => ( _sender.Send(new GetDocumentBasePathQuery(request), cancellationToken)) .ToActionResult404();

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.Create, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.Create)]
        public Task<IActionResult> Create(DocumentBasePathCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateDocumentBasePathCommand(request), cancellationToken)).ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.DocumentBasePath.Create}", request);

        [HttpPut(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.Update, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.Update)]
        public Task<IActionResult> Update(DocumentBasePathUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateDocumentBasePathCommand(request), cancellationToken)) .ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.DocumentBasePath.Create}", request);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.Delete, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            =>_sender.Send(new DeleteDocumentBasePathCommand(new DocumentBasePathDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}