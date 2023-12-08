using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ShellMaterial.Queries
{
    public  record GetShellMaterialQuery(ApplicationRequestShellMaterialDTO  RequestShellMaterialDTO) :  IRequest<Either<GeneralFailure, ApplicationResponseShellMaterialDTO>>;
}