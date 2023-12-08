using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.RevisionCapacityInterval.Handlers
{
    public  class UpdateRevisionCapacityIntervalCommandHandler  :  IRequestHandler<UpdateRevisionCapacityIntervalCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UpdateRevisionCapacityIntervalCommandHandler> _logger;
        public UpdateRevisionCapacityIntervalCommandHandler(IUnitOfWork unitOfWork, IAppLogger<UpdateRevisionCapacityIntervalCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(UpdateRevisionCapacityIntervalCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}