using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ShellMaterial.Handlers
{
    public  class DeleteShellMaterialCommandHandler  :  IRequestHandler<DeleteShellMaterialCommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateShellMaterialCommandHandler> _logger;
        public DeleteShellMaterialCommandHandler(IUnitOfWork unitOfWork, IAppLogger<DeleteShellMaterialCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, int>> Handle(DeleteShellMaterialCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}