using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacityDocument.Commands
{
    public  record DeleteCapacityDocumentCommand(ApplicationCapacityDocumentDeleteRequestDTO  DeleteCapacityDocumentDTO) :  IRequest<Either<GeneralFailure, int>>;
}