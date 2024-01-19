using WebAppTemplateManager.Application.Contracts.Logging;
using WebAppTemplateManager.Application.CQRS.ModelType.Commands;
using WebAppTemplateManager.Contracts.RequestDTO;
using WebAppTemplateManager.Domain.Entities;
using WebAppTemplateManager.Domain.Errors;
using WebAppTemplateManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace WebAppTemplateManager.Application.CQRS.ModelType.Handlers
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
            var entity = Domain.Entities.ModelType.Create(request.UpdateModelTypeDTO.ModelTypeName, request.UpdateModelTypeDTO.ModelTypeGroupName, request.UpdateModelTypeDTO.ModelTypeId);
            return await _unitOfWork.ModelTypeRepository.UpdateAsync(entity, cancellationToken);
            //_logger.LogInformation("AddNewModelTypeCommandHandler- New data Added");
        }

        private Domain.Entities.ModelType modify(Domain.Entities.ModelType x, ModelTypeUpdateRequestDTO modelTypeUpdateDTO)
        {
            return Domain.Entities.ModelType.Create(modelTypeUpdateDTO.ModelTypeName, modelTypeUpdateDTO.ModelTypeGroupName, x.GuidId);
        }
    }
}
