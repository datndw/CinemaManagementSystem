using CinemaManagementSystem.Application.DTOs.Actor;
using CinemaManagementSystem.Application.Features.Actors.Requests.Commands;
using CinemaManagementSystem.Application.Features.Actors.Requests.Queries;
using CinemaManagementSystem.Application.Responses.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorsController : ControllerBase
	{
        private readonly IMediator _mediator;
        public ActorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<ActorDTO>>> Get()
        {
            var actors = await _mediator.Send(new GetActorsRequest());
            return Ok(actors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ActorDTO>> Get(Guid id)
        {
            var actor = await _mediator.Send(new GetActorRequest { Id = id });
            return Ok(actor);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateActorDTO createActorDTO)
        {
            var command = new CreateActorCommand { CreateActorDTO = createActorDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Put([FromBody] UpdateActorDTO updateActorDTO)
        {
            var command = new UpdateActorCommand { Id = updateActorDTO.Id, UpdateActorDTO = updateActorDTO };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteActorCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

