using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
namespace DocumentVersionManager.Application.CQRS.CapacityDocument.Handlers
{
    public  class UpdateCapacityDocumentCommandHandler  :  IRequestHandler<UpdateCapacityDocumentCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UpdateCapacityDocumentCommandHandler> _logger;
        public UpdateCapacityDocumentCommandHandler(IUnitOfWork unitOfWork, IAppLogger<UpdateCapacityDocumentCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(UpdateCapacityDocumentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}