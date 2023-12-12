using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.ShellMaterial.Commands;
using DocumentVersionManager.Application.CQRS.ShellMaterial.Queries;
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
    public  class ShellMaterialsController  : DVBaseController<ShellMaterialsController>
    {
        public ShellMaterialsController(ILogger<ShellMaterialsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.ShellMaterial.Create, Name = DocumentVersionManagerAPIEndPoints.ShellMaterial.Create)]
        public async Task<IActionResult> Create(ShellMaterialCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationShellMaterialCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateModelType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ShellMaterial.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateShellMaterial(ApplicationShellMaterialCreateDTO createdDto, CancellationToken cancellationToken)
        => await _sender.Send(new CreateShellMaterialCommand(createdDto), cancellationToken);
    }
}