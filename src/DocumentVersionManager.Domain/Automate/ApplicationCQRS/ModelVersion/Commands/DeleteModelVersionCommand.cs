using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelVersion.Commands
{
    public  record DeleteModelVersionCommand(ModelVersionDeleteRequestDTO  DeleteModelVersionDTO) :  IRequest<Either<GeneralFailure, int>>;
}