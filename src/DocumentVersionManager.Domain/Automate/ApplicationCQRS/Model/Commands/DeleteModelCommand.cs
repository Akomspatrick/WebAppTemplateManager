using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Model.Commands
{
    public  record DeleteModelCommand(ApplicationModelDeleteRequestDTO  DeleteModelDTO) :  IRequest<Either<GeneralFailure, int>>;
}