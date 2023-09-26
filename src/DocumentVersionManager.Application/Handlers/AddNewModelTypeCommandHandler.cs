using DocumentVersionManager.Application.Commands;
using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.Handlers
{
    public class AddNewModelTypeCommandHandler : IRequestHandler<AddNewModelTypeCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddNewModelTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<int> Handle(AddNewModelTypeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = new ModelType { ModelTypeName= request.modelType.ModelTypeName};
                await _unitOfWork.modelTypesRepository.AddAsync(entity, cancellationToken);
                var x= await _unitOfWork.CommitAllChanges(cancellationToken);
                return x;
            }
            catch (Exception  ex)
            {

                return 0;
            }
        }
    }
}
