
using WebAppTemplateManager.Api.Extensions;
using WebAppTemplateManager.Application.CQRS.ModelType.Commands;
using WebAppTemplateManager.Application.CQRS.ModelType.Queries;
using WebAppTemplateManager.Contracts.RequestDTO;
using WebAppTemplateManager.Contracts.ResponseDTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAppTemplateManager.Api.Controllers.v1
{
    public class ModelTypesController : TheBaseController<ModelTypesController>
    {
        public ModelTypesController(ILogger<ModelTypesController> logger, ISender sender) : base(logger, sender) { }


        [ProducesResponseType(typeof(IEnumerable<ModelTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: WebAppTemplateManagerAPIEndPoints.ModelType.Get, Name = WebAppTemplateManagerAPIEndPoints.ModelType.Get)]
        public  Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllModelTypeQuery(), cToken).ToActionResult();


        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: WebAppTemplateManagerAPIEndPoints.ModelType.GetById, Name = WebAppTemplateManagerAPIEndPoints.ModelType.GetById)]
        public  Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                 (_sender.Send(new GetModelTypeByGuidQuery(new ModelTypeGetRequestByGuidDTO(guid)), cancellationToken)).ToActionResult404()
                :
                 (_sender.Send(new GetModelTypeByIdQuery(new ModelTypeGetRequestByIdDTO(NameOrGuid)), cancellationToken)).ToActionResult404();     
        }


        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: WebAppTemplateManagerAPIEndPoints.ModelType.GetByJSONBody, Name = WebAppTemplateManagerAPIEndPoints.ModelType.GetByJSONBody)]
        public  Task<IActionResult> GetByJSONBody([FromBody] ModelTypeGetRequestDTO request, CancellationToken cancellationToken)
            => ( _sender.Send(new GetModelTypeQuery(request), cancellationToken)) .ToActionResult404();
       
        
        [HttpPost(template: WebAppTemplateManagerAPIEndPoints.ModelType.Create, Name = WebAppTemplateManagerAPIEndPoints.ModelType.Create)]
        public  Task<IActionResult> Create(ModelTypeCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateModelTypeCommand(request), cancellationToken)).ToActionResultCreated($"{WebAppTemplateManagerAPIEndPoints.ModelType.Create}", request);
  
        
        [HttpPut(template: WebAppTemplateManagerAPIEndPoints.ModelType.Update, Name = WebAppTemplateManagerAPIEndPoints.ModelType.Update)]
        public  Task<IActionResult> Update(ModelTypeUpdateRequestDTO request, CancellationToken cancellationToken)
                => (_sender.Send(new UpdateModelTypeCommand(request), cancellationToken)) .ToActionResultCreated($"{WebAppTemplateManagerAPIEndPoints.ModelType.Create}", request);
                 
   
        [HttpDelete(template: WebAppTemplateManagerAPIEndPoints.ModelType.Delete, Name = WebAppTemplateManagerAPIEndPoints.ModelType.Delete)]
        public  Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            => _sender.Send(new DeleteModelTypeCommand(new ModelTypeDeleteRequestDTO(request)), cancellationToken).ToActionResult();
    }
}