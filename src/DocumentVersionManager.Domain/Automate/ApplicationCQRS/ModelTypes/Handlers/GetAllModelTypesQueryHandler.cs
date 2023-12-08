using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelTypes.Handlers
{
    public  class GetAllModelTypesQueryHandler  :  IRequestHandler<GetAllModelTypesQuery, Either<GeneralFailure, IEnumerable<ApplicationModelTypesResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllModelTypesQueryHandler> _logger;
        public GetAllModelTypesQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllModelTypesQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, IEnumerable<ApplicationModelTypesResponseDTO>>> Handle(GetAllModelTypesQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}