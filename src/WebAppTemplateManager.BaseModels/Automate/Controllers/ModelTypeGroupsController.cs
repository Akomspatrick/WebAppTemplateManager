using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.CQRS.ModelTypeGroup.Commands;
using DocumentVersionManager.Application.CQRS.ModelTypeGroup.Queries;
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
    public  class ModelTypeGroupsController  : TheBaseController<ModelTypeGroupsController>
    {

        public ModelTypeGroupsController(ILogger<ModelTypeGroupsController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<ModelTypeGroupResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelTypeGroup.Get, Name = DocumentVersionManagerAPIEndPoints.ModelTypeGroup.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllModelTypeGroupQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(ModelTypeGroupResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelTypeGroup.GetById, Name = DocumentVersionManagerAPIEndPoints.ModelTypeGroup.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                (_sender.Send(new GetModelTypeGroupByGuidQuery(new ModelTypeGroupGetRequestByGuidDTO(guid)), cancellationToken)).ToActionResult404()
                :
                (_sender.Send(new GetModelTypeGroupByIdQuery(new ModelTypeGroupGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToActionResult404();
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelTypeGroup.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.ModelTypeGroup.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] ModelTypeGroupGetRequestDTO request, CancellationToken cancellationToken)
                => ( _sender.Send(new GetModelTypeGroupQuery(request), cancellationToken)) .ToActionResult404();

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.ModelTypeGroup.Create, Name = DocumentVersionManagerAPIEndPoints.ModelTypeGroup.Create)]
        public Task<IActionResult> Create(ModelTypeGroupCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateModelTypeGroupCommand(request), cancellationToken)).ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.ModelTypeGroup.Create}", request);

        [HttpPut(template: DocumentVersionManagerAPIEndPoints.ModelTypeGroup.Update, Name = DocumentVersionManagerAPIEndPoints.ModelTypeGroup.Update)]
        public Task<IActionResult> Update(ModelTypeGroupUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateModelTypeGroupCommand(request), cancellationToken)) .ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.ModelTypeGroup.Create}", request);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.ModelTypeGroup.Delete, Name = DocumentVersionManagerAPIEndPoints.ModelTypeGroup.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            =>_sender.Send(new DeleteModelTypeGroupCommand(new ModelTypeGroupDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}