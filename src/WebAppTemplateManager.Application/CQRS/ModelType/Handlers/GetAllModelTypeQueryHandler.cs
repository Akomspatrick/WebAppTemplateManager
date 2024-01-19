using WebAppTemplateManager.Application.Contracts.Logging;
using WebAppTemplateManager.Application.CQRS.ModelType.Queries;
using WebAppTemplateManager.Contracts.ResponseDTO;
using WebAppTemplateManager.Domain.Errors;
using WebAppTemplateManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace WebAppTemplateManager.Application.CQRS.ModelType.Handlers
{
    public class GetAllModelTypeQueryHandler : IRequestHandler<GetAllModelTypeQuery, Either<GeneralFailure, IEnumerable<ModelTypeResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllModelTypeQueryHandler> _logger;
        public GetAllModelTypeQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllModelTypeQueryHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }


        async Task<Either<GeneralFailure, IEnumerable<ModelTypeResponseDTO>>> IRequestHandler<GetAllModelTypeQuery, Either<GeneralFailure, IEnumerable<ModelTypeResponseDTO>>>.Handle(GetAllModelTypeQuery request, CancellationToken cancellationToken)
        {

            return (await _unitOfWork.ModelTypeRepository
                  .GetAllAsync(s => true, new List<string>() { "Models" }, null, cancellationToken))
                  .Map(task => task
                 .Select(result => new ModelTypeResponseDTO(result.GuidId, result.ModelTypeName, result.ModelTypeGroupName, null)));
        }


    }
}
