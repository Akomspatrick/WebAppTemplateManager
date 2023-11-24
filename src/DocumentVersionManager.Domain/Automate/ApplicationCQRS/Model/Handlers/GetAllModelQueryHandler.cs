using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Model.Handlers
{
    public  class GetAllModelQueryHandler  :  IRequestHandler<GetAllModelQuery, Either<GeneralFailures, IEnumerable<ApplicationModelResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllModelQueryHandler> _logger;
        public GetAllModelQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllModelQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, IEnumerable<ApplicationModelResponseDTO>>> Handle(GetAllModelQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}