using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelVersion.Commands
{
    public  record CreateModelVersionCommand(ModelVersionCreateRequestDTO  CreateModelVersionDTO) :  IRequest<Either<GeneralFailure, Guid>>;
}