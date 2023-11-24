using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelTypes.Commands
{
    public  record DeleteModelTypesCommand(ApplicationDeleteModelTypesDTO  DeleteModelTypesDTO) :  IRequest<Either<GeneralFailures, int>>;
}