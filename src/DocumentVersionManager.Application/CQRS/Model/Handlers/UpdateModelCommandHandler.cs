using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace DocumentVersionManager.Application.CQRS.Model.Handlers
{
    public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, Either<GeneralFailure, int>>
    {
        private readonly IAppLogger<UpdateModelCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateModelCommandHandler(IAppLogger<UpdateModelCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }


        public async Task<Either<GeneralFailure, int>> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            var entity = Domain.Entities.Model.Create(Guid.NewGuid(), request.UpdateModelDTO.Value.ModelName, request.UpdateModelDTO.Value.ModelTypesName);


            //entity.AddDomainEvent(new ModelUpdatedEvent(entity));

            return await _unitOfWork.ModelRepository.UpdateAsync(entity, cancellationToken);



        }




    }
}
