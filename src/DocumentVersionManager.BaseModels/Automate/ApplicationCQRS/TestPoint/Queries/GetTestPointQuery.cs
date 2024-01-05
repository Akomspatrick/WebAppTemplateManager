using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.TestPoint.Queries{
    public  record GetTestPointQuery(ApplicationTestPointGetRequestDTO  RequestTestPointDTO) :  IRequest<Either<GeneralFailure, ApplicationTestPointResponseDTO>>;
    public  record GetTestPointByGuidQuery(ApplicationTestPointGetRequestByGuidDTO  RequestTestPointDTO) :  IRequest<Either<GeneralFailure, ApplicationTestPointResponseDTO>>;
    public  record GetTestPointByIdQuery(ApplicationTestPointGetRequestByIdDTO  RequestTestPointDTO) :  IRequest<Either<GeneralFailure, ApplicationTestPointResponseDTO>>;
    public  record GetAllTestPointQuery :  IRequest<Either<GeneralFailure, IEnumerable<ApplicationTestPointResponseDTO>>>;
}