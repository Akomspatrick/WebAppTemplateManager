using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentBasePath.Commands
{
    public  record UpdateDocumentBasePathCommand(DocumentBasePathUpdateRequestDTO  UpdateDocumentBasePathDTO) :  IRequest<Either<GeneralFailure, int>>;
}