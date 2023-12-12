using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.Revision.Commands;
using DocumentVersionManager.Application.CQRS.Revision.Queries;
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
    public  class RevisionsController  : DVBaseController<RevisionsController>
    {
        public RevisionsController(ILogger<RevisionsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.Revision.Create, Name = DocumentVersionManagerAPIEndPoints.Revision.Create)]
        public async Task<IActionResult> Create(RevisionCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationRevisionCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateModelType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Revision.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateRevision(ApplicationRevisionCreateDTO createdDto, CancellationToken cancellationToken)
        => await _sender.Send(new CreateRevisionCommand(createdDto), cancellationToken);
    }
}