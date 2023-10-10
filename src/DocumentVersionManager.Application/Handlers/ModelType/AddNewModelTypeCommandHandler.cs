using DocumentVersionManager.Application.Commands.ModelType;
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
    public class AddNewModelTypeCommandHandler : IRequestHandler<AddNewModelTypeCommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AddNewModelTypeCommandHandler> _logger;
        //public AddNewModelTypeCommandHandler(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        //}

        //public async Task<Either<ModelFailures, int>> Handle(AddNewModelTypeCommand request, CancellationToken cancellationToken)
        //{
        //    var entity = ModelType.Create(request.modelTypeName.ModelTypeName);
        //    await _unitOfWork.ModelTypesRepository.AddAsync(entity, cancellationToken);
        //    var x = await _unitOfWork.CommitAllChanges(cancellationToken);
        //    return x;

        //}


        public AddNewModelTypeCommandHandler(IUnitOfWork unitOfWork, ILogger<AddNewModelTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, int>> Handle(AddNewModelTypeCommand request, CancellationToken cancellationToken)
        {
            //var entity = ModelType.Create(request.modelTypeName.ModelTypeName);
            //await _unitOfWork.ModelTypesRepository.AddAsync(entity, cancellationToken);
            //var x = await _unitOfWork.CommitAllChanges(cancellationToken);
            //return x;
            var entity = DocumentVersionManager.Domain.ModelAggregateRoot.Entities.ModelType.Create(request.modelTypeName.ModelTypeName);
            var repository = _unitOfWork.AsyncRepository<DocumentVersionManager.Domain.ModelAggregateRoot.Entities.ModelType>();
            var x = await repository.AddAsync(entity, cancellationToken);
            //var x = await _unitOfWork.CommitAllChanges(cancellationToken);
            return x;


        }
    }
}
