using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelTypeGroup.Handlers
{
    public  class GetAllModelTypeGroupQueryHandler  :  IRequestHandler<GetAllModelTypeGroupQuery, Either<GeneralFailure, IEnumerable<ApplicationModelTypeGroupResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllModelTypeGroupQueryHandler> _logger;
        public GetAllModelTypeGroupQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllModelTypeGroupQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, IEnumerable<ApplicationModelTypeGroupResponseDTO>>> Handle(GetAllModelTypeGroupQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}