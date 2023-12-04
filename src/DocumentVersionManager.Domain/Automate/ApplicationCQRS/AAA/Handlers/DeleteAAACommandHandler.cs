using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.AAA.Handlers
{
    public  class DeleteAAACommandHandler  :  IRequestHandler<DeleteAAACommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateAAACommandHandler> _logger;
        public DeleteAAACommandHandler(IUnitOfWork unitOfWork, IAppLogger<DeleteAAACommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, int>> Handle(DeleteAAACommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}