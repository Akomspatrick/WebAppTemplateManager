using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacityTestPoint.Handlers
{
    public  class GetCapacityTestPointQueryHandler  :  IRequestHandler<GetCapacityTestPointQuery, Either<GeneralFailure, ApplicationCapacityTestPointResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetCapacityTestPointQueryHandler> _logger;
        public GetCapacityTestPointQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetCapacityTestPointQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationCapacityTestPointResponseDTO>> Handle(GetCapacityTestPointQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}