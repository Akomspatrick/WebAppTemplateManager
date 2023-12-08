using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Revision.Handlers
{
    public  class DeleteRevisionCommandHandler  :  IRequestHandler<DeleteRevisionCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateRevisionCommandHandler> _logger;
        public DeleteRevisionCommandHandler(IUnitOfWork unitOfWork, IAppLogger<DeleteRevisionCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(DeleteRevisionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}