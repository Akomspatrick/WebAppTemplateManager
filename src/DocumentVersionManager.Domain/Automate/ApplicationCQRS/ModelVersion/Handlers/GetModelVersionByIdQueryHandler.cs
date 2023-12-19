using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelVersion.Handlers
{
    public  class GetModelVersionByIdQueryHandler  :  IRequestHandler<GetModelVersionByIdQuery, Either<GeneralFailure, ApplicationModelVersionResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetModelVersionByIdQueryHandler> _logger;
        public GetModelVersionByIdQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetModelVersionByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationModelVersionResponseDTO>> Handle(GetModelVersionByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}