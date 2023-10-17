﻿using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
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

namespace DocumentVersionManager.Application.CQRS.ModelType.Handlers
{
    public class UpdateModelTypeCommandHandler : IRequestHandler<UpdateModelTypeCommand, Either<GeneralFailures, int>>
    {
        private readonly IAppLogger<UpdateModelTypeCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateModelTypeCommandHandler(IAppLogger<UpdateModelTypeCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
        public async Task<Either<GeneralFailures, int>> Handle(UpdateModelTypeCommand request, CancellationToken cancellationToken)
        {
            //return (await _unitOfWork.AsyncRepository<ModelTypes>().GetByIdAsync(request.modelTypeName.ModelTypeId, cancellationToken))
            //    .Match(Left: x => x,
            //           Right: x => _unitOfWork
            //                       .AsyncRepository<ModelTypes>()
            //                       .UpdateAsync(modify(x, request.modelTypeName), cancellationToken)
            //                       .Result);
            //bool x = request.modelTypeName.ModelTypeId==
            return (await _unitOfWork.AsyncRepository<ModelTypes>().GetMatch(s=>(s.ModelTypeId==request.modelTypeName.ModelTypeId ),cancellationToken))
        .Match(Left: x => x,
               Right: x => _unitOfWork
                           .AsyncRepository<ModelTypes>()
                           .UpdateAsync(modify(x, request.modelTypeName), cancellationToken)
                           .Result);


            
        }

        private ModelTypes modify(ModelTypes x, ApplicationModelTypeUpdateDTO modelTypeName)
        {
           return ModelTypes.Create (x.ModelTypeId,modelTypeName.ModelTypeName) ;
        }
    }
}