using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Revision.Handlers
{
    public  class GetAllRevisionQueryHandler  :  IRequestHandler<GetAllRevisionQuery, Either<GeneralFailures, IEnumerable<ApplicationRevisionResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllRevisionQueryHandler> _logger;
        public GetAllRevisionQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllRevisionQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, IEnumerable<ApplicationRevisionResponseDTO>>> Handle(GetAllRevisionQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}