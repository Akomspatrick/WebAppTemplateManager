using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.CQRS.DocumentDocumentType.Commands;
using DocumentVersionManager.Application.CQRS.DocumentDocumentType.Queries;
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
    public  class DocumentDocumentTypesController  : TheBaseController<DocumentDocumentTypesController>
    {

        public DocumentDocumentTypesController(ILogger<DocumentDocumentTypesController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<DocumentDocumentTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Get, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllDocumentDocumentTypeQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(DocumentDocumentTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.GetById, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                (_sender.Send(new GetDocumentDocumentTypeByGuidQuery(new DocumentDocumentTypeGetRequestByGuidDTO(guid)), cancellationToken)).ToActionResult404()
                :
                (_sender.Send(new GetDocumentDocumentTypeByIdQuery(new DocumentDocumentTypeGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToActionResult404();
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] DocumentDocumentTypeGetRequestDTO request, CancellationToken cancellationToken)
                => ( _sender.Send(new GetDocumentDocumentTypeQuery(request), cancellationToken)) .ToActionResult404();

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Create, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Create)]
        public Task<IActionResult> Create(DocumentDocumentTypeCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateDocumentDocumentTypeCommand(request), cancellationToken)).ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Create}", request);

        [HttpPut(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Update, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Update)]
        public Task<IActionResult> Update(DocumentDocumentTypeUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateDocumentDocumentTypeCommand(request), cancellationToken)) .ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Create}", request);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Delete, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            =>_sender.Send(new DeleteDocumentDocumentTypeCommand(new DocumentDocumentTypeDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}