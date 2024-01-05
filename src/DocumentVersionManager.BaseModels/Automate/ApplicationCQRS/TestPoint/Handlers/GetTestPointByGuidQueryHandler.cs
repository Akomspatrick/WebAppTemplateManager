using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.TestPoint.Handlers
{
    public  class GetTestPointByGuidQueryHandler  :  IRequestHandler<GetTestPointByGuidQuery, Either<GeneralFailure, ApplicationTestPointResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetTestPointByGuidQueryHandler> _logger;
        public GetTestPointByGuidQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetTestPointByGuidQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationTestPointResponseDTO>> Handle(GetTestPointByGuidQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}