using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.ModelType.Queries;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace DocumentVersionManager.Application.CQRS.ModelType.Handlers
{
    public class GetModelTypeQueryHandler : IRequestHandler<GetModelTypeQuery, Either<GeneralFailure, ApplicationModelTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetModelTypeQueryHandler> _logger;
        public GetModelTypeQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetModelTypeQueryHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<Either<GeneralFailure, ApplicationModelTypeResponseDTO>> Handle(GetModelTypeQuery request, CancellationToken cancellationToken)
        {

            List<string> includes = new List<string>() { "Models" };
            return (await _unitOfWork.ModelTypesRepository
                    .GetMatch(s => (s.ModelTypeName == request.modelTypeRequestDTO.Value.ModelTypeName), includes, cancellationToken))
                    .Map((result) => new ApplicationModelTypeResponseDTO(result.GuidId, result.ModelTypeName, convertToModelDto(result.Models)));

        }

        private ICollection<ApplicationModelResponseDTO> convertToModelDto(IEnumerable<Domain.Entities.Model> models)
        {
            return models.Select(x => new ApplicationModelResponseDTO(x.GuidId, x.ModelName, x.ModelTypesName)).ToList();
        }
    }
}
