using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.TestFlowType.Handlers
{
    public  class GetTestFlowTypeByIdQueryHandler  :  IRequestHandler<GetTestFlowTypeByIdQuery, Either<GeneralFailure, ApplicationTestFlowTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetTestFlowTypeByIdQueryHandler> _logger;
        public GetTestFlowTypeByIdQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetTestFlowTypeByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationTestFlowTypeResponseDTO>> Handle(GetTestFlowTypeByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}