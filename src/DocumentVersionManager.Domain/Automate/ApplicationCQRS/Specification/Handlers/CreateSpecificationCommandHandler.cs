using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Application.CQRS.Model.Commands;
namespace DocumentVersionManager.Application.CQRS.Specification.Handlers
{
    public  class CreateSpecificationCommandHandler  :  IRequestHandler<CreateSpecificationCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateSpecificationCommandHandler> _logger;
        public CreateSpecificationCommandHandler(IUnitOfWork unitOfWork, IAppLogger<CreateSpecificationCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(CreateSpecificationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}