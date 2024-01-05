using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentBasePath.Handlers
{
    public  class GetDocumentBasePathByIdQueryHandler  :  IRequestHandler<GetDocumentBasePathByIdQuery, Either<GeneralFailure, ApplicationDocumentBasePathResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetDocumentBasePathByIdQueryHandler> _logger;
        public GetDocumentBasePathByIdQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetDocumentBasePathByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationDocumentBasePathResponseDTO>> Handle(GetDocumentBasePathByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}