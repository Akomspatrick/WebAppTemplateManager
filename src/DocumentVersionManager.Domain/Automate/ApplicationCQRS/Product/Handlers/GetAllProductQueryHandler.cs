using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Product.Handlers
{
    public  class GetAllProductQueryHandler  :  IRequestHandler<GetAllProductQuery, Either<GeneralFailure, IEnumerable<ApplicationProductResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllProductQueryHandler> _logger;
        public GetAllProductQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllProductQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, IEnumerable<ApplicationProductResponseDTO>>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}