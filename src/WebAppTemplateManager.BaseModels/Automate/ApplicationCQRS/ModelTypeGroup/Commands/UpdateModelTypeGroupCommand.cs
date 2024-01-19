using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelTypeGroup.Commands
{
    public  record UpdateModelTypeGroupCommand(ModelTypeGroupUpdateRequestDTO  UpdateModelTypeGroupDTO) :  IRequest<Either<GeneralFailure, int>>;
}