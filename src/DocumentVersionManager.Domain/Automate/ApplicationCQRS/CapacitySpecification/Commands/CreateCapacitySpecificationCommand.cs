using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacitySpecification.Commands
{
    public  record CreateCapacitySpecificationCommand(ApplicationCreateCapacitySpecificationDTO : CreateCapacitySpecificationDTO) :  IRequest<Either<GeneralFailures, int>>;
}