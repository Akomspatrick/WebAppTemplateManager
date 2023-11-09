using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacitySpecification.Handlers
{
    public  class DeleteCapacitySpecificationCommandHandler  :  IRequestHandler<DeleteCapacitySpecificationCommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateCapacitySpecificationCommandHandler> _logger;
        public DeleteCapacitySpecificationCommandHandler(IUnitOfWork unitOfWork, IAppLogger<DeleteCapacitySpecificationCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, int>> Handle(DeleteCapacitySpecificationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}