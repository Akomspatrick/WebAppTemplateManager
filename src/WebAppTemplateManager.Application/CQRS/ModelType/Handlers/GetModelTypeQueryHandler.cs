using WebAppTemplateManager.Application.Contracts.Logging;

using WebAppTemplateManager.Application.CQRS.ModelType.Queries;
using WebAppTemplateManager.Contracts.ResponseDTO;
using WebAppTemplateManager.Domain.Errors;
using WebAppTemplateManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace WebAppTemplateManager.Application.CQRS.ModelType.Handlers
{
    public class GetModelTypeQueryHandler : IRequestHandler<GetModelTypeQuery, Either<GeneralFailure, ModelTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetModelTypeQueryHandler> _logger;
        public GetModelTypeQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetModelTypeQueryHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<Either<GeneralFailure, ModelTypeResponseDTO>> Handle(GetModelTypeQuery request, CancellationToken cancellationToken)
        {

            List<string> includes = new List<string>() { "Models" };
            return (await _unitOfWork.ModelTypeRepository
                    .GetMatch(s => (s.ModelTypeName == request.RequestModelTypeDTO.ModelTypeName), includes, cancellationToken))
                    .Map((result) => new ModelTypeResponseDTO(result.GuidId, result.ModelTypeName, result.ModelTypeGroupName, null));

        }

 
    }
}
