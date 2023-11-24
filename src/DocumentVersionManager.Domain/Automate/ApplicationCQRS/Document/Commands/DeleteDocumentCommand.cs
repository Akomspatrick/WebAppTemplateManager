using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Document.Commands
{
    public  record DeleteDocumentCommand(ApplicationDeleteDocumentDTO  DeleteDocumentDTO) :  IRequest<Either<GeneralFailures, int>>;
}