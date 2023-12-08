using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentBasePath.Queries
{
    public  record GetDocumentBasePathQuery(ApplicationRequestDocumentBasePathDTO  RequestDocumentBasePathDTO) :  IRequest<Either<GeneralFailure, ApplicationResponseDocumentBasePathDTO>>;
}