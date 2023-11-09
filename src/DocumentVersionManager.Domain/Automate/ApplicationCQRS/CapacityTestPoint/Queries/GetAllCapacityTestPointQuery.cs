using DocumentVersionManager.Application.Contracts.RequestDTO;
"using DocumentVersionManager.Application.Contracts.ResponsetDTO;
using  DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.CapacityTestPoint.Queries
{
    public  record GetAllCapacityTestPointQuery(ApplicationRequestCapacityTestPointDTO : RequestCapacityTestPointDTO) :  IRequest<Either<GeneralFailures, IEnumerable<ApplicationRequestCapacityTestPointDTO>>>;
}