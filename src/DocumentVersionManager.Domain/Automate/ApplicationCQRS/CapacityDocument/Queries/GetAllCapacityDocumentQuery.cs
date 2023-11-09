using DocumentVersionManager.Application.Contracts.RequestDTO;
"using DocumentVersionManager.Application.Contracts.ResponsetDTO;
using  DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacityDocument.Queries
{
    public  record GetAllCapacityDocumentQuery(ApplicationRequestCapacityDocumentDTO : RequestCapacityDocumentDTO) :  IRequest<Either<GeneralFailures, IEnumerable<ApplicationRequestCapacityDocumentDTO>>>;
}