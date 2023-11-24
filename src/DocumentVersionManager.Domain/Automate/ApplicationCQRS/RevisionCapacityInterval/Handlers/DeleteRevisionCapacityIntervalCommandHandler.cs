using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.RevisionCapacityInterval.Handlers
{
    public  class DeleteRevisionCapacityIntervalCommandHandler  :  IRequestHandler<DeleteRevisionCapacityIntervalCommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateRevisionCapacityIntervalCommandHandler> _logger;
        public DeleteRevisionCapacityIntervalCommandHandler(IUnitOfWork unitOfWork, IAppLogger<DeleteRevisionCapacityIntervalCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, int>> Handle(DeleteRevisionCapacityIntervalCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}