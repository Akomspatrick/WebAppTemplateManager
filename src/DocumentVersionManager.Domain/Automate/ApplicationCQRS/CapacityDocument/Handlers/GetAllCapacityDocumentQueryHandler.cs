using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacityDocument.Handlers
{
    public  class GetAllCapacityDocumentQueryHandler  :  IRequestHandler<GetAllCapacityDocumentQuery, Either<GeneralFailures, IEnumerable<ApplicationCapacityDocumentResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllCapacityDocumentQueryHandler> _logger;
        public GetAllCapacityDocumentQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllCapacityDocumentQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, IEnumerable<ApplicationCapacityDocumentResponseDTO>>> Handle(GetAllCapacityDocumentQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}