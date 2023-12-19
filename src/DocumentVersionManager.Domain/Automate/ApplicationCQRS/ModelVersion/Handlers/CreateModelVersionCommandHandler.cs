using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
namespace DocumentVersionManager.Application.CQRS.ModelVersion.Handlers
{
    public  class CreateModelVersionCommandHandler  :  IRequestHandler<CreateModelVersionCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateModelVersionCommandHandler> _logger;
        public CreateModelVersionCommandHandler(IUnitOfWork unitOfWork, IAppLogger<CreateModelVersionCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(CreateModelVersionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}