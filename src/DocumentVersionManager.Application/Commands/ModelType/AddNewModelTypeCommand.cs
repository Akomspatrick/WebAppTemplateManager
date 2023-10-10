using DocumentVersionManager.Application.ApplicationDTO.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;

namespace DocumentVersionManager.Application.Commands.ModelType
{
    public record AddNewModelTypeCommand(ApplicationModelTypeRequestDTO modelTypeName) : IRequest<Either<GeneralFailures, int>>;

}
