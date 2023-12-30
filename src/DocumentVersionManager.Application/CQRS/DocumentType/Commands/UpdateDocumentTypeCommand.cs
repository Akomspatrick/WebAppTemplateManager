using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentType.Commands
{
    public  record UpdateDocumentTypeCommand(DocumentTypeUpdateRequestDTO  UpdateDocumentTypeDTO) :  IRequest<Either<GeneralFailure, int>>;
}