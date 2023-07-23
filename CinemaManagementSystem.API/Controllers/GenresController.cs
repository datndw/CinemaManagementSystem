using CinemaManagementSystem.Application.DTOs.Genre;
using CinemaManagementSystem.Application.Features.Genres.Requests.Commands;
using CinemaManagementSystem.Application.Features.Genres.Requests.Queries;
using CinemaManagementSystem.Application.Responses.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<GenreDTO>>> Get()
        {
            var genres = await _mediator.Send(new GetGenresRequest());
            return Ok(genres);
        }

        [HttpGet("Details")]
        public async Task<ActionResult<List<GenreDetailDTO>>> GetDetails()
        {
            var genres = await _mediator.Send(new GetGenresDetailRequest());
            return Ok(genres);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreDTO>> Get(Guid id)
        {
            var genre = await _mediator.Send(new GetGenreRequest { Id = id });
            return Ok(genre);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateGenreDTO createGenreDTO)
        {
            var command = new CreateGenreCommand { CreateGenreDTO = createGenreDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Put([FromBody] UpdateGenreDTO updateGenreDTO)
        {
            var command = new UpdateGenreCommand { Id = updateGenreDTO.Id, UpdateGenreDTO = updateGenreDTO };
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteGenreCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}

