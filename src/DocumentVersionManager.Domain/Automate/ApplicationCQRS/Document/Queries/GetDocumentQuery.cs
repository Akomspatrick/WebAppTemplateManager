using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Document.Queries
{
    public  record GetDocumentQuery(ApplicationRequestDocumentDTO  RequestDocumentDTO) :  IRequest<Either<GeneralFailure, ApplicationResponseDocumentDTO>>;
}