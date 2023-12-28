using AutoMapper;
using DocumentVersionManager.Api.Extensions;
using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using DocumentVersionManager.Application.CQRS.ModelType.Queries;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Infrastructure.Maps;
using LanguageExt;
using LanguageExt.Pipes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
namespace DocumentVersionManager.Api.Controllers.v1
{
    public class ModelTypesController : TheBaseController<ModelTypesController>
    {
        public ModelTypesController(ILogger<ModelTypesController> logger, ISender sender, IMapper mapper) : base(logger, sender, mapper) { }


        [ProducesResponseType(typeof(IEnumerable<ModelTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelType.Get, Name = DocumentVersionManagerAPIEndPoints.ModelType.Get)]
        public  Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllModelTypeQuery(), cToken).ToActionResult();


        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelType.GetById, Name = DocumentVersionManagerAPIEndPoints.ModelType.GetById)]
        public  Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
            return Guid.TryParse(NameOrGuid, out Guid guid)  ?
                 (_sender.Send(new GetModelTypeByGuidQuery(new ApplicationModelTypeGetRequestByGuidDTO(new ModelTypeGetRequestByGuidDTO(guid))), cancellationToken))
                .ToActionResult404(_mapper, typeof(ApplicationModelTypeResponseDTO), typeof(ModelTypeResponseDTO))
                :
                 (_sender.Send(new GetModelTypeByIdQuery(new ApplicationModelTypeGetRequestByIdDTO(new ModelTypeGetRequestByIdDTO(NameOrGuid))), cancellationToken))
                    .ToActionResult404(_mapper, typeof(ApplicationModelTypeResponseDTO), typeof(ModelTypeResponseDTO)); 
        }

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelType.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.ModelType.GetByJSONBody)]
        public  Task<IActionResult> GetByJSONBody([FromBody] ModelTypeGetRequestDTO request, CancellationToken cancellationToken)
            => ( _sender.Send(new GetModelTypeQuery(new ApplicationModelTypeGetRequestDTO(request)), cancellationToken))
                .ToActionResult404(_mapper, typeof(ApplicationModelTypeResponseDTO), typeof(ModelTypeResponseDTO));

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.ModelType.Create, Name = DocumentVersionManagerAPIEndPoints.ModelType.Create)]
        public  Task<IActionResult> Create(ModelTypeCreateRequestDTO request, CancellationToken cancellationToken)
             => (_sender.Send(new CreateModelTypeCommand(new ApplicationModelTypeCreateRequestDTO(request)), cancellationToken))
              .ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.ModelType.Create}", new ApplicationModelTypeCreateRequestDTO(request));
        
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.ModelType.Update, Name = DocumentVersionManagerAPIEndPoints.ModelType.Update)]
        public  Task<IActionResult> Update(ModelTypeUpdateRequestDTO request, CancellationToken cancellationToken)
                => (_sender.Send(new UpdateModelTypeCommand(new ApplicationModelTypeUpdateRequestDTO(request)), cancellationToken))
                  .ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.ModelType.Create}", new ApplicationModelTypeUpdateRequestDTO(request));
   
        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.ModelType.Delete, Name = DocumentVersionManagerAPIEndPoints.ModelType.Delete)]
        public  Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
            => _sender.Send(new DeleteModelTypeCommand(new ApplicationModelTypeDeleteRequestDTO(new ModelTypeDeleteRequestDTO(request))), cancellationToken).ToActionResult();
    }
}