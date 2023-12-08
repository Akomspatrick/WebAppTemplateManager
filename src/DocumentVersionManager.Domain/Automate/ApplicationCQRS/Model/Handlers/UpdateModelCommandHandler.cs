using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Model.Handlers
{
    public  class UpdateModelCommandHandler  :  IRequestHandler<UpdateModelCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UpdateModelCommandHandler> _logger;
        public UpdateModelCommandHandler(IUnitOfWork unitOfWork, IAppLogger<UpdateModelCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}