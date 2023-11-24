using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.RevisionCapacityInterval.Commands
{
    public  record DeleteRevisionCapacityIntervalCommand(ApplicationDeleteRevisionCapacityIntervalDTO  DeleteRevisionCapacityIntervalDTO) :  IRequest<Either<GeneralFailures, int>>;
}