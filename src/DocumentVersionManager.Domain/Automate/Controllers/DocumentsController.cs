using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.Document.Commands;
using DocumentVersionManager.Application.CQRS.Document.Queries;
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
    public  class DocumentsController  : DVBaseController<DocumentsController>
    {
        public DocumentsController(ILogger<DocumentsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.Document.Create, Name = DocumentVersionManagerAPIEndPoints.Document.Create)]
        public async Task<IActionResult> Create(DocumentCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateDocument(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Document.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateDocument(ApplicationDocumentCreateDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateDocumentCommand(createType), cancellationToken);
        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.Document.Delete, Name = DocumentVersionManagerAPIEndPoints.Document.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            return (await _sender.Send(new DeleteDocumentCommand(new ApplicationDocumentDeleteDTO(guid)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.Document.Update, Name = DocumentVersionManagerAPIEndPoints.Document.Update)]
        public async Task<IActionResult> Update(DocumentUpdateDTO request,, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentUpdateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelType(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new OkObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Document.Create}/{dto.}", dto)));
        }
         }

        private async Task<Either<GeneralFailure, int>> UpdateDocument(ApplicationDocumentUpdateDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateDocumentCommand(updateType), cancellationToken);
        [ProducesResponseType(typeof(IEnumerable<DocumentResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Document.Get, Name = DocumentVersionManagerAPIEndPoints.Document.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
            return (await _sender.Send(new GetAllDocumentQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(GetDocumentResponseResult(result)));
        }

        private IEnumerable<DocumentResponseDTO> GetDocumentResponseResult(IEnumerable<ApplicationDocumentResponseDTO> result)
        { throw new NotImplementedException("Please implement like below");// return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)));
        }
        [ProducesResponseType(typeof(IEnumerable<DocumentResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Document.GetById, Name = DocumentVersionManagerAPIEndPoints.Document.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");var result = Guid.TryParse(NameOrGuid, out Guid guid); if (result){return (await _sender.Send(new GetModelTypeByGuidQuery(new ApplicationModelTypeRequestByGuidDTO(guid)), cancellationToken)).Match<IActionResult>(Left: errors => new OkObjectResult(errors),Right: result => new OkObjectResult(new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelTypeResponse(result.Models)
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Document.Get, Name = DocumentVersionManagerAPIEndPoints.Document.Get)]
        public async Task<IActionResult> Get(DocumentCreateDTO request, CancellationToken cancellationToken)
        {
    }
}