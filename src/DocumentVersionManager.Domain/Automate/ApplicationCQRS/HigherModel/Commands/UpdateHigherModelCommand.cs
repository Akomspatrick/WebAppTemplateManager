using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.HigherModel.Commands
{
    public  record UpdateHigherModelCommand(ApplicationUpdateHigherModelDTO  UpdateHigherModelDTO) :  IRequest<Either<GeneralFailures, int>>;
}