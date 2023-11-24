using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentDocumentType.Handlers
{
    public  class GetAllDocumentDocumentTypeQueryHandler  :  IRequestHandler<GetAllDocumentDocumentTypeQuery, Either<GeneralFailures, IEnumerable<ApplicationDocumentDocumentTypeResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllDocumentDocumentTypeQueryHandler> _logger;
        public GetAllDocumentDocumentTypeQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllDocumentDocumentTypeQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, IEnumerable<ApplicationDocumentDocumentTypeResponseDTO>>> Handle(GetAllDocumentDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}