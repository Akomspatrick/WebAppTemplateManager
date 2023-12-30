using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace DocumentVersionManager.Application.CQRS.Model.Handlers
{
    public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, Either<GeneralFailure, Guid>>
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
            _logger.LogInformation($"AddNewModelTypeCommandHandler- Attempt to   Add New Model {request.CreateModelDTO.ModelName}");
            var entity = Domain.Entities.Model.Create(request.CreateModelDTO.ModelName, request.CreateModelDTO.ModelTypesName, request.CreateModelDTO.GuidId);

            var result=  await _unitOfWork.ModelRepository.AddAsync(entity, cancellationToken);
            return result.Map(x=>entity.GuidId);
        }
    }
}
