using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Specification.Commands
{
    public  record DeleteSpecificationCommand(ApplicationDeleteSpecificationDTO  DeleteSpecificationDTO) :  IRequest<Either<GeneralFailures, int>>;
}