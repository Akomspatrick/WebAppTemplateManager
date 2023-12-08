using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentBasePath.Handlers
{
    public  class GetAllDocumentBasePathQueryHandler  :  IRequestHandler<GetAllDocumentBasePathQuery, Either<GeneralFailure, IEnumerable<ApplicationDocumentBasePathResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllDocumentBasePathQueryHandler> _logger;
        public GetAllDocumentBasePathQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllDocumentBasePathQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, IEnumerable<ApplicationDocumentBasePathResponseDTO>>> Handle(GetAllDocumentBasePathQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}