using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using DocumentVersionManager.Application.CQRS.ModelType.Queries;
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
    public  class ModelTypesController  : DVBaseController<ModelTypesController>
    {
        public ModelTypesController(ILogger<ModelTypesController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.ModelType.Create, Name = DocumentVersionManagerAPIEndPoints.ModelType.Create)]
        public async Task<IActionResult> Create(ModelTypeCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelTypeCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateModelType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ModelType.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateModelType(ApplicationModelTypeCreateDTO createdDto, CancellationToken cancellationToken)
        => await _sender.Send(new CreateModelTypeCommand(createdDto), cancellationToken);
    }
}