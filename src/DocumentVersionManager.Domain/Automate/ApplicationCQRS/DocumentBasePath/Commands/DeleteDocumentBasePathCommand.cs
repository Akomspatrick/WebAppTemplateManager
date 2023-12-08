using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentBasePath.Commands
{
    public  record DeleteDocumentBasePathCommand(ApplicationDeleteDocumentBasePathDTO  DeleteDocumentBasePathDTO) :  IRequest<Either<GeneralFailure, int>>;
}