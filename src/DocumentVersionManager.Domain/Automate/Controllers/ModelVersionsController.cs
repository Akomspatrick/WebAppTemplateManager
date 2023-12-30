using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.CQRS.ModelVersion.Commands;
using DocumentVersionManager.Application.CQRS.ModelVersion.Queries;
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
    public  class ModelVersionsController  : TheBaseController<ModelVersionsController>
    {

        public ModelVersionsController(ILogger<ModelVersionsController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<ModelVersionResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelVersion.Get, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.Get)]
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllModelVersionQuery(), cToken).ToActionResult();

        [ProducesResponseType(typeof(ModelVersionResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelVersion.GetById, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.GetById)]
        public Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                (_sender.Send(new GetModelVersionByGuidQuery(new ModelVersionGetRequestByGuidDTO(guid)), cancellationToken)).ToActionResult404()
                :
                (_sender.Send(new GetModelVersionByIdQuery(new ModelVersionGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToActionResult404();
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelVersion.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.GetByJSONBody)]
        public Task<IActionResult> GetByJSONBody([FromBody] ModelVersionGetRequestDTO request, CancellationToken cancellationToken)
                => ( _sender.Send(new GetModelVersionQuery(request), cancellationToken)) .ToActionResult404();

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.ModelVersion.Create, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.Create)]
        public Task<IActionResult> Create(ModelVersionCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateModelVersionCommand(request), cancellationToken)).ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.ModelVersion.Create}", request);

        [HttpPut(template: DocumentVersionManagerAPIEndPoints.ModelVersion.Update, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.Update)]
        public Task<IActionResult> Update(ModelVersionUpdateRequestDTO request, CancellationToken cancellationToken)
            => (_sender.Send(new UpdateModelVersionCommand(request), cancellationToken)) .ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.ModelVersion.Create}", request);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.ModelVersion.Delete, Name = DocumentVersionManagerAPIEndPoints.ModelVersion.Delete)]
        public Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            =>_sender.Send(new DeleteModelVersionCommand(new ModelVersionDeleteRequestDTO(request)), cancellationToken).ToActionResult();

    }
}