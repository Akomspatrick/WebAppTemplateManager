using DocumentVersionManager.Application.ApplicationDTO.RequestDTO;
using DocumentVersionManager.Application.ApplicationDTO.ResponseDTO;
using DocumentVersionManager.Application.Queries.ModelType;
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

namespace DocumentVersionManager.Application.Handlers.ModelType
{
    public class GetAllNewModelTypeQueryHandler : IRequestHandler<GetAllModelTypeQuery, Either<GeneralFailures, IEnumerable<ApplicationModelTypeResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetAllNewModelTypeQueryHandler> _logger;
        public GetAllNewModelTypeQueryHandler(IUnitOfWork unitOfWork, ILogger<GetAllNewModelTypeQueryHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }


        async Task<Either<GeneralFailures, IEnumerable<ApplicationModelTypeResponseDTO>>> IRequestHandler<GetAllModelTypeQuery, Either<GeneralFailures, IEnumerable<ApplicationModelTypeResponseDTO>>>.Handle(GetAllModelTypeQuery request, CancellationToken cancellationToken)
        {
            //var repository = _unitOfWork.AsyncRepository<ModelType>();
            //var x = await repository.GetAllAsync(cancellationToken);
            //return x.Map(task=> task.Result.Select(x=> new ApplicationModelTypeResponseDTO(x.ModelTypeName)));

            var repository = _unitOfWork.AsyncRepository<Domain.ModelAggregateRoot.Entities.ModelType>();
            return (await repository.GetAllAsync(cancellationToken))
             .Map(task => task.Result
             .Select(x => new ApplicationModelTypeResponseDTO(x.ModelTypeName)));

            // .Map((Task<IReadOnlyList<ModelType>> type) => type.Result.Select(x => new ApplicationModelTypeResponseDTO(x.ModelTypeName)));
            // return x.Map(task => task.Result.Select(x => new ApplicationModelTypeResponseDTO(x.ModelTypeName)));
        }
        //public async Task<Either<ModelFailures, IEnumerable<ApplicationModelTypeRequestDTO>>> Handle(GetAllNewModelTypeQuery request, CancellationToken cancellationToken)
        //{
        //   // var entity = ModelType.Create(request.modelTypeName.ModelTypeName);
        //    var repository = _unitOfWork.AsyncRepository<ModelType>();
        //    var x = await repository.GetAllAsync(cancellationToken);
        //    //var x = await _unitOfWork.CommitAllChanges(cancellationToken);
        //    var result = x.Map(PrepareData);
        //    return result;
        //}
        //private IEnumerable<ApplicationModelTypeResponseDTO> PrepareResultData(Task<IReadOnlyList<ModelType>> task)
        //{

        //    return task.Result.Select(x => new ApplicationModelTypeResponseDTO(x.ModelTypeName));
        //}


    }
}
