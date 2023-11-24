using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ShellMaterial.Queries
{
    public  record GetAllShellMaterialQuery(ApplicationRequestShellMaterialDTO  RequestShellMaterialDTO) :  IRequest<Either<GeneralFailures, IEnumerable<ApplicationResponseShellMaterialDTO>>>;
}