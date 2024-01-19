using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentBasePath.Handlers
{
    public  class GetDocumentBasePathQueryHandler  :  IRequestHandler<GetDocumentBasePathQuery, Either<GeneralFailure, ApplicationDocumentBasePathResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetDocumentBasePathQueryHandler> _logger;
        public GetDocumentBasePathQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetDocumentBasePathQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationDocumentBasePathResponseDTO>> Handle(GetDocumentBasePathQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}