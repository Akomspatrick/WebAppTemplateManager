using DocumentVersionManager.Application.Contracts.RequestDTO;
"using DocumentVersionManager.Application.Contracts.ResponsetDTO;
using  DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Model.Queries
{
    public  record GetModelQuery(ApplicationRequestModelDTO : RequestModelDTO) :  IRequest<Either<GeneralFailures, ApplicationRequestModelDTO>>;
}