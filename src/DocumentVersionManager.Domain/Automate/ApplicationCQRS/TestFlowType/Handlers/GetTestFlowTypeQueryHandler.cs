using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.TestFlowType.Handlers
{
    public  class GetTestFlowTypeQueryHandler  :  IRequestHandler<GetTestFlowTypeQuery, Either<GeneralFailure, ApplicationTestFlowTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetTestFlowTypeQueryHandler> _logger;
        public GetTestFlowTypeQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetTestFlowTypeQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationTestFlowTypeResponseDTO>> Handle(GetTestFlowTypeQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}