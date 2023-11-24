using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.HigherModel.Handlers
{
    public  class GetHigherModelQueryHandler  :  IRequestHandler<GetHigherModelQuery, Either<GeneralFailures, ApplicationHigherModelResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetHigherModelQueryHandler> _logger;
        public GetHigherModelQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetHigherModelQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, ApplicationHigherModelResponseDTO>> Handle(GetHigherModelQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}