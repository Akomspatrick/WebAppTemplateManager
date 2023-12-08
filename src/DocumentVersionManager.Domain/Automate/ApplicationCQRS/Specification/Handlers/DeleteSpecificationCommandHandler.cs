using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Specification.Handlers
{
    public  class DeleteSpecificationCommandHandler  :  IRequestHandler<DeleteSpecificationCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateSpecificationCommandHandler> _logger;
        public DeleteSpecificationCommandHandler(IUnitOfWork unitOfWork, IAppLogger<DeleteSpecificationCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(DeleteSpecificationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}