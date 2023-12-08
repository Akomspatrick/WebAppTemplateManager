using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using DocumentVersionManager.Domain.Entities;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace DocumentVersionManager.Application.CQRS.ModelType.Handlers
{
    public class UpdateModelTypeCommandHandler : IRequestHandler<UpdateModelTypeCommand, Either<GeneralFailure, int>>
    {
        private readonly IAppLogger<UpdateModelTypeCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateModelTypeCommandHandler(IAppLogger<UpdateModelTypeCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<Either<GeneralFailure, int>> Handle(UpdateModelTypeCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException("Operation Not Allowed ");
            var entity = ModelTypes.Create(request.modelTypeUpdateDTO.ModelTypesId, request.modelTypeUpdateDTO.modelTypesName);
            return await _unitOfWork.ModelTypesRepository.UpdateAsync(entity, cancellationToken);
            //_logger.LogInformation("AddNewModelTypeCommandHandler- New data Added");
        }

        private ModelTypes modify(ModelTypes x, ApplicationModelTypeUpdateDTO modelTypeUpdateDTO)
        {
            return ModelTypes.Create(x.GuidId, modelTypeUpdateDTO.modelTypesName);
        }
    }
}
