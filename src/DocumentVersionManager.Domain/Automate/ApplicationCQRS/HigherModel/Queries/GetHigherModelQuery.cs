using DocumentVersionManager.Application.Contracts.RequestDTO;
"using DocumentVersionManager.Application.Contracts.ResponsetDTO;
using  DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.HigherModel.Queries
{
    public  record GetHigherModelQuery(ApplicationRequestHigherModelDTO : RequestHigherModelDTO) :  IRequest<Either<GeneralFailures, ApplicationRequestHigherModelDTO>>;
}