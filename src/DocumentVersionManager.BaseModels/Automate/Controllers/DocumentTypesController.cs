using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.DocumentType.Commands;
using DocumentVersionManager.Application.CQRS.DocumentType.Queries;
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
    public  class DocumentTypesController  : TheBaseController<DocumentTypesController>
    {

        public DocumentTypesController(ILogger<DocumentTypesController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<DocumentTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentType.Get, Name = DocumentVersionManagerAPIEndPoints.DocumentType.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
             return (await _sender.Send<Either<GeneralFailure, IEnumerable<ApplicationDocumentTypeResponseDTO>>>(new GetAllDocumentTypeQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(GetDocumentTypeResponseResult(result)));
        }

        private IEnumerable<DocumentTypeResponseDTO> GetDocumentTypeResponseResult(IEnumerable<ApplicationDocumentTypeResponseDTO> result)
        
        => throw new NotImplementedException("Please implement like below");
        //=> result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertDocumentTypeResponse(x.Models)));
        

        private ICollection<ModelResponseDTO> CovertModelTypeResponse(ICollection<ApplicationModelResponseDTO> models)
        => throw new NotImplementedException("Please implement like below");
        //=> models.Select(x => new ModelResponseDTO(x.ModelId, x.ModelName, x.ModelTypesName)).ToList();

        [ProducesResponseType(typeof(DocumentTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentType.GetById, Name = DocumentVersionManagerAPIEndPoints.DocumentType.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");
            var result = Guid.TryParse(NameOrGuid, out Guid guid);
            if (result)
            {
                var DocumentTypeRequestByIdDTO = new DocumentTypeGetRequestByGuidDTO(guid);
                return (await _sender.Send(new GetDocumentTypeByGuidQuery(new ApplicationDocumentTypeGetRequestByGuidDTO(DocumentTypeRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationDocumentTypeResponseDTO_To_DocumentTypeResponseDTO(result)));
            }
            else
            {
                var DocumentTypeRequestByIdDTO = new DocumentTypeGetRequestByIdDTO(NameOrGuid);
                return (await _sender.Send<Either<GeneralFailure, ApplicationDocumentTypeResponseDTO>>(new GetDocumentTypeByIdQuery(new ApplicationDocumentTypeGetRequestByIdDTO(DocumentTypeRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationDocumentTypeResponseDTO_To_DocumentTypeResponseDTO(result)));
            }
        }

        private DocumentTypeResponseDTO MapApplicationDocumentTypeResponseDTO_To_DocumentTypeResponseDTO(ApplicationDocumentTypeResponseDTO result)
        => throw new NotImplementedException("Please implement like below");
        // => new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelResponse(result.Models));

         private ICollection<ModelResponseDTO> CovertToModelResponse(ICollection<ApplicationModelResponseDTO> models)
        => throw new NotImplementedException("Please implement like below");
        // => models.Select(x => new ModelResponseDTO(x.ModelId, x.ModelName, x.ModelTypesName)).ToList();

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentType.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.DocumentType.GetByJSONBody)]
        public async Task<IActionResult> GetByJSONBody([FromBody] DocumentTypeGetRequestDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _sender.Send(new GetDocumentTypeQuery(new ApplicationDocumentTypeGetRequestDTO(request)), cancellationToken))
            .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                Right: result => new OkObjectResult(MapApplicationDocumentTypeResponseDTO_To_DocumentTypeResponseDTO(result)));
        }

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.DocumentType.Create, Name = DocumentVersionManagerAPIEndPoints.DocumentType.Create)]
        public async Task<IActionResult> Create(DocumentTypeCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentTypeCreateRequestDTO(request);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateDocumentType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new BadRequestObjectResult(errors2),
                    Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.DocumentType.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateDocumentType(ApplicationDocumentTypeCreateRequestDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateDocumentTypeCommand(createType), cancellationToken);


        [HttpPut(template: DocumentVersionManagerAPIEndPoints.DocumentType.Update, Name = DocumentVersionManagerAPIEndPoints.DocumentType.Update)]
        public async Task<IActionResult> Update(DocumentTypeUpdateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentTypeUpdateRequestDTO(request);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateDocumentType(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new     BadRequestObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.DocumentType.Create}/{dto}", dto)));

         }

        private async Task<Either<GeneralFailure, int>> UpdateDocumentType(ApplicationDocumentTypeUpdateRequestDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateDocumentTypeCommand(updateType), cancellationToken);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.DocumentType.Delete, Name = DocumentVersionManagerAPIEndPoints.DocumentType.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
        {
        var result = new DocumentTypeDeleteRequestDTO(request);
        var guid = new ApplicationDocumentTypeDeleteRequestDTO(result);
        return guid.EnsureInputIsNotEmpty("Input Cannot be null")
            .Bind<Either<GeneralFailure, int>>(guid => DeleteDocumentType(guid, cancellationToken).Result)
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }

        private async Task<Either<GeneralFailure, int>> DeleteDocumentType(ApplicationDocumentTypeDeleteRequestDTO dto, CancellationToken cancellationToken)
        =>  await _sender.Send(new DeleteDocumentTypeCommand(dto), cancellationToken);

    }
}