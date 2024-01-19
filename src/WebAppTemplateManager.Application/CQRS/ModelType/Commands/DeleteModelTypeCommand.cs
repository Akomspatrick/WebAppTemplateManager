using WebAppTemplateManager.Contracts.RequestDTO;
using WebAppTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace WebAppTemplateManager.Application.CQRS.ModelType.Commands
{
    public  record DeleteModelTypeCommand(ModelTypeDeleteRequestDTO  DeleteModelTypeDTO) :  IRequest<Either<GeneralFailure, int>>;
}