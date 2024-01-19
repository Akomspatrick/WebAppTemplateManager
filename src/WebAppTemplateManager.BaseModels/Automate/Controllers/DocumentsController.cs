using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.CQRS.Document.Commands;
using DocumentVersionManager.Application.CQRS.Document.Queries;
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
    public  class DocumentsController  : TheBaseController<DocumentsController>
    {

        public DocumentsController(ILogger<DocumentsController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<DocumentResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Document.Get, Name = DocumentVersionManagerAPIEndPoints.Document.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllDocumentQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(DocumentResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Document.GetById, Name = DocumentVersionManagerAPIEndPoints.Document.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                (_sender.Send(new GetDocumentByGuidQuery(new DocumentGetRequestByGuidDTO(guid)), cancellationToken)).ToActionResult404()
                :
                (_sender.Send(new GetDocumentByIdQuery(new DocumentGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToActionResult404();
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Document.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.Document.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] DocumentGetRequestDTO request, CancellationToken cancellationToken)
                => ( _sender.Send(new GetDocumentQuery(request), cancellationToken)) .ToActionResult404();

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.Document.Create, Name = DocumentVersionManagerAPIEndPoints.Document.Create)]
        public Task<IActionResult> Create(DocumentCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateDocumentCommand(request), cancellationToken)).ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.Document.Create}", request);

        [HttpPut(template: DocumentVersionManagerAPIEndPoints.Document.Update, Name = DocumentVersionManagerAPIEndPoints.Document.Update)]
        public Task<IActionResult> Update(DocumentUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateDocumentCommand(request), cancellationToken)) .ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.Document.Create}", request);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.Document.Delete, Name = DocumentVersionManagerAPIEndPoints.Document.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            =>_sender.Send(new DeleteDocumentCommand(new DocumentDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}