
using DocumentVersionManager.Api.Extensions;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using DocumentVersionManager.Application.CQRS.ModelType.Queries;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DocumentVersionManager.Api.Controllers.v1
{
    public class ModelTypesController : TheBaseController<ModelTypesController>
    {
        public ModelTypesController(ILogger<ModelTypesController> logger, ISender sender) : base(logger, sender) { }


        [ProducesResponseType(typeof(IEnumerable<ModelTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelType.Get, Name = DocumentVersionManagerAPIEndPoints.ModelType.Get)]
        public  Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllModelTypeQuery(), cToken).ToActionResult();


        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelType.GetById, Name = DocumentVersionManagerAPIEndPoints.ModelType.GetById)]
        public  Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                 (_sender.Send(new GetModelTypeByGuidQuery(new ModelTypeGetRequestByGuidDTO(guid)), cancellationToken)).ToActionResult404()
                :
                 (_sender.Send(new GetModelTypeByIdQuery(new ModelTypeGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToActionResult404();     
        }


        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelType.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.ModelType.GetByJSONBody)]
        public  Task<IActionResult> GetByJSONBody([FromBody] ModelTypeGetRequestDTO request, CancellationToken cancellationToken)
            => ( _sender.Send(new GetModelTypeQuery(request), cancellationToken)) .ToActionResult404();
       
        
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.ModelType.Create, Name = DocumentVersionManagerAPIEndPoints.ModelType.Create)]
        public  Task<IActionResult> Create(ModelTypeCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateModelTypeCommand(request), cancellationToken)).ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.ModelType.Create}", request);
  
        
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.ModelType.Update, Name = DocumentVersionManagerAPIEndPoints.ModelType.Update)]
        public  Task<IActionResult> Update(ModelTypeUpdateRequestDTO request, CancellationToken cancellationToken)
                => (_sender.Send(new UpdateModelTypeCommand(request), cancellationToken)) .ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.ModelType.Create}", request);
                 
   
        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.ModelType.Delete, Name = DocumentVersionManagerAPIEndPoints.ModelType.Delete)]
        public  Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            => _sender.Send(new DeleteModelTypeCommand(new ModelTypeDeleteRequestDTO(request)), cancellationToken).ToActionResult();
    }
}