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
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateShellMaterial(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ShellMaterial.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateShellMaterial(ApplicationShellMaterialCreateDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateShellMaterialCommand(createType), cancellationToken);
        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.ShellMaterial.Delete, Name = DocumentVersionManagerAPIEndPoints.ShellMaterial.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            return (await _sender.Send(new DeleteShellMaterialCommand(new ApplicationShellMaterialDeleteDTO(guid)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.ShellMaterial.Update, Name = DocumentVersionManagerAPIEndPoints.ShellMaterial.Update)]
        public async Task<IActionResult> Update(ShellMaterialUpdateDTO request,, CancellationToken cancellationToken)
        {
            var dto = new ApplicationShellMaterialUpdateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelType(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new OkObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ShellMaterial.Create}/{dto.}", dto)));
        }
         }

        private async Task<Either<GeneralFailure, int>> UpdateShellMaterial(ApplicationShellMaterialUpdateDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateShellMaterialCommand(updateType), cancellationToken);
        [ProducesResponseType(typeof(IEnumerable<ShellMaterialResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ShellMaterial.Get, Name = DocumentVersionManagerAPIEndPoints.ShellMaterial.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
            return (await _sender.Send(new GetAllShellMaterialQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(GetShellMaterialResponseResult(result)));
        }

        private IEnumerable<ShellMaterialResponseDTO> GetShellMaterialResponseResult(IEnumerable<ApplicationShellMaterialResponseDTO> result)
        { throw new NotImplementedException("Please implement like below");// return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)));
        }
        [ProducesResponseType(typeof(IEnumerable<ShellMaterialResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ShellMaterial.GetById, Name = DocumentVersionManagerAPIEndPoints.ShellMaterial.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");var result = Guid.TryParse(NameOrGuid, out Guid guid); if (result){return (await _sender.Send(new GetModelTypeByGuidQuery(new ApplicationModelTypeRequestByGuidDTO(guid)), cancellationToken)).Match<IActionResult>(Left: errors => new OkObjectResult(errors),Right: result => new OkObjectResult(new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelTypeResponse(result.Models)
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ShellMaterial.Get, Name = DocumentVersionManagerAPIEndPoints.ShellMaterial.Get)]
        public async Task<IActionResult> Get(ShellMaterialCreateDTO request, CancellationToken cancellationToken)
        {
    }
}