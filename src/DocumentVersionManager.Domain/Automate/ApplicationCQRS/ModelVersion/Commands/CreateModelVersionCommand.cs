using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelVersion.Commands
{
    public  record CreateModelVersionCommand(ApplicationCreateModelVersionDTO  CreateModelVersionDTO) :  IRequest<Either<GeneralFailures, int>>;
}