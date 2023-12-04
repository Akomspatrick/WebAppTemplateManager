using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.AAA.Handlers
{
    public  class GetAAAQueryHandler  :  IRequestHandler<GetAAAQuery, Either<GeneralFailures, ApplicationAAAResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAAAQueryHandler> _logger;
        public GetAAAQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAAAQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, ApplicationAAAResponseDTO>> Handle(GetAAAQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}