using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.ModelType.Queries;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using MediatR;


namespace DocumentVersionManager.Application.CQRS.ModelType.Handlers
{
    public class GetModelTypeByIdQueryHandler : IRequestHandler<GetModelTypeByIdQuery, Either<GeneralFailure, ModelTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetModelTypeByIdQueryHandler> _logger;

        public GetModelTypeByIdQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetModelTypeByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Either<GeneralFailure, ModelTypeResponseDTO>> Handle(GetModelTypeByIdQuery request, CancellationToken cancellationToken)
        {
            List<string> includes = new List<string>() { "Models" };
            return (await _unitOfWork.ModelTypeRepository
                            //==4
                            //.GetMatch(s => s.ModelTypeName == request.modelTypeRequestDTO.Value.ModelTypeId, includes, cancellationToken))
                            //.Map((result) => new ApplicationModelTypeResponseDTO(result.GuidId, result.ModelTypeName, convertToModelDto(result.Models)));

                            .GetMatch(s => s.ModelTypeName == request.RequestModelTypeDTO.ModelTypeId, includes, cancellationToken))
                            .Map((result) => new ModelTypeResponseDTO(result.GuidId, result.ModelTypeName, convertToModelDto(result.Models)));
        }

        private ICollection<ModelResponseDTO> convertToModelDto(IReadOnlyCollection<Domain.Entities.Model> models)
        {
            return models.Select(x => new ModelResponseDTO(x.GuidId, x.ModelName, x.ModelTypeName, null)).ToList();
        }

    }
}
