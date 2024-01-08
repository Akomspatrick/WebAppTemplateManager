using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelTypeGroup.Queries{
    public  record GetModelTypeGroupQuery(ModelTypeGroupGetRequestDTO  RequestModelTypeGroupDTO) :  IRequest<Either<GeneralFailure, ModelTypeGroupResponseDTO>>;
    public  record GetModelTypeGroupByGuidQuery(ModelTypeGroupGetRequestByGuidDTO  RequestModelTypeGroupDTO) :  IRequest<Either<GeneralFailure, ModelTypeGroupResponseDTO>>;
    public  record GetModelTypeGroupByIdQuery(ModelTypeGroupGetRequestByIdDTO  RequestModelTypeGroupDTO) :  IRequest<Either<GeneralFailure, ModelTypeGroupResponseDTO>>;
    public  record GetAllModelTypeGroupQuery :  IRequest<Either<GeneralFailure, IEnumerable<ModelTypeGroupResponseDTO>>>;
}