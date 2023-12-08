using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ShellMaterial.Handlers
{
    public  class UpdateShellMaterialCommandHandler  :  IRequestHandler<UpdateShellMaterialCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UpdateShellMaterialCommandHandler> _logger;
        public UpdateShellMaterialCommandHandler(IUnitOfWork unitOfWork, IAppLogger<UpdateShellMaterialCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(UpdateShellMaterialCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}