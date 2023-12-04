using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.AAA.Commands
{
    public  record UpdateAAACommand(ApplicationUpdateAAADTO  UpdateAAADTO) :  IRequest<Either<GeneralFailures, int>>;
}