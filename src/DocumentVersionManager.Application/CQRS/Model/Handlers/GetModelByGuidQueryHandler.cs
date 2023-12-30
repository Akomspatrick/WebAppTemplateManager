using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Application.Contracts.Logging;
using LanguageExt;
using MediatR;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Contracts.ResponseDTO;

namespace DocumentVersionManager.Application.CQRS.Model.Handlers
{
    public class GetModelByGuidQueryHandler : IRequestHandler<GetModelByGuidQuery, Either<GeneralFailure, ModelResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetModelByGuidQueryHandler> _logger;
        public GetModelByGuidQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetModelByGuidQueryHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailure, ModelResponseDTO>> Handle(GetModelByGuidQuery request, CancellationToken cancellationToken)
        {
            List<string> includes = new List<string>() { "ModelVersions" };
            return (await _unitOfWork.ModelRepository
                            .GetMatch(s => s.GuidId == request.RequestModelDTO.guid, includes, cancellationToken))
                            .Map((result) => new ModelResponseDTO(result.GuidId, result.ModelName, result.ModelTypeName, null
                            //convertToModelDto(result.Models

                            //)));
                            ));
        }
    }
}