using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentDocumentType.Commands
{
    public  record CreateDocumentDocumentTypeCommand(DocumentDocumentTypeCreateRequestDTO  CreateDocumentDocumentTypeDTO) :  IRequest<Either<GeneralFailure, Guid>>;
}