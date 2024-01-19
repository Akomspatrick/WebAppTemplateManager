
using WebAppTemplateManager.Contracts.RequestDTO;
using WebAppTemplateManager.Contracts.ResponseDTO;
using WebAppTemplateManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace WebAppTemplateManager.Application.CQRS.ModelType.Queries
{
    public record GetModelTypeQuery(ModelTypeGetRequestDTO RequestModelTypeDTO) : IRequest<Either<GeneralFailure, ModelTypeResponseDTO>>;
    public record GetModelTypeByGuidQuery(ModelTypeGetRequestByGuidDTO RequestModelTypeDTO) : IRequest<Either<GeneralFailure, ModelTypeResponseDTO>>;
    public record GetModelTypeByIdQuery(ModelTypeGetRequestByIdDTO RequestModelTypeDTO) : IRequest<Either<GeneralFailure, ModelTypeResponseDTO>>;
    public record GetAllModelTypeQuery : IRequest<Either<GeneralFailure, IEnumerable<ModelTypeResponseDTO>>>;
}