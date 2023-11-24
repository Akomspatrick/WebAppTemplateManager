using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacityTestPoint.Commands
{
    public  record CreateCapacityTestPointCommand(ApplicationCreateCapacityTestPointDTO  CreateCapacityTestPointDTO) :  IRequest<Either<GeneralFailures, int>>;
}