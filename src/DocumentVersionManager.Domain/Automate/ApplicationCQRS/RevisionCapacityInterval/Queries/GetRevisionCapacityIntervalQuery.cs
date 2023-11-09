using DocumentVersionManager.Application.Contracts.RequestDTO;
"using DocumentVersionManager.Application.Contracts.ResponsetDTO;
using  DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.RevisionCapacityInterval.Queries
{
    public  record GetRevisionCapacityIntervalQuery(ApplicationRequestRevisionCapacityIntervalDTO : RequestRevisionCapacityIntervalDTO) :  IRequest<Either<GeneralFailures, ApplicationRequestRevisionCapacityIntervalDTO>>;
}