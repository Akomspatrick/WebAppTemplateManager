using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Specification.Handlers
{
    public  class UpdateSpecificationCommandHandler  :  IRequestHandler<UpdateSpecificationCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UpdateSpecificationCommandHandler> _logger;
        public UpdateSpecificationCommandHandler(IUnitOfWork unitOfWork, IAppLogger<UpdateSpecificationCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(UpdateSpecificationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}