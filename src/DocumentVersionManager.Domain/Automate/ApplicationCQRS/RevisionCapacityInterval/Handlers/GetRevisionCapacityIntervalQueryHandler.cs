using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.RevisionCapacityInterval.Handlers
{
    public  class GetRevisionCapacityIntervalQueryHandler  :  IRequestHandler<GetRevisionCapacityIntervalQuery, Either<GeneralFailures, ApplicationRevisionCapacityIntervalResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetRevisionCapacityIntervalQueryHandler> _logger;
        public GetRevisionCapacityIntervalQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetRevisionCapacityIntervalQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, ApplicationRevisionCapacityIntervalResponseDTO>> Handle(GetRevisionCapacityIntervalQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}