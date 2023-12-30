using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
namespace DocumentVersionManager.Application.CQRS.Product.Handlers
{
    public  class CreateProductCommandHandler  :  IRequestHandler<CreateProductCommand, Either<GeneralFailure, Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateProductCommandHandler> _logger;
        public CreateProductCommandHandler(IUnitOfWork unitOfWork, IAppLogger<CreateProductCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, Guid>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            //Follow the format below , initial the entity variable by calling the entity Create method;
        }var entity =null;// Domain.Entities.Product.Create(request.modelTypeCreateDTO.ModelTypeName, request.modelTypeCreateDTO.Value.GuidId);return ( await _unitOfWork.ProductRepository.AddAsync(entity, cancellationToken)). Map((x) =>  entity.GuidId);
    }
}