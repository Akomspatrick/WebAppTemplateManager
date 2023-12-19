using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentType.Handlers
{
    public  class GetDocumentTypeByGuidQueryHandler  :  IRequestHandler<GetDocumentTypeByGuidQuery, Either<GeneralFailure, ApplicationDocumentTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetDocumentTypeByGuidQueryHandler> _logger;
        public GetDocumentTypeByGuidQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetDocumentTypeByGuidQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationDocumentTypeResponseDTO>> Handle(GetDocumentTypeByGuidQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}