using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
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
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
             return (await _sender.Send<Either<GeneralFailure, IEnumerable<ApplicationModelTypeGroupResponseDTO>>>(new GetAllModelTypeGroupQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(GetModelTypeGroupResponseResult(result)));
        }

        private IEnumerable<ModelTypeGroupResponseDTO> GetModelTypeGroupResponseResult(IEnumerable<ApplicationModelTypeGroupResponseDTO> result)
        
        => throw new NotImplementedException("Please implement like below");
        //=> result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertModelTypeGroupResponse(x.Models)));
        

        private ICollection<ModelResponseDTO> CovertModelTypeResponse(ICollection<ApplicationModelResponseDTO> models)
        => throw new NotImplementedException("Please implement like below");
        //=> models.Select(x => new ModelResponseDTO(x.ModelId, x.ModelName, x.ModelTypesName)).ToList();

        [ProducesResponseType(typeof(ModelTypeGroupResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelTypeGroup.GetById, Name = DocumentVersionManagerAPIEndPoints.ModelTypeGroup.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");
            var result = Guid.TryParse(NameOrGuid, out Guid guid);
            if (result)
            {
                var ModelTypeGroupRequestByIdDTO = new ModelTypeGroupGetRequestByGuidDTO(guid);
                return (await _sender.Send(new GetModelTypeGroupByGuidQuery(new ApplicationModelTypeGroupGetRequestByGuidDTO(ModelTypeGroupRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationModelTypeGroupResponseDTO_To_ModelTypeGroupResponseDTO(result)));
            }
            else
            {
                var ModelTypeGroupRequestByIdDTO = new ModelTypeGroupGetRequestByIdDTO(NameOrGuid);
                return (await _sender.Send<Either<GeneralFailure, ApplicationModelTypeGroupResponseDTO>>(new GetModelTypeGroupByIdQuery(new ApplicationModelTypeGroupGetRequestByIdDTO(ModelTypeGroupRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationModelTypeGroupResponseDTO_To_ModelTypeGroupResponseDTO(result)));
            }
        }

        private ModelTypeGroupResponseDTO MapApplicationModelTypeGroupResponseDTO_To_ModelTypeGroupResponseDTO(ApplicationModelTypeGroupResponseDTO result)
        => throw new NotImplementedException("Please implement like below");
        // => new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelResponse(result.Models));

         private ICollection<ModelResponseDTO> CovertToModelResponse(ICollection<ApplicationModelResponseDTO> models)
        => throw new NotImplementedException("Please implement like below");
        // => models.Select(x => new ModelResponseDTO(x.ModelId, x.ModelName, x.ModelTypesName)).ToList();

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelTypeGroup.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.ModelTypeGroup.GetByJSONBody)]
        public async Task<IActionResult> GetByJSONBody([FromBody] ModelTypeGroupGetRequestDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _sender.Send(new GetModelTypeGroupQuery(new ApplicationModelTypeGroupGetRequestDTO(request)), cancellationToken))
            .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                Right: result => new OkObjectResult(MapApplicationModelTypeGroupResponseDTO_To_ModelTypeGroupResponseDTO(result)));
        }

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.ModelTypeGroup.Create, Name = DocumentVersionManagerAPIEndPoints.ModelTypeGroup.Create)]
        public async Task<IActionResult> Create(ModelTypeGroupCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelTypeGroupCreateRequestDTO(request);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateModelTypeGroup(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new BadRequestObjectResult(errors2),
                    Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ModelTypeGroup.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateModelTypeGroup(ApplicationModelTypeGroupCreateRequestDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateModelTypeGroupCommand(createType), cancellationToken);


        [HttpPut(template: DocumentVersionManagerAPIEndPoints.ModelTypeGroup.Update, Name = DocumentVersionManagerAPIEndPoints.ModelTypeGroup.Update)]
        public async Task<IActionResult> Update(ModelTypeGroupUpdateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelTypeGroupUpdateRequestDTO(request);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelTypeGroup(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new     BadRequestObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ModelTypeGroup.Create}/{dto}", dto)));

         }

        private async Task<Either<GeneralFailure, int>> UpdateModelTypeGroup(ApplicationModelTypeGroupUpdateRequestDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateModelTypeGroupCommand(updateType), cancellationToken);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.ModelTypeGroup.Delete, Name = DocumentVersionManagerAPIEndPoints.ModelTypeGroup.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
        {
        var result = new ModelTypeGroupDeleteRequestDTO(request);
        var guid = new ApplicationModelTypeGroupDeleteRequestDTO(result);
        return guid.EnsureInputIsNotEmpty("Input Cannot be null")
            .Bind<Either<GeneralFailure, int>>(guid => DeleteModelTypeGroup(guid, cancellationToken).Result)
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }

        private async Task<Either<GeneralFailure, int>> DeleteModelTypeGroup(ApplicationModelTypeGroupDeleteRequestDTO dto, CancellationToken cancellationToken)
        =>  await _sender.Send(new DeleteModelTypeGroupCommand(dto), cancellationToken);

    }
}