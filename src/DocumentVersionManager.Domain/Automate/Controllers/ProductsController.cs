using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.Product.Commands;
using DocumentVersionManager.Application.CQRS.Product.Queries;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
namespace DocumentVersionManager.Api.Controllers.v1
{
    public  class ProductsController  : TheBaseController<ProductsController>
    {

        public ProductsController(ILogger<ProductsController> logger, ISender sender) : base(logger, sender){}

        [ProducesResponseType(typeof(IEnumerable<ProductResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Product.Get, Name = DocumentVersionManagerAPIEndPoints.Product.Get)]
        public async Task<IActionResult> Get( CancellationToken cancellationToken)
        {
             return (await _sender.Send<Either<GeneralFailure, IEnumerable<ApplicationProductResponseDTO>>>(new GetAllProductQuery(), cancellationToken))
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(GetProductResponseResult(result)));
        }

        private IEnumerable<ProductResponseDTO> GetProductResponseResult(IEnumerable<ApplicationProductResponseDTO> result)
        
        => throw new NotImplementedException("Please implement like below");//
        => result.Select(x => new ModelTypeResponseDTO(x.ModelTypesId, x.ModelTypesName, CovertProductResponse(x.Models)));
        

        private ICollection<ModelResponseDTO> CovertModelTypeResponse(ICollection<ApplicationModelResponseDTO> models)
        => throw new NotImplementedException("Please implement like below");
        //=> models.Select(x => new ModelResponseDTO(x.ModelId, x.ModelName, x.ModelTypesName)).ToList();

        [ProducesResponseType(typeof(ProductResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Product.GetById, Name = DocumentVersionManagerAPIEndPoints.Product.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");
            var result = Guid.TryParse(NameOrGuid, out Guid guid);
            if (result)
            {
                var ProductRequestByIdDTO = new ProductGetRequestByGuidDTO(guid);
                return (await _sender.Send(new GetProductByGuidQuery(new ApplicationProductGetRequestByGuidDTO(ProductRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationProductResponseDTO_To_ProductResponseDTO(result)));
            }
            else
            {
                var ProductRequestByIdDTO = new ProductGetRequestByIdDTO(NameOrGuid);
                return (await _sender.Send<Either<GeneralFailure, ApplicationProductResponseDTO>>(new GetProductByIdQuery(new ApplicationProductGetRequestByIdDTO(ProductRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationProductResponseDTO_To_ProductResponseDTO(result)));
            }
        }

        private ProductResponseDTO MapApplicationProductResponseDTO_To_ProductResponseDTO(ApplicationProductResponseDTO result)
        => throw new NotImplementedException("Please implement like below");
        // => new ModelTypeResponseDTO(result.ModelTypesId, result.ModelTypesName, CovertToModelResponse(result.Models));

         private ICollection<ModelResponseDTO> CovertToModelResponse(ICollection<ApplicationModelResponseDTO> models)
        => throw new NotImplementedException("Please implement like below");
        // => models.Select(x => new ModelResponseDTO(x.ModelId, x.ModelName, x.ModelTypesName)).ToList();

        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Product.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.Product.GetByJSONBody)]
        public async Task<IActionResult> GetByJSONBody([FromBody] ProductGetRequestDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _sender.Send(new GetProductQuery(new ApplicationProductGetRequestDTO(request)), cancellationToken))
            .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                Right: result => new OkObjectResult(MapApplicationProductResponseDTO_To_ProductResponseDTO(result)));
         }

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.Product.Create, Name = DocumentVersionManagerAPIEndPoints.Product.Create)]
        public async Task<IActionResult> Create(ProductCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationProductCreateRequestDTO(request);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (  CreateProduct(dto, cancellationToken).Result   ) )
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new BadRequestObjectResult(errors2),
                    Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Product.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateProduct(ApplicationProductCreateRequestDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateProductCommand(createType), cancellationToken);


        [HttpPut(template: DocumentVersionManagerAPIEndPoints.Product.Update, Name = DocumentVersionManagerAPIEndPoints.Product.Update)]
        public async Task<IActionResult> Update(ProductUpdateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationProductUpdateRequestDTO(request);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateProduct(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new     BadRequestObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Product.Create}/{dto}", dto)));

         }

        private async Task<Either<GeneralFailure, int>> UpdateProduct(ApplicationProductUpdateRequestDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateProductCommand(updateType), cancellationToken);


        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.Product.Delete, Name = DocumentVersionManagerAPIEndPoints.Product.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
        {
        var result = new ProductDeleteRequestDTO(request);
        var guid = new ApplicationProductDeleteRequestDTO(result);
        return guid.EnsureInputIsNotEmpty("Input Cannot be null")
            .Bind<Either<GeneralFailure, int>>(guid => DeleteProduct(guid, cancellationToken).Result)
            .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                Right: result => new OkObjectResult(result));
        }

        private async Task<Either<GeneralFailure, int>> DeleteProduct(ApplicationProductDeleteRequestDTO dto, CancellationToken cancellationToken)
        =>  await _sender.Send(new DeleteProductCommand(dto), cancellationToken);

    }
}