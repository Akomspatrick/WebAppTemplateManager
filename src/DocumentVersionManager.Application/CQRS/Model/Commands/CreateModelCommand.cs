using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Model.Commands
{
    public  record CreateModelCommand(ModelCreateRequestDTO  CreateModelDTO) :  IRequest<Either<GeneralFailure, Guid>>;
}