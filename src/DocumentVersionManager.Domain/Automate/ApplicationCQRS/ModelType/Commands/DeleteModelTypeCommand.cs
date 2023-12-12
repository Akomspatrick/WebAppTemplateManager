using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelType.Commands
{
    public  record DeleteModelTypeCommand(ApplicationDeleteModelTypeDTO  DeleteModelTypeDTO) :  IRequest<Either<GeneralFailure, int>>;
}