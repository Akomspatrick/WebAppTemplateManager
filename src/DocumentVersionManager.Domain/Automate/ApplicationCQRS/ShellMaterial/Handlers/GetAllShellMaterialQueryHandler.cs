using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ShellMaterial.Handlers
{
    public  class GetAllShellMaterialQueryHandler  :  IRequestHandler<GetAllShellMaterialQuery, Either<GeneralFailure, IEnumerable<ApplicationShellMaterialResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllShellMaterialQueryHandler> _logger;
        public GetAllShellMaterialQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllShellMaterialQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, IEnumerable<ApplicationShellMaterialResponseDTO>>> Handle(GetAllShellMaterialQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}