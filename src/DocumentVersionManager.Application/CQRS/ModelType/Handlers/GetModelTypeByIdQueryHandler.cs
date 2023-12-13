using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.ModelType.Queries;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.CQRS.ModelType.Handlers
{
    public class GetModelTypeByIdQueryHandler : IRequestHandler<GetModelTypeByIdQuery, Either<GeneralFailure, ApplicationModelTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetModelTypeByIdQueryHandler> _logger;

        public GetModelTypeByIdQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetModelTypeByIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Either<GeneralFailure, ApplicationModelTypeResponseDTO>> Handle(GetModelTypeByIdQuery request, CancellationToken cancellationToken)
        {
            List<string> includes = new List<string>() { "Models" };
            return (await _unitOfWork.ModelTypeRepository
                            .GetMatch(s => s.ModelTypeName == request.modelTypeRequestDTO.Value.ModelTypeId, includes, cancellationToken))
                            .Map((result) => new ApplicationModelTypeResponseDTO(result.GuidId, result.ModelTypeName, convertToModelDto(result.Models)));
        }

        private ICollection<ApplicationModelResponseDTO> convertToModelDto(IReadOnlyCollection<Domain.Entities.Model> models)
        {
            return models.Select(x => new ApplicationModelResponseDTO(x.GuidId, x.ModelName, x.ModelTypeName)).ToList();
        }

    }
}
