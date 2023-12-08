using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacityTestPoint.Handlers
{
    public  class GetAllCapacityTestPointQueryHandler  :  IRequestHandler<GetAllCapacityTestPointQuery, Either<GeneralFailure, IEnumerable<ApplicationCapacityTestPointResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllCapacityTestPointQueryHandler> _logger;
        public GetAllCapacityTestPointQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllCapacityTestPointQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, IEnumerable<ApplicationCapacityTestPointResponseDTO>>> Handle(GetAllCapacityTestPointQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}