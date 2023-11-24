using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using DocumentVersionManager.Domain.Entities;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace DocumentVersionManager.Application.CQRS.ModelType.Handlers
{
    public class CreateModelTypeCommandHandler : IRequestHandler<CreateModelTypeCommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateModelTypeCommandHandler> _logger;


        public CreateModelTypeCommandHandler(IUnitOfWork unitOfWork, IAppLogger<CreateModelTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, int>> Handle(CreateModelTypeCommand request, CancellationToken cancellationToken)
        {
            //var entity = ModelType.Create(request.modelTypesName.modelTypesName);
            //await _unitOfWork.ModelTypesRepository.AddAsync(entity, cancellationToken);
            //var x = await _unitOfWork.CommitAllChanges(cancellationToken);
            //return x;
            var entity = ModelTypes.Create(Guid.NewGuid(), request.modelTypeCreateDTO.ModelTypesName);

            var x = await _unitOfWork.ModelTypesRepository.AddAsync(entity, cancellationToken);
            //var x = await _unitOfWork.CommitAllChanges(cancellationToken);
            _logger.LogInformation("AddNewModelTypeCommandHandler- New data Added");
            return x;


        }
    }
}
