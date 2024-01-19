using WebAppTemplateManager.Contracts.RequestDTO;
using WebAppTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace WebAppTemplateManager.Application.CQRS.ModelType.Commands
{
    public  record CreateModelTypeCommand(ModelTypeCreateRequestDTO  CreateModelTypeDTO) :  IRequest<Either<GeneralFailure, Guid>>;
}