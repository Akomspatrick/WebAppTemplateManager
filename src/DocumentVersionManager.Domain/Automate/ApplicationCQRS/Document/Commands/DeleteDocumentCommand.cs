using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Document.Commands
{
    public  record DeleteDocumentCommand(ApplicationDocumentDeleteRequestDTO  DeleteDocumentDTO) :  IRequest<Either<GeneralFailure, int>>;
}