
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.CQRS.DocumentType.Commands;
using DocumentVersionManager.Application.CQRS.HigherModel.Commands;
using DocumentVersionManager.Application.CQRS.ModelType.Handlers;
using DocumentVersionManager.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.CQRS.HigherModel.Handlers
{

    public class AddNewHigherModelCommandHandler : IRequestHandler<AddNewHigherModelCommand, ApplicationModelTypeRequestDTO>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<AddNewHigherModelCommandHandler> _logger;
        public AddNewHigherModelCommandHandler(IUnitOfWork unitOfWork, IAppLogger<AddNewHigherModelCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<ApplicationModelTypeRequestDTO> Handle(AddNewHigherModelCommand request, CancellationToken cancellationToken)
        {

            //var entity = Domain.ModelAggregateRoot.Entities.HigherModel.Create(request.HigherModelName, request.ProductId, request.HigherModelDescription, request.Capacity);
            //var repository = _unitOfWork.AsyncRepository<Domain.ModelAggregateRoot.Entities.HigherModel>();
            //var x = await repository.AddAsync(entity, cancellationToken);
          throw new NotImplementedException("Operation Not Allowed ");
            //return new ApplicationModelTypeRequestDTO(x.ModelId);
        }
    }

}
