using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacitySpecification.Queries
{
    public  record GetCapacitySpecificationQuery(ApplicationRequestCapacitySpecificationDTO  RequestCapacitySpecificationDTO) :  IRequest<Either<GeneralFailures, ApplicationResponseCapacitySpecificationDTO>>;
}