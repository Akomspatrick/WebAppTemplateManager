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
    public  class DocumentsController  : TheBaseController<DocumentsController>
    {
        public DocumentsController(ILogger<DocumentsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.Document.Create, Name = DocumentVersionManagerAPIEndPoints.Document.Create)]
        public async Task<IActionResult> Create(DocumentCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentCreateRequestDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateDocument(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new BadRequestObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Document.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateDocument(ApplicationDocumentCreateRequestDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateDocumentCommand(createType), cancellationToken);

        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.Document.Delete, Name = DocumentVersionManagerAPIEndPoints.Document.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
        var result = new DocumentDeleteRequestDTO(request);
        var guid = new ApplicationDocumentDeleteRequestDTO(result);
        return guid.EnsureInputIsNotEmpty("Input Cannot be null")
            .Bind<Either<GeneralFailure, int>>(guid => DeleteDocument(guid, cancellationToken).Result)
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }

        private async Task<Either<GeneralFailure, int>> DeleteDocument(ApplicationDocumentDeleteRequestDTO dto, CancellationToken cancellationToken)
        =>  await _sender.Send(new DeleteDocumentCommand(dto), cancellationToken);
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.Document.Update, Name = DocumentVersionManagerAPIEndPoints.Document.Update)]
        public async Task<IActionResult> Update(DocumentUpdateRequestDTO request,, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentUpdateRequestDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateDocument(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new     BadRequestObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Document.Create}/{dto.}", dto)));

         }

        private async Task<Either<GeneralFailure, int>> UpdateDocument(ApplicationDocumentUpdateRequestDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateDocumentCommand(updateType), cancellationToken);
        [ProducesResponseType(typeof(IEnumerable<DocumentResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Document.Get, Name = DocumentVersionManagerAPIEndPoints.Document.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
             return (await _sender.Send<Either<GeneralFailure, IEnumerable<ApplicationDocumentResponseDTO>>>(new GetAllDocumentQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(GetDocumentResponseResult(result)));
        }

        private IEnumerable<DocumentResponseDTO> GetDocumentResponseResult(IEnumerable<ApplicationDocumentResponseDTO> result)
        { throw new NotImplementedException("Please implement like below");// return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)));
        }
        [ProducesResponseType(typeof(DocumentResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Document.GetById, Name = DocumentVersionManagerAPIEndPoints.Document.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");
            var result = Guid.TryParse(NameOrGuid, out Guid guid);
            if (result)
            {
                var DocumentRequestByIdDTO = new DocumentGetRequestByGuidDTO(guid);
                return (await _sender.Send(new GetDocumentByGuidQuery(new ApplicationDocumentGetRequestByGuidDTO(DocumentRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationDocumentResponseDTO_To_DocumentResponseDTO(result)));
            }
            else
            {
                var DocumentRequestByIdDTO = new DocumentGetRequestByIdDTO(NameOrGuid);
                return (await _sender.Send<Either<GeneralFailure, ApplicationDocumentResponseDTO>>(new GetDocumentByIdQuery(new ApplicationDocumentGetRequestByIdDTO(DocumentRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationDocumentResponseDTO_To_DocumentResponseDTO(result)));
            }
        }
        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Document.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.Document.GetByJSONBody)]
        public async Task<IActionResult> GetByJSONBody([FromBody] DocumentGetRequestDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _sender.Send(new GetDocumentQuery(new ApplicationDocumentGetRequestDTO(request)), cancellationToken))
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(MapApplicationDocumentResponseDTO_To_DocumentResponseDTO(result)));
         }
    }
}