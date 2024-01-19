using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Document.Commands
{
    public  record CreateDocumentCommand(DocumentCreateRequestDTO  CreateDocumentDTO) :  IRequest<Either<GeneralFailure, Guid>>;
}