using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.HigherModel.Handlers
{
    public  class GetAllHigherModelQueryHandler  :  IRequestHandler<GetAllHigherModelQuery, Either<GeneralFailures, IEnumerable<ApplicationHigherModelResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllHigherModelQueryHandler> _logger;
        public GetAllHigherModelQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllHigherModelQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, IEnumerable<ApplicationHigherModelResponseDTO>>> Handle(GetAllHigherModelQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}