using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.TestPoint.Commands
{
    public  record DeleteTestPointCommand(ApplicationDeleteTestPointDTO  DeleteTestPointDTO) :  IRequest<Either<GeneralFailure, int>>;
}