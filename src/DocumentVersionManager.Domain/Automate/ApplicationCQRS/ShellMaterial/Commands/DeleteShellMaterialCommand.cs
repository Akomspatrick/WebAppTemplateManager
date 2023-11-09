using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ShellMaterial.Commands
{
    public  record DeleteShellMaterialCommand(ApplicationDeleteShellMaterialDTO : DeleteShellMaterialDTO) :  IRequest<Either<GeneralFailures, int>>;
}