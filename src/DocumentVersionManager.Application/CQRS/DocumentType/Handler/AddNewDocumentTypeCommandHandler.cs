
using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.DocumentType.Commands;
using DocumentVersionManager.Application.CQRS.ModelType.Handlers;
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

namespace DocumentVersionManager.Application.CQRS.DocumentType.Handler
{
    public class AddNewDocumentTypeCommandHandler : IRequestHandler<AddNewDocumentTypeCommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<AddNewModelTypeCommandHandler> _logger;

        public AddNewDocumentTypeCommandHandler(IUnitOfWork unitOfWork, IAppLogger<AddNewModelTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Either<GeneralFailures, int>> Handle(AddNewDocumentTypeCommand request, CancellationToken cancellationToken)
        {
            var entity = Domain.ModelAggregateRoot.Entities.DocumentType.Create(request.documentTypeName.DocumentTypeName);
            var repository = _unitOfWork.AsyncRepository<Domain.ModelAggregateRoot.Entities.DocumentType>();
            return await repository.AddAsync(entity, cancellationToken);

        }

    }
}
