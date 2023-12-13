using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace DocumentVersionManager.Application.CQRS.ModelType.Handlers
{
    public class DeleteModelTypeCommandHandler : IRequestHandler<DeleteModelTypeCommand, Either<GeneralFailure, int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAppLogger<DeleteModelTypeCommandHandler> _logger;

        public DeleteModelTypeCommandHandler(IUnitOfWork unitOfWork, IAppLogger<DeleteModelTypeCommandHandler> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }


        public async Task<Either<GeneralFailure, int>> Handle(DeleteModelTypeCommand request, CancellationToken cancellationToken)
        {
            return (
                await _unitOfWork.ModelTypeRepository
                .GetMatch(s => (s.GuidId.Equals(request.modelTypeDeleteDTO.Value.ModelTypeId)), null, cancellationToken))
                .Match(Left: x => x, Right: x => _unitOfWork.ModelTypeRepository
                .DeleteAsync(x, cancellationToken)
                .Result);

        }


    }
}
