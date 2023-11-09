using DocumentVersionManager.Application.Contracts.RequestDTO;
"using DocumentVersionManager.Application.Contracts.ResponsetDTO;
using  DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Model.Queries
{
    public  record GetAllModelQuery(ApplicationRequestModelDTO : RequestModelDTO) :  IRequest<Either<GeneralFailures, IEnumerable<ApplicationRequestModelDTO>>>;
}