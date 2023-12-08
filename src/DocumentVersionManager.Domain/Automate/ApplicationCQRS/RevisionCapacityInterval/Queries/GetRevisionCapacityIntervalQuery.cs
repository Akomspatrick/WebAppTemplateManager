using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.RevisionCapacityInterval.Queries
{
    public  record GetRevisionCapacityIntervalQuery(ApplicationRequestRevisionCapacityIntervalDTO  RequestRevisionCapacityIntervalDTO) :  IRequest<Either<GeneralFailure, ApplicationResponseRevisionCapacityIntervalDTO>>;
}