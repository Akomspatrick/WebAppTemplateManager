using DocumentVersionManager.Application.Contracts.RequestDTO;
"using DocumentVersionManager.Application.Contracts.ResponsetDTO;
using  DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelTypes.Queries
{
    public  record GetModelTypesQuery(ApplicationRequestModelTypesDTO : RequestModelTypesDTO) :  IRequest<Either<GeneralFailures, ApplicationRequestModelTypesDTO>>;
}