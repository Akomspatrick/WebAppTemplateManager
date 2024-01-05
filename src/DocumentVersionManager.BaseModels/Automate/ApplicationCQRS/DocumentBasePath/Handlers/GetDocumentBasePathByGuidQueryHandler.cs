using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentBasePath.Handlers
{
    public  class GetDocumentBasePathByGuidQueryHandler  :  IRequestHandler<GetDocumentBasePathByGuidQuery, Either<GeneralFailure, ApplicationDocumentBasePathResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetDocumentBasePathByGuidQueryHandler> _logger;
        public GetDocumentBasePathByGuidQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetDocumentBasePathByGuidQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationDocumentBasePathResponseDTO>> Handle(GetDocumentBasePathByGuidQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}