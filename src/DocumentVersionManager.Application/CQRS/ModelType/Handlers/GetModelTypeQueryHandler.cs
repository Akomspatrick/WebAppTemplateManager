using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.ModelType.Queries;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using LanguageExt;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.CQRS.ModelType.Handlers
{
    public class GetModelTypeQueryHandler : IRequestHandler<GetModelTypeQuery, Either<GeneralFailures, ApplicationModelTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetModelTypeQueryHandler> _logger;
        public GetModelTypeQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetModelTypeQueryHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<Either<GeneralFailures, ApplicationModelTypeResponseDTO>> Handle(GetModelTypeQuery request, CancellationToken cancellationToken)
        {


            return (await _unitOfWork.ModelTypesRepository
                    .GetMatch(s => (s.ModelTypesName == request.modelTypeRequestDTO.ModelTypesName), null, cancellationToken))
                    .Map((result) => new ApplicationModelTypeResponseDTO(result.GuidId, result.ModelTypesName, convertToModelDto(result.Models))); 

        }

        private ICollection<ApplicationModelResponseDTO> convertToModelDto(ICollection<Domain.ModelAggregateRoot.Entities.Model> models)
        {
             return models.Select(x => new ApplicationModelResponseDTO(x.GuidId, x.ModelName, x.ModelTypesName)).ToList();
        }
    }
}
