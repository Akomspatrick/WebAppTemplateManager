using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Application.CQRS.Model.Commands;
namespace DocumentVersionManager.Application.CQRS.RevisionCapacityInterval.Handlers
{
    public  class CreateRevisionCapacityIntervalCommandHandler  :  IRequestHandler<CreateRevisionCapacityIntervalCommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateRevisionCapacityIntervalCommandHandler> _logger;
        public CreateRevisionCapacityIntervalCommandHandler(IUnitOfWork unitOfWork, IAppLogger<CreateRevisionCapacityIntervalCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, int>> Handle(CreateRevisionCapacityIntervalCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}