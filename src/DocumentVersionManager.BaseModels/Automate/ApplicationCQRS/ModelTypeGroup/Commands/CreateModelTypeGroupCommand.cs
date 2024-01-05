using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelTypeGroup.Commands
{
    public  record CreateModelTypeGroupCommand(ApplicationModelTypeGroupCreateRequestDTO  CreateModelTypeGroupDTO) :  IRequest<Either<GeneralFailure, int>>;
}