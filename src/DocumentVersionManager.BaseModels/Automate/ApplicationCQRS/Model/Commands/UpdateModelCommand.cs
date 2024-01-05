using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Model.Commands
{
    public  record UpdateModelCommand(ApplicationModelUpdateRequestDTO  UpdateModelDTO) :  IRequest<Either<GeneralFailure, int>>;
}