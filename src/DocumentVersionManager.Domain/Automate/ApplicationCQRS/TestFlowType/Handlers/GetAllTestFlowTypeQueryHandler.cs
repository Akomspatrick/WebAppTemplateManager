using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.TestFlowType.Handlers
{
    public  class GetAllTestFlowTypeQueryHandler  :  IRequestHandler<GetAllTestFlowTypeQuery, Either<GeneralFailure, IEnumerable<ApplicationTestFlowTypeResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllTestFlowTypeQueryHandler> _logger;
        public GetAllTestFlowTypeQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllTestFlowTypeQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, IEnumerable<ApplicationTestFlowTypeResponseDTO>>> Handle(GetAllTestFlowTypeQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}