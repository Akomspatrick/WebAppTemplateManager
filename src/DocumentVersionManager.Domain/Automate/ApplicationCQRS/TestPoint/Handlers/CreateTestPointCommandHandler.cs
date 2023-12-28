using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
namespace DocumentVersionManager.Application.CQRS.TestPoint.Handlers
{
    public  class CreateTestPointCommandHandler  :  IRequestHandler<CreateTestPointCommand, Either<GeneralFailure, Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateTestPointCommandHandler> _logger;
        public CreateTestPointCommandHandler(IUnitOfWork unitOfWork, IAppLogger<CreateTestPointCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, Guid>> Handle(CreateTestPointCommand request, CancellationToken cancellationToken)
        {
            //Follow the format below , initial the entity variable by calling the entity Create method;
        }var entity =null;// Domain.Entities.TestPoint.Create(request.modelTypeCreateDTO.Value.ModelTypeName, request.modelTypeCreateDTO.Value.GuidId);return ( await _unitOfWork.TestPointRepository.AddAsync(entity, cancellationToken)). Map((x) =>  entity.GuidId);
    }
}