using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacityDocument.Handlers
{
    public  class GetCapacityDocumentQueryHandler  :  IRequestHandler<GetCapacityDocumentQuery, Either<GeneralFailure, ApplicationCapacityDocumentResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetCapacityDocumentQueryHandler> _logger;
        public GetCapacityDocumentQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetCapacityDocumentQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationCapacityDocumentResponseDTO>> Handle(GetCapacityDocumentQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}