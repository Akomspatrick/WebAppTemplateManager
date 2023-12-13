using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
namespace DocumentVersionManager.Application.CQRS.Product.Commands
{
    public  record CreateProductCommand(ApplicationProductCreateRequestDTO  CreateProductDTO) :  IRequest<Either<GeneralFailure, int>>;
}