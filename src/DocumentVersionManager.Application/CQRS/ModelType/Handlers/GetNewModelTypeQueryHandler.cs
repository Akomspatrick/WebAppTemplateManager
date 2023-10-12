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
    public class GetNewModelTypeQueryHandler : IRequestHandler<GetModelTypeQuery, Either<GeneralFailures, ApplicationModelTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetNewModelTypeQueryHandler> _logger;
        public GetNewModelTypeQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetNewModelTypeQueryHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<Either<GeneralFailures, ApplicationModelTypeResponseDTO>> Handle(GetModelTypeQuery request, CancellationToken cancellationToken)
        {


            return (await _unitOfWork.AsyncRepository<Domain.ModelAggregateRoot.Entities.ModelType>()
                    .GetByIdAsync(request.ModelTypeName.ModelTypeName, cancellationToken))
                    .Map((type) => new ApplicationModelTypeResponseDTO(type.ModelTypeName));

        }

        //public async Task<Either<ModelFailures, ApplicationModelTypeResponseDTO>> Handle(GetNewModelTypeQuery request, CancellationToken cancellationToken)
        //{

        //    var repository = _unitOfWork.AsyncRepository<ModelType>();
        //    var x = await repository.GetByIdAsync(request.ModelTypeName.ModelTypeName, cancellationToken);
        //    var result = x.Map(PrepareData);
        //    return result;

        //}

        //private ApplicationModelTypeResponseDTO PrepareData(ModelType type)=> new ApplicationModelTypeResponseDTO(type.ModelTypeName);

    }
}
