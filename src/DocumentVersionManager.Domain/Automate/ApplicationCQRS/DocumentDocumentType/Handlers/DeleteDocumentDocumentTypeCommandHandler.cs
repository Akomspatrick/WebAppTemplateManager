using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentDocumentType.Handlers
{
    public  class DeleteDocumentDocumentTypeCommandHandler  :  IRequestHandler<DeleteDocumentDocumentTypeCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateDocumentDocumentTypeCommandHandler> _logger;
        public DeleteDocumentDocumentTypeCommandHandler(IUnitOfWork unitOfWork, IAppLogger<DeleteDocumentDocumentTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(DeleteDocumentDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}