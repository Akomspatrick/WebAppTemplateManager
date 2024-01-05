using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
namespace DocumentVersionManager.Application.CQRS.DocumentBasePath.Handlers
{
    public  class UpdateDocumentBasePathCommandHandler  :  IRequestHandler<UpdateDocumentBasePathCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UpdateDocumentBasePathCommandHandler> _logger;
        public UpdateDocumentBasePathCommandHandler(IUnitOfWork unitOfWork, IAppLogger<UpdateDocumentBasePathCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(UpdateDocumentBasePathCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}