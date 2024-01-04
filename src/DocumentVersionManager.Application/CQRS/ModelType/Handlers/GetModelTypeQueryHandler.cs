using DocumentVersionManager.Application.Contracts.Logging;

using DocumentVersionManager.Application.CQRS.ModelType.Queries;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace DocumentVersionManager.Application.CQRS.ModelType.Handlers
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
                    .Map((result) => new ModelTypeResponseDTO(result.GuidId, result.ModelTypeName, result.ModelTypeGroupName, convertToModelDto(result.Models)));

        }

        private ICollection<ModelResponseDTO> convertToModelDto(IEnumerable<Domain.Entities.Model> models)
        {
            return models.Select(x => new ModelResponseDTO(x.GuidId, x.ModelName, x.ModelTypeName, null)).ToList();
        }
    }
}
