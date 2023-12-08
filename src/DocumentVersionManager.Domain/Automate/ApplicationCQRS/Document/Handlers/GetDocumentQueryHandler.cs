using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Document.Handlers
{
    public  class GetDocumentQueryHandler  :  IRequestHandler<GetDocumentQuery, Either<GeneralFailure, ApplicationDocumentResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetDocumentQueryHandler> _logger;
        public GetDocumentQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetDocumentQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationDocumentResponseDTO>> Handle(GetDocumentQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}