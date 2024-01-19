using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentDocumentType.Handlers
{
    public  class GetDocumentDocumentTypeByGuidQueryHandler  :  IRequestHandler<GetDocumentDocumentTypeByGuidQuery, Either<GeneralFailure, ApplicationDocumentDocumentTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetDocumentDocumentTypeByGuidQueryHandler> _logger;
        public GetDocumentDocumentTypeByGuidQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetDocumentDocumentTypeByGuidQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationDocumentDocumentTypeResponseDTO>> Handle(GetDocumentDocumentTypeByGuidQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}