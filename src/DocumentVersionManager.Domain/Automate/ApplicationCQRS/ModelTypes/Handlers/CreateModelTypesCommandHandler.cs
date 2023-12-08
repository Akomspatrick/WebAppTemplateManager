using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Application.CQRS.Model.Commands;
namespace DocumentVersionManager.Application.CQRS.ModelTypes.Handlers
{
    public  class CreateModelTypesCommandHandler  :  IRequestHandler<CreateModelTypesCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateModelTypesCommandHandler> _logger;
        public CreateModelTypesCommandHandler(IUnitOfWork unitOfWork, IAppLogger<CreateModelTypesCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(CreateModelTypesCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}