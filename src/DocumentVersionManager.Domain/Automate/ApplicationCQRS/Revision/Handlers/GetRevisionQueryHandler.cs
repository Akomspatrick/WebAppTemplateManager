using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Revision.Handlers
{
    public  class GetRevisionQueryHandler  :  IRequestHandler<GetRevisionQuery, Either<GeneralFailure, ApplicationRevisionResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetRevisionQueryHandler> _logger;
        public GetRevisionQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetRevisionQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationRevisionResponseDTO>> Handle(GetRevisionQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}