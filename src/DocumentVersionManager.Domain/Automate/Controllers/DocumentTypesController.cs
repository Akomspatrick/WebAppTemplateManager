using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.DocumentType.Commands;
using DocumentVersionManager.Application.CQRS.DocumentType.Queries;
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
    public  class DocumentTypesController  : DVBaseController<DocumentTypesController>
    {
        public DocumentTypesController(ILogger<DocumentTypesController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.DocumentType.Create, Name = DocumentVersionManagerAPIEndPoints.DocumentType.Create)]
        public async Task<IActionResult> Create(DocumentTypeCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentTypeCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateDocumentType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.DocumentType.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateDocumentType(ApplicationDocumentTypeCreateDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateDocumentTypeCommand(createType), cancellationToken);
        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.DocumentType.Delete, Name = DocumentVersionManagerAPIEndPoints.DocumentType.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            return (await _sender.Send(new DeleteDocumentTypeCommand(new ApplicationDocumentTypeDeleteDTO(guid)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.DocumentType.Update, Name = DocumentVersionManagerAPIEndPoints.DocumentType.Update)]
        public async Task<IActionResult> Update(DocumentTypeUpdateDTO request,, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentTypeUpdateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelType(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new OkObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.DocumentType.Create}/{dto.}", dto)));
        }
         }

        private async Task<Either<GeneralFailure, int>> UpdateDocumentType(ApplicationDocumentTypeUpdateDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateDocumentTypeCommand(updateType), cancellationToken);
        [ProducesResponseType(typeof(IEnumerable<DocumentTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentType.Get, Name = DocumentVersionManagerAPIEndPoints.DocumentType.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
            return (await _sender.Send(new GetAllDocumentTypeQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(GetDocumentTypeResponseResult(result)));
        }

        private IEnumerable<DocumentTypeResponseDTO> GetDocumentTypeResponseResult(IEnumerable<ApplicationDocumentTypeResponseDTO> result)
        { throw new NotImplementedException("Please implement like below");// return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)));
        }
        [ProducesResponseType(typeof(IEnumerable<DocumentTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentType.GetById, Name = DocumentVersionManagerAPIEndPoints.DocumentType.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");var result = Guid.TryParse(NameOrGuid, out Guid guid); if (result){return (await _sender.Send(new GetModelTypeByGuidQuery(new ApplicationModelTypeRequestByGuidDTO(guid)), cancellationToken)).Match<IActionResult>(Left: errors => new OkObjectResult(errors),Right: result => new OkObjectResult(new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelTypeResponse(result.Models)
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentType.Get, Name = DocumentVersionManagerAPIEndPoints.DocumentType.Get)]
        public async Task<IActionResult> Get(DocumentTypeCreateDTO request, CancellationToken cancellationToken)
        {
    }
}