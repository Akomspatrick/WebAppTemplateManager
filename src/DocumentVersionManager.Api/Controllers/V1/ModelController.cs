using Asp.Versioning;
using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.Model.Commands;
using DocumentVersionManager.Application.CQRS.Model.Queries;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using DocumentVersionManager.Application.CQRS.ModelType.Queries;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using LanguageExt;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentVersionManager.Api.Controllers.v1
{

    public class ModelController : TheBaseController<ModelController>
    {
        public ModelController(ILogger<ModelController> logger, ISender sender) : base(logger, sender)
        {
        }



        //[HttpGet(template: DocumentVersionManagerAPIEndPoints.Model.Get, Name = DocumentVersionManagerAPIEndPoints.Model.Get)]
        //public async Task<IActionResult> GetbyJsonBodyFormer_Get([FromBody] ModelRequestDTO request, CancellationToken cancellationToken)
        //{
        //    var x = request.EnsureInputIsNotNull("Input Cannot be null");
        //    return (await _sender.Send(new GetModelQuery(new ApplicationModelRequestDTO(request.ModelName)), cancellationToken))
        //    .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
        //                        Right: result => new OkObjectResult(result));
        //}

        private ModelResponseDTO MapApplicationModelResponseDTO_To_ModelResponseDTO(ApplicationModelResponseDTO result)
        //=> throw new NotImplementedException("Please implement like below");
         => new ModelResponseDTO(result.ModelId, result.ModelName, result.ModelTypesName);


        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Model.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.Model.GetByJSONBody)]
        public async Task<IActionResult> GetByJSONBody([FromBody] ModelGetRequestDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return (await _sender.Send(new GetModelQuery(new ApplicationModelGetRequestDTO(request)), cancellationToken))
            .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                Right: result => new OkObjectResult(MapApplicationModelResponseDTO_To_ModelResponseDTO(result)));
        }



        [ProducesResponseType(typeof(IEnumerable<ModelResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Model.Get, Name = DocumentVersionManagerAPIEndPoints.Model.Get)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            return (await _sender.Send<Either<GeneralFailure, IEnumerable<ApplicationModelResponseDTO>>>(new GetAllModelQuery(), cancellationToken))
           .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
               Right: result => new OkObjectResult(GetModelResponseResult(result)));
        }

        private IEnumerable<ModelResponseDTO> GetModelResponseResult(IEnumerable<ApplicationModelResponseDTO> result)
         => result.Select(x => new ModelResponseDTO(x.ModelId, x.ModelName, x.ModelTypesName));


        //GetAll is the new Get
        //[HttpGet(template: DocumentVersionManagerAPIEndPoints.Model.GetAll, Name = DocumentVersionManagerAPIEndPoints.Model.GetAll)]
        //public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        //{
        //    return (await _sender.Send(new GetAllModelQuery(), cancellationToken))
        //    .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
        //                        Right: result => new OkObjectResult(result));
        //}

        //[HttpPost(template: DocumentVersionManagerAPIEndPoints.Model.Create, Name = DocumentVersionManagerAPIEndPoints.Model.Create)]
        //public async Task<IActionResult> Create(ModelCreateDTO request, CancellationToken cancellationToken)
        //{
        //    var model = new ApplicationModelCreateDTO(request.ModelId, request.ModelName, request.ModelTypesName);

        //    return model.EnsureInputIsNotEmpty("Input Cannot be Empty")//.EnsureInputIsNotEmpty("Input Cannot be empty")
        //        .Bind<Either<GeneralFailure, int>>(modelType => CreateModel(model, cancellationToken).Result)
        //        .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
        //              Right: result => result.Match<IActionResult>(
        //              Left: errors2 => new OkObjectResult(errors2),
        //              Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ModelType.Create}/{model.ModelId}", model)));
        //}

        [HttpPost(template: DocumentVersionManagerAPIEndPoints.Model.Create, Name = DocumentVersionManagerAPIEndPoints.Model.Create)]
        public async Task<IActionResult> Create(ModelCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelCreateRequestDTO(request);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(_ => (CreateModel(dto, cancellationToken).Result))
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new BadRequestObjectResult(errors2),
                    Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Model.Create}/{dto}", dto)));
        }

        private async Task<Either<GeneralFailure, int>> CreateModel(ApplicationModelCreateRequestDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateModelCommand(createType), cancellationToken);


        //[HttpDelete(template: DocumentVersionManagerAPIEndPoints.Model.Delete, Name = DocumentVersionManagerAPIEndPoints.Model.Delete)]
        //public async Task<IActionResult> Get([FromBody] ModelDeleteDTO request, CancellationToken cancellationToken)
        //{
        //    var x = request.EnsureInputIsNotNull("Input Cannot be null");
        //    return (await _sender.Send(new DeleteModelCommand(new ApplicationModelDeleteDTO(request.ModelId)), cancellationToken))
        //    .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
        //                        Right: result => new OkObjectResult(result));
        //}



        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.Model.Delete, Name = DocumentVersionManagerAPIEndPoints.Model.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
        {
            var result = new ModelDeleteRequestDTO(request);
            var guid = new ApplicationModelDeleteRequestDTO(result);
            return guid.EnsureInputIsNotEmpty("Input Cannot be null")
                .Bind<Either<GeneralFailure, int>>(guid => DeleteModel(guid, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => new OkObjectResult(result));
        }

        private async Task<Either<GeneralFailure, int>> DeleteModel(ApplicationModelDeleteRequestDTO dto, CancellationToken cancellationToken)
        => await _sender.Send(new DeleteModelCommand(dto), cancellationToken);



        [HttpPut(template: DocumentVersionManagerAPIEndPoints.Model.Update, Name = DocumentVersionManagerAPIEndPoints.Model.Update)]
        public async Task<IActionResult> Update(ModelUpdateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelUpdateRequestDTO(request);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType => UpdateModel(dto, cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new BadRequestObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Model.Create}/{dto}", dto)));

        }

        private async Task<Either<GeneralFailure, int>> UpdateModel(ApplicationModelUpdateRequestDTO updateType, CancellationToken cancellationToken)
        => await _sender.Send(new UpdateModelCommand(updateType), cancellationToken);


        //[HttpPut(template: DocumentVersionManagerAPIEndPoints.Model.Update, Name = DocumentVersionManagerAPIEndPoints.Model.Update)]
        //public async Task<IActionResult> Update(ModelUpdateDTO request, CancellationToken cancellationToken)
        //{
        //    var modelType = new ApplicationModelUpdateDTO(request.ModelId, request.ModelName, request.ModelTypesName);

        //    return modelType.EnsureInputIsNotEmpty("Input Cannot be Empty")//.EnsureInputIsNotEmpty("Input Cannot be empty")
        //        .Bind<Either<GeneralFailure, int>>(modelType => UpdateModelType(modelType, cancellationToken).Result)
        //        .Match<IActionResult>(Left: errors => new OkObjectResult(errors),
        //              Right: result => result.Match<IActionResult>(
        //              Left: errors2 => new OkObjectResult(errors2),
        //              Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ModelType.Create}/{modelType.ModelId}", modelType)));
        //}

        // private async Task<Either<GeneralFailure, int>> UpdateModelType(ApplicationModelUpdateDTO modelType, CancellationToken cancellationToken)
        //=> await _sender.Send(new UpdateModelCommand(modelType), cancellationToken);










        private async Task<Either<GeneralFailure, int>> CreateModel(ApplicationModelCreateDTO modelType, CancellationToken cancellationToken)
           => await _sender.Send(new CreateModelCommand(modelType), cancellationToken);

    }
}
