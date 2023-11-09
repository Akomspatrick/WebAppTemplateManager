using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacitySpecification.Handlers
{
    public  class GetCapacitySpecificationQueryHandler  :  IRequestHandler<GetCapacitySpecificationQuery, Either<GeneralFailures, ApplicationCapacitySpecificationResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetCapacitySpecificationQueryHandler> _logger;
        public GetCapacitySpecificationQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetCapacitySpecificationQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, ApplicationCapacitySpecificationResponseDTO>> Handle(GetCapacitySpecificationQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}