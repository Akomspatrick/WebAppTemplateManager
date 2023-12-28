using AutoMapper;
using DocumentVersionManager.Api.Extensions;
using DocumentVersionManager.Api.Extentions;
using DocumentVersionManager.Application.Contracts.RequestDTO;
using DocumentVersionManager.Application.Contracts.ResponseDTO;
using DocumentVersionManager.Application.CQRS.ModelType.Commands;
using DocumentVersionManager.Application.CQRS.ModelType.Queries;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Contracts.ResponseDTO;
using DocumentVersionManager.Domain.Errors;
using DocumentVersionManager.Infrastructure.Maps;
using LanguageExt;
using LanguageExt.Pipes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
namespace DocumentVersionManager.Api.Controllers.v1
{
    public class ModelTypesController : TheBaseController<ModelTypesController>
    {
       
        public ModelTypesController(ILogger<ModelTypesController> logger, ISender sender, IMapper mapper) : base(logger, sender, mapper) { }


        [ProducesResponseType(typeof(IEnumerable<ModelTypeResponseDTO>), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelType.Get, Name = DocumentVersionManagerAPIEndPoints.ModelType.Get)]
        public  Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllModelTypeQuery(), cToken).ToActionResult();



        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelType.GetById, Name = DocumentVersionManagerAPIEndPoints.ModelType.GetById)]
        public  Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            var _ = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");
            var result = Guid.TryParse(NameOrGuid, out Guid guid);
            if (result)
            {
                var ModelTypeRequestByIdDTO = new ModelTypeGetRequestByGuidDTO(guid);
                return ( _sender.Send(new GetModelTypeByGuidQuery(new ApplicationModelTypeGetRequestByGuidDTO(ModelTypeRequestByIdDTO)), cancellationToken))
                .ToActionResult404( _mapper, typeof(ApplicationModelTypeResponseDTO), typeof(ModelTypeResponseDTO));
                
            }
            else
            {
                var ModelTypeRequestByIdDTO = new ModelTypeGetRequestByIdDTO(NameOrGuid);
                return (_sender.Send(new GetModelTypeByIdQuery(new ApplicationModelTypeGetRequestByIdDTO(ModelTypeRequestByIdDTO)), cancellationToken))
                    .ToActionResult404(_mapper, typeof(ApplicationModelTypeResponseDTO), typeof(ModelTypeResponseDTO)) ; //    .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
             }
        }


        [ProducesResponseType(typeof(ModelTypeResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.ModelType.GetByJSONBody, Name = DocumentVersionManagerAPIEndPoints.ModelType.GetByJSONBody)]
        public  Task<IActionResult> GetByJSONBody([FromBody] ModelTypeGetRequestDTO request, CancellationToken cancellationToken)
        {
            var x = request.EnsureInputIsNotNull("Input Cannot be null");
            return ( _sender.Send(new GetModelTypeQuery(new ApplicationModelTypeGetRequestDTO(request)), cancellationToken))
                .ToActionResult404(_mapper, typeof(ApplicationModelTypeResponseDTO), typeof(ModelTypeResponseDTO));
        }

        //[HttpPost(template: DocumentVersionManagerAPIEndPoints.ModelType.Create, Name = DocumentVersionManagerAPIEndPoints.ModelType.Create)]
        //public async Task<IActionResult> Create(ModelTypeCreateRequestDTO request, CancellationToken cancellationToken)
        //{
        //    var dto = new ApplicationModelTypeCreateRequestDTO(request);

        //    return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
        //        .Bind<Either<GeneralFailure, Guid>>(_ => ( _sender.Send(new CreateModelTypeCommand(dto), cancellationToken).Result))
        //        .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
        //            Right: result => result.Match<IActionResult>(
        //            Left: errors2 => new BadRequestObjectResult(errors2),
        //            Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ModelType.Create}/{result2}", dto)));

        //}


        [HttpPost(template: DocumentVersionManagerAPIEndPoints.ModelType.Create, Name = DocumentVersionManagerAPIEndPoints.ModelType.Create)]
        public  Task<IActionResult> Create(ModelTypeCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelTypeCreateRequestDTO(request);

            //return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
            //    .Bind<Either<GeneralFailure, Guid>>(_ => (_sender.Send(new CreateModelTypeCommand(dto), cancellationToken).Result))
            //    .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
            //                         Right: result => Created($"/{DocumentVersionManagerAPIEndPoints.ModelType.Create}/{result}", dto));
            var x = dto.EnsureInputIsNotEmpty("Input Cannot be Empty");
            return (_sender.Send(new CreateModelTypeCommand(dto), cancellationToken))
              .ToActionResultCreated($"{DocumentVersionManagerAPIEndPoints.ModelType.Create}", dto);
              //.Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
              //                     Right: result => Created($"/{DocumentVersionManagerAPIEndPoints.ModelType.Create}/{result}", dto));


        }

        //private async Task<Either<GeneralFailure, Guid>> CreateModelType(ApplicationModelTypeCreateRequestDTO dto, CancellationToken cancellationToken)
        //=> await _sender.Send(new CreateModelTypeCommand(dto), cancellationToken);


        [HttpPut(template: DocumentVersionManagerAPIEndPoints.ModelType.Update, Name = DocumentVersionManagerAPIEndPoints.ModelType.Update)]
        public async Task<IActionResult> Update(ModelTypeUpdateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelTypeUpdateRequestDTO(request);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, int>>(modelType =>  _sender.Send(new UpdateModelTypeCommand(dto), cancellationToken).Result)
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                     Right: result => result.Match<IActionResult>(
                     Left: errors2 => new BadRequestObjectResult(errors2),
                     Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.ModelType.Create}/{dto}", dto)));

        }

        //private async Task<Either<GeneralFailure, int>> UpdateModelType(ApplicationModelTypeUpdateRequestDTO updateType, CancellationToken cancellationToken)
        //=> await _sender.Send(new UpdateModelTypeCommand(updateType), cancellationToken);


    
        [HttpDelete(template: DocumentVersionManagerAPIEndPoints.ModelType.Delete, Name = DocumentVersionManagerAPIEndPoints.ModelType.Delete)]
        public  Task<IActionResult> Delete([FromRoute] Guid request, CancellationToken cancellationToken)
        {
            var result = new ModelTypeDeleteRequestDTO(request);
            var guid = new ApplicationModelTypeDeleteRequestDTO(result);
            var _ = guid.EnsureInputIsNotEmpty("Input Cannot be null");
   
            return _sender.Send(new DeleteModelTypeCommand(guid), cancellationToken).ToActionResult();
        }


    }
}