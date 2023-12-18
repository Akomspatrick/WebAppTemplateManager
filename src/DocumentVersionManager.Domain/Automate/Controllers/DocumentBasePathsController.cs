using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.DocumentBasePath.Commands;
using DocumentVersionManager.Application.CQRS.DocumentBasePath.Queries;
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
    public  class DocumentBasePathsController  : TheBaseController<DocumentBasePathsController>
    {

        public DocumentBasePathsController(ILogger<DocumentBasePathsController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<DocumentBasePathResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.Get, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
             return (await _sender.Send<Either<GeneralFailure, IEnumerable<ApplicationDocumentBasePathResponseDTO>>>(new GetAllDocumentBasePathQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(GetDocumentBasePathResponseResult(result)));
        }

        private IEnumerable<DocumentBasePathResponseDTO> GetDocumentBasePathResponseResult(IEnumerable<ApplicationDocumentBasePathResponseDTO> result)
        
        => throw new NotImplementedException("Please implement like below");
        //=> result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertDocumentBasePathResponse(x.Models)));
        

        private ICollection<ModelResponseDTO> CovertModelTypeResponse(ICollection<ApplicationModelResponseDTO> models)
        => throw new NotImplementedException("Please implement like below");
        //=> models.Select(x => new ModelResponseDTO(x.ModelId, x.ModelName, x.ModelTypesName)).ToList();

        [ProducesResponseType(typeof(DocumentBasePathResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.GetById, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");
            var result = Guid.TryParse(NameOrGuid, out Guid guid);
            if (result)
            {
                var DocumentBasePathRequestByIdDTO = new DocumentBasePathGetRequestByGuidDTO(guid);
                return (await _sender.Send(new GetDocumentBasePathByGuidQuery(new ApplicationDocumentBasePathGetRequestByGuidDTO(DocumentBasePathRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationDocumentBasePathResponseDTO_To_DocumentBasePathResponseDTO(result)));
            }
            else
            {
                var DocumentBasePathRequestByIdDTO = new DocumentBasePathGetRequestByIdDTO(NameOrGuid);
                return (await _sender.Send<Either<GeneralFailure, ApplicationDocumentBasePathResponseDTO>>(new GetDocumentBasePathByIdQuery(new ApplicationDocumentBasePathGetRequestByIdDTO(DocumentBasePathRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationDocumentBasePathResponseDTO_To_DocumentBasePathResponseDTO(result)));
            }
        }

        private DocumentBasePathResponseDTO MapApplicationDocumentBasePathResponseDTO_To_DocumentBasePathResponseDTO(ApplicationDocumentBasePathResponseDTO result)
        => throw new NotImplementedException("Please implement like below");
        // => new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelResponse(result.Models));

         private ICollection<ModelResponseDTO> CovertToModelResponse(ICollection<ApplicationModelResponseDTO> models)
        => throw new NotImplementedException("Please implement like below");
        // => models.Select(x => new ModelResponseDTO(x.ModelId, x.ModelName, x.ModelTypesName)).ToList();

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.GetByJSONBody)]
        public async Task<IActionResult> GetByJSONBody([FromBody] DocumentBasePathGetRequestDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _sender.Send(new GetDocumentBasePathQuery(new ApplicationDocumentBasePathGetRequestDTO(request)), cancellationToken))
            .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                Right: result => new OkObjectResult(MapApplicationDocumentBasePathResponseDTO_To_DocumentBasePathResponseDTO(result)));
        }

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.Create, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.Create)]
        public async Task<IActionResult> Create(DocumentBasePathCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentBasePathCreateRequestDTO(request);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateDocumentBasePath(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new BadRequestObjectResult(errors2),
                    Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.DocumentBasePath.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateDocumentBasePath(ApplicationDocumentBasePathCreateRequestDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateDocumentBasePathCommand(createType), cancellationToken);


        [HttpPut(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.Update, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.Update)]
        public async Task<IActionResult> Update(DocumentBasePathUpdateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentBasePathUpdateRequestDTO(request);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateDocumentBasePath(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new     BadRequestObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.DocumentBasePath.Create}/{dto}", dto)));

         }

        private async Task<Either<GeneralFailure, int>> UpdateDocumentBasePath(ApplicationDocumentBasePathUpdateRequestDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateDocumentBasePathCommand(updateType), cancellationToken);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.Delete, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
        {
        var result = new DocumentBasePathDeleteRequestDTO(request);
        var guid = new ApplicationDocumentBasePathDeleteRequestDTO(result);
        return guid.EnsureInputIsNotEmpty("Input Cannot be null")
            .Bind<Either<GeneralFailure, int>>(guid => DeleteDocumentBasePath(guid, cancellationToken).Result)
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }

        private async Task<Either<GeneralFailure, int>> DeleteDocumentBasePath(ApplicationDocumentBasePathDeleteRequestDTO dto, CancellationToken cancellationToken)
        =>  await _sender.Send(new DeleteDocumentBasePathCommand(dto), cancellationToken);

    }
}