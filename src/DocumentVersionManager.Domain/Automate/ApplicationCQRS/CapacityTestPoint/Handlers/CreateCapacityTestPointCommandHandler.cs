using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Application.CQRS.Model.Commands;
namespace DocumentVersionManager.Application.CQRS.CapacityTestPoint.Handlers
{
    public  class CreateCapacityTestPointCommandHandler  :  IRequestHandler<CreateCapacityTestPointCommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateCapacityTestPointCommandHandler> _logger;
        public CreateCapacityTestPointCommandHandler(IUnitOfWork unitOfWork, IAppLogger<CreateCapacityTestPointCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, int>> Handle(CreateCapacityTestPointCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}