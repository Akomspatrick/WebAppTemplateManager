using DocumentVersionManager.Application.Commands;
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

namespace DocumentVersionManager.Application.Handlers
{
    public class AddNewModelTypeCommandHandler : IRequestHandler<AddNewModelTypeCommand, Either<ModelFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;

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


        public AddNewModelTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Either<ModelFailures, int>> Handle(AddNewModelTypeCommand request, CancellationToken cancellationToken)
        {
            //var entity = ModelType.Create(request.modelTypeName.ModelTypeName);
            //await _unitOfWork.ModelTypesRepository.AddAsync(entity, cancellationToken);
            //var x = await _unitOfWork.CommitAllChanges(cancellationToken);
            //return x;
            var entity = ModelType.Create(request.modelTypeName.ModelTypeName);
            var repository = _unitOfWork.AsyncRepository<ModelType>();
            await repository.AddAsync(entity, cancellationToken);
            var x = await _unitOfWork.CommitAllChanges(cancellationToken);
            return x;

            
        }
    }
}
