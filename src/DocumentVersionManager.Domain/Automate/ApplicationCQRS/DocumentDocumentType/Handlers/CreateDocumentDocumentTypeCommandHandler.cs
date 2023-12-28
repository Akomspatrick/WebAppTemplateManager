using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
namespace DocumentVersionManager.Application.CQRS.DocumentDocumentType.Handlers
{
    public  class CreateDocumentDocumentTypeCommandHandler  :  IRequestHandler<CreateDocumentDocumentTypeCommand, Either<GeneralFailure, Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateDocumentDocumentTypeCommandHandler> _logger;
        public CreateDocumentDocumentTypeCommandHandler(IUnitOfWork unitOfWork, IAppLogger<CreateDocumentDocumentTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, Guid>> Handle(CreateDocumentDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            //Follow the format below , initial the entity variable by calling the entity Create method;
        }var entity =null;// Domain.Entities.DocumentDocumentType.Create(request.modelTypeCreateDTO.Value.ModelTypeName, request.modelTypeCreateDTO.Value.GuidId);return ( await _unitOfWork.DocumentDocumentTypeRepository.AddAsync(entity, cancellationToken)). Map((x) =>  entity.GuidId);
    }
}