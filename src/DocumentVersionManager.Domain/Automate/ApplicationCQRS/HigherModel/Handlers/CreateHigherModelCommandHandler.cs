using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Application.CQRS.Model.Commands;
namespace DocumentVersionManager.Application.CQRS.HigherModel.Handlers
{
    public  class CreateHigherModelCommandHandler  :  IRequestHandler<CreateHigherModelCommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateHigherModelCommandHandler> _logger;
        public CreateHigherModelCommandHandler(IUnitOfWork unitOfWork, IAppLogger<CreateHigherModelCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, int>> Handle(CreateHigherModelCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}