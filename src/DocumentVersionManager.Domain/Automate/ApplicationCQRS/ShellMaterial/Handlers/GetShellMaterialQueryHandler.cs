using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ShellMaterial.Handlers
{
    public  class GetShellMaterialQueryHandler  :  IRequestHandler<GetShellMaterialQuery, Either<GeneralFailures, ApplicationShellMaterialResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetShellMaterialQueryHandler> _logger;
        public GetShellMaterialQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetShellMaterialQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, ApplicationShellMaterialResponseDTO>> Handle(GetShellMaterialQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}