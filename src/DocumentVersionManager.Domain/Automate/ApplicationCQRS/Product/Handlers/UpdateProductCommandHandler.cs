using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Product.Handlers
{
    public  class UpdateProductCommandHandler  :  IRequestHandler<UpdateProductCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<UpdateProductCommandHandler> _logger;
        public UpdateProductCommandHandler(IUnitOfWork unitOfWork, IAppLogger<UpdateProductCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}