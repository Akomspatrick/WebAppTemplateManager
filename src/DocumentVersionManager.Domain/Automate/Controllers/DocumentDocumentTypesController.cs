using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.DocumentDocumentType.Commands;
using DocumentVersionManager.Application.CQRS.DocumentDocumentType.Queries;
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
    public  class DocumentDocumentTypesController  : DVBaseController<DocumentDocumentTypesController>
    {
        public DocumentDocumentTypesController(ILogger<DocumentDocumentTypesController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Create, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Create)]
        public async Task<IActionResult> Create(DocumentDocumentTypeCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentDocumentTypeCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateDocumentDocumentType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateDocumentDocumentType(ApplicationDocumentDocumentTypeCreateDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateDocumentDocumentTypeCommand(createType), cancellationToken);
        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Delete, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            return (await _sender.Send(new DeleteDocumentDocumentTypeCommand(new ApplicationDocumentDocumentTypeDeleteDTO(guid)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Update, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Update)]
        public async Task<IActionResult> Update(DocumentDocumentTypeUpdateDTO request,, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentDocumentTypeUpdateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelType(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new OkObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Create}/{dto.}", dto)));
        }
         }

        private async Task<Either<GeneralFailure, int>> UpdateDocumentDocumentType(ApplicationDocumentDocumentTypeUpdateDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateDocumentDocumentTypeCommand(updateType), cancellationToken);
        [ProducesResponseType(typeof(IEnumerable<DocumentDocumentTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Get, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
            return (await _sender.Send(new GetAllDocumentDocumentTypeQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(GetDocumentDocumentTypeResponseResult(result)));
        }

        private IEnumerable<DocumentDocumentTypeResponseDTO> GetDocumentDocumentTypeResponseResult(IEnumerable<ApplicationDocumentDocumentTypeResponseDTO> result)
        { throw new NotImplementedException("Please implement like below");// return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)));
        }
        [ProducesResponseType(typeof(IEnumerable<DocumentDocumentTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.GetById, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");var result = Guid.TryParse(NameOrGuid, out Guid guid); if (result){return (await _sender.Send(new GetModelTypeByGuidQuery(new ApplicationModelTypeRequestByGuidDTO(guid)), cancellationToken)).Match<IActionResult>(Left: errors => new OkObjectResult(errors),Right: result => new OkObjectResult(new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelTypeResponse(result.Models)
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Get, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Get)]
        public async Task<IActionResult> Get(DocumentDocumentTypeCreateDTO request, CancellationToken cancellationToken)
        {
    }
}