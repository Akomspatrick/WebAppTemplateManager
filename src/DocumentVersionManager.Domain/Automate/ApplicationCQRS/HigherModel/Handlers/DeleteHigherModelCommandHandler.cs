using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.HigherModel.Handlers
{
    public  class DeleteHigherModelCommandHandler  :  IRequestHandler<DeleteHigherModelCommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateHigherModelCommandHandler> _logger;
        public DeleteHigherModelCommandHandler(IUnitOfWork unitOfWork, IAppLogger<DeleteHigherModelCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, int>> Handle(DeleteHigherModelCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}