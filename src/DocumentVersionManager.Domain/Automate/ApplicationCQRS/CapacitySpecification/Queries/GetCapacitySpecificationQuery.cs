using DocumentVersionManager.Application.Contracts.RequestDTO;
"using DocumentVersionManager.Application.Contracts.ResponsetDTO;
using  DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacitySpecification.Queries
{
    public  record GetCapacitySpecificationQuery(ApplicationRequestCapacitySpecificationDTO : RequestCapacitySpecificationDTO) :  IRequest<Either<GeneralFailures, ApplicationRequestCapacitySpecificationDTO>>;
}