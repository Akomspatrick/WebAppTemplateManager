using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Revision.Commands
{
    public  record DeleteRevisionCommand(ApplicationDeleteRevisionDTO  DeleteRevisionDTO) :  IRequest<Either<GeneralFailures, int>>;
}