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
    public class GetAllModelTypeQueryHandler : IRequestHandler<GetAllModelTypeQuery, Either<GeneralFailures, IEnumerable<ApplicationModelTypeResponseDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetAllModelTypeQueryHandler> _logger;
        public GetAllModelTypeQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetAllModelTypeQueryHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }


        async Task<Either<GeneralFailures, IEnumerable<ApplicationModelTypeResponseDTO>>> IRequestHandler<GetAllModelTypeQuery, Either<GeneralFailures, IEnumerable<ApplicationModelTypeResponseDTO>>>.Handle(GetAllModelTypeQuery request, CancellationToken cancellationToken)
        {
            var repository = _unitOfWork.AsyncRepository<ModelTypes>();
            return (await repository.GetAllAsync(cancellationToken))
             .Map(task => task.Result
             .Select(result => new ApplicationModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName)));

        }


    }
}
