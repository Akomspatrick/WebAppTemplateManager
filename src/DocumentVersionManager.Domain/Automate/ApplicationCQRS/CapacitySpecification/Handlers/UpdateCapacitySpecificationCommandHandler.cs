using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacitySpecification.Handlers
{
    public  class UpdateCapacitySpecificationCommandHandler  :  IRequestHandler<UpdateCapacitySpecificationCommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UpdateCapacitySpecificationCommandHandler> _logger;
        public UpdateCapacitySpecificationCommandHandler(IUnitOfWork unitOfWork, IAppLogger<UpdateCapacitySpecificationCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, int>> Handle(UpdateCapacitySpecificationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}