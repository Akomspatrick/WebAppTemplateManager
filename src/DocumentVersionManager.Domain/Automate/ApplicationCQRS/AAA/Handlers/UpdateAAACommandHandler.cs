using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.AAA.Handlers
{
    public  class UpdateAAACommandHandler  :  IRequestHandler<UpdateAAACommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UpdateAAACommandHandler> _logger;
        public UpdateAAACommandHandler(IUnitOfWork unitOfWork, IAppLogger<UpdateAAACommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, int>> Handle(UpdateAAACommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}