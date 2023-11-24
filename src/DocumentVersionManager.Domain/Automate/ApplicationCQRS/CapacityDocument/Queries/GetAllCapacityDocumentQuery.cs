using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacityDocument.Queries
{
    public  record GetAllCapacityDocumentQuery(ApplicationRequestCapacityDocumentDTO  RequestCapacityDocumentDTO) :  IRequest<Either<GeneralFailures, IEnumerable<ApplicationResponseCapacityDocumentDTO>>>;
}