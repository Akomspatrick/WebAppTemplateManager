using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentType.Commands
{
    public  record CreateDocumentTypeCommand(ApplicationDocumentTypeCreateRequestDTO  CreateDocumentTypeDTO) :  IRequest<Either<GeneralFailure, Guid>>;
}