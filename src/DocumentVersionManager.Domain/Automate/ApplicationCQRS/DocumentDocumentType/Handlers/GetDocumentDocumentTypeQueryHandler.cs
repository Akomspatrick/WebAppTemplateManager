using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentDocumentType.Handlers
{
    public  class GetDocumentDocumentTypeQueryHandler  :  IRequestHandler<GetDocumentDocumentTypeQuery, Either<GeneralFailures, ApplicationDocumentDocumentTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetDocumentDocumentTypeQueryHandler> _logger;
        public GetDocumentDocumentTypeQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetDocumentDocumentTypeQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, ApplicationDocumentDocumentTypeResponseDTO>> Handle(GetDocumentDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}