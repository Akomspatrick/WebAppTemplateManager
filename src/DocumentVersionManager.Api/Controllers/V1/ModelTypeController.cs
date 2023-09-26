using DocumentVersionManager.Application.Commands;
using DocumentVersionManager.Contracts.RequestDTO;
using DocumentVersionManager.Domain.ModelAggregateRoot.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DocumentVersionManager.Api.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    public class ModelTypeController:ControllerBase
    {
        private readonly ILogger<ModelTypeController> _logger;
        private readonly IMediator _mediator;

        public ModelTypeController(ILogger<ModelTypeController> logger, IMediator mediator)
        {
                _logger = logger;
                _mediator = mediator;
        }

        //[HttpGet(Name = "GetAllModelTypes")]
        //public IEnumerable<Contracts.RequestDTO.ModelTypeDTO> Get()
        //{
        //    return null;
        //}

        [HttpPost(Name = "Add")]
        public async Task<IEnumerable<ModelTypeDTO>> Post(ModelTypeDTO request)
        {  
           // var modeltype = new ModelType { ModelTypeName = request.ModelTypeName.ToString() }; 
            var command = new AddNewModelTypeCommand(request);
            await  _mediator.Send(command);
            return null;
        }
    }
}
