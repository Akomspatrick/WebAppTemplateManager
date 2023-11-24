using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentDocumentType.Queries
{
    public  record GetAllDocumentDocumentTypeQuery(ApplicationRequestDocumentDocumentTypeDTO  RequestDocumentDocumentTypeDTO) :  IRequest<Either<GeneralFailures, IEnumerable<ApplicationResponseDocumentDocumentTypeDTO>>>;
}