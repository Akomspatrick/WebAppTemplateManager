using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Specification.Handlers
{
    public  class GetSpecificationQueryHandler  :  IRequestHandler<GetSpecificationQuery, Either<GeneralFailure, ApplicationSpecificationResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetSpecificationQueryHandler> _logger;
        public GetSpecificationQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetSpecificationQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationSpecificationResponseDTO>> Handle(GetSpecificationQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}