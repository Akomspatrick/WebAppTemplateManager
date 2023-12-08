using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Revision.Handlers
{
    public  class UpdateRevisionCommandHandler  :  IRequestHandler<UpdateRevisionCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UpdateRevisionCommandHandler> _logger;
        public UpdateRevisionCommandHandler(IUnitOfWork unitOfWork, IAppLogger<UpdateRevisionCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(UpdateRevisionCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}