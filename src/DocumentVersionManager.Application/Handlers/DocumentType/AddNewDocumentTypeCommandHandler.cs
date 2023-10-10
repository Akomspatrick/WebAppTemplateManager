using DocumentVersionManager.Application.Commands.DocumentType;
using DocumentVersionManager.Application.Commands.ModelType;
using DocumentVersionManager.Application.Handlers.ModelType;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.Handlers.DocumentType
{
    public class AddNewDocumentTypeCommandHandler : IRequestHandler<AddNewDocumentTypeCommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AddNewModelTypeCommandHandler> _logger;

        public AddNewDocumentTypeCommandHandler(IUnitOfWork unitOfWork, ILogger<AddNewModelTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<Either<GeneralFailures, int>> Handle(AddNewDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = DocumentVersionManager.Domain.ModelAggregateRoot.Entities.DocumentType.Create(request.documentTypeName.DocumentTypeName);
            var repository = _unitOfWork.AsyncRepository<DocumentVersionManager.Domain.ModelAggregateRoot.Entities.DocumentType>();
            return  await repository.AddAsync(entity, cancellationToken);
           
        }

    }
}
