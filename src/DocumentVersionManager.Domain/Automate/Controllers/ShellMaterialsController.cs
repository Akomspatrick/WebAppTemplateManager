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
    public  class ShellMaterialsController  : TheBaseController<ShellMaterialsController>
    {
        public ShellMaterialsController(ILogger<ShellMaterialsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.ShellMaterial.Create, Name = DocumentVersionManagerAPIEndPoints.ShellMaterial.Create)]
        public async Task<IActionResult> Create(ShellMaterialCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationShellMaterialCreateRequestDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateShellMaterial(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new BadRequestObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ShellMaterial.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateShellMaterial(ApplicationShellMaterialCreateRequestDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateShellMaterialCommand(createType), cancellationToken);

        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.ShellMaterial.Delete, Name = DocumentVersionManagerAPIEndPoints.ShellMaterial.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
        var result = new ShellMaterialDeleteRequestDTO(request);
        var guid = new ApplicationShellMaterialDeleteRequestDTO(result);
        return guid.EnsureInputIsNotEmpty("Input Cannot be null")
            .Bind<Either<GeneralFailure, int>>(guid => DeleteShellMaterial(guid, cancellationToken).Result)
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }

        private async Task<Either<GeneralFailure, int>> DeleteShellMaterial(ApplicationShellMaterialDeleteRequestDTO dto, CancellationToken cancellationToken)
        =>  await _sender.Send(new DeleteShellMaterialCommand(dto), cancellationToken);
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.ShellMaterial.Update, Name = DocumentVersionManagerAPIEndPoints.ShellMaterial.Update)]
        public async Task<IActionResult> Update(ShellMaterialUpdateRequestDTO request,, CancellationToken cancellationToken)
        {
            var dto = new ApplicationShellMaterialUpdateRequestDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateShellMaterial(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new     BadRequestObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ShellMaterial.Create}/{dto.}", dto)));

         }

        private async Task<Either<GeneralFailure, int>> UpdateShellMaterial(ApplicationShellMaterialUpdateRequestDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateShellMaterialCommand(updateType), cancellationToken);
        [ProducesResponseType(typeof(IEnumerable<ShellMaterialResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ShellMaterial.Get, Name = DocumentVersionManagerAPIEndPoints.ShellMaterial.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
             return (await _sender.Send<Either<GeneralFailure, IEnumerable<ApplicationShellMaterialResponseDTO>>>(new GetAllShellMaterialQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(GetShellMaterialResponseResult(result)));
        }

        private IEnumerable<ShellMaterialResponseDTO> GetShellMaterialResponseResult(IEnumerable<ApplicationShellMaterialResponseDTO> result)
        { throw new NotImplementedException("Please implement like below");// return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)));
        }
        [ProducesResponseType(typeof(ShellMaterialResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ShellMaterial.GetById, Name = DocumentVersionManagerAPIEndPoints.ShellMaterial.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");
            var result = Guid.TryParse(NameOrGuid, out Guid guid);
            if (result)
            {
                var ShellMaterialRequestByIdDTO = new ShellMaterialGetRequestByGuidDTO(guid);
                return (await _sender.Send(new GetShellMaterialByGuidQuery(new ApplicationShellMaterialGetRequestByGuidDTO(ShellMaterialRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationShellMaterialResponseDTO_To_ShellMaterialResponseDTO(result)));
            }
            else
            {
                var ShellMaterialRequestByIdDTO = new ShellMaterialGetRequestByIdDTO(NameOrGuid);
                return (await _sender.Send<Either<GeneralFailure, ApplicationShellMaterialResponseDTO>>(new GetShellMaterialByIdQuery(new ApplicationShellMaterialGetRequestByIdDTO(ShellMaterialRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationShellMaterialResponseDTO_To_ShellMaterialResponseDTO(result)));
            }
        }
        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ShellMaterial.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.ShellMaterial.GetByJSONBody)]
        public async Task<IActionResult> GetByJSONBody([FromBody] ShellMaterialGetRequestDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _sender.Send(new GetShellMaterialQuery(new ApplicationShellMaterialGetRequestDTO(request)), cancellationToken))
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(MapApplicationShellMaterialResponseDTO_To_ShellMaterialResponseDTO(result)));
         }
    }
}