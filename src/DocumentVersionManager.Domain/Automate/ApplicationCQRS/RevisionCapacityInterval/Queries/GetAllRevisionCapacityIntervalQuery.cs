using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.RevisionCapacityInterval.Queries
{
    public  record GetAllRevisionCapacityIntervalQuery(ApplicationRequestRevisionCapacityIntervalDTO  RequestRevisionCapacityIntervalDTO) :  IRequest<Either<GeneralFailure, IEnumerable<ApplicationResponseRevisionCapacityIntervalDTO>>>;
}