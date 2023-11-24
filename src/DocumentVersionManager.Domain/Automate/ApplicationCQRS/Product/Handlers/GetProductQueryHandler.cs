using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Product.Handlers
{
    public  class GetProductQueryHandler  :  IRequestHandler<GetProductQuery, Either<GeneralFailures, ApplicationProductResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetProductQueryHandler> _logger;
        public GetProductQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetProductQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, ApplicationProductResponseDTO>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}