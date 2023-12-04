using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.AAA.Handlers
{
    public  class GetAllAAAQueryHandler  :  IRequestHandler<GetAllAAAQuery, Either<GeneralFailures, IEnumerable<ApplicationAAAResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllAAAQueryHandler> _logger;
        public GetAllAAAQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllAAAQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, IEnumerable<ApplicationAAAResponseDTO>>> Handle(GetAllAAAQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}