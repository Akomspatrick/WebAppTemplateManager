using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;

namespace DocumentVersionManager.Application.CQRS.ModelType.Commands
{
    public record CreateModelTypeCommand(ApplicationModelTypeCreateRequestDTO modelTypeCreateDTO) : IRequest<Either<GeneralFailure, int>>;

}
