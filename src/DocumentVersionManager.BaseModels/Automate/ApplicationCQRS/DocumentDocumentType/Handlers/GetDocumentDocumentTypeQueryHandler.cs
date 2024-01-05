using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentDocumentType.Handlers
{
    public  class GetDocumentDocumentTypeQueryHandler  :  IRequestHandler<GetDocumentDocumentTypeQuery, Either<GeneralFailure, ApplicationDocumentDocumentTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetDocumentDocumentTypeQueryHandler> _logger;
        public GetDocumentDocumentTypeQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetDocumentDocumentTypeQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationDocumentDocumentTypeResponseDTO>> Handle(GetDocumentDocumentTypeQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}