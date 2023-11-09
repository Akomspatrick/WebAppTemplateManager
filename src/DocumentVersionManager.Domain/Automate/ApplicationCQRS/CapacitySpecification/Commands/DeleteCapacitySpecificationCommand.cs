using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacitySpecification.Commands
{
    public  record DeleteCapacitySpecificationCommand(ApplicationDeleteCapacitySpecificationDTO : DeleteCapacitySpecificationDTO) :  IRequest<Either<GeneralFailures, int>>;
}