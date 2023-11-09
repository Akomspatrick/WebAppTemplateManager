using DocumentVersionManager.Application.Contracts.RequestDTO;
"using DocumentVersionManager.Application.Contracts.ResponsetDTO;
using  DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelVersion.Queries
{
    public  record GetAllModelVersionQuery(ApplicationRequestModelVersionDTO : RequestModelVersionDTO) :  IRequest<Either<GeneralFailures, IEnumerable<ApplicationRequestModelVersionDTO>>>;
}