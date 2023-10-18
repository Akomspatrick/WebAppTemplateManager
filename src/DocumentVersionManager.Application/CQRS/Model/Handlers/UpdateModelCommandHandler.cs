using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
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
    public class UpdateModelCommandHandler : IRequestHandler<UpdateModelCommand, Either<GeneralFailures, int>>
    {
        private readonly IAppLogger<UpdateModelCommandHandler> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateModelCommandHandler(IAppLogger<UpdateModelCommandHandler> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }


        public async Task<Either<GeneralFailures, int>> Handle(UpdateModelCommand request, CancellationToken cancellationToken)
        {
            var entity = Domain.ModelAggregateRoot.Entities. Model.Create(request.modelUpdateDTO.ModelId, request.modelUpdateDTO.ModelName,request.modelUpdateDTO.ModelTypeId);

            return await _unitOfWork.AsyncRepository<Domain.ModelAggregateRoot.Entities.Model>().UpdateAsync(entity, cancellationToken);
        }



  
    }
}
