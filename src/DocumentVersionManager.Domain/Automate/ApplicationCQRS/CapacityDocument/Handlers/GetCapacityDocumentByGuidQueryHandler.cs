using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacityDocument.Handlers
{
    public  class GetCapacityDocumentByGuidQueryHandler  :  IRequestHandler<GetCapacityDocumentByGuidQuery, Either<GeneralFailure, ApplicationCapacityDocumentResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetCapacityDocumentByGuidQueryHandler> _logger;
        public GetCapacityDocumentByGuidQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetCapacityDocumentByGuidQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationCapacityDocumentResponseDTO>> Handle(GetCapacityDocumentByGuidQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}