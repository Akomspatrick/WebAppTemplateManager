using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentBasePath.Handlers
{
    public  class DeleteDocumentBasePathCommandHandler  :  IRequestHandler<DeleteDocumentBasePathCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateDocumentBasePathCommandHandler> _logger;
        public DeleteDocumentBasePathCommandHandler(IUnitOfWork unitOfWork, IAppLogger<DeleteDocumentBasePathCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(DeleteDocumentBasePathCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}