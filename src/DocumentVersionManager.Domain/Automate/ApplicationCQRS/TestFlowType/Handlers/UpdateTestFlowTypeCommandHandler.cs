using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
namespace DocumentVersionManager.Application.CQRS.TestFlowType.Handlers
{
    public  class UpdateTestFlowTypeCommandHandler  :  IRequestHandler<UpdateTestFlowTypeCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UpdateTestFlowTypeCommandHandler> _logger;
        public UpdateTestFlowTypeCommandHandler(IUnitOfWork unitOfWork, IAppLogger<UpdateTestFlowTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(UpdateTestFlowTypeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}