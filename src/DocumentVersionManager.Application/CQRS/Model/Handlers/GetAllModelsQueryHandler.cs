using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using MediatR;
using System.Linq.Expressions;

namespace DocumentVersionManager.Application.CQRS.Model.Handlers
{
    public class GetAllModelsQueryHandler : IRequestHandler<GetAllModelsQuery, Either<GeneralFailure, IEnumerable<ApplicationModelResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllModelsQueryHandler> _logger;
        public GetAllModelsQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllModelsQueryHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<Either<GeneralFailure, IEnumerable<ApplicationModelResponseDTO>>> Handle(GetAllModelsQuery request, CancellationToken cancellationToken)
        {

            // List<string> includes = new List<string>() {"ModelType"};
            // var repository = _unitOfWork.AsyncRepository<DocumentVersionManager.Domain.ModelAggregateRoot.Entities.Model>();
            //return (await _unitOfWork.ModelRepository.GetAllAsync(null, includes,null,  cancellationToken))
            // .Map(task => task.Result
            // .Select(result => new ApplicationModelResponseDTO(result.GuidId, result.ModelName,result.ModelTypesName)));

            // 

            //  return (await _unitOfWork.ModelRepository.GetAllWithIncludes(cancellationToken))
            //.Map(task => task
            // .Select(result => new ApplicationModelResponseDTO(result.GuidId, result.ModelName, result.ModelTypesName)));
            // public async Task<Either<GeneralFailure, Task<IReadOnlyList<T>>>> GetAllAsync(Expression<Func<T, bool>> expression = null, List<string> includes = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, CancellationToken cancellationToken = default)

            return (await _unitOfWork.ModelRepository
                    .GetAllAsync(s => true, new List<string>() { "ModelVersions" }, null, cancellationToken))
                    .Map(task => task.Select(result => new ApplicationModelResponseDTO(result.GuidId, result.ModelName, result.ModelTypeName)));
            //.Select(result => new ApplicationModelResponseDTO(result.GuidId, result.ModelName, result.ModelTypesName)));

            //.Map((result) => new ApplicationModelTypeResponseDTO(result.GuidId, result.ModelTypeName, convertToModelDto(result.Models)));


        }
    }


}
