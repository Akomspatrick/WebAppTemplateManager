using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentBasePath.Commands
{
    public  record CreateDocumentBasePathCommand(DocumentBasePathCreateRequestDTO  CreateDocumentBasePathDTO) :  IRequest<Either<GeneralFailure, Guid>>;
}