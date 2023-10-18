using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.CQRS.DocumentType.Commands;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DocumentVersionManager.Api.Controllers.V1
{

    [ApiController]
    [Route("[controller]")]
    public class DocumentTypeController : ControllerBase
    {
        private readonly ILogger<DocumentTypeController> _logger;
        //private readonly IMediator _mediator;
        private readonly ISender _mediator;

        public DocumentTypeController(ILogger<DocumentTypeController> logger, ISender mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(Name = "PostEitherDocumentType")]
        public async Task<IActionResult> Post(DocumentTypeDTO request, CancellationToken cancellationToken)
        {

            return request.EnsureInputIsNotNull("Input Cannot be null")//.EnsureInputIsNotEmpty("Input Cannot be empty")
            .Bind<Either<GeneralFailures, int>>(request => AddDocumentType(request, cancellationToken).Result)
        .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                              Right: result => result.Match<IActionResult>(
                                                  Left: errors2 => new OkObjectResult(ModelFailuresExtensions.GetEnumDescription(errors2)),
                                                  Right: result2 => new OkObjectResult(result2)
                                                                           )
                                       );

        }

        private async Task<Either<GeneralFailures, int>> AddDocumentType(DocumentTypeDTO request, CancellationToken cancellationToken)
            => await _mediator.Send(new CreateDocumentTypeCommand(new ApplicationDocumentTypeRequestDTO(request.DocumentTypeName)), cancellationToken);

    }
}

