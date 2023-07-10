using CinemaManagementSystem.Application.DTOs.Movie;
using CinemaManagementSystem.Application.Features.Movies.Requests.Commands;
using CinemaManagementSystem.Application.Features.Movies.Requests.Queries;
using CinemaManagementSystem.Application.Responses.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CinemaManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
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
            var movie = await _mediator.Send(new GetMovieRequest { Id = id});
            return Ok(movie);
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateMovieDTO createMovieDTO)
        {
            var command = new CreateMovieCommand { CreateMovieDTO = createMovieDTO };
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [Authorize]
        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Put([FromBody] UpdateMovieDTO movieDTO)
        {
            var command = new UpdateMovieCommand { MovieDTO = movieDTO };
            await _mediator.Send(command);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteMovieCommand { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
