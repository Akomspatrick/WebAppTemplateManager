using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
namespace DocumentVersionManager.Application.CQRS.Model.Handlers
{
    public  class CreateModelCommandHandler  :  IRequestHandler<CreateModelCommand, Either<GeneralFailure, Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateModelCommandHandler> _logger;
        public CreateModelCommandHandler(IUnitOfWork unitOfWork, IAppLogger<CreateModelCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, Guid>> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            //Follow the format below , initial the entity variable by calling the entity Create method;
        }var entity =null;// Domain.Entities.Model.Create(request.modelTypeCreateDTO.ModelTypeName, request.modelTypeCreateDTO.Value.GuidId);return ( await _unitOfWork.ModelRepository.AddAsync(entity, cancellationToken)). Map((x) =>  entity.GuidId);
    }
}