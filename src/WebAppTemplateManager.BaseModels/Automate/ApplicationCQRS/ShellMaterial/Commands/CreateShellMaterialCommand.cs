using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ShellMaterial.Commands
{
    public  record CreateShellMaterialCommand(ShellMaterialCreateRequestDTO  CreateShellMaterialDTO) :  IRequest<Either<GeneralFailure, Guid>>;
}