using DocumentVersionManager.Application.Contracts.Logging;
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
    public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, Either<GeneralFailures, int>>
    {   
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateModelCommandHandler> _logger;

        public CreateModelCommandHandler(IUnitOfWork unitOfWork, IAppLogger<CreateModelCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }  

        public async Task<Either<GeneralFailures, int>> Handle(CreateModelCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("AddNewModelTypeCommandHandler- New data Added");
            var entity = Domain.ModelAggregateRoot.Entities.Model.Create(request.ModelCreateDTO.ModelId,request.ModelCreateDTO.ModelName, request.ModelCreateDTO.ModelTypeId);
           
            return await _unitOfWork.AsyncRepository<Domain.ModelAggregateRoot.Entities.Model>().AddAsync(entity, cancellationToken);
        }
    }
}
