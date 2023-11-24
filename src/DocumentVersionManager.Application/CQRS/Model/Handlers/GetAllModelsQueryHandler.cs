using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace DocumentVersionManager.Application.CQRS.Model.Handlers
{
    public class GetAllModelsQueryHandler : IRequestHandler<GetAllModelsQuery, Either<GeneralFailures, IEnumerable<ApplicationModelResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllModelsQueryHandler> _logger;
        public GetAllModelsQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllModelsQueryHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<Either<GeneralFailures, IEnumerable<ApplicationModelResponseDTO>>> Handle(GetAllModelsQuery request, CancellationToken cancellationToken)
        {

            // List<string> includes = new List<string>() {"ModelType"};
            // var repository = _unitOfWork.AsyncRepository<DocumentVersionManager.Domain.ModelAggregateRoot.Entities.Model>();
            //return (await _unitOfWork.ModelRepository.GetAllAsync(null, includes,null,  cancellationToken))
            // .Map(task => task.Result
            // .Select(result => new ApplicationModelResponseDTO(result.GuidId, result.ModelName,result.ModelTypesName)));
            return (await _unitOfWork.ModelRepository.GetAllWithIncludes(cancellationToken))
          .Map(task => task
          .Select(result => new ApplicationModelResponseDTO(result.GuidId, result.ModelName, result.ModelTypesName)));
        }
    }


}
