using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.TestFlowType.Handlers
{
    public  class GetTestFlowTypeByGuidQueryHandler  :  IRequestHandler<GetTestFlowTypeByGuidQuery, Either<GeneralFailure, ApplicationTestFlowTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetTestFlowTypeByGuidQueryHandler> _logger;
        public GetTestFlowTypeByGuidQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetTestFlowTypeByGuidQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationTestFlowTypeResponseDTO>> Handle(GetTestFlowTypeByGuidQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}