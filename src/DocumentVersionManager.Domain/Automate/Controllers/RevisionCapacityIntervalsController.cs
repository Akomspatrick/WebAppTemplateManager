using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.RevisionCapacityInterval.Commands;
using DocumentVersionManager.Application.CQRS.RevisionCapacityInterval.Queries;
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
    public  class RevisionCapacityIntervalsController  : DVBaseController<RevisionCapacityIntervalsController>
    {
        public RevisionCapacityIntervalsController(ILogger<RevisionCapacityIntervalsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.RevisionCapacityInterval.Create, Name = DocumentVersionManagerAPIEndPoints.RevisionCapacityInterval.Create)]
        public async Task<IActionResult> Create(RevisionCapacityIntervalCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationRevisionCapacityIntervalCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateModelType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.RevisionCapacityInterval.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateRevisionCapacityInterval(ApplicationRevisionCapacityIntervalCreateDTO createdDto, CancellationToken cancellationToken)
        => await _sender.Send(new CreateRevisionCapacityIntervalCommand(createdDto), cancellationToken);
    }
}