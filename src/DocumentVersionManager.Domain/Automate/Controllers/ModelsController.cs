using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using DocumentVersionManager.Application.CQRS.Model.Queries;
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
    public  class ModelsController  : DVBaseController<ModelsController>
    {
        public ModelsController(ILogger<ModelsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.Model.Create, Name = DocumentVersionManagerAPIEndPoints.Model.Create)]
        public async Task<IActionResult> Create(ModelCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateModelType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Model.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateModel(ApplicationModelCreateDTO createdDto, CancellationToken cancellationToken)
        => await _sender.Send(new CreateModelCommand(createdDto), cancellationToken);
    }
}