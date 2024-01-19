﻿using WebAppTemplateManager.Application.Contracts.Logging;
using WebAppTemplateManager.Application.CQRS.ModelType.Commands;
using WebAppTemplateManager.Domain.Errors;
using WebAppTemplateManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace WebAppTemplateManager.Application.CQRS.ModelType.Handlers
{
    public sealed class CreateModelTypeCommandHandler : IRequestHandler<CreateModelTypeCommand, Either<GeneralFailure, Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<CreateModelTypeCommandHandler> _logger;


        public CreateModelTypeCommandHandler(IUnitOfWork unitOfWork, IAppLogger<CreateModelTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task<Either<GeneralFailure, Guid>> Handle(CreateModelTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = Domain.Entities.ModelType.Create(request.CreateModelTypeDTO.ModelTypeName, request.CreateModelTypeDTO.ModelTypeGroupName, request.CreateModelTypeDTO.GuidId);
            return (await _unitOfWork.ModelTypeRepository.AddAsync(entity, cancellationToken)).Map((x) => entity.GuidId);
        }

    }
}
