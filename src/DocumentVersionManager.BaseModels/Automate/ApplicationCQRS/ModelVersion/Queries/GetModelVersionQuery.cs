using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelVersion.Queries{
    public  record GetModelVersionQuery(ApplicationModelVersionGetRequestDTO  RequestModelVersionDTO) :  IRequest<Either<GeneralFailure, ApplicationModelVersionResponseDTO>>;
    public  record GetModelVersionByGuidQuery(ApplicationModelVersionGetRequestByGuidDTO  RequestModelVersionDTO) :  IRequest<Either<GeneralFailure, ApplicationModelVersionResponseDTO>>;
    public  record GetModelVersionByIdQuery(ApplicationModelVersionGetRequestByIdDTO  RequestModelVersionDTO) :  IRequest<Either<GeneralFailure, ApplicationModelVersionResponseDTO>>;
    public  record GetAllModelVersionQuery :  IRequest<Either<GeneralFailure, IEnumerable<ApplicationModelVersionResponseDTO>>>;
}