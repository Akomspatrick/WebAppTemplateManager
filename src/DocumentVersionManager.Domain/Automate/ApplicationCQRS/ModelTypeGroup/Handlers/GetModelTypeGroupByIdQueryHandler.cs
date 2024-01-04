using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelTypeGroup.Handlers
{
    public  class GetModelTypeGroupByIdQueryHandler  :  IRequestHandler<GetModelTypeGroupByIdQuery, Either<GeneralFailure, ApplicationModelTypeGroupResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetModelTypeGroupByIdQueryHandler> _logger;
        public GetModelTypeGroupByIdQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetModelTypeGroupByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationModelTypeGroupResponseDTO>> Handle(GetModelTypeGroupByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}