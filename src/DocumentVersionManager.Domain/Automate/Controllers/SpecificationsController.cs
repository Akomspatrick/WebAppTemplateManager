using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.Specification.Commands;
using DocumentVersionManager.Application.CQRS.Specification.Queries;
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
    public  class SpecificationsController  : DVBaseController<SpecificationsController>
    {
        public SpecificationsController(ILogger<SpecificationsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.Specification.Create, Name = DocumentVersionManagerAPIEndPoints.Specification.Create)]
        public async Task<IActionResult> Create(SpecificationCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationSpecificationCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateSpecification(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Specification.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateSpecification(ApplicationSpecificationCreateDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateSpecificationCommand(createType), cancellationToken);
        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.Specification.Delete, Name = DocumentVersionManagerAPIEndPoints.Specification.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            return (await _sender.Send(new DeleteSpecificationCommand(new ApplicationSpecificationDeleteDTO(guid)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.Specification.Update, Name = DocumentVersionManagerAPIEndPoints.Specification.Update)]
        public async Task<IActionResult> Update(SpecificationUpdateDTO request,, CancellationToken cancellationToken)
        {
            var dto = new ApplicationSpecificationUpdateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelType(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new OkObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Specification.Create}/{dto.}", dto)));
        }
         }

        private async Task<Either<GeneralFailure, int>> UpdateSpecification(ApplicationSpecificationUpdateDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateSpecificationCommand(updateType), cancellationToken);
        [ProducesResponseType(typeof(IEnumerable<SpecificationResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Specification.Get, Name = DocumentVersionManagerAPIEndPoints.Specification.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
            return (await _sender.Send(new GetAllSpecificationQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(GetSpecificationResponseResult(result)));
        }

        private IEnumerable<SpecificationResponseDTO> GetSpecificationResponseResult(IEnumerable<ApplicationSpecificationResponseDTO> result)
        { throw new NotImplementedException("Please implement like below");// return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)));
        }
        [ProducesResponseType(typeof(IEnumerable<SpecificationResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Specification.GetById, Name = DocumentVersionManagerAPIEndPoints.Specification.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");var result = Guid.TryParse(NameOrGuid, out Guid guid); if (result){return (await _sender.Send(new GetModelTypeByGuidQuery(new ApplicationModelTypeRequestByGuidDTO(guid)), cancellationToken)).Match<IActionResult>(Left: errors => new OkObjectResult(errors),Right: result => new OkObjectResult(new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelTypeResponse(result.Models)
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Specification.Get, Name = DocumentVersionManagerAPIEndPoints.Specification.Get)]
        public async Task<IActionResult> Get(SpecificationCreateDTO request, CancellationToken cancellationToken)
        {
    }
}