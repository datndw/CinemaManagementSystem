using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.Features.Movies.Requests.Commands;
using CinemaManagementSystem.Application.Features.Movies.Requests.Queries;
using CinemaManagementSystem.Application.Resposes.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<MovieDTO>>> Get()
        {
            var movies = await _mediator.Send(new GetMoviesRequest());
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDTO>> Get(Guid id)
        {
            var movie = await _mediator.Send(new GetMovieRequest());
            return Ok(movie);
        }

        [Authorize]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] MovieDTO movieDTO)
        {
            var command = new CreateMovieCommand { MovieDTO = movieDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Authorize]
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] UpdateMovieDTO movieDTO)
        {
            var command = new UpdateMovieCommand { MovieDTO = movieDTO };
            await _mediator.Send(command);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteMovieCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
