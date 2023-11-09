using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.RevisionCapacityInterval.Commands
{
    public  record CreateRevisionCapacityIntervalCommand(ApplicationCreateRevisionCapacityIntervalDTO : CreateRevisionCapacityIntervalDTO) :  IRequest<Either<GeneralFailures, int>>;
}