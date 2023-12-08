using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.CQRS.DocumentType.Commands;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DocumentVersionManager.Api.Controllers.v1
{

    [ApiController]
    [Route("[controller]")]
    public class DocumentTypeController : ControllerBase
    {
        private readonly ILogger<DocumentTypeController> _logger;
        //private readonly IMediator _sender;
        private readonly ISender _sender;

        public DocumentTypeController(ILogger<DocumentTypeController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpPost(Name = "PostEitherDocumentType")]
        public async Task<IActionResult> Post(DocumentTypeDTO request, CancellationToken cancellationToken)
        {

            return request.EnsureInputIsNotNull("Input Cannot be null")//.EnsureInputIsNotEmpty("Input Cannot be empty")
            .Bind<Either<GeneralFailure, int>>(request => AddDocumentType(request, cancellationToken).Result)
        .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                              Right: result => result.Match<IActionResult>(
                                                  Left: errors2 => new OkObjectResult(errors2),
                                                  Right: result2 => new OkObjectResult(result2)
                                                                           )
                                       );

        }

        private async Task<Either<GeneralFailure, int>> AddDocumentType(DocumentTypeDTO request, CancellationToken cancellationToken)
            => await _sender.Send(new CreateDocumentTypeCommand(new ApplicationDocumentTypeRequestDTO(request.DocumentTypeName)), cancellationToken);

    }
}

