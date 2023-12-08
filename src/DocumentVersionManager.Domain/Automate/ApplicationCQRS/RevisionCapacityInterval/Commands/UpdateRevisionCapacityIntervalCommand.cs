using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.RevisionCapacityInterval.Commands
{
    public  record UpdateRevisionCapacityIntervalCommand(ApplicationUpdateRevisionCapacityIntervalDTO  UpdateRevisionCapacityIntervalDTO) :  IRequest<Either<GeneralFailure, int>>;
}