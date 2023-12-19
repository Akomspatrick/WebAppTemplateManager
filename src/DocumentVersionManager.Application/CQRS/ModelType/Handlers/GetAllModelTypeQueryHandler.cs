using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.ModelType.Queries;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace DocumentVersionManager.Application.CQRS.ModelType.Handlers
{
    public class GetAllModelTypeQueryHandler : IRequestHandler<GetAllModelTypeQuery, Either<GeneralFailure, IEnumerable<ApplicationModelTypeResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllModelTypeQueryHandler> _logger;
        public GetAllModelTypeQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllModelTypeQueryHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }


        async Task<Either<GeneralFailure, IEnumerable<ApplicationModelTypeResponseDTO>>> IRequestHandler<GetAllModelTypeQuery, Either<GeneralFailure, IEnumerable<ApplicationModelTypeResponseDTO>>>.Handle(GetAllModelTypeQuery request, CancellationToken cancellationToken)
        {

            //return (await _unitOfWork.ModelTypesRepository.GetAllWithIncludes(cancellationToken))
            // .Map(task => task
            // .Select(result => new ApplicationModelTypeResponseDTO(result.GuidId, result.ModelTypeName, ConvertTo(result.Models))));


            return (await _unitOfWork.ModelTypeRepository
                  .GetAllAsync(s => true, new List<string>() { "Models" }, null, cancellationToken))
                  .Map(task => task
                 .Select(result => new ApplicationModelTypeResponseDTO(result.GuidId, result.ModelTypeName, ConvertTo(result.Models))));





        }

        private ICollection<ApplicationModelResponseDTO> ConvertTo(IEnumerable<Domain.Entities.Model> models)
        {

            return models.Select(x => new ApplicationModelResponseDTO(x.GuidId, x.ModelName, x.ModelTypeName, null)).ToList();
        }
    }
}
