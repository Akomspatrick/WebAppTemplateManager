using WebAppTemplateManager.Application.Contracts.Logging;
using WebAppTemplateManager.Application.CQRS.ModelType.Commands;
using WebAppTemplateManager.Domain.Errors;
using WebAppTemplateManager.Domain.Interfaces;
using LanguageExt;
using MediatR;

namespace WebAppTemplateManager.Application.CQRS.ModelType.Handlers
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
                .GetMatch(s => (s.GuidId.Equals(request.DeleteModelTypeDTO.guid)), null, cancellationToken))
                .Match(Left: x => x, Right: x => _unitOfWork.ModelTypeRepository
                .DeleteAsync(x, cancellationToken)
                .Result);

        }


    }
}
