using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelVersion.Handlers
{
    public  class GetAllModelVersionQueryHandler  :  IRequestHandler<GetAllModelVersionQuery, Either<GeneralFailures, IEnumerable<ApplicationModelVersionResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllModelVersionQueryHandler> _logger;
        public GetAllModelVersionQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllModelVersionQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, IEnumerable<ApplicationModelVersionResponseDTO>>> Handle(GetAllModelVersionQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}