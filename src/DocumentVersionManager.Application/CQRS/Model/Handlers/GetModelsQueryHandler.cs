using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Application.CQRS.ModelType.Handlers;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using LanguageExt;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.CQRS.Model.Handlers
{
    public class GetModelsQueryHandler : IRequestHandler<GetModelsQuery, Either<GeneralFailures, ApplicationModelResponseDTO>>
    {
      
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetModelsQueryHandler> _logger;
        public GetModelsQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetModelsQueryHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<Either<GeneralFailures, ApplicationModelResponseDTO>> Handle(GetModelsQuery request, CancellationToken cancellationToken)
        {
            return (await _unitOfWork.AsyncRepository<Domain.ModelAggregateRoot.Entities.Model>()
                    .GetMatch(s => (s.ModelName == request.modelRequestDTO.ModelName), cancellationToken))
                    .Map((result) => new ApplicationModelResponseDTO(result.GuidId, result.ModelName, result.ModelTypesName));
        }
     
    }
}
