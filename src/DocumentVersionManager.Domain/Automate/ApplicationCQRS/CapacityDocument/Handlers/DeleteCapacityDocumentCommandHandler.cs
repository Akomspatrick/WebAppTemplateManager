using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacityDocument.Handlers
{
    public  class DeleteCapacityDocumentCommandHandler  :  IRequestHandler<DeleteCapacityDocumentCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateCapacityDocumentCommandHandler> _logger;
        public DeleteCapacityDocumentCommandHandler(IUnitOfWork unitOfWork, IAppLogger<DeleteCapacityDocumentCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(DeleteCapacityDocumentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}