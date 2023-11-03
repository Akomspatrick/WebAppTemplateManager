using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace DocumentVersionManager.Application.CQRS.Model.Handlers
{
    public class DeleteModelCommandHandler : IRequestHandler<DeleteModelCommand, Either<GeneralFailures, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<DeleteModelCommandHandler> _logger;

        public DeleteModelCommandHandler(IUnitOfWork unitOfWork, IAppLogger<DeleteModelCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<Either<GeneralFailures, int>> Handle(DeleteModelCommand request, CancellationToken cancellationToken)
        {
            return (
                  await _unitOfWork.ModelRepository
                  .GetMatch(s => (s.GuidId == request.modelDeleteDTO.ModelId),null, cancellationToken))
                  .Match(Left: x => x, Right: x => _unitOfWork
                  .ModelRepository
                  .DeleteAsync(x, cancellationToken)
                  .Result);
        }

   
    }
}
