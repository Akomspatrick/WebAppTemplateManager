using DocumentVersionManager.Application.Contracts.RequestDTO;
"using DocumentVersionManager.Application.Contracts.ResponsetDTO;
using  DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ShellMaterial.Queries
{
    public  record GetShellMaterialQuery(ApplicationRequestShellMaterialDTO : RequestShellMaterialDTO) :  IRequest<Either<GeneralFailures, ApplicationRequestShellMaterialDTO>>;
}