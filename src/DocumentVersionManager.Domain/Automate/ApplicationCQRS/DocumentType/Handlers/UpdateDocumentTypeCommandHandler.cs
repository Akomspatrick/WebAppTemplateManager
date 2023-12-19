using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
namespace DocumentVersionManager.Application.CQRS.DocumentType.Handlers
{
    public  class UpdateDocumentTypeCommandHandler  :  IRequestHandler<UpdateDocumentTypeCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UpdateDocumentTypeCommandHandler> _logger;
        public UpdateDocumentTypeCommandHandler(IUnitOfWork unitOfWork, IAppLogger<UpdateDocumentTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(UpdateDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}