using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.DocumentDocumentType.Commands;
using DocumentVersionManager.Application.CQRS.DocumentDocumentType.Queries;
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
    public  class DocumentDocumentTypesController  : TheBaseController<DocumentDocumentTypesController>
    {

        public DocumentDocumentTypesController(ILogger<DocumentDocumentTypesController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<DocumentDocumentTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Get, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
             return (await _sender.Send<Either<GeneralFailure, IEnumerable<ApplicationDocumentDocumentTypeResponseDTO>>>(new GetAllDocumentDocumentTypeQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(GetDocumentDocumentTypeResponseResult(result)));
        }

        private IEnumerable<DocumentDocumentTypeResponseDTO> GetDocumentDocumentTypeResponseResult(IEnumerable<ApplicationDocumentDocumentTypeResponseDTO> result)
        
        => throw new NotImplementedException("Please implement like below");//
        => result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertDocumentDocumentTypeResponse(x.Models)));
        

        private ICollection<ModelResponseDTO> CovertModelTypeResponse(ICollection<ApplicationModelResponseDTO> models)
        => throw new NotImplementedException("Please implement like below");
        //=> models.Select(x => new ModelResponseDTO(x.ModelId, x.ModelName, x.ModelTypesName)).ToList();

        [ProducesResponseType(typeof(DocumentDocumentTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.GetById, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");
            var result = Guid.TryParse(NameOrGuid, out Guid guid);
            if (result)
            {
                var DocumentDocumentTypeRequestByIdDTO = new DocumentDocumentTypeGetRequestByGuidDTO(guid);
                return (await _sender.Send(new GetDocumentDocumentTypeByGuidQuery(new ApplicationDocumentDocumentTypeGetRequestByGuidDTO(DocumentDocumentTypeRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationDocumentDocumentTypeResponseDTO_To_DocumentDocumentTypeResponseDTO(result)));
            }
            else
            {
                var DocumentDocumentTypeRequestByIdDTO = new DocumentDocumentTypeGetRequestByIdDTO(NameOrGuid);
                return (await _sender.Send<Either<GeneralFailure, ApplicationDocumentDocumentTypeResponseDTO>>(new GetDocumentDocumentTypeByIdQuery(new ApplicationDocumentDocumentTypeGetRequestByIdDTO(DocumentDocumentTypeRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationDocumentDocumentTypeResponseDTO_To_DocumentDocumentTypeResponseDTO(result)));
            }
        }

        private DocumentDocumentTypeResponseDTO MapApplicationDocumentDocumentTypeResponseDTO_To_DocumentDocumentTypeResponseDTO(ApplicationDocumentDocumentTypeResponseDTO result)
        => throw new NotImplementedException("Please implement like below");
        // => new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelResponse(result.Models));

         private ICollection<ModelResponseDTO> CovertToModelResponse(ICollection<ApplicationModelResponseDTO> models)
        => throw new NotImplementedException("Please implement like below");
        // => models.Select(x => new ModelResponseDTO(x.ModelId, x.ModelName, x.ModelTypesName)).ToList();

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.GetByJSONBody)]
        public async Task<IActionResult> GetByJSONBody([FromBody] DocumentDocumentTypeGetRequestDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _sender.Send(new GetDocumentDocumentTypeQuery(new ApplicationDocumentDocumentTypeGetRequestDTO(request)), cancellationToken))
            .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                Right: result => new OkObjectResult(MapApplicationDocumentDocumentTypeResponseDTO_To_DocumentDocumentTypeResponseDTO(result)));
         }

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Create, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Create)]
        public async Task<IActionResult> Create(DocumentDocumentTypeCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentDocumentTypeCreateRequestDTO(request);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateDocumentDocumentType(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new BadRequestObjectResult(errors2),
                    Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateDocumentDocumentType(ApplicationDocumentDocumentTypeCreateRequestDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateDocumentDocumentTypeCommand(createType), cancellationToken);


        [HttpPut(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Update, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Update)]
        public async Task<IActionResult> Update(DocumentDocumentTypeUpdateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentDocumentTypeUpdateRequestDTO(request);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateDocumentDocumentType(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new     BadRequestObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Create}/{dto}", dto)));

         }

        private async Task<Either<GeneralFailure, int>> UpdateDocumentDocumentType(ApplicationDocumentDocumentTypeUpdateRequestDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateDocumentDocumentTypeCommand(updateType), cancellationToken);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Delete, Name = DocumentVersionManagerAPIEndPoints.DocumentDocumentType.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
        {
        var result = new DocumentDocumentTypeDeleteRequestDTO(request);
        var guid = new ApplicationDocumentDocumentTypeDeleteRequestDTO(result);
        return guid.EnsureInputIsNotEmpty("Input Cannot be null")
            .Bind<Either<GeneralFailure, int>>(guid => DeleteDocumentDocumentType(guid, cancellationToken).Result)
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }

        private async Task<Either<GeneralFailure, int>> DeleteDocumentDocumentType(ApplicationDocumentDocumentTypeDeleteRequestDTO dto, CancellationToken cancellationToken)
        =>  await _sender.Send(new DeleteDocumentDocumentTypeCommand(dto), cancellationToken);

    }
}