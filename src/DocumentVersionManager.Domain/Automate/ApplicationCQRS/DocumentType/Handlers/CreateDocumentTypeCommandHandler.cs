using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Application.CQRS.Model.Commands;
namespace DocumentVersionManager.Application.CQRS.DocumentType.Handlers
{
    public  class CreateDocumentTypeCommandHandler  :  IRequestHandler<CreateDocumentTypeCommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateDocumentTypeCommandHandler> _logger;
        public CreateDocumentTypeCommandHandler(IUnitOfWork unitOfWork, IAppLogger<CreateDocumentTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, int>> Handle(CreateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}