using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
namespace DocumentVersionManager.Application.CQRS.TestFlowType.Handlers
{
    public  class CreateTestFlowTypeCommandHandler  :  IRequestHandler<CreateTestFlowTypeCommand, Either<GeneralFailure, Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateTestFlowTypeCommandHandler> _logger;
        public CreateTestFlowTypeCommandHandler(IUnitOfWork unitOfWork, IAppLogger<CreateTestFlowTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, Guid>> Handle(CreateTestFlowTypeCommand request, CancellationToken cancellationToken)
        {
            //Follow the format below , initial the entity variable by calling the entity Create method;
        }var entity =null;// Domain.Entities.TestFlowType.Create(request.modelTypeCreateDTO.ModelTypeName, request.modelTypeCreateDTO.Value.GuidId);return ( await _unitOfWork.TestFlowTypeRepository.AddAsync(entity, cancellationToken)). Map((x) =>  entity.GuidId);
    }
}