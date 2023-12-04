using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Specification.Handlers
{
    public  class GetAllSpecificationQueryHandler  :  IRequestHandler<GetAllSpecificationQuery, Either<GeneralFailures, IEnumerable<ApplicationSpecificationResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllSpecificationQueryHandler> _logger;
        public GetAllSpecificationQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllSpecificationQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, IEnumerable<ApplicationSpecificationResponseDTO>>> Handle(GetAllSpecificationQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}