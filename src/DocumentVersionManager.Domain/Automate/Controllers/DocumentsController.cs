using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.Document.Commands;
using DocumentVersionManager.Application.CQRS.Document.Queries;
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
    public  class DocumentsController  : DVBaseController<DocumentsController>
    {
        public DocumentsController(ILogger<DocumentsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.Document.Create, Name = DocumentVersionManagerAPIEndPoints.Document.Create)]
        public async Task<IActionResult> Create(DocumentCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateModelType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Document.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateDocument(ApplicationDocumentCreateDTO createdDto, CancellationToken cancellationToken)
        => await _sender.Send(new CreateDocumentCommand(createdDto), cancellationToken);
    }
}