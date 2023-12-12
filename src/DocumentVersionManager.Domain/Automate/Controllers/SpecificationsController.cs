using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.Specification.Commands;
using DocumentVersionManager.Application.CQRS.Specification.Queries;
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
    public  class SpecificationsController  : DVBaseController<SpecificationsController>
    {
        public SpecificationsController(ILogger<SpecificationsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.Specification.Create, Name = DocumentVersionManagerAPIEndPoints.Specification.Create)]
        public async Task<IActionResult> Create(SpecificationCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationSpecificationCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateModelType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Specification.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateSpecification(ApplicationSpecificationCreateDTO createdDto, CancellationToken cancellationToken)
        => await _sender.Send(new CreateSpecificationCommand(createdDto), cancellationToken);
    }
}