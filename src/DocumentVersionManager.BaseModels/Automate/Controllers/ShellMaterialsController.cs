using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.CQRS.ShellMaterial.Commands;
using DocumentVersionManager.Application.CQRS.ShellMaterial.Queries;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
namespace DocumentVersionManager.Api.Controllers.v1
{
    public  class ShellMaterialsController  : TheBaseController<ShellMaterialsController>
    {

        public ShellMaterialsController(ILogger<ShellMaterialsController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<ShellMaterialResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ShellMaterial.Get, Name = DocumentVersionManagerAPIEndPoints.ShellMaterial.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllShellMaterialQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(ShellMaterialResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ShellMaterial.GetById, Name = DocumentVersionManagerAPIEndPoints.ShellMaterial.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                (_sender.Send(new GetShellMaterialByGuidQuery(new ShellMaterialGetRequestByGuidDTO(guid)), cancellationToken)).ToActionResult404()
                :
                (_sender.Send(new GetShellMaterialByIdQuery(new ShellMaterialGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToActionResult404();
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ShellMaterial.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.ShellMaterial.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] ShellMaterialGetRequestDTO request, CancellationToken cancellationToken)
                => ( _sender.Send(new GetShellMaterialQuery(request), cancellationToken)) .ToActionResult404();

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.ShellMaterial.Create, Name = DocumentVersionManagerAPIEndPoints.ShellMaterial.Create)]
        public Task<IActionResult> Create(ShellMaterialCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateShellMaterialCommand(request), cancellationToken)).ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.ShellMaterial.Create}", request);

        [HttpPut(template: DocumentVersionManagerAPIEndPoints.ShellMaterial.Update, Name = DocumentVersionManagerAPIEndPoints.ShellMaterial.Update)]
        public Task<IActionResult> Update(ShellMaterialUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateShellMaterialCommand(request), cancellationToken)) .ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.ShellMaterial.Create}", request);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.ShellMaterial.Delete, Name = DocumentVersionManagerAPIEndPoints.ShellMaterial.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            =>_sender.Send(new DeleteShellMaterialCommand(new ShellMaterialDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}