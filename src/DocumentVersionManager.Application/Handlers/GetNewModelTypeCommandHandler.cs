﻿using DocumentVersionManager.Application.ApplicationDTO.RequestDTO;
using DocumentVersionManager.Application.ApplicationDTO.ResponseDTO;
using DocumentVersionManager.Application.Queries;
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

namespace DocumentVersionManager.Application.Handlers
{
    public class GetNewModelTypeCommandHandler : IRequestHandler<GetNewModelTypeQuery, Either<ModelFailures, ApplicationModelTypeResponseDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GetNewModelTypeCommandHandler> _logger;
        public GetNewModelTypeCommandHandler(IUnitOfWork unitOfWork, ILogger<GetNewModelTypeCommandHandler> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<Either<ModelFailures, ApplicationModelTypeResponseDTO>> Handle(GetNewModelTypeQuery request, CancellationToken cancellationToken)
        {

      
            return  ( await _unitOfWork.AsyncRepository<ModelType>()
                    .GetByIdAsync(request.ModelTypeName.ModelTypeName, cancellationToken))
                    .Map((ModelType type) => new ApplicationModelTypeResponseDTO(type.ModelTypeName));
           


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
