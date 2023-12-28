using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentBasePath.Commands
{
    public  record CreateDocumentBasePathCommand(ApplicationDocumentBasePathCreateRequestDTO  CreateDocumentBasePathDTO) :  IRequest<Either<GeneralFailure, Guid>>;
}