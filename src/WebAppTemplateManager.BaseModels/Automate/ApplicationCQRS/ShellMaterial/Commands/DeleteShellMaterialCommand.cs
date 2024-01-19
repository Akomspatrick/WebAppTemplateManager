using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ShellMaterial.Commands
{
    public  record DeleteShellMaterialCommand(ShellMaterialDeleteRequestDTO  DeleteShellMaterialDTO) :  IRequest<Either<GeneralFailure, int>>;
}