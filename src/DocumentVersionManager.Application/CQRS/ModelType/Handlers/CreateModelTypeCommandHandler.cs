using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using DocumentVersionManager.Domain.Entities;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace DocumentVersionManager.Application.CQRS.ModelType.Handlers
{
    public sealed class CreateModelTypeCommandHandler : IRequestHandler<CreateModelTypeCommand, Either<GeneralFailure, Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateModelTypeCommandHandler> _logger;


        public CreateModelTypeCommandHandler(IUnitOfWork unitOfWork, IAppLogger<CreateModelTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, int>> HandleKeep(CreateModelTypeCommand request, CancellationToken cancellationToken)
        {
            //var entity = ModelType.Create(request.modelTypesName.modelTypesName);
            //await _unitOfWork.ModelTypesRepository.AddAsync(entity, cancellationToken);
            //var x = await _unitOfWork.CommitAllChanges(cancellationToken);
            //return x;
            var entity = Domain.Entities.ModelType.Create(request.modelTypeCreateDTO.Value.ModelTypeName, Guid.NewGuid());

            var x = await _unitOfWork.ModelTypeRepository.AddAsync(entity, cancellationToken);

            _logger.LogInformation("AddNewModelTypeCommandHandler- New data Added");
            return x;


        }

        public async Task<Either<GeneralFailure, Guid>> Handle(CreateModelTypeCommand request, CancellationToken cancellationToken)
        {

            var entity = Domain.Entities.ModelType.Create(request.modelTypeCreateDTO.Value.ModelTypeName, request.modelTypeCreateDTO.Value.GuidId);
            try
            {
                Either<GeneralFailure, int> px = await _unitOfWork.ModelTypeRepository.AddAsync(entity, cancellationToken);

                _logger.LogInformation("AddNewModelTypeCommandHandler- New data Added");
                return px.Map((x) => SwapIntForGuid(x, entity));

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        private Guid SwapIntForGuid(int x, Domain.Entities.ModelType entity)
        {
            if (x < 1)
            {
                return Guid.Empty;
            }
            return entity.GuidId;
        }


    }
}
