using DocumentVersionManager.Application.Contracts.RequestDTO;
"using DocumentVersionManager.Application.Contracts.ResponsetDTO;
using  DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentType.Queries
{
    public  record GetAllDocumentTypeQuery(ApplicationRequestDocumentTypeDTO : RequestDocumentTypeDTO) :  IRequest<Either<GeneralFailures, IEnumerable<ApplicationRequestDocumentTypeDTO>>>;
}