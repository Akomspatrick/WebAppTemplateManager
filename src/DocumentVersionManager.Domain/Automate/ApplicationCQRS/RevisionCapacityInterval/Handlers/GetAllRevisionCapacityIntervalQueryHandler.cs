using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.RevisionCapacityInterval.Handlers
{
    public  class GetAllRevisionCapacityIntervalQueryHandler  :  IRequestHandler<GetAllRevisionCapacityIntervalQuery, Either<GeneralFailures, IEnumerable<ApplicationRevisionCapacityIntervalResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllRevisionCapacityIntervalQueryHandler> _logger;
        public GetAllRevisionCapacityIntervalQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllRevisionCapacityIntervalQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, IEnumerable<ApplicationRevisionCapacityIntervalResponseDTO>>> Handle(GetAllRevisionCapacityIntervalQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}