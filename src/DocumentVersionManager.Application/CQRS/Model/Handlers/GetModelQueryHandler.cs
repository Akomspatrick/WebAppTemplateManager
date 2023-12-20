﻿using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace DocumentVersionManager.Application.CQRS.Model.Handlers
{
    public class GetModelQueryHandler : IRequestHandler<GetModelQuery, Either<GeneralFailure, ApplicationModelResponseDTO>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<GetModelQueryHandler> _logger;
        public GetModelQueryHandler(IUnitOfWork unitOfWork, IAppLogger<GetModelQueryHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<Either<GeneralFailure, ApplicationModelResponseDTO>> Handle(GetModelQuery request, CancellationToken cancellationToken)
        {

            return (await _unitOfWork.ModelRepository
                    .GetMatch(s => (s.ModelName == request.RequestModelDTO.Value.ModelName), null, cancellationToken))
                    .Map((result) => new ApplicationModelResponseDTO(result.GuidId, result.ModelName, result.ModelTypeName, null));
        }

    }
}