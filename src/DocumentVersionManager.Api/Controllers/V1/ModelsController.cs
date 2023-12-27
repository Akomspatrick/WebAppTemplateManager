﻿using AutoMapper;
using DocumentVersionManager.Api.Extensions;
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
using Microsoft.AspNetCore.Mvc;

namespace DocumentVersionManager.Api.Controllers.v1
{

    public class ModelsController : TheBaseController<ModelsController>
    {
        public ModelsController(ILogger<ModelsController> logger, ISender sender,IMapper mapper) : base(logger, sender, mapper)
        {
        }


        private ModelResponseDTO MapApplicationModelResponseDTO_To_ModelResponseDTO(ApplicationModelResponseDTO result)
         => new ModelResponseDTO(result.GuidId, result.ModelName, result.ModelTypeName, null);


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
        public Task<IActionResult> Get(CancellationToken cToken) => _sender.Send(new GetAllModelQuery(), cToken).ToActionResult();

        //public async Task<IActionResult> Get(CancellationToken cancellationToken)
        //{
        //    return (await _sender.Send<Either<GeneralFailure, IEnumerable<ApplicationModelResponseDTO>>>(new GetAllModelQuery(), cancellationToken))
        //   .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
        //       Right: result => new OkObjectResult(GetModelResponseResult(result)));
        //}

        [ProducesResponseType(typeof(ModelResponseDTO), StatusCodes.Status200OK)]
        [HttpGet(template: DocumentVersionManagerAPIEndPoints.Model.GetById, Name = DocumentVersionManagerAPIEndPoints.Model.GetById)]
        public async Task<IActionResult> GetById([FromRoute] string NameOrGuid, CancellationToken cancellationToken)
        {
            var x = NameOrGuid.EnsureInputIsNotEmpty("Input Cannot be null");
            var result = Guid.TryParse(NameOrGuid, out Guid guid);
            if (result)
            {
                var ModelRequestByIdDTO = new ModelGetRequestByGuidDTO(guid);
                return (await _sender.Send(new GetModelByGuidQuery(new ApplicationModelGetRequestByGuidDTO(ModelRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationModelResponseDTO_To_ModelResponseDTO(result)));
            }
            else
            {
                var ModelRequestByIdDTO = new ModelGetRequestByIdDTO(NameOrGuid);
                return (await _sender.Send<Either<GeneralFailure, ApplicationModelResponseDTO>>(new GetModelByIdQuery(new ApplicationModelGetRequestByIdDTO(ModelRequestByIdDTO)), cancellationToken))
                .Match<IActionResult>(Left: errors => new NotFoundObjectResult(errors),
                    Right: result => new OkObjectResult(MapApplicationModelResponseDTO_To_ModelResponseDTO(result)));
            }
        }
        //private IEnumerable<ModelResponseDTO> GetModelResponseResult(IEnumerable<ApplicationModelResponseDTO> result)
        // => result.Select(x => new ModelResponseDTO(x.GuidId, x.ModelName, x.ModelTypeName));


        [HttpPost(template: DocumentVersionManagerAPIEndPoints.Model.Create, Name = DocumentVersionManagerAPIEndPoints.Model.Create)]
        public async Task<IActionResult> Create(ModelCreateRequestDTO request, CancellationToken cancellationToken)
        {
            var dto = new ApplicationModelCreateRequestDTO(request);

            return dto.EnsureInputIsNotEmpty("Input Cannot be Empty")
                .Bind<Either<GeneralFailure, Guid>>(_ => (CreateModel(dto, cancellationToken).Result))
                .Match<IActionResult>(Left: errors => new BadRequestObjectResult(errors),
                    Right: result => result.Match<IActionResult>(
                    Left: errors2 => new BadRequestObjectResult(errors2),
                    Right: result2 => Created($"/{DocumentVersionManagerAPIEndPoints.Model.Create}/{result2}", dto)));
        }

        private async Task<Either<GeneralFailure, Guid>> CreateModel(ApplicationModelCreateRequestDTO createType, CancellationToken cancellationToken)
        => await _sender.Send(new CreateModelCommand(createType), cancellationToken);


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

    }
}
