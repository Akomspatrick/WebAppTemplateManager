using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Document.Queries
{
    public  record GetAllDocumentQuery(ApplicationRequestDocumentDTO  RequestDocumentDTO) :  IRequest<Either<GeneralFailures, IEnumerable<ApplicationResponseDocumentDTO>>>;
}