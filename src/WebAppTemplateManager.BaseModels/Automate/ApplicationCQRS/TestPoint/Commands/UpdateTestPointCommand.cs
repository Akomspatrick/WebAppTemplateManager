using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.TestPoint.Commands
{
    public  record UpdateTestPointCommand(TestPointUpdateRequestDTO  UpdateTestPointDTO) :  IRequest<Either<GeneralFailure, int>>;
}