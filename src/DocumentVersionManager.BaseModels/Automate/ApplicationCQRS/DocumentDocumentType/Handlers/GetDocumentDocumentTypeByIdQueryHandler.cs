using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentDocumentType.Handlers
{
    public  class GetDocumentDocumentTypeByIdQueryHandler  :  IRequestHandler<GetDocumentDocumentTypeByIdQuery, Either<GeneralFailure, ApplicationDocumentDocumentTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetDocumentDocumentTypeByIdQueryHandler> _logger;
        public GetDocumentDocumentTypeByIdQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetDocumentDocumentTypeByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationDocumentDocumentTypeResponseDTO>> Handle(GetDocumentDocumentTypeByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}