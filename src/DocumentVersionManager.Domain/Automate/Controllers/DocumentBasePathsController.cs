using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.DocumentBasePath.Commands;
using DocumentVersionManager.Application.CQRS.DocumentBasePath.Queries;
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
    public  class DocumentBasePathsController  : DVBaseController<DocumentBasePathsController>
    {
        public DocumentBasePathsController(ILogger<DocumentBasePathsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.Create, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.Create)]
        public async Task<IActionResult> Create(DocumentBasePathCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentBasePathCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateDocumentBasePath(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.DocumentBasePath.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateDocumentBasePath(ApplicationDocumentBasePathCreateDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateDocumentBasePathCommand(createType), cancellationToken);
        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.Delete, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            return (await _sender.Send(new DeleteDocumentBasePathCommand(new ApplicationDocumentBasePathDeleteDTO(guid)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.Update, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.Update)]
        public async Task<IActionResult> Update(DocumentBasePathUpdateDTO request,, CancellationToken cancellationToken)
        {
            var dto = new ApplicationDocumentBasePathUpdateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelType(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new OkObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.DocumentBasePath.Create}/{dto.}", dto)));
        }
         }

        private async Task<Either<GeneralFailure, int>> UpdateDocumentBasePath(ApplicationDocumentBasePathUpdateDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateDocumentBasePathCommand(updateType), cancellationToken);
        [ProducesResponseType(typeof(IEnumerable<DocumentBasePathResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.Get, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
            return (await _sender.Send(new GetAllDocumentBasePathQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(GetDocumentBasePathResponseResult(result)));
        }

        private IEnumerable<DocumentBasePathResponseDTO> GetDocumentBasePathResponseResult(IEnumerable<ApplicationDocumentBasePathResponseDTO> result)
        { throw new NotImplementedException("Please implement like below");// return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)));
        }
        [ProducesResponseType(typeof(IEnumerable<DocumentBasePathResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.GetById, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");var result = Guid.TryParse(NameOrGuid, out Guid guid); if (result){return (await _sender.Send(new GetModelTypeByGuidQuery(new ApplicationModelTypeRequestByGuidDTO(guid)), cancellationToken)).Match<IActionResult>(Left: errors => new OkObjectResult(errors),Right: result => new OkObjectResult(new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelTypeResponse(result.Models)
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.DocumentBasePath.Get, Name = DocumentVersionManagerAPIEndPoints.DocumentBasePath.Get)]
        public async Task<IActionResult> Get(DocumentBasePathCreateDTO request, CancellationToken cancellationToken)
        {
    }
}