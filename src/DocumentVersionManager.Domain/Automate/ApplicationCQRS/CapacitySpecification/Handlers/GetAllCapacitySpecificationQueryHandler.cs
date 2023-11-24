using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacitySpecification.Handlers
{
    public  class GetAllCapacitySpecificationQueryHandler  :  IRequestHandler<GetAllCapacitySpecificationQuery, Either<GeneralFailures, IEnumerable<ApplicationCapacitySpecificationResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllCapacitySpecificationQueryHandler> _logger;
        public GetAllCapacitySpecificationQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllCapacitySpecificationQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, IEnumerable<ApplicationCapacitySpecificationResponseDTO>>> Handle(GetAllCapacitySpecificationQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}