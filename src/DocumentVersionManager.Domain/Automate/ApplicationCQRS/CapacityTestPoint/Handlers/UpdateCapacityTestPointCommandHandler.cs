using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacityTestPoint.Handlers
{
    public  class UpdateCapacityTestPointCommandHandler  :  IRequestHandler<UpdateCapacityTestPointCommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UpdateCapacityTestPointCommandHandler> _logger;
        public UpdateCapacityTestPointCommandHandler(IUnitOfWork unitOfWork, IAppLogger<UpdateCapacityTestPointCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, int>> Handle(UpdateCapacityTestPointCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}