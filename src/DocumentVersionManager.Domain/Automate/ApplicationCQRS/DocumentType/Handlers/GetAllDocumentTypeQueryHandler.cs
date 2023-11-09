using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentType.Handlers
{
    public  class GetAllDocumentTypeQueryHandler  :  IRequestHandler<GetAllDocumentTypeQuery, Either<GeneralFailures, IEnumerable<ApplicationDocumentTypeResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllDocumentTypeQueryHandler> _logger;
        public GetAllDocumentTypeQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllDocumentTypeQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, IEnumerable<ApplicationDocumentTypeResponseDTO>>> Handle(GetAllDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}