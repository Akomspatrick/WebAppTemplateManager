using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.CQRS.DocumentType.Commands;
using DocumentVersionManager.Application.CQRS.DocumentType.Queries;
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
    public  class DocumentTypesController  : TheBaseController<DocumentTypesController>
    {

        public DocumentTypesController(ILogger<DocumentTypesController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<DocumentTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentType.Get, Name = DocumentVersionManagerAPIEndPoints.DocumentType.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllDocumentTypeQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(DocumentTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentType.GetById, Name = DocumentVersionManagerAPIEndPoints.DocumentType.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                (_sender.Send(new GetDocumentTypeByGuidQuery(new DocumentTypeGetRequestByGuidDTO(guid)), cancellationToken)).ToActionResult404()
                :
                (_sender.Send(new GetDocumentTypeByIdQuery(new DocumentTypeGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToActionResult404();
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentType.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.DocumentType.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] DocumentTypeGetRequestDTO request, CancellationToken cancellationToken)
                => ( _sender.Send(new GetDocumentTypeQuery(request), cancellationToken)) .ToActionResult404();

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.DocumentType.Create, Name = DocumentVersionManagerAPIEndPoints.DocumentType.Create)]
        public Task<IActionResult> Create(DocumentTypeCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateDocumentTypeCommand(request), cancellationToken)).ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.DocumentType.Create}", request);

        [HttpPut(template: DocumentVersionManagerAPIEndPoints.DocumentType.Update, Name = DocumentVersionManagerAPIEndPoints.DocumentType.Update)]
        public Task<IActionResult> Update(DocumentTypeUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateDocumentTypeCommand(request), cancellationToken)) .ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.DocumentType.Create}", request);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.DocumentType.Delete, Name = DocumentVersionManagerAPIEndPoints.DocumentType.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            =>_sender.Send(new DeleteDocumentTypeCommand(new DocumentTypeDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}