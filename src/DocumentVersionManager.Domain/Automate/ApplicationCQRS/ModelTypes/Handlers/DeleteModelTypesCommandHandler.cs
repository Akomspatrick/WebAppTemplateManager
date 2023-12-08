using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelTypes.Handlers
{
    public  class DeleteModelTypesCommandHandler  :  IRequestHandler<DeleteModelTypesCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateModelTypesCommandHandler> _logger;
        public DeleteModelTypesCommandHandler(IUnitOfWork unitOfWork, IAppLogger<DeleteModelTypesCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(DeleteModelTypesCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}