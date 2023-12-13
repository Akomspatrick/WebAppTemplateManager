using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.DocumentType.Commands
{
    public  record DeleteDocumentTypeCommand(ApplicationDocumentTypeDeleteRequestDTO  DeleteDocumentTypeDTO) :  IRequest<Either<GeneralFailure, int>>;
}