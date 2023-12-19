using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
namespace DocumentVersionManager.Application.CQRS.ModelVersion.Handlers
{
    public  class UpdateModelVersionCommandHandler  :  IRequestHandler<UpdateModelVersionCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UpdateModelVersionCommandHandler> _logger;
        public UpdateModelVersionCommandHandler(IUnitOfWork unitOfWork, IAppLogger<UpdateModelVersionCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(UpdateModelVersionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}