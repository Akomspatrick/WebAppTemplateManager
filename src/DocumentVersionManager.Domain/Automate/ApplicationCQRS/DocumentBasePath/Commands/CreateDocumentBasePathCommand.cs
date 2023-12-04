using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentBasePath.Commands
{
    public  record CreateDocumentBasePathCommand(ApplicationCreateDocumentBasePathDTO  CreateDocumentBasePathDTO) :  IRequest<Either<GeneralFailures, int>>;
}