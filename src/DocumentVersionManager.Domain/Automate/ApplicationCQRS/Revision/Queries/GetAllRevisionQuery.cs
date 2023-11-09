using DocumentVersionManager.Application.Contracts.RequestDTO;
"using DocumentVersionManager.Application.Contracts.ResponsetDTO;
using  DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Revision.Queries
{
    public  record GetAllRevisionQuery(ApplicationRequestRevisionDTO : RequestRevisionDTO) :  IRequest<Either<GeneralFailures, IEnumerable<ApplicationRequestRevisionDTO>>>;
}