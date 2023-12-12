using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.ModelVersion.Commands;
using DocumentVersionManager.Application.CQRS.ModelVersion.Queries;
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
    public  class ModelVersionsController  : DVBaseController<ModelVersionsController>
    {
        public ModelVersionsController(ILogger<ModelVersionsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.ModelVersion.Create, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.Create)]
        public async Task<IActionResult> Create(ModelVersionCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelVersionCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateModelType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ModelVersion.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateModelVersion(ApplicationModelVersionCreateDTO createdDto, CancellationToken cancellationToken)
        => await _sender.Send(new CreateModelVersionCommand(createdDto), cancellationToken);
    }
}