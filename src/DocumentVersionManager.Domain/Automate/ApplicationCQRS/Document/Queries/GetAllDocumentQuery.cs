using DocumentVersionManager.Application.Contracts.RequestDTO;
"using DocumentVersionManager.Application.Contracts.ResponsetDTO;
using  DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Document.Queries
{
    public  record GetAllDocumentQuery(ApplicationRequestDocumentDTO : RequestDocumentDTO) :  IRequest<Either<GeneralFailures, IEnumerable<ApplicationRequestDocumentDTO>>>;
}