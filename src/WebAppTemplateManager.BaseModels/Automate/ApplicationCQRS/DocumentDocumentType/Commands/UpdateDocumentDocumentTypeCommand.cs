using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentDocumentType.Commands
{
    public  record UpdateDocumentDocumentTypeCommand(DocumentDocumentTypeUpdateRequestDTO  UpdateDocumentDocumentTypeDTO) :  IRequest<Either<GeneralFailure, int>>;
}