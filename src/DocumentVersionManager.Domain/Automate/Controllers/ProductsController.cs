using DocumentVersionManager..Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.Product.Commands;
using DocumentVersionManager.Application.CQRS.Product.Queries;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using  MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
namespace DocumentVersionManager.Api.Controllers.v1
{
    public  class ProductsController  : DVBaseController<ProductsController>
    {
        public ProductsController(ILogger<ProductsController> logger, ISender sender) : base(logger, sender){}
        [HttpPost(template: DocumentVersionManagerAPIEndPoints.Product.Create, Name = DocumentVersionManagerAPIEndPoints.Product.Create)]
        public async Task<IActionResult> Create(ProductCreateDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationProductCreateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateProduct(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new OkObjectResult(errors2),Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Product.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateProduct(ApplicationProductCreateDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateProductCommand(createType), cancellationToken);
        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.Product.Delete, Name = DocumentVersionManagerAPIEndPoints.Product.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid guid, CancellationToken cancellationToken)
        {
            return (await _sender.Send(new DeleteProductCommand(new ApplicationProductDeleteDTO(guid)), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }
        [HttpPut(template: DocumentVersionManagerAPIEndPoints.Product.Update, Name = DocumentVersionManagerAPIEndPoints.Product.Update)]
        public async Task<IActionResult> Update(ProductUpdateDTO request,, CancellationToken cancellationToken)
        {
            var dto = new ApplicationProductUpdateDTO(request.);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelType(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new OkObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Product.Create}/{dto.}", dto)));
        }
         }

        private async Task<Either<GeneralFailure, int>> UpdateProduct(ApplicationProductUpdateDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateProductCommand(updateType), cancellationToken);
        [ProducesResponseType(typeof(IEnumerable<ProductResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Product.Get, Name = DocumentVersionManagerAPIEndPoints.Product.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
            return (await _sender.Send(new GetAllProductQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
                Right: result => new OkObjectResult(GetProductResponseResult(result)));
        }

        private IEnumerable<ProductResponseDTO> GetProductResponseResult(IEnumerable<ApplicationProductResponseDTO> result)
        { throw new NotImplementedException("Please implement like below");// return result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertToModelTypeResponse(x.Models)));
        }
        [ProducesResponseType(typeof(IEnumerable<ProductResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Product.GetById, Name = DocumentVersionManagerAPIEndPoints.Product.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");var result = Guid.TryParse(NameOrGuid, out Guid guid); if (result){return (await _sender.Send(new GetModelTypeByGuidQuery(new ApplicationModelTypeRequestByGuidDTO(guid)), cancellationToken)).Match<IActionResult>(Left: errors => new OkObjectResult(errors),Right: result => new OkObjectResult(new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelTypeResponse(result.Models)
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Product.Get, Name = DocumentVersionManagerAPIEndPoints.Product.Get)]
        public async Task<IActionResult> Get(ProductCreateDTO request, CancellationToken cancellationToken)
        {
    }
}