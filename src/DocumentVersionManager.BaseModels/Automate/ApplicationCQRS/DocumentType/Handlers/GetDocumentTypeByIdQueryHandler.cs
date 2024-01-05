using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentType.Handlers
{
    public  class GetDocumentTypeByIdQueryHandler  :  IRequestHandler<GetDocumentTypeByIdQuery, Either<GeneralFailure, ApplicationDocumentTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetDocumentTypeByIdQueryHandler> _logger;
        public GetDocumentTypeByIdQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetDocumentTypeByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationDocumentTypeResponseDTO>> Handle(GetDocumentTypeByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}