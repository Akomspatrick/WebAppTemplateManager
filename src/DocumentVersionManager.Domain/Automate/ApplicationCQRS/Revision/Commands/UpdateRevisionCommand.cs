using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Revision.Commands
{
    public  record UpdateRevisionCommand(ApplicationUpdateRevisionDTO  UpdateRevisionDTO) :  IRequest<Either<GeneralFailures, int>>;
}