using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ShellMaterial.Handlers
{
    public  class GetShellMaterialQueryHandler  :  IRequestHandler<GetShellMaterialQuery, Either<GeneralFailure, ApplicationShellMaterialResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetShellMaterialQueryHandler> _logger;
        public GetShellMaterialQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetShellMaterialQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationShellMaterialResponseDTO>> Handle(GetShellMaterialQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}