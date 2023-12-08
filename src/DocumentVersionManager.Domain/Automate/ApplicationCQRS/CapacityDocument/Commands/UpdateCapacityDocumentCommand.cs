using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacityDocument.Commands
{
    public  record UpdateCapacityDocumentCommand(ApplicationUpdateCapacityDocumentDTO  UpdateCapacityDocumentDTO) :  IRequest<Either<GeneralFailure, int>>;
}