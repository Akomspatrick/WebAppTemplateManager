using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Product.Queries{
    public  record GetProductQuery(ProductGetRequestDTO  RequestProductDTO) :  IRequest<Either<GeneralFailure, ProductResponseDTO>>;
    public  record GetProductByGuidQuery(ProductGetRequestByGuidDTO  RequestProductDTO) :  IRequest<Either<GeneralFailure, ProductResponseDTO>>;
    public  record GetProductByIdQuery(ProductGetRequestByIdDTO  RequestProductDTO) :  IRequest<Either<GeneralFailure, ProductResponseDTO>>;
    public  record GetAllProductQuery :  IRequest<Either<GeneralFailure, IEnumerable<ProductResponseDTO>>>;
}