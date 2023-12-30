using DocumentVersionManager.Api.Extensions;
using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using DocumentVersionManager.Application.CQRS.Model.Queries;
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
    public class ModelsController : TheBaseController<ModelsController>
    {

        public ModelsController(ILogger<ModelsController> logger, ISender sender) : base(logger, sender) { }

        [ProducesResponseType(typeof(IEnumerable<ModelResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Model.Get, Name = DocumentVersionManagerAPIEndPoints.Model.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllModelQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(ModelResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Model.GetById, Name = DocumentVersionManagerAPIEndPoints.Model.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid) ?
                (_sender.Send(new GetModelByGuidQuery(new ModelGetRequestByGuidDTO(guid)), cancellationToken)).ToActionResult404()
                :
                (_sender.Send(new GetModelByIdQuery(new ModelGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToActionResult404();
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Model.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.Model.GetByJSONBody)]

        public Task<IActionResult> GetByJSONBody([FromBody] ModelGetRequestDTO request, CancellationToken cancellationToken)
                => (_sender.Send(new GetModelQuery(request), cancellationToken)).ToActionResult404();

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.Model.Create, Name = DocumentVersionManagerAPIEndPoints.Model.Create)]
        public Task<IActionResult> Create(ModelCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateModelCommand(request), cancellationToken)).ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.Model.Create}", request);


        [HttpPut(template: DocumentVersionManagerAPIEndPoints.Model.Update, Name = DocumentVersionManagerAPIEndPoints.Model.Update)]
        public Task<IActionResult> Update(ModelUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateModelCommand(request), cancellationToken)).ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.Model.Create}", request);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.Model.Delete, Name = DocumentVersionManagerAPIEndPoints.Model.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            => _sender.Send(new DeleteModelCommand(new ModelDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}