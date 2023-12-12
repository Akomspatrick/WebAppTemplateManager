using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.DocumentDocumentType.Commands;
using DocumentVersionManager.Application.CQRS.DocumentDocumentType.Queries;
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
    public  class DocumentDocumentTypesController  : DVBaseController<DocumentDocumentTypesController>
    {
        public DocumentDocumentTypesController(ILogger<DocumentDocumentTypesController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Create, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Create)]
        public async Task<IActionResult> Create(DocumentDocumentTypeCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentDocumentTypeCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateModelType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateDocumentDocumentType(ApplicationDocumentDocumentTypeCreateDTO createdDto, CancellationToken cancellationToken)
        => await _sender.Send(new CreateDocumentDocumentTypeCommand(createdDto), cancellationToken);
    }
}