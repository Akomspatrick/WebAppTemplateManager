using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacityDocument.Handlers
{
    public  class GetCapacityDocumentByIdQueryHandler  :  IRequestHandler<GetCapacityDocumentByIdQuery, Either<GeneralFailure, ApplicationCapacityDocumentResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetCapacityDocumentByIdQueryHandler> _logger;
        public GetCapacityDocumentByIdQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetCapacityDocumentByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationCapacityDocumentResponseDTO>> Handle(GetCapacityDocumentByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}