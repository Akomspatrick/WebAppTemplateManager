using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Document.Handlers
{
    public  class UpdateDocumentCommandHandler  :  IRequestHandler<UpdateDocumentCommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UpdateDocumentCommandHandler> _logger;
        public UpdateDocumentCommandHandler(IUnitOfWork unitOfWork, IAppLogger<UpdateDocumentCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, int>> Handle(UpdateDocumentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}