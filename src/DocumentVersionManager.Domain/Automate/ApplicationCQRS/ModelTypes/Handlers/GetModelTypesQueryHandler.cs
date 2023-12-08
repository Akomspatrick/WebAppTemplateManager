using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelTypes.Handlers
{
    public  class GetModelTypesQueryHandler  :  IRequestHandler<GetModelTypesQuery, Either<GeneralFailure, ApplicationModelTypesResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetModelTypesQueryHandler> _logger;
        public GetModelTypesQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetModelTypesQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationModelTypesResponseDTO>> Handle(GetModelTypesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}