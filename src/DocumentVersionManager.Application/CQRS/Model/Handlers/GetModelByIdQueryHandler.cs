using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
namespace DocumentVersionManager.Application.CQRS.Model.Handlers
{
    public class GetModelByIdQueryHandler : IRequestHandler<GetModelByIdQuery, Either<GeneralFailure, ApplicationModelResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetModelByIdQueryHandler> _logger;
        public GetModelByIdQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetModelByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ApplicationModelResponseDTO>> Handle(GetModelByIdQuery request, CancellationToken cancellationToken)
        {
            List<string> includes = new List<string>() { "ModelVersions" };
            return (await _unitOfWork.ModelRepository
                            .GetMatch(s => s.ModelName == request.RequestModelDTO.Value.ModelName, includes, cancellationToken))
                            .Map((result) => new ApplicationModelResponseDTO(result.GuidId, result.ModelName, result.ModelTypeName, null
                            //convertToModelDto(result.Models

                            //)));
                            ));
        }

        private ICollection<ApplicationModelResponseDTO> convertToModelDto(IReadOnlyCollection<Domain.Entities.Model> models)
        {
            return models.Select(x => new ApplicationModelResponseDTO(x.GuidId, x.ModelName, x.ModelTypeName, null)).ToList();
        }

    }
}