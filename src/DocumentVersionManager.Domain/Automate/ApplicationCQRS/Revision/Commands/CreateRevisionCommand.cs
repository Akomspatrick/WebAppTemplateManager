using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Revision.Commands
{
    public  record CreateRevisionCommand(ApplicationCreateRevisionDTO  CreateRevisionDTO) :  IRequest<Either<GeneralFailure, int>>;
}