using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Application.CQRS.Model.Commands;
namespace DocumentVersionManager.Application.CQRS.Revision.Handlers
{
    public  class CreateRevisionCommandHandler  :  IRequestHandler<CreateRevisionCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateRevisionCommandHandler> _logger;
        public CreateRevisionCommandHandler(IUnitOfWork unitOfWork, IAppLogger<CreateRevisionCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(CreateRevisionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}