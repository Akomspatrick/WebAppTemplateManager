using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
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
using System.Threading;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application.CQRS.ModelType.Handlers
{
    public class DeleteModelTypeCommandHandler : IRequestHandler<DeleteModelTypeCommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<DeleteModelTypeCommandHandler> _logger;

        public DeleteModelTypeCommandHandler(IUnitOfWork unitOfWork, IAppLogger<DeleteModelTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task<Either<GeneralFailures, int>> Handle(DeleteModelTypeCommand request, CancellationToken cancellationToken)
        {
            return ( 
                await _unitOfWork.AsyncRepository<ModelTypes>()
                .GetMatch(s=> (s.ModelTypeId==request.ModelTypeId.ModelTypeId), cancellationToken))
                .Match(Left: x => x,Right: x => _unitOfWork
                .AsyncRepository<ModelTypes>()
                .DeleteAsync(x, cancellationToken)
                .Result);
                          
        }


    }
}
