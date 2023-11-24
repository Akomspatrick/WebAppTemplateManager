using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.HigherModel.Commands
{
    public  record CreateHigherModelCommand(ApplicationCreateHigherModelDTO  CreateHigherModelDTO) :  IRequest<Either<GeneralFailures, int>>;
}