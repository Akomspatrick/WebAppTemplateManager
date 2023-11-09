using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ShellMaterial.Commands
{
    public  record UpdateShellMaterialCommand(ApplicationUpdateShellMaterialDTO : UpdateShellMaterialDTO) :  IRequest<Either<GeneralFailures, int>>;
}