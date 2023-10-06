using DocumentVersionManager.Application.ApplicationDTO.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;

namespace DocumentVersionManager.Application.Commands
{
    public record AddNewModelTypeCommand(ApplicationModelTypeRequestDTO modelTypeName) : IRequest<Either<ModelFailures, int>>;

}
