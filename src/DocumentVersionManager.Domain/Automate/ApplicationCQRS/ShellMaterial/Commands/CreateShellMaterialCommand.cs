using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ShellMaterial.Commands
{
    public  record CreateShellMaterialCommand(ApplicationCreateShellMaterialDTO  CreateShellMaterialDTO) :  IRequest<Either<GeneralFailure, int>>;
}