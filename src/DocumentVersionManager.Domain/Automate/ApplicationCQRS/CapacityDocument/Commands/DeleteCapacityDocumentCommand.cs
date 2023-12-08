using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacityDocument.Commands
{
    public  record DeleteCapacityDocumentCommand(ApplicationDeleteCapacityDocumentDTO  DeleteCapacityDocumentDTO) :  IRequest<Either<GeneralFailure, int>>;
}