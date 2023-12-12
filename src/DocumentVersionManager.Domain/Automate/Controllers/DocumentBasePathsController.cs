using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.DocumentBasePath.Commands;
using DocumentVersionManager.Application.CQRS.DocumentBasePath.Queries;
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
    public  class DocumentBasePathsController  : DVBaseController<DocumentBasePathsController>
    {
        public DocumentBasePathsController(ILogger<DocumentBasePathsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.Create, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.Create)]
        public async Task<IActionResult> Create(DocumentBasePathCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentBasePathCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateModelType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.DocumentBasePath.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateDocumentBasePath(ApplicationDocumentBasePathCreateDTO createdDto, CancellationToken cancellationToken)
        => await _sender.Send(new CreateDocumentBasePathCommand(createdDto), cancellationToken);
    }
}