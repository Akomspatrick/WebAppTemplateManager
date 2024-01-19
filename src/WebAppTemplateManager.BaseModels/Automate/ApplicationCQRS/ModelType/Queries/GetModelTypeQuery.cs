using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.ModelType.Queries{
    public  record GetModelTypeQuery(ModelTypeGetRequestDTO  RequestModelTypeDTO) :  IRequest<Either<GeneralFailure, ModelTypeResponseDTO>>;
    public  record GetModelTypeByGuidQuery(ModelTypeGetRequestByGuidDTO  RequestModelTypeDTO) :  IRequest<Either<GeneralFailure, ModelTypeResponseDTO>>;
    public  record GetModelTypeByIdQuery(ModelTypeGetRequestByIdDTO  RequestModelTypeDTO) :  IRequest<Either<GeneralFailure, ModelTypeResponseDTO>>;
    public  record GetAllModelTypeQuery :  IRequest<Either<GeneralFailure, IEnumerable<ModelTypeResponseDTO>>>;
}