using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelTypeGroup.Queries{
    public  record GetModelTypeGroupQuery(ApplicationModelTypeGroupGetRequestDTO  RequestModelTypeGroupDTO) :  IRequest<Either<GeneralFailure, ApplicationModelTypeGroupResponseDTO>>;
    public  record GetModelTypeGroupByGuidQuery(ApplicationModelTypeGroupGetRequestByGuidDTO  RequestModelTypeGroupDTO) :  IRequest<Either<GeneralFailure, ApplicationModelTypeGroupResponseDTO>>;
    public  record GetModelTypeGroupByIdQuery(ApplicationModelTypeGroupGetRequestByIdDTO  RequestModelTypeGroupDTO) :  IRequest<Either<GeneralFailure, ApplicationModelTypeGroupResponseDTO>>;
    public  record GetAllModelTypeGroupQuery :  IRequest<Either<GeneralFailure, IEnumerable<ApplicationModelTypeGroupResponseDTO>>>;
}