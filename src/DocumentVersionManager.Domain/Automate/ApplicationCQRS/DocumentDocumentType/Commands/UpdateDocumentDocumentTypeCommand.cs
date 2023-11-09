using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentDocumentType.Commands
{
    public  record UpdateDocumentDocumentTypeCommand(ApplicationUpdateDocumentDocumentTypeDTO : UpdateDocumentDocumentTypeDTO) :  IRequest<Either<GeneralFailures, int>>;
}